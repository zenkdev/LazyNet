namespace Dekart.LazyNet.Win.Modules {
    partial class UsersFilter {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersFilter));
            this.treeList = new DevExpress.XtraTreeList.TreeList();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList
            // 
            this.treeList.Appearance.Empty.BackColor = ((System.Drawing.Color)(resources.GetObject("treeList.Appearance.Empty.BackColor")));
            this.treeList.Appearance.Empty.Options.UseBackColor = true;
            this.treeList.Appearance.FocusedRow.Font = ((System.Drawing.Font)(resources.GetObject("treeList.Appearance.FocusedRow.Font")));
            this.treeList.Appearance.FocusedRow.Options.UseFont = true;
            this.treeList.Appearance.HideSelectionRow.Font = ((System.Drawing.Font)(resources.GetObject("treeList.Appearance.HideSelectionRow.Font")));
            this.treeList.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treeList.Appearance.Row.BackColor = ((System.Drawing.Color)(resources.GetObject("treeList.Appearance.Row.BackColor")));
            this.treeList.Appearance.Row.Options.UseBackColor = true;
            this.treeList.Appearance.SelectedRow.Font = ((System.Drawing.Font)(resources.GetObject("treeList.Appearance.SelectedRow.Font")));
            this.treeList.Appearance.SelectedRow.Options.UseFont = true;
            this.treeList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.treeList.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.treeList, "treeList");
            this.treeList.Name = "treeList";
            this.treeList.OptionsBehavior.Editable = false;
            this.treeList.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.Single;
            this.treeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeList.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None;
            this.treeList.OptionsView.ShowColumns = false;
            this.treeList.OptionsView.ShowHorzLines = false;
            this.treeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeList.OptionsView.ShowIndicator = false;
            this.treeList.OptionsView.ShowVertLines = false;
            this.treeList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.treeList.BeforeDragNode += new DevExpress.XtraTreeList.BeforeDragNodeEventHandler(this.treeList_BeforeDragNode);
            this.treeList.BeforeFocusNode += new DevExpress.XtraTreeList.BeforeFocusNodeEventHandler(this.treeList_BeforeFocusNode);
            this.treeList.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList_FocusedNodeChanged);
            this.treeList.CalcNodeDragImageIndex += new DevExpress.XtraTreeList.CalcNodeDragImageIndexEventHandler(this.treeList_CalcNodeDragImageIndex);
            this.treeList.PopupMenuShowing += new DevExpress.XtraTreeList.PopupMenuShowingEventHandler(this.treeList_PopupMenuShowing);
            this.treeList.VirtualTreeGetChildNodes += new DevExpress.XtraTreeList.VirtualTreeGetChildNodesEventHandler(this.treeList_VirtualTreeGetChildNodes);
            this.treeList.VirtualTreeGetCellValue += new DevExpress.XtraTreeList.VirtualTreeGetCellValueEventHandler(this.treeList_VirtualTreeGetCellValue);
            this.treeList.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeList_DragDrop);
            this.treeList.DragOver += new System.Windows.Forms.DragEventHandler(this.treeList_DragOver);
            this.treeList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeList_MouseDoubleClick);
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            resources.ApplyResources(this.repositoryItemButtonEdit1, "repositoryItemButtonEdit1");
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // UsersFilter
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList);
            this.Name = "UsersFilter";
            ((System.ComponentModel.ISupportInitialize)(this.treeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
    }
}
