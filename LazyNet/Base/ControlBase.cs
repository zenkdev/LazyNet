using System;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Utils.Design;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace Dekart.LazyNet
{
    public class ControlBase : XtraUserControl
    {
        MainFormBase _parent;

        protected ControlBase()
        {
            if (!DesignTimeTools.IsDesignMode)
                LookAndFeel.ActiveLookAndFeel.StyleChanged += ActiveLookAndFeelStyleChanged;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignTimeTools.IsDesignMode)
                LookAndFeelStyleChanged();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && !DesignTimeTools.IsDesignMode)
                LookAndFeel.ActiveLookAndFeel.StyleChanged -= ActiveLookAndFeelStyleChanged;
            base.Dispose(disposing);
        }
        void ActiveLookAndFeelStyleChanged(object sender, EventArgs e)
        {
            LookAndFeelStyleChanged();
        }
        protected virtual void LookAndFeelStyleChanged() { }
        public MainFormBase ParentFormMain
        {
            get { return _parent; }
            set
            {
                if (_parent != null) return;
                _parent = value;
            }
        }
        public FormLayoutManager LayoutManager
        {
            get
            {
                if (_parent != null)
                    return _parent.LayoutManager;
                return null;
            }
        }
        public IDXMenuManager MenuManager
        {
            get
            {
                if (_parent == null) return null;
                return _parent.MenuManager;
            }
        }

        public virtual void SetMenuManager(IDXMenuManager manager)
        {
            SetMenuManager(Controls, manager);
        }
        protected void SetMenuManager(ControlCollection controlCollection, IDXMenuManager manager)
        {
            foreach (Control ctrl in controlCollection)
            {
                var grid = ctrl as GridControl;
                if (grid != null)
                {
                    grid.MenuManager = manager;
                    break;
                }
                var edit = ctrl as BaseEdit;
                if (edit != null)
                {
                    edit.MenuManager = manager;
                    break;
                }
                SetMenuManager(ctrl.Controls, manager);
            }
        }

    }
}