using System;
using System.Linq;
using System.Windows.Forms;
using Dekart.LazyNet.Win.Properties;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraGrid.Controls;

namespace Dekart.LazyNet.Win
{
    public class FindControlManager : IDisposable
    {
        readonly RibbonControl _ribbon;
        readonly FindControl _fControl;
        public FindControlManager(RibbonControl ribbon, FindControl control)
        {
            _ribbon = ribbon;
            _fControl = control;
            AddFindControlEvents();
        }
        void AddFindControlEvents()
        {
            _fControl.FindButton.GotFocus += FindControlGotFocus;
            _fControl.FindEdit.GotFocus += FindControlGotFocus;
            _fControl.ClearButton.GotFocus += FindControlGotFocus;
            _fControl.FindButton.Leave += FindControlLeave;
            _fControl.FindEdit.Leave += FindControlLeave;
            _fControl.ClearButton.Leave += FindControlLeave;
            _fControl.FindButton.Image = Resources.Search;
            _fControl.ClearButton.Image = Resources.icon_delete_16;
            _fControl.FindButton.TabStop = false;
            _fControl.ClearButton.TabStop = false;
            _fControl.CalcButtonsBestFit();
        }

        void FindControlLeave(object sender, EventArgs e)
        {
            _fControl.BeginInvoke(new MethodInvoker(UpdateSearchTools));
        }
        void FindControlGotFocus(object sender, EventArgs e)
        {
            UpdateSearchTools();
        }
        void UpdateSearchTools()
        {
            if (_fControl.FindButton.Focused || _fControl.FindEdit.ContainsFocus || _fControl.ClearButton.Focused)
            {
                SearchCategory.Visible = true;
                _ribbon.SelectedPage = SearchCategory.Pages[0];
            }
            else
            {
                SearchCategory.Visible = false;
                _ribbon.SelectedPage = _ribbon.DefaultPageCategory.Pages[0];
            }
        }

        private RibbonPageCategory SearchCategory
        {
            get
            {
                return _ribbon.PageCategories.OfType<RibbonPageCategory>().First(rpc => TagResources.SearchTools.Equals(rpc.Tag));
            }
        }

        #region IDisposable Members
        public void Dispose()
        {
            _fControl.FindButton.GotFocus -= FindControlGotFocus;
            _fControl.FindEdit.GotFocus -= FindControlGotFocus;
            _fControl.ClearButton.GotFocus -= FindControlGotFocus;
            _fControl.FindButton.Leave -= FindControlLeave;
            _fControl.FindEdit.Leave -= FindControlLeave;
            _fControl.ClearButton.Leave -= FindControlLeave;
        }
        #endregion
    }
}