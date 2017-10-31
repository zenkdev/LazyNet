using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.Gallery;
using DevExpress.XtraEditors.Controls;

namespace Dekart.LazyNet.Win.Modules
{
    public partial class DeviceDetail : DetailBase
    {
        readonly int? _room;
        string _path;
        bool _visible;

        /// <summary> new </summary>
        public DeviceDetail(Form parent, GetSessionCallback session, int? room, CloseDetailForm closeForm)
            : base(parent, session, null, closeForm)
        {
            _room = room;

            InitializeComponent();
            LabelForManufacturer.Appearance.ForeColor = ColorHelper.HyperLinkTextColor;
        }
        /// <summary> edit </summary>
        public DeviceDetail(Form parent, GetSessionCallback session, Device editObject, CloseDetailForm closeForm)
            : base(parent, session, editObject, closeForm)
        {
            InitializeComponent();
            LabelForManufacturer.Appearance.ForeColor = ColorHelper.HyperLinkTextColor;
        }

        public override string EditObjectName => _path + teName.Text;

        Device Device => EditObject as Device;

        /// <summary>Creates new edit object</summary>
        protected override LazyNetBaseObject CreateNewObject()
        {
            base.CreateNewObject();
            return new Device(Session) { Room = Session.GetObjectByKey<Room>(_room) };
        }

        protected override void OnLoad(EventArgs e)
        {
            InitEditors();
            base.OnLoad(e);
        }

        void InitEditors()
        {
            EditorsHelpers.InitDeviceTypeComboBox(icbDeviceType.Properties);
            icbDeviceState.Properties.Items.AddLocalizedEnum<DeviceStateEnum>();
            DictionaryHelper.InitDictionary(spellChecker1);
            deBuyedOn.Properties.NullDate = DateTime.MinValue;
            EditorsHelpers.InitGenderComboBox(riGender);
            gebSoftware.Init(gvSoftware);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            _visible = true;
        }

        /// <summary>Loads form layout</summary>
        protected override void LoadFormLayout()
        {
            LayoutManager?.RestoreFormLayout(new FormLayoutInfo(this, lcMain, rcMain.Toolbar));
        }

        /// <summary>Saves form layout</summary>
        protected override void SaveFormLayout()
        {
            LayoutManager?.SaveFormLayout(new FormLayoutInfo(this, lcMain, rcMain.Toolbar));
        }

        /// <summary> Initialize edit object data </summary>
        protected override void InitData()
        {
            _path = BuildFullPath(_room ?? Device.Room.ToInt32());

            icbDeviceType.EditValue = Device.DeviceType;
            teName.Text = Device.Name;
            teSKU.Text = Device.SKU;
            teSerial.Text = Device.Serial;
            mruSpecification.Text = Device.Specification;
            InitSpecificationItems(mruSpecification.Properties.Items);
            deBuyedOn.DateTime = Device.BuyedOn;
            icbDeviceState.EditValue = Device.DeviceState;
            beHostName.Text = Device.HostName;
            ipAddressEdit.IPAddress = Device.IP;
            beMAC.Text = Device.MAC;
            pictureEdit.Image = Device.Picture;
            InitPhotoGallery();
            reHtmlText.HtmlText = Device.HtmlNote;
            reHtmlText.Document.Sections[0].Page.PaperKind = PaperKind.A4;

            leRoom.EditValue = Device.Room?.Id;
            dsRooms.Refresh();
            leUser.EditValue = Device.User?.Id;
            dsUsers.Refresh();

            ucRepairs.InitData(Device, GetSession, rcMain);
            ucMovements.InitData(Device, GetSession, rcMain);
            gcSoftware.DataSource = Device.Software;

            bsiCreatedOn.Caption = string.Format(ConstStrings.CreatedOnCaption, Device.CreatedOn);
            bsiUpdatedOn.Caption = string.Format(ConstStrings.UpdatedOnCaption, Device.UpdatedOn);
        }

