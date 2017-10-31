using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.XtraEditors;

namespace Dekart.LazyNet.Win
{
    partial class LayoutOptions : XtraForm
    {
        readonly FormLayoutManager _layoutManager;
        WinFormProperty CurrentProperty { get { return _layoutManager.Properties.CurrentProperty; } }

        /// <summary>ctor</summary>
        public LayoutOptions(FormLayoutManager layoutManager)
        {
            InitializeComponent();

            _layoutManager = layoutManager;
            Icon = ImagesHelper.AppIcon;

            InitData();
        }

        /// <summary>OnClosing override</summary>
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (DialogResult == DialogResult.OK)
                SaveData();
        }

        void InitData()
        {
            ceAllowRestoreFormLayout.Checked = CurrentProperty.AllowRestoreFormLayout;
            ceAllowRestoreLayoutControlLayout.Checked = CurrentProperty.AllowRestoreLayoutControlLayout;
            ceAllowRestoreGridViewLayout.Checked = CurrentProperty.AllowRestoreGridViewLayout;
            ceDefaultEditGridViewInDetailForms.Checked = CurrentProperty.DefaultEditGridViewInDetailForms;
            spinEdit1.Value = CurrentProperty.GridSize.Width;
            spinEdit2.Value = CurrentProperty.GridSize.Height;
        }

        void SbClearLayoutsClick(object sender, EventArgs e)
        {
            _layoutManager.ClearLayouts();
            DialogResult = DialogResult.Ignore;
            Close();
        }

        void SaveData()
        {
            CurrentProperty.AllowRestoreFormLayout = ceAllowRestoreFormLayout.Checked;
            CurrentProperty.AllowRestoreLayoutControlLayout = ceAllowRestoreLayoutControlLayout.Checked;
            CurrentProperty.AllowRestoreGridViewLayout = ceAllowRestoreGridViewLayout.Checked;
            CurrentProperty.DefaultEditGridViewInDetailForms = ceDefaultEditGridViewInDetailForms.Checked;
            CurrentProperty.GridSize = new Size((int)spinEdit1.Value, (int)spinEdit2.Value);
            _layoutManager.Properties.Save();
        }
    }
}
