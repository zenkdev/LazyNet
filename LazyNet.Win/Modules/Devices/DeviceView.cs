using System;
using System.Drawing;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraBars.Docking2010;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraRichEdit;

namespace Dekart.LazyNet.Win.Modules
{
    public partial class DeviceView : ControlBase
    {
        Device _device;

        public DeviceView()
        {
            InitializeComponent();
            gvRepairs.SetViewFontSize(2, 1);
            lcDevice.Tag = 0; lcRepairs.Tag = 1; lcNotes.Tag = 2;
            new LabelTabController(0, lcDevice, lcRepairs, lcNotes).EditValueChanged += (s, e) =>
            {
                lciDevice.Visibility = 0.Equals(s) ? LayoutVisibility.Always : LayoutVisibility.Never;
                lciDevices.Visibility = 1.Equals(s) ? LayoutVisibility.Always : LayoutVisibility.Never;
                lciNotes.Visibility = 2.Equals(s) ? LayoutVisibility.Always : LayoutVisibility.Never;
            };
            riRepairType.Items.AddLocalizedEnum<RepairTypeEnum>();
            ((WindowsUIButton)buttonPanel.Buttons[0]).Click += (s1, e1) => { _device.Ping(); };
            ((WindowsUIButton)buttonPanel.Buttons[1]).Click += (s1, e1) => { _device.OpenRadmin(); };
            ((WindowsUIButton)buttonPanel.Buttons[2]).Click += (s1, e1) => { XtraMessageBox.Show(FindForm(), "To do..", ""); };
            ((WindowsUIButton)buttonPanel.Buttons[3]).Click += (s1, e1) => { XtraMessageBox.Show(FindForm(), "To do..", ""); };
            Init(null, null);
        }
        protected override void LookAndFeelStyleChanged()
        {
            base.LookAndFeelStyleChanged();
            Color controlColor = CommonSkins.GetSkin(UserLookAndFeel.Default).Colors.GetColor("Control");
            pictureEdit.BackColor = controlColor;
        }
        public void Init(Device device, string toolTip)
        {
            _device = device;

            ItemForButtonPanel.Enabled = device != null;
            if (device != null)
            {
                pictureEdit.Image = device.PictureExists;
                sliName.Text = device.Name;
                lcSpecification.Text = device.Specification;
                if (device.Room != null)
                {
                    ItemForRoom.Visibility = LayoutVisibility.Always;
                    lcRoom.Text = device.Room.Name;
                }
                else ItemForRoom.Visibility = LayoutVisibility.Never;
                lcSKU.Text = device.SKU;
                ItemForSKU.Visibility = !string.IsNullOrEmpty(device.SKU) ? LayoutVisibility.Always : LayoutVisibility.Never;
                lcSerial.Text = device.Serial;
                ItemForSerial.Visibility = !string.IsNullOrEmpty(device.Serial) ? LayoutVisibility.Always : LayoutVisibility.Never;
                lcBuyedOn.Text = device.BuyedOn.ToShortDateString();
                ItemForBuyedOn.Visibility = device.BuyedOn != DateTime.MinValue ? LayoutVisibility.Always : LayoutVisibility.Never;
                lcHostName.Text = device.HostName;
                ItemForHostName.Visibility = !string.IsNullOrEmpty(device.HostName) ? LayoutVisibility.Always : LayoutVisibility.Never;
                lcIP.Text = device.IP;
                ItemForIP.Visibility = !string.IsNullOrEmpty(device.IP) ? LayoutVisibility.Always : LayoutVisibility.Never;
                lcMAC.Text = device.MAC;
                ItemForMAC.Visibility = !string.IsNullOrEmpty(device.MAC) ? LayoutVisibility.Always : LayoutVisibility.Never;
                richEditControl.HtmlText = device.HtmlNote;
                gcRepairs.DataSource = device.Repairs;
            }
            else
            {
                pictureEdit.Image = null;
                sliName.Text = @" ";
                lcSpecification.Text = richEditControl.HtmlText = string.Empty;
                ItemForSKU.Visibility = ItemForSerial.Visibility = ItemForRoom.Visibility = ItemForBuyedOn.Visibility = LayoutVisibility.Never;
                gcRepairs.DataSource = null;
            }
            if (!string.IsNullOrEmpty(toolTip))
            {
                pictureEdit.ToolTip = toolTip;
                pictureEdit.Cursor = Cursors.Hand;
            }
            else pictureEdit.Cursor = Cursors.Default;
            Refresh();
        }
        public float ZoomFactor
        {
            get { return richEditControl.Views.SimpleView.ZoomFactor; }
            set { richEditControl.Views.SimpleView.ZoomFactor = value; }
        }
        public RichEditControl RichEdit => richEditControl;
    }
}