        /// <summary> Validate edit object data </summary>
        protected override bool ValidateData()
        {
            if (!base.ValidateData())
            {
                return false;
            }

            var sku = teSKU.Text.Trim();
            if (sku != string.Empty)
            {
                var query = (from device in new XPQuery<Device>(Session)
                             where !device.DeletionMark && device.Id != Device.Id && device.SKU == sku
                             select device);
                if (query.Any())
                {
                    Error(string.Format(ConstStrings.RuleUniqueSKUWarning, sku, query.First().Name));
                    return false;
                }
            }

            var serial = teSerial.Text.Trim();
            if (serial != string.Empty)
            {
                var query = (from device in new XPQuery<Device>(Session)
                             where !device.DeletionMark && device.Id != Device.Id && device.Serial == serial
                             select device);
                if (query.Any())
                {
                    Error(string.Format(ConstStrings.RuleUniqueSerialWarning, serial, query.First().Name));
                    return false;
                }
            }

            var ipAddress = (ipAddressEdit.IPAddress ?? string.Empty).Trim();
            if (ipAddress != string.Empty)
            {
                var query = (from device in new XPQuery<Device>(Session)
                             where !device.DeletionMark && device.Id != Device.Id && device.IP == ipAddress
                             select device);
                if (query.Any())
                {
                    Error(string.Format(ConstStrings.RuleUniqueIPAddressWarning, ipAddress, query.First().Name));
                    return false;
                }
            }

            var room = Device.Movements.OrderByDescending(m => m.CreatedOn).Select(m => m.NewRoom).FirstOrDefault();
            if (room != null && Device.Room.ToInt32() != room.ToInt32())
            {
                var str1 = Device.Room.ToString2();
                var str2 = room.ToString2();
                if (Question(string.Format(ConstStrings.MoveDeviceQuestion, str1, str2)))
                    Device.Room = room;
            }

            return true;
        }

        /// <summary>Saves data</summary>
        protected override void SaveData()
        {
            var oldIP = Device.IP;
            var oldRoom = Device.Room;
            var oldUser = Device.User;

            Device.DeviceType = (DeviceTypeEnum)icbDeviceType.EditValue;
            Device.Name = teName.Text;
            Device.SKU = teSKU.Text;
            Device.Serial = teSerial.Text;
            Device.Specification = mruSpecification.Text;
            Device.BuyedOn = deBuyedOn.DateTime.Date;
            Device.DeviceState = (DeviceStateEnum)icbDeviceState.EditValue;
            Device.HostName = beHostName.Text;
            Device.IP = ipAddressEdit.IPAddress;
            Device.IPInt = IPAddressHelper.ToInt64((IPv4Addr) ipAddressEdit.EditValue);
            Device.MAC = beMAC.Text;
            Device.Picture = pictureEdit.Image;
            Device.HtmlNote = reHtmlText.HtmlText;
            Device.Room = Session.GetObjectByKey<Room>(leRoom.EditValue);
            Device.User = Session.GetObjectByKey<User>(leUser.EditValue);

            if (!string.IsNullOrWhiteSpace(Device.IP))
            {
                if (oldIP != Device.IP || string.IsNullOrEmpty(Device.MAC))
                {
                    Device.MAC = NetHelper.GetMacAddressFromArp(Device.IP) ?? NetHelper.GetMacAddress(Device.IP);
                }
            }

            if (!ReferenceEquals(oldRoom, Device.Room) || !ReferenceEquals(oldUser, Device.User))
            {
                Device.Movements.Add(new Movement(Session) { OldRoom = oldRoom, NewRoom = Device.Room, OldUser = oldUser, NewUser = Device.User });
            }

            CommitSession();
        }

        void InitSpecificationItems(ComboBoxItemCollection items)
        {
            var deviceType = (DeviceTypeEnum)icbDeviceType.EditValue;

            var query = new XPQuery<Device>(Session);
            items.Clear();
            items.AddRange(query.Where(d => !d.DeletionMark && d.DeviceType == deviceType && d.Specification != "").GroupBy(d => d.Specification).Select(g => g.Key).ToList());
        }

