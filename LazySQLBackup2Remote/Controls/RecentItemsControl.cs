using System;
using DevExpress.XtraBars.Ribbon;
using System.IO;
using Dekart.LazyNet.SQLBackup2Remote.Helpers;

namespace Dekart.LazyNet.SQLBackup2Remote.Controls
{
    public partial class RecentItemsControl : RibbonApplicationUserControl
    {
        public RecentItemsControl()
        {
            InitializeComponent();
            _mruFileList = new MRUArrayList(splitContainer1.Panel1, imageCollection3.Images[0], imageCollection3.Images[1], imageCollection1.Images[0], false, true);
            _mruFileList.LabelClicked += MRUFileListLabelClicked;
            _mruFolderList = new MRUArrayList(panel2, imageCollection3.Images[0], imageCollection3.Images[1], imageCollection1.Images[1], false, true);
            _mruFolderList.LabelClicked += MRUFolderListLabelClicked;
        }

        void MRUFolderListLabelClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", (string)sender);
            BackstageView.Ribbon.HideApplicationButtonContentControl();
        }

        void MRUFileListLabelClicked(object sender, EventArgs e)
        {
            var frm = (AppMainForm)BackstageView.Ribbon.FindForm();
            frm?.OpenFile((string)sender);
            BackstageView.Ribbon.HideApplicationButtonContentControl();
        }

        readonly MRUArrayList _mruFileList;
        readonly MRUArrayList _mruFolderList;
        public MRUArrayList MRUFileList => _mruFileList;
        public MRUArrayList MRUFolderList => _mruFolderList;

        void CheckEdit1CheckedChanged(object sender, EventArgs e)
        {
            spinEdit1.Enabled = checkEdit1.Checked;
            UpdateRecentItems();
        }
        void SpinEdit1EditValueChanged(object sender, EventArgs e)
        {
            UpdateRecentItems();
        }
        void ClearRecentItems()
        {
            if (BackstageView == null)
                return;
            for (var i = 0; i < BackstageView.Items.Count; )
            {
                var item = BackstageView.Items[i] as BackstageViewButtonItem;
                if ((item?.Tag != null) || BackstageView.Items[i] is BackstageViewItemSeparator)
                {
                    if (item != null)
                        item.ItemClick -= OnRecentItemClick;
                    BackstageView.Items.RemoveAt(i);
                }
                else
                    i++;
            }
        }
        void UpdateRecentItems()
        {
            BackstageView.BeginUpdate();
            try
            {
                ClearRecentItems();
                if (checkEdit1.Checked)
                    InitRecentItems();
            }
            finally
            {
                BackstageView.EndUpdate();
            }
        }
        void InitRecentItems()
        {
            BackstageView.Items.Insert(4, new BackstageViewItemSeparator());
            var itemCount = Math.Min(MRUFileList.Count, (int)spinEdit1.Value);
            for (var i = 0; i < itemCount; i++)
            {
                var item = new BackstageViewButtonItem
                    {
                        Caption = Path.GetFileName((string) MRUFileList[i]),
                        Glyph = imageCollection3.Images[2],
                        Tag = MRUFileList[i]
                    };
                item.ItemClick += OnRecentItemClick;
                BackstageView.Items.Insert(5 + i, item);
            }
        }
        void OnRecentItemClick(object sender, BackstageViewItemEventArgs e)
        {
            var frm = (AppMainForm)BackstageView.Ribbon.FindForm();
            frm?.OpenFile((string)e.Item.Tag);
            BackstageView.Ribbon.HideApplicationButtonContentControl();
        }
    }
}
