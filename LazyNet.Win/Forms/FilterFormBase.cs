using System;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.XtraEditors;

namespace Dekart.LazyNet.Win
{
    abstract partial class FilterFormBase : XtraForm
    {
        readonly FilterItemBase _filterItem;

        protected FilterFormBase(FilterItemBase filterItem)
        {
            InitializeComponent();

            _filterItem = filterItem;

            Icon = ImagesHelper.AppIcon;
            filterName.Text = _filterItem.Name;
            filterControl.FilterCriteria = _filterItem.FilterCriteria;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BuildFilterColumns();
        }

        protected abstract void BuildFilterColumns();

        protected static int ID = 1;

        protected virtual string GetDefaultName()
        {
            return "Custom Filter " + (ID++);
        }

        public bool Save
        {
            get { return saveFilter.Checked; }
        }

        void okBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            var name = filterName.Text;
            if (string.IsNullOrEmpty(name))
                name = GetDefaultName();
            if (Save)
                _filterItem.Name = name;
            _filterItem.FilterCriteria = filterControl.FilterCriteria;
            Close();
        }
    }
}