        void InitPhoto(BaseGallery gallery)
        {
            gallery.Destroy();

            foreach (var keyValuePair in DataHelper.PhotoLibrary)
            {
                var galleryItemGroup = new GalleryItemGroup { Caption = keyValuePair.Key };
                foreach (var photoLibrary in keyValuePair.Value)
                {
                    var galleryItem = new GalleryItem { Caption = photoLibrary.Name, Image = ImagesHelper.ModifyImage(photoLibrary.Photo, null, null) };
                    galleryItem.HoverImage = galleryItem.Image;
                    galleryItemGroup.Items.Add(galleryItem);
                }
                gallery.Groups.Add(galleryItemGroup);
            }
        }

        void InitPhotoGallery()
        {
            gddPicture.Gallery.BeginUpdate();
            try
            {
                InitPhoto(gddPicture.Gallery);
            }
            finally
            {
                gddPicture.Gallery.EndUpdate();
            }
        }

        string BuildFullPath(int? parent)
        {
            var obj = Session.GetObjectByKey<Room>(parent);
            if (obj == null) return "/";
            return BuildFullPath(obj.Parent) + obj.Name + "/";
        }

        void ReHtmlTextSelectionChanged(object sender, EventArgs e)
        {
            tableToolsRibbonPageCategory1.Visible = reHtmlText.IsSelectionInTable();
            floatingPictureToolsRibbonPageCategory1.Visible = reHtmlText.IsFloatingObjectSelected;
        }

        void ReHtmlTextHtmlTextChanged(object sender, EventArgs e)
        {
            if (_visible && reHtmlText.HtmlText.Trim() != (Device.HtmlNote ?? "").Trim())
                Dirty = true;
        }

        void BbiClearPhotoItemClick(object sender, ItemClickEventArgs e)
        {
            pictureEdit.Image = null;
        }

        void BbiCustomPhotoItemClick(object sender, ItemClickEventArgs e)
        {
            if (ofdCustomPicture.ShowDialog(this) == DialogResult.OK)
            {
                pictureEdit.Image = ImagesHelper.ModifyImage(Image.FromFile(ofdCustomPicture.FileName), 125, 125);

                using (var form = new AddPhotoLibrary(this, new Session(), ofdCustomPicture.FileName, rcMain.Manager))
                {
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        DataHelper.ResetPhotoLibrary();
                    }
                }

                InitPhotoGallery();
            }
        }

        void GddPhotoGalleryItemClick(object sender, GalleryItemClickEventArgs e)
        {
            pictureEdit.Image = e.Item.Image;
        }

        void IcbDeviceTypeEditValueChanged(object sender, EventArgs e)
        {
            if (_visible)
            {
                InitSpecificationItems(mruSpecification.Properties.Items);
            }
        }

        void BeHostNameEditValueChanged(object sender, EventArgs e)
        {
            bbiImportFromAD.Enabled = beHostName.Text.Trim() != string.Empty;
        }

