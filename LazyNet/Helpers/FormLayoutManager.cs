using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.Data.Filtering;
using DevExpress.Utils;
using DevExpress.Utils.Serializing;
using DevExpress.Xpo;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraLayout;

namespace Dekart.LazyNet.Helpers
{
    public interface IFormWithLayoutManager
    {
        FormLayoutManager LayoutManager { get; }
    }

    public class FormLayoutManager
    {
        readonly UnitOfWork _session;
        readonly WinFormProperties _properties;

        public FormLayoutManager()
        {
            _session = new UnitOfWork();
            _properties = new WinFormProperties(_session);
        }

        /// <summary>
        /// Gets the session
        /// </summary>
        public UnitOfWork Session { get { return _session; } }

        /// <summary>
        /// Gets the properties
        /// </summary>
        public WinFormProperties Properties { get { return _properties; } }

        /// <summary>
        /// Saves control layout
        /// </summary>
        public static MemoryStream SaveControlLayout(ISupportXtraSerializer control)
        {
            if (control == null) return null;
            var stream = new MemoryStream();
            control.SaveLayoutToStream(stream);
            return stream;
        }

        /// <summary>
        /// Restore control layout
        /// </summary>
        public static void RestoreControlLayout(MemoryStream layout, ISupportXtraSerializer control)
        {
            if (layout == null || layout == Stream.Null || control == null) return;
            layout.Seek(0, SeekOrigin.Begin);
            control.RestoreLayoutFromStream(layout);
        }

        /// <summary>
        /// Saves form layout
        /// </summary>
        public void SaveFormLayout(FormLayoutInfo info)
        {
            var layout = Session.FindObject<WinFormLayout>(CriteriaOperator.Parse("Name = ? and CreatedBy = ?", info.Name, DataHelper.CurrentUserId)) ?? new WinFormLayout(Session, info.Name);
            if (info.Form != null)
            {
                layout.WindowState = info.Form.WindowState;
                layout.FormBounds = info.Form.WindowState == FormWindowState.Maximized ? info.Form.RestoreBounds : info.Form.Bounds;
            }
            layout.MainLayoutControlLayout = SaveControlLayout(info.LayoutControl);
            layout.MainColumnViewLayout = SaveControlLayout(info.MainColumnView);
            layout.AlternateColumnViewLayout = SaveControlLayout(info.AlternateColumnView);
            layout.QuickAccessToolbar = SaveControlLayout(info.QuickAccessToolbar);
            layout.MainView = info.MainView;
            if (info.DataPane != null)
            {
                layout.DataPaneState = info.DataPane.DataPaneState;
                layout.SplitterPosition = info.DataPane.SplitterPosition;
            }
            SessionHelper.CommitSession(Session, new ExceptionProcesser(null));
        }

        /// <summary>
        /// Restore form layout
        /// </summary>
        public void RestoreFormLayout(FormLayoutInfo info)
        {
            var layout = Session.FindObject<WinFormLayout>(CriteriaOperator.Parse("Name = ? and CreatedBy = ?", info.Name, DataHelper.CurrentUserId));
            if (layout == null) return;
            AttachLayoutEvents(info);

            try
            {
                if (Properties.CurrentProperty.AllowRestoreLayoutControlLayout)
                {
                    RestoreControlLayout(layout.MainLayoutControlLayout, info.LayoutControl);
                }
                if (Properties.CurrentProperty.AllowRestoreGridViewLayout)
                {
                    RestoreControlLayout(layout.MainColumnViewLayout, info.MainColumnView);
                    RestoreControlLayout(layout.AlternateColumnViewLayout, info.AlternateColumnView);
                }

                RestoreControlLayout(layout.QuickAccessToolbar, info.QuickAccessToolbar);

                if (info.MainColumnView != null && info.AlternateColumnView != null && !layout.MainView)
                {
                    info.MainColumnView.GridControl.MainView = info.AlternateColumnView;
                }

                if (Properties.CurrentProperty.AllowRestoreLayoutControlLayout && info.DataPane != null)
                {
                    info.DataPane.DataPaneState = layout.DataPaneState;
                    info.DataPane.SplitterPosition = layout.SplitterPosition;
                }
                if (!layout.FormBounds.IsEmpty && info.Form != null && Properties.CurrentProperty.AllowRestoreFormLayout)
                {
                    info.Form.Size = layout.FormBounds.Size;
                    info.Form.Location = ControlUtils.CalcFormLocation(layout.FormBounds.Location, layout.FormBounds.Size);
                    info.Form.WindowState = layout.WindowState;
                }
            }
            finally
            {
                DetachLayoutEvents(info);
            }
        }

