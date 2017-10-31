using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Dekart.LazyNet.Drawing;
using Dekart.LazyNet.Helpers;
using Dekart.LazyNet.Win.Controls;
using DevExpress.Xpo;
using DevExpress.XtraEditors;

namespace Dekart.LazyNet.Win.Modules
{
    public partial class Maps : ModuleBase, ISupportZoom, IDataPaneModule
    {
        readonly DrawablePicture _picture = new DrawablePicture();
        // The object we are currently drawing.
        Drawable _newDrawable;
        MapsControl _mapsControl;
        object _parent;
        Size _gridSize = Size.Empty;

        public override string ModuleName { get { return ConstStrings.Maps; } }

        public Maps()
        {
            InitializeComponent();

            _picture.SelectedDrawableChanged += ((s, e) => RaiseEnableEdit());

            bbiOpenWeb.ItemClick += (s, e) => ButtonClick(TagResources.OpenWeb);
            bbiOpenRadmin.ItemClick += (s, e) => ButtonClick(TagResources.OpenRadmin);
            bbiOpenRomViewer.ItemClick += (s, e) => ButtonClick(TagResources.OpenRomViewer);
            bbiOpenMstsc.ItemClick += (s, e) => ButtonClick(TagResources.OpenMstsc);
            bbiPing.ItemClick += (s, e) => ButtonClick(TagResources.Ping);
            bbiTracert.ItemClick += (s, e) => ButtonClick(TagResources.Tracert);

            ShowPreview();
        }

        public override void InitModule(object data, UnitOfWork session)
        {
            base.InitModule(data, session);
            _mapsControl = data as MapsControl;
        }

        public override void ShowModule(bool firstShow)
        {
            base.ShowModule(firstShow);
            UpdateDataPaneState();
            RaiseEnableEdit();
        }

        public override void DataSourceChanged(DataSourceChangedEventArgs args)
        {
            partNameCore = args.Caption;
            _parent = args.Data;
            RefreshData();
        }

        protected override void LoadFormLayout()
        {
            if (LayoutManager == null) return;
            LayoutManager.RestoreFormLayout(new FormLayoutInfo(Name, null, null, null, this));
            _gridSize = LayoutManager.Properties.CurrentProperty.GridSize;
        }
        protected override void SaveFormLayout()
        {
            if (LayoutManager != null)
                LayoutManager.SaveFormLayout(new FormLayoutInfo(Name, null, null, null, this));
        }

        protected override void BeginRefreshData()
        {
            base.BeginRefreshData();

            _picture.SelectedDrawable = null;
            _picture.Drawables.Clear();

            var zoomFaction = pictureEdit.ZoomFactor;

            _current = Session.GetObjectByKey<Map>(_parent);
            if (_current == null)
            {
                pictureEdit.Image = null;
            }
            else
            {
                pictureEdit.Image = _current.Picture;
                foreach (var mapToDevice in _current.Devices.OrderBy(item => item.SortOrder))
                {
                    var drawable = new DrawableDevice(mapToDevice.X1, mapToDevice.Y1)
                    {
                        Text = mapToDevice.Device.ObjectName,
                        Picture = mapToDevice.Device.PictureExists,
                        Tag = mapToDevice.Id
                    };
                    _picture.Drawables.Add(drawable);
                }
            }

            pictureEdit.ZoomFactor = zoomFaction;

            UpdateListBox();

            RaiseEnableEdit();
        }

        public override void ButtonClick(string tag)
        {
            switch (tag)
            {
                case TagResources.UserEdit:
                    EditItem();
                    break;
                case TagResources.DeleteItem:
                    DeleteItem();
                    break;
                case TagResources.MapBackground:
                    _mapsControl.MapImage();
                    break;
                case TagResources.BringToFront:
                    if (_picture.SelectedDrawable != null)
                    {
                        _picture.BringToFront(_picture.SelectedDrawable);
                        int n = 0;
                        foreach (var drawable in _picture.Drawables)
                        {
                            if (drawable is DrawableDevice)
                            {
                                var mapToDevice = Session.GetObjectByKey<MapToDevice>(drawable.Tag);
                                mapToDevice.SortOrder = n++;
                                mapToDevice.Save();
                            }
                        }
                        Session.CommitChanges();
                        pictureEdit.Invalidate(true);
                    }
                    break;
                case TagResources.SendToBack:
                    if (_picture.SelectedDrawable != null)
                    {
                        _picture.SendToBack(_picture.SelectedDrawable);
                        int n = 0;
                        foreach (var drawable in _picture.Drawables)
                        {
                            if (drawable is DrawableDevice)
                            {
                                var mapToDevice = Session.GetObjectByKey<MapToDevice>(drawable.Tag);
                                mapToDevice.SortOrder = n++;
                                mapToDevice.Save();
                            }
                        }
                        Session.CommitChanges();
                        pictureEdit.Invalidate(true);
                    }
                    break;
                case TagResources.OpenWeb:
                    if (_picture.SelectedDrawable is DrawableDevice)
                    {
                        var mapToDevice = Session.GetObjectByKey<MapToDevice>(_picture.SelectedDrawable.Tag);
                        mapToDevice.Device.OpenWeb();
                    }
                    break;
                case TagResources.OpenRadmin:
                    if (_picture.SelectedDrawable is DrawableDevice)
                    {
                        var mapToDevice = Session.GetObjectByKey<MapToDevice>(_picture.SelectedDrawable.Tag);
                        mapToDevice.Device.OpenRadmin();
                    }
                    break;
                case TagResources.OpenRomViewer:
                    if (_picture.SelectedDrawable is DrawableDevice)
                    {
                        var mapToDevice = Session.GetObjectByKey<MapToDevice>(_picture.SelectedDrawable.Tag);
                        mapToDevice.Device.OpenRomViewer();
                    }
                    break;
                case TagResources.OpenMstsc:
                    if (_picture.SelectedDrawable is DrawableDevice)
                    {
                        var mapToDevice = Session.GetObjectByKey<MapToDevice>(_picture.SelectedDrawable.Tag);
                        mapToDevice.Device.OpenMstsc();
                    }
                    break;
                case TagResources.Ping:
                    if (_picture.SelectedDrawable is DrawableDevice)
                    {
                        var mapToDevice = Session.GetObjectByKey<MapToDevice>(_picture.SelectedDrawable.Tag);
                        mapToDevice.Device.Ping();
                    }
                    break;
                case TagResources.Tracert:
                    if (_picture.SelectedDrawable is DrawableDevice)
                    {
                        var mapToDevice = Session.GetObjectByKey<MapToDevice>(_picture.SelectedDrawable.Tag);
                        mapToDevice.Device.Tracert();
                    }
                    break;
            }
        }

        void UpdateListBox()
        {

            imageListBoxControl1.BeginUpdate();

            imageListBoxControl1.Items.Clear();
            icDevices.Images.Clear();

            imageListBoxControl1.DataSource = DataHelper.GetMapListBoxItems(icDevices.Images, Session);

            imageListBoxControl1.EndUpdate();
        }

        void RaiseEnableEdit()
        {
            ParentFormMain.EnableEdit(_picture.SelectedDrawable != null);
        }

        void EditItem()
        {
            if (_picture.SelectedDrawable is DrawableDevice)
            {
                var device = Session.GetObjectByKey<MapToDevice>(_picture.SelectedDrawable.Tag).Device;
                Cursor.Current = Cursors.WaitCursor;
                if (!ParentFormMain.IsDetailExist(device.Oid))
                {
                    ParentFormMain.ShowDetail(new DeviceDetail(ParentFormMain, GetSession, device, CloseDetailForm));
                }
                Cursor.Current = Cursors.Default;
            }
        }

        void DeleteItem()
        {
            if (_picture.SelectedDrawable is DrawableDevice)
            {
                var mapToDevice = Session.GetObjectByKey<MapToDevice>(_picture.SelectedDrawable.Tag);
                ObjectHelper.DeleteObject(this, mapToDevice, true);
                _picture.Remove(_picture.SelectedDrawable);

                _mapsControl.DecrementData();
                UpdateListBox();
                pictureEdit.Invalidate(true);
            }
        }

        void CloseDetailForm(DialogResult result)
        {
            ParentFormMain.CloseActiveDetailForm();
            if (result == DialogResult.Cancel) return;

            //RefreshData();
            ParentFormMain.UpdateTreeView();
            //FocusRow(_focusedRow);
        }

        void ShowPreview()
        {
            pictureEdit.Invalidate(true);
        }

        #region ListBox

        ImageListBoxItemData _imageListBoxItem;
        private Map _current;

        void ImageListBoxControl1GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (_imageListBoxItem == null) return;

            e.UseDefaultCursors = false;
        }

        void ImageListBoxControl1MouseDown(object sender, MouseEventArgs e)
        {
            var selectedIndex = imageListBoxControl1.IndexFromPoint(new Point(e.X, e.Y));
            _imageListBoxItem = imageListBoxControl1.GetItem(selectedIndex) as ImageListBoxItemData;
        }

        void ImageListBoxControl1MouseMove(object sender, MouseEventArgs e)
        {
            if (_imageListBoxItem == null || e.Button != MouseButtons.Left) return;

            DragItem = _imageListBoxItem;
            imageListBoxControl1.DoDragDrop(DragItem, DragDropEffects.Copy);
        }

        #endregion

        #region IDragManager Implementation

        public ImageListBoxItemData DragItem { get; set; }

        public void SetDragCursor(DragCursorTypeEnum cursorType)
        {
            if (cursorType == DragCursorTypeEnum.None)
                Cursor = Cursors.No;
            if (cursorType == DragCursorTypeEnum.Copy)
                Cursor = ImagesHelper.GetCursor("copy");
            if (cursorType == DragCursorTypeEnum.Move)
                Cursor = ImagesHelper.GetCursor("device");
            if (cursorType == DragCursorTypeEnum.Delete)
                Cursor = ImagesHelper.GetCursor("delete");
        }

        public void SetDefaultCursor()
        {
            Cursor = Cursors.Default;
        }

        #endregion

        void PictureEdit1Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawGrid(e.Graphics, e.ClipRectangle, _gridSize, Color.Gainsboro);

