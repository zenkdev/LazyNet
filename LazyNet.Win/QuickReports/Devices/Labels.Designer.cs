namespace Dekart.LazyNet.Win.QuickReports
{
    partial class Labels
    {
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.QRCodeGenerator qrCodeGenerator1 = new DevExpress.XtraPrinting.BarCode.QRCodeGenerator();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Labels));
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.objectDataSource2 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource();
            this.Field_DeviceType = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_MAC = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_BuyedOn = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Specification = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.Label_SKU = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_IP = new DevExpress.XtraReports.UI.XRLabel();
            this.BarCode_SKU = new DevExpress.XtraReports.UI.XRBarCode();
            this.Label_HostName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Field_MAC = new DevExpress.XtraReports.UI.XRLabel();
            this.Field_BuyedOn = new DevExpress.XtraReports.UI.XRLabel();
            this.Label_Serial = new DevExpress.XtraReports.UI.XRLabel();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.Field_IP = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.Field_Name = new DevExpress.XtraReports.UI.XRLabel();
            this.Field_Specification = new DevExpress.XtraReports.UI.XRLabel();
            this.Field_HostName = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 89F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // objectDataSource2
            // 
            this.objectDataSource2.DataSource = typeof(Dekart.LazyNet.Device);
            this.objectDataSource2.Name = "objectDataSource2";
            // 
            // Field_DeviceType
            // 
            this.Field_DeviceType.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Field_DeviceType.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "DeviceTypeText")});
            this.Field_DeviceType.Dpi = 254F;
            this.Field_DeviceType.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Field_DeviceType.LocationFloat = new DevExpress.Utils.PointFloat(14.05155F, 82.78452F);
            this.Field_DeviceType.Name = "Field_DeviceType";
            this.Field_DeviceType.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Field_DeviceType.Scripts.OnBeforePrint = "Field_DeviceType_BeforePrint";
            this.Field_DeviceType.SizeF = new System.Drawing.SizeF(598.5353F, 42.54369F);
            this.Field_DeviceType.StylePriority.UseBorders = false;
            this.Field_DeviceType.StylePriority.UseFont = false;
            this.Field_DeviceType.StylePriority.UseTextAlignment = false;
            this.Field_DeviceType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Label_MAC
            // 
            this.Label_MAC.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Label_MAC.Dpi = 254F;
            this.Label_MAC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_MAC.LocationFloat = new DevExpress.Utils.PointFloat(14.05074F, 300.5882F);
            this.Label_MAC.Name = "Label_MAC";
            this.Label_MAC.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label_MAC.Scripts.OnBeforePrint = "Label_MAC_BeforePrint";
            this.Label_MAC.SizeF = new System.Drawing.SizeF(227.5471F, 58.42001F);
            this.Label_MAC.StylePriority.UseBorders = false;
            this.Label_MAC.StylePriority.UseFont = false;
            this.Label_MAC.Text = "MAC адрес";
            // 
            // Label_BuyedOn
            // 
            this.Label_BuyedOn.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Label_BuyedOn.Dpi = 254F;
            this.Label_BuyedOn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_BuyedOn.LocationFloat = new DevExpress.Utils.PointFloat(14.05074F, 125.3282F);
            this.Label_BuyedOn.Name = "Label_BuyedOn";
            this.Label_BuyedOn.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label_BuyedOn.Scripts.OnBeforePrint = "Label_BuyedOn_BeforePrint";
            this.Label_BuyedOn.SizeF = new System.Drawing.SizeF(227.5471F, 58.41995F);
            this.Label_BuyedOn.StylePriority.UseBorders = false;
            this.Label_BuyedOn.StylePriority.UseFont = false;
            this.Label_BuyedOn.Text = "Дата покупки";
            // 
            // Label_Specification
            // 
            this.Label_Specification.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Label_Specification.Dpi = 254F;
            this.Label_Specification.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_Specification.LocationFloat = new DevExpress.Utils.PointFloat(14.05074F, 417.4283F);
            this.Label_Specification.Name = "Label_Specification";
            this.Label_Specification.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label_Specification.SizeF = new System.Drawing.SizeF(272.5208F, 47.83667F);
            this.Label_Specification.StylePriority.UseBorders = false;
            this.Label_Specification.StylePriority.UseFont = false;
            this.Label_Specification.StylePriority.UseTextAlignment = false;
            this.Label_Specification.Text = "Характеристики";
            this.Label_Specification.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft;
            // 
            // xrPanel1
            // 
            this.xrPanel1.BorderColor = System.Drawing.Color.Gray;
            this.xrPanel1.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dot;
            this.xrPanel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel1.CanGrow = false;
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.Label_SKU,
            this.xrLabel1,
            this.Field_BuyedOn,
            this.Field_DeviceType,
            this.Label_MAC,
            this.Field_MAC,
            this.Label_IP,
            this.Label_HostName,
            this.BarCode_SKU,
            this.Label_Specification,
            this.Label_BuyedOn,
            this.Field_Specification,
            this.Field_IP,
            this.Field_HostName,
            this.Label_Serial,
            this.Field_Name});
            this.xrPanel1.Dpi = 254F;
            this.xrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.SizeF = new System.Drawing.SizeF(629.3146F, 926F);
            this.xrPanel1.StylePriority.UseBorderColor = false;
            this.xrPanel1.StylePriority.UseBorderDashStyle = false;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 89F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Label_SKU
            // 
            this.Label_SKU.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Label_SKU.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SKU")});
            this.Label_SKU.Dpi = 254F;
            this.Label_SKU.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_SKU.LocationFloat = new DevExpress.Utils.PointFloat(143.698F, 553.1087F);
            this.Label_SKU.Name = "Label_SKU";
            this.Label_SKU.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label_SKU.SizeF = new System.Drawing.SizeF(332.3578F, 58.42001F);
            this.Label_SKU.StylePriority.UseBorders = false;
            this.Label_SKU.StylePriority.UseFont = false;
            this.Label_SKU.StylePriority.UseTextAlignment = false;
            this.Label_SKU.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            // 
            // Label_IP
            // 
            this.Label_IP.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Label_IP.Dpi = 254F;
            this.Label_IP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_IP.LocationFloat = new DevExpress.Utils.PointFloat(14.05074F, 242.1681F);
            this.Label_IP.Name = "Label_IP";
            this.Label_IP.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label_IP.Scripts.OnBeforePrint = "Label_IP_BeforePrint";
            this.Label_IP.SizeF = new System.Drawing.SizeF(227.5471F, 58.42001F);
            this.Label_IP.StylePriority.UseBorders = false;
            this.Label_IP.StylePriority.UseFont = false;
            this.Label_IP.Text = "IP адрес";
            // 
            // BarCode_SKU
            // 
            this.BarCode_SKU.Alignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.BarCode_SKU.AutoModule = true;
            this.BarCode_SKU.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.BarCode_SKU.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "SKU")});
            this.BarCode_SKU.Dpi = 254F;
            this.BarCode_SKU.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BarCode_SKU.LocationFloat = new DevExpress.Utils.PointFloat(143.698F, 611.5287F);
            this.BarCode_SKU.Module = 6.08F;
            this.BarCode_SKU.Name = "BarCode_SKU";
            this.BarCode_SKU.Padding = new DevExpress.XtraPrinting.PaddingInfo(25, 25, 0, 0, 254F);
            this.BarCode_SKU.Scripts.OnBeforePrint = "BarCode_SKU_BeforePrint";
            this.BarCode_SKU.ShowText = false;
            this.BarCode_SKU.SizeF = new System.Drawing.SizeF(332.3578F, 279.768F);
            this.BarCode_SKU.StylePriority.UseBorders = false;
            this.BarCode_SKU.StylePriority.UseFont = false;
            this.BarCode_SKU.StylePriority.UseTextAlignment = false;
            qrCodeGenerator1.CompactionMode = DevExpress.XtraPrinting.BarCode.QRCodeCompactionMode.Byte;
            qrCodeGenerator1.Version = DevExpress.XtraPrinting.BarCode.QRCodeVersion.Version2;
            this.BarCode_SKU.Symbology = qrCodeGenerator1;
            this.BarCode_SKU.Text = "1234567890";
            this.BarCode_SKU.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // Label_HostName
            // 
            this.Label_HostName.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Label_HostName.Dpi = 254F;
            this.Label_HostName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_HostName.LocationFloat = new DevExpress.Utils.PointFloat(14.05074F, 359.0082F);
            this.Label_HostName.Name = "Label_HostName";
            this.Label_HostName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label_HostName.Scripts.OnBeforePrint = "Label_HostName_BeforePrint";
            this.Label_HostName.SizeF = new System.Drawing.SizeF(227.5471F, 58.42004F);
            this.Label_HostName.StylePriority.UseBorders = false;
            this.Label_HostName.StylePriority.UseFont = false;
            this.Label_HostName.Text = "Сетевое имя";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Serial")});
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(248.2807F, 183.7482F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(364.3072F, 58.41998F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.Text = "xrLabel1";
            // 
            // Field_MAC
            // 
            this.Field_MAC.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Field_MAC.CanGrow = false;
            this.Field_MAC.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "MAC")});
            this.Field_MAC.Dpi = 254F;
            this.Field_MAC.LocationFloat = new DevExpress.Utils.PointFloat(248.2807F, 300.5882F);
            this.Field_MAC.Name = "Field_MAC";
            this.Field_MAC.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Field_MAC.Scripts.OnBeforePrint = "Field_MAC_BeforePrint";
            this.Field_MAC.SizeF = new System.Drawing.SizeF(364.3072F, 58.41998F);
            this.Field_MAC.StylePriority.UseBorders = false;
            this.Field_MAC.WordWrap = false;
            // 
            // Field_BuyedOn
            // 
            this.Field_BuyedOn.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Field_BuyedOn.CanGrow = false;
            this.Field_BuyedOn.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "BuyedOn", "{0:dd.MM.yyyy}")});
            this.Field_BuyedOn.Dpi = 254F;
            this.Field_BuyedOn.LocationFloat = new DevExpress.Utils.PointFloat(248.2814F, 125.3282F);
            this.Field_BuyedOn.Name = "Field_BuyedOn";
            this.Field_BuyedOn.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Field_BuyedOn.Scripts.OnBeforePrint = "Field_BuyedOn_BeforePrint";
            this.Field_BuyedOn.SizeF = new System.Drawing.SizeF(364.3071F, 58.42001F);
            this.Field_BuyedOn.StylePriority.UseBorders = false;
            this.Field_BuyedOn.WordWrap = false;
            // 
            // Label_Serial
            // 
            this.Label_Serial.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Label_Serial.Dpi = 254F;
            this.Label_Serial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_Serial.LocationFloat = new DevExpress.Utils.PointFloat(14.05074F, 183.7482F);
            this.Label_Serial.Name = "Label_Serial";
            this.Label_Serial.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Label_Serial.Scripts.OnBeforePrint = "Label_Serial_BeforePrint";
            this.Label_Serial.SizeF = new System.Drawing.SizeF(227.5471F, 58.41995F);
            this.Label_Serial.StylePriority.UseBorders = false;
            this.Label_Serial.StylePriority.UseFont = false;
            this.Label_Serial.Text = "Серийный №";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox1,
            this.xrPanel1});
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 930F;
            this.Detail.MultiColumn.ColumnWidth = 635F;
            this.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnWidth;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.Detail.SortFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("Name", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // Field_IP
            // 
            this.Field_IP.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Field_IP.CanGrow = false;
            this.Field_IP.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "IP")});
            this.Field_IP.Dpi = 254F;
            this.Field_IP.LocationFloat = new DevExpress.Utils.PointFloat(248.2783F, 242.1681F);
            this.Field_IP.Name = "Field_IP";
            this.Field_IP.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Field_IP.Scripts.OnBeforePrint = "Field_IP_BeforePrint";
            this.Field_IP.SizeF = new System.Drawing.SizeF(364.3072F, 58.42001F);
            this.Field_IP.StylePriority.UseBorders = false;
            this.Field_IP.Text = "Field_IP";
            this.Field_IP.WordWrap = false;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Dpi = 254F;
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(617.4381F, 894.1039F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(30F, 30F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.Squeeze;
            // 
            // Field_Name
            // 
            this.Field_Name.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Field_Name.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Name")});
            this.Field_Name.Dpi = 254F;
            this.Field_Name.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Field_Name.LocationFloat = new DevExpress.Utils.PointFloat(14.05074F, 12.56004F);
            this.Field_Name.Name = "Field_Name";
            this.Field_Name.Padding = new DevExpress.XtraPrinting.PaddingInfo(20, 5, 0, 0, 254F);
            this.Field_Name.SizeF = new System.Drawing.SizeF(598.5347F, 70.22454F);
            this.Field_Name.StylePriority.UseBorders = false;
            this.Field_Name.StylePriority.UseFont = false;
            this.Field_Name.StylePriority.UsePadding = false;
            // 
            // Field_Specification
            // 
            this.Field_Specification.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Field_Specification.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Specification")});
            this.Field_Specification.Dpi = 254F;
            this.Field_Specification.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Field_Specification.LocationFloat = new DevExpress.Utils.PointFloat(14.05203F, 465.265F);
            this.Field_Specification.Name = "Field_Specification";
            this.Field_Specification.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Field_Specification.Scripts.OnBeforePrint = "Field_Specification_BeforePrint";
            this.Field_Specification.SizeF = new System.Drawing.SizeF(598.5358F, 87.84366F);
            this.Field_Specification.StylePriority.UseBorders = false;
            this.Field_Specification.StylePriority.UseFont = false;
            this.Field_Specification.Text = "Field_Specification";
            // 
            // Field_HostName
            // 
            this.Field_HostName.AutoWidth = true;
            this.Field_HostName.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.Field_HostName.CanGrow = false;
            this.Field_HostName.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "HostName")});
            this.Field_HostName.Dpi = 254F;
            this.Field_HostName.LocationFloat = new DevExpress.Utils.PointFloat(248.2814F, 359.0083F);
            this.Field_HostName.Name = "Field_HostName";
            this.Field_HostName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.Field_HostName.SizeF = new System.Drawing.SizeF(364.3066F, 58.41995F);
            this.Field_HostName.StylePriority.UseBorders = false;
            this.Field_HostName.Text = "Field_HostName";
            this.Field_HostName.WordWrap = false;
            // 
            // DeviceLabelReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.ComponentStorage.Add(this.objectDataSource2);
            this.Dpi = 254F;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margins = new System.Drawing.Printing.Margins(84, 0, 89, 89);
            this.PageHeight = 2970;
            this.PageWidth = 2100;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportPrintOptions.DetailCountOnEmptyDataSource = 44;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.ScriptsSource = resources.GetString("$this.ScriptsSource");
            this.Version = "14.2";
            this.Watermark.Image = ((System.Drawing.Image)(resources.GetObject("DeviceLabelReport.Watermark.Image")));
            this.Watermark.ImageTiling = true;
            this.Watermark.ImageTransparency = 240;
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource2;
        private DevExpress.XtraReports.UI.XRLabel Field_DeviceType;
        private DevExpress.XtraReports.UI.XRLabel Label_MAC;
        private DevExpress.XtraReports.UI.XRLabel Label_BuyedOn;
        private DevExpress.XtraReports.UI.XRLabel Label_Specification;
        private DevExpress.XtraReports.UI.XRPanel xrPanel1;
        private DevExpress.XtraReports.UI.XRLabel Label_SKU;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel Field_BuyedOn;
        private DevExpress.XtraReports.UI.XRLabel Field_MAC;
        private DevExpress.XtraReports.UI.XRLabel Label_IP;
        private DevExpress.XtraReports.UI.XRLabel Label_HostName;
        private DevExpress.XtraReports.UI.XRBarCode BarCode_SKU;
        private DevExpress.XtraReports.UI.XRLabel Field_Specification;
        private DevExpress.XtraReports.UI.XRLabel Field_IP;
        private DevExpress.XtraReports.UI.XRLabel Field_HostName;
        private DevExpress.XtraReports.UI.XRLabel Label_Serial;
        private DevExpress.XtraReports.UI.XRLabel Field_Name;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;


    }
}