        void BeHostNameButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (ipAddressEdit.IPAddress == "") return;
            beHostName.Text = NetHelper.GetHostByAddress(ipAddressEdit.IPAddress);
        }

        void IPAddressEditButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Search)
            {
                if (beHostName.Text.Trim() != "")
                {
                    var ipAddress = NetHelper.GetIPAddressFromHostName(beHostName.Text.Trim());
                    if (ipAddress != null)
                    {
                        ipAddressEdit.IPAddress = ipAddress.ToString();
                    }
                }

            }
            else if (e.Button.Kind == ButtonPredefines.Clear)
            {
                ipAddressEdit.IPAddress = null;
            }
        }

        void BeMACButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Kind == ButtonPredefines.Search)
            {
                if (ipAddressEdit.IPAddress != "")
                {
                    var mac = NetHelper.GetMacAddressFromArp(ipAddressEdit.IPAddress) ?? NetHelper.GetMacAddress(ipAddressEdit.IPAddress);
                    if (!string.IsNullOrEmpty(mac))
                    {
                        beMAC.Text = mac;
                    }
                }

            }
            else if (e.Button.Kind == ButtonPredefines.Clear)
            {
                beMAC.Text = null;
            }
        }

        void OnResolveSession(object sender, ResolveSessionEventArgs e)
        {
            e.Session = new Session();
        }

        void OnDismissSession(object sender, ResolveSessionEventArgs e)
        {
            var session = e.Session as IDisposable;
            session?.Dispose();
        }

        void bbiImportFromAD_ItemClick(object sender, ItemClickEventArgs e)
        {
            var hostName = beHostName.Text.Trim();
            string managedBy, operatingSystemFull, room;
            if (AdHelper.GetComputerPropertiesFromAD(hostName, out managedBy, out operatingSystemFull, out room))
            {
                var roomObj = Session.FindObject<Room>(CriteriaOperator.Parse("Name=? And DeletionMark=0", room));
                if (roomObj != null)
                {
                    leRoom.EditValue = roomObj.Id;
                }
                if (!string.IsNullOrWhiteSpace(managedBy))
                {
                    var index = managedBy.IndexOf(@"\", StringComparison.Ordinal);
                    if (index < 0)
                    {
                        if (!string.IsNullOrEmpty(Environment.UserDomainName))
                            managedBy = string.Concat(Environment.UserDomainName, @"\", managedBy);
                    }
                    var userObj = Session.FindObject<User>(CriteriaOperator.Parse("UserName=?", managedBy));
                    if (userObj != null)
                    {
                        leUser.EditValue = userObj.Id;
                    }
                }
            }
        }

        void beMAC_EditValueChanged(object sender, EventArgs e)
        {
            var str = Regex.Replace(beMAC.Text, "[^0-9|a-f|A-F]", "");
            var query = new XPQuery<Manufacturer>(Session);
            var result = query.FirstOrDefault(m => str.StartsWith(m.MAC));
            LabelForManufacturer.Text = result != null ? result.Name : ConstStrings.ManufacturerUnknown;
        }

        void bbiNewUser_ItemClick(object sender, ItemClickEventArgs e)
        {
            leUser.EditValue = AddNewUser(leUser.EditValue);
        }

        void leUser_AddNewValue(object sender, AddNewValueEventArgs e)
        {
            e.NewValue = AddNewUser(leUser.EditValue);
        }

        object AddNewUser(object defaultValue)
        {
            DialogResult result = DialogResult.Cancel;
            using (var form = new UserDetail(ParentFormMain, GetSession, arg => result = arg))
            {
                form.ShowDialog(this);
                if (result == DialogResult.OK)
                    return form.User.Id;
            }

            return defaultValue;
        }

        #region Software

        SoftwareObject CurrentSoftware => gvSoftware.GetRow(gvSoftware.FocusedRowHandle) as SoftwareObject;

        void gebSoftware_AddRecord(object sender, EventArgs e)
        {
            using (var form = new AddSoftware(ParentFormMain, Session, null, ParentFormMain.MenuManager))
            {
                if (form.ShowDialog() != DialogResult.Cancel)
                {
                    Device.Software.Add(form.Software);
                    GridHelper.GridViewFocusObject(gvSoftware, form.Software);
                    Dirty = true;
                }
            }
        }

        void gebSoftware_DeleteRecord(object sender, EventArgs e)
        {
            if (CurrentSoftware == null) return;

            gvSoftware.HideEditor();
            gvSoftware.UpdateCurrentRow();
            Device.Software.Remove(CurrentSoftware);
            if (ObjectHelper.SafeDelete(ParentFormMain, CurrentSoftware, false))
                Dirty = true;
        }

        void gvSoftware_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.RowHandle >= 0 && e.Clicks == 2)
            {
                if (CurrentSoftware == null || !gvSoftware.Editable) return;
                using (var form = new AddSoftware(ParentFormMain, Session, CurrentSoftware, ParentFormMain.MenuManager))
                {
                    if (form.ShowDialog() != DialogResult.Cancel)
                        Dirty = true;
                }
            }
        }

        void MinPowerSpinEdit_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            if (Convert.ToInt32(e.Value) == 0)
            {
                e.DisplayText = "";
            }
        }
        #endregion
    }
}