            var point = pictureEdit.ScreenPoint(new Point(0, 0));
            _picture.Draw(e.Graphics, pictureEdit.ZoomFactor, point.X, point.Y, true);
        }

        void PictureEdit1DragOver(object sender, DragEventArgs e)
        {
            if (DragItem == null) return;

            e.Effect = DragDropEffects.Copy;
            SetDragCursor(DragCursorTypeEnum.Move);
        }

        void PictureEdit1DragLeave(object sender, EventArgs e)
        {
            SetDefaultCursor();
        }

        void PictureEdit1DragDrop(object sender, DragEventArgs e)
        {
            if (DragItem != null)
            {
                var screenPoint = pictureEdit.PointToClient2(new Point(e.X, e.Y));
                var imagePoint = pictureEdit.ImagePoint(screenPoint);
                // Start drawing an image.
                _newDrawable = new DrawableDevice(imagePoint.X, imagePoint.Y)
                {
                    Text = DragItem.Name,
                    Picture = DragItem.Picture,
                    Tag = DragItem.Id
                };
                _picture.Add(_newDrawable);
                //pictureEdit1.MouseMove += NewDrawableMouseMove;
                //pictureEdit1.MouseUp += NewDrawableMouseUp;
                _newDrawable.Tag = DataHelper.AddDeviceToMap(_parent, DragItem.Id, imagePoint.X, imagePoint.Y, 0, 0, Session);
                _newDrawable = null;
                _mapsControl.IncrementData();
                UpdateListBox();
                pictureEdit.Invalidate(true);
            }
            DragItem = null;
            SetDefaultCursor();
        }

        void PictureEdit1GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (DragItem != null)
            {
                e.UseDefaultCursors = false;
            }
        }

        #region "New object event handlers"
        // Perform an action depending on the currently pushed tool.
        void PictureEdit1MouseDown(object sender, MouseEventArgs e)
        {
            // See which button was pressed.
            if (e.Button == MouseButtons.Right)
            {
                // Right button. See if we're drawing something.
                if (_newDrawable == null)
                {
                    // We are not drawing. Ignore this button.
                    if (_picture.SelectedDrawable is DrawableDevice)
                    {
                        radialMenu1.ShowPopup(pictureEdit.PointToScreen(e.Location));
                    }
                }
                else
                {
                    // We are drawing something. Cancel it.
                    _picture.Remove(_newDrawable);

                    _newDrawable = null;
                    pictureEdit.MouseMove -= NewDrawableMouseMove;
                    pictureEdit.MouseUp -= NewDrawableMouseUp;

                    // Redraw to erase the new object.
                    pictureEdit.Invalidate(true);
                }
            }
            else
            {
                if (e.Clicks == 2)
                {
                    ButtonClick(TagResources.UserEdit);
                }
                var screenPoint = new Point(e.X / _gridSize.Width * _gridSize.Width, e.Y / _gridSize.Height * _gridSize.Height);
                var imagePoint = pictureEdit.ImagePoint(screenPoint);
                _picture.SelectObjectAt(imagePoint.X, imagePoint.Y);
                if (_picture.SelectedDrawable != null)
                {
                    var newX1 = _picture.SelectedDrawable.X1 / _gridSize.Width * _gridSize.Width;
                    var newY1 = _picture.SelectedDrawable.Y1 / _gridSize.Height * _gridSize.Height;
                    if (_picture.SelectedDrawable.X1 != newX1 || _picture.SelectedDrawable.Y1 != newY1)
                    {
                        _picture.SelectedDrawable.MoveRelative(newX1 - _picture.SelectedDrawable.X1, newY1 - _picture.SelectedDrawable.Y1);
                        DataHelper.MoveMapToDevice(_picture.SelectedDrawable.Tag, _picture.SelectedDrawable.X1, _picture.SelectedDrawable.Y1, _picture.SelectedDrawable.X2, _picture.SelectedDrawable.Y2, Session);
                    }
                }
                //// Left button. See which tool is pushed.
                //switch (m_SelectedToolButton.ToolTipText)
                //{
                //    case "Pointer":
                //        // Select an object.
                //        _picture.SelectObjectAt(e.X, e.Y);
                //        break;
                //    case "Line":
                //        // Start drawing a line.
                //        _newDrawable = new DrawableLine(m_CurrentForeColor, m_CurrentLineWidth, e.X, e.Y, e.X, e.Y);
                //        _picture.Add(_newDrawable);
                //        pictureEdit1.MouseMove += NewDrawableMouseMove;
                //        pictureEdit1.MouseUp += NewDrawableMouseUp;
                //        break;
                //    case "Rectangle":
                //        // Start drawing a rectangle.
                //        _newDrawable = new DrawableRectangle(m_CurrentForeColor, m_CurrentFillColor, m_CurrentLineWidth, e.X, e.Y, e.X, e.Y);
                //        _picture.Add(_newDrawable);
                //        pictureEdit1.MouseMove += NewDrawableMouseMove;
                //        pictureEdit1.MouseUp += NewDrawableMouseUp;
                //        break;
                //    case "Ellipse":
                //        // Start drawing an ellipse.
                //        _newDrawable = new DrawableEllipse(m_CurrentForeColor, m_CurrentFillColor, m_CurrentLineWidth, e.X, e.Y, e.X, e.Y);
                //        _picture.Add(_newDrawable);
                //        pictureEdit1.MouseMove += NewDrawableMouseMove;
                //        pictureEdit1.MouseUp += NewDrawableMouseUp;
                //        break;
                //    case "Star":
                //        // Start drawing a star.
                //        _newDrawable = new DrawableStar(m_CurrentForeColor, m_CurrentFillColor, m_CurrentLineWidth, e.X, e.Y, e.X, e.Y);
                //        _picture.Add(_newDrawable);
                //        pictureEdit1.MouseMove += NewDrawableMouseMove;
                //        pictureEdit1.MouseUp += NewDrawableMouseUp;
                //        break;
                //    case "Image":
                //        // Start drawing an image.
                //        _newDrawable = new DrawableImage(e.X, e.Y, e.X, e.Y);
                //        _picture.Add(_newDrawable);
                //        pictureEdit1.MouseMove += NewDrawableMouseMove;
                //        pictureEdit1.MouseUp += NewDrawableMouseUp;
                //        break;
                //}

                // Redraw.
                pictureEdit.Invalidate();
            }
        }

        // If we have an object selected, move it.
        void PictureEdit1MouseMove(object sender, MouseEventArgs e)
        {
            // Only move if the left button is down.
            if (e.Button == MouseButtons.Left)
            {
                // Move it.
                var screenPoint = new Point(e.X / _gridSize.Width * _gridSize.Width, e.Y / _gridSize.Height * _gridSize.Height);
                var imagePoint = pictureEdit.ImagePoint(screenPoint);
                Debug.WriteLine("ImagePoint: {0}", imagePoint);
                _picture.MoveSelectedDrawableToMouse(imagePoint.X, imagePoint.Y, _gridSize);
                var drawableDevice = _picture.SelectedDrawable as DrawableDevice;
                if (drawableDevice != null)
                {
                    DataHelper.MoveMapToDevice(drawableDevice.Tag, drawableDevice.X1, drawableDevice.Y1, drawableDevice.X2, drawableDevice.Y2, Session);
                }

                // Redraw to show the new position.
                ((Control)sender).Invalidate();
            }
        }

        // On mouse move, continue drawing.
        void NewDrawableMouseMove(object sender, MouseEventArgs e)
        {
            // Update the new line's coordinates.
            var imagePoint = pictureEdit.ImagePoint(new Point(e.X, e.Y));
            _newDrawable.NewPoint(imagePoint.X, imagePoint.Y);

            // Redraw to show the new line.
            pictureEdit.Invalidate();
        }

        // On mouse up, finish drawing the new object.
        void NewDrawableMouseUp(object sender, MouseEventArgs e)
        {
            // No longer watch for MouseMove or MouseUp.
            pictureEdit.MouseMove -= NewDrawableMouseMove;
            pictureEdit.MouseUp -= NewDrawableMouseUp;

            // See if the new object is empty (e.g. a zero-length line).
            if (_newDrawable.IsEmpty())
            {
                // Discard this object.
                _picture.Remove(_newDrawable);
            }
            else
            {
                // If it's a new image, get the image file.
                if ((_newDrawable) is DrawableImage)
                {
                    if (ofdImage.ShowDialog() == DialogResult.OK)
                    {
                        // Discard this object.
                        var drawableImage = (DrawableImage)_newDrawable;
                        drawableImage.Picture = new Bitmap(ofdImage.FileName);
                    }
                    else
                    {
                        // Discard this object.
                        _picture.Remove(_newDrawable);
                    }
                }
            }

            // We're no longer working with the new object.
            _newDrawable = null;

            // Redraw.
            pictureEdit.Invalidate();
        }
        #endregion

        #region ISupportZoom Implementation
        public int ZoomLevel
        {
            get { return (int)(pictureEdit.ZoomFactor * 100); }
            set
            {
                if (ZoomLevel == value) return;
                pictureEdit.ZoomFactor = value / 100f;
                var handler = ZoomChanged;
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
            }
        }
        public bool ZoomEnabled { get { return true; } }

        public event EventHandler ZoomChanged;

        #endregion

        #region IDataPaneModule Implementation

        DataPaneStateEnum _dataPaneState;
        public DataPaneStateEnum DataPaneState
        {
            get { return _dataPaneState; }
            set
            {
                if (_dataPaneState == value) return;
                _dataPaneState = value;
                UpdateDataPaneState();
            }
        }

        public int SplitterPosition
        {
            get { return splitContainerControl.SplitterPosition; }
            set
            {
                if (value <= 0) return;
                splitContainerControl.SplitterPosition = value;
            }
        }
        public bool DataPaneEnabled { get { return true; } }
        public event EventHandler DataPaneChanged;

        void UpdateDataPaneState()
        {
            switch (_dataPaneState)
            {
                case DataPaneStateEnum.Right:
                    splitContainerControl.PanelVisibility = SplitPanelVisibility.Both;
                    splitContainerControl.Horizontal = true;
                    break;
                case DataPaneStateEnum.Bottom:
                    splitContainerControl.PanelVisibility = SplitPanelVisibility.Both;
                    splitContainerControl.Horizontal = false;
                    break;
                case DataPaneStateEnum.Off:
                    splitContainerControl.PanelVisibility = SplitPanelVisibility.Panel1;
                    break;
            }
        }

        #endregion

    }

}