        /// <summary>
        /// Clear layouts
        /// </summary>
        public void ClearLayouts()
        {
            Cursor.Current = Cursors.WaitCursor;
            foreach (var layout in new XPCollection<WinFormLayout>(Session, CriteriaOperator.Parse("CreatedBy=?", DataHelper.CurrentUserId)))
            {
                layout.FormBounds = Rectangle.Empty;
                layout.MainLayoutControlLayout = null;
                layout.MainColumnViewLayout = null;
                layout.AlternateColumnViewLayout = null;
                layout.MainView = true;
                layout.SplitterPosition = -1;
            }
            SessionHelper.CommitSession(Session, new ExceptionProcesser(null));
        }

        #region prevent load layout on upgrade

        void AttachLayoutEvents(FormLayoutInfo layout)
        {
            if (layout.LayoutControl != null)
            {
                layout.LayoutControl.BeforeLoadLayout += BeforeLoadLayout;
            }
            if (layout.MainColumnView != null)
            {
                layout.MainColumnView.BeforeLoadLayout += BeforeLoadLayout;
            }
            if (layout.AlternateColumnView != null)
            {
                layout.AlternateColumnView.BeforeLoadLayout += BeforeLoadLayout;
            }
        }

        void DetachLayoutEvents(FormLayoutInfo layout)
        {
            if (layout.LayoutControl != null)
            {
                layout.LayoutControl.BeforeLoadLayout -= BeforeLoadLayout;
            }
            if (layout.MainColumnView != null)
            {
                layout.MainColumnView.BeforeLoadLayout -= BeforeLoadLayout;
            }
            if (layout.AlternateColumnView != null)
            {
                layout.AlternateColumnView.BeforeLoadLayout -= BeforeLoadLayout;
            }
        }

        void BeforeLoadLayout(object sender, LayoutAllowEventArgs e)
        {
            var layoutControlImplementor = sender as LayoutControlImplementor;
            if (layoutControlImplementor != null && layoutControlImplementor.Control is LayoutControl)
            {
                e.Allow = e.PreviousVersion == ((LayoutControl)layoutControlImplementor.Control).LayoutVersion;
            }
            else
            {
                var columnView = sender as ColumnView;
                if (columnView != null)
                {
                    e.Allow = e.PreviousVersion == columnView.OptionsLayout.LayoutVersion;
                }
            }
        }

        #endregion

    }

    public class FormLayoutInfo
    {
        readonly string _name;

        /// <summary>ctor</summary>
        public FormLayoutInfo(Form form, LayoutControl layoutControl) : this(string.Empty, form, layoutControl, null, null, null, null) { }
        /// <summary>ctor</summary>
        public FormLayoutInfo(Form form, LayoutControl layoutControl, RibbonQuickAccessToolbar toolbar) : this(string.Empty, form, layoutControl, null, null, toolbar, null) { }
        /// <summary>ctor</summary>
        public FormLayoutInfo(string name, LayoutControl layoutControl) : this(name, null, layoutControl, null, null, null, null) { }
        /// <summary>ctor</summary>
        public FormLayoutInfo(string name, LayoutControl layoutControl, ColumnView view) : this(name, null, layoutControl, view, null, null, null) { }
        public FormLayoutInfo(string name, LayoutControl layoutControl, ColumnView view, ColumnView alternateView) : this(name, null, layoutControl, view, alternateView, null, null) { }
        public FormLayoutInfo(string name, LayoutControl layoutControl, ColumnView view, ColumnView alternateView, IDataPaneModule dataPane) : this(name, null, layoutControl, view, alternateView, null, dataPane) { }
        /// <summary>ctor</summary>
        public FormLayoutInfo(string name, Form form, LayoutControl layoutControl, ColumnView view, ColumnView alternateView, RibbonQuickAccessToolbar toolbar, IDataPaneModule dataPane)
        {
            _name = name;
            Form = form;
            LayoutControl = layoutControl;
            MainColumnView = view;
            AlternateColumnView = alternateView;
            QuickAccessToolbar = toolbar;
            DataPane = dataPane;
        }
        /// <summary>Name</summary>
        public string Name
        {
            get
            {
                if (!string.IsNullOrEmpty(_name)) return _name;
                return Form != null ? Form.Name : string.Empty;
            }
        }
        /// <summary>Form</summary>
        public Form Form { get; private set; }
        /// <summary>Layout control</summary>
        public LayoutControl LayoutControl { get; private set; }
        /// <summary>Main column view</summary>
        public ColumnView MainColumnView { get; private set; }
        /// <summary>Alternate column view</summary>
        public ColumnView AlternateColumnView { get; private set; }
        /// <summary>Quick access toolbar</summary>
        public RibbonQuickAccessToolbar QuickAccessToolbar { get; private set; }
        /// <summary>Main view</summary>
        public bool MainView
        {
            get { return MainColumnView != null && MainColumnView.GridControl.MainView == MainColumnView; }
        }
        /// <summary>
        /// Data pane module
        /// </summary>
        public IDataPaneModule DataPane { get; private set; }
    }

}
