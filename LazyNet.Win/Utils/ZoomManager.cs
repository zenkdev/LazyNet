using System;
using Dekart.LazyNet.Helpers;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;

namespace Dekart.LazyNet.Win
{
    public interface ISupportZoom
    {
        int ZoomLevel { get; set; }
        bool ZoomEnabled { get; }
        event EventHandler ZoomChanged;
    }
    class ZoomManager
    {
        ZoomTrackBarControl _zoomControl;
        int _zoomLevel;
        readonly int[] _zoomValues = { 100, 115, 130, 150, 200, 250, 300, 350, 400, 500 };
        readonly BarEditItem _beiZoom;
        readonly ModulesNavigator _modulesNavigator;
        public ZoomManager(ModulesNavigator modulesNavigator, BarEditItem beItem)
        {
            _modulesNavigator = modulesNavigator;
            modulesNavigator.CurrentModuleChanged += modulesNavigator_CurrentModuleChanged;
            _beiZoom = beItem;
            _beiZoom.HiddenEditor += beiZoom_HiddenEditor;
            _beiZoom.ShownEditor += beiZoom_ShownEditor;
        }

        ISupportZoom _zoomModule;
        void modulesNavigator_CurrentModuleChanged(object sender, EventArgs e)
        {
            if (_zoomModule != null)
                _zoomModule.ZoomChanged -= zoomModule_ZoomChanged;
            UpdateZoomLevelFromModule();
            _zoomModule = _modulesNavigator.CurrentModule as ISupportZoom;
            if (_zoomModule != null)
                _zoomModule.ZoomChanged += zoomModule_ZoomChanged;
        }
        void zoomModule_ZoomChanged(object sender, EventArgs e)
        {
            UpdateZoomLevelFromModule();
        }
        ZoomTrackBarControl ZoomControl { get { return _zoomControl; } }
        public int ZoomLevel
        {
            get { return _zoomLevel; }
            set
            {
                _zoomLevel = value;
                _beiZoom.Caption = string.Format(" {0}%", ZoomLevel);
                var index = Array.IndexOf(_zoomValues, ZoomLevel);
                if (index == -1)
                    _beiZoom.EditValue = ZoomLevel / 10;
                else _beiZoom.EditValue = 10 + index;
                var zoomModule = _modulesNavigator.CurrentModule as ISupportZoom;
                if (zoomModule != null)
                    zoomModule.ZoomLevel = ZoomLevel;
            }
        }
        void beiZoom_ShownEditor(object sender, ItemClickEventArgs e)
        {
            _zoomControl = _beiZoom.Manager.ActiveEditor as ZoomTrackBarControl;
            if (ZoomControl != null)
            {
                ZoomControl.ValueChanged += OnZoomTackValueChanged;
                OnZoomTackValueChanged(ZoomControl, EventArgs.Empty);
            }
        }
        void beiZoom_HiddenEditor(object sender, ItemClickEventArgs e)
        {
            ZoomControl.ValueChanged -= OnZoomTackValueChanged;
            _zoomControl = null;
        }
        void OnZoomTackValueChanged(object sender, EventArgs e)
        {
            var val = ZoomControl.Value * 10;
            if (ZoomControl.Value > 10) val = _zoomValues[ZoomControl.Value - 10];
            ZoomLevel = val;
        }
        void UpdateZoomLevelFromModule()
        {
            ISupportZoom supportZoom = _modulesNavigator.CurrentModule as ISupportZoom;
            if (supportZoom != null)
                ZoomLevel = supportZoom.ZoomLevel;
            _beiZoom.Visibility = (supportZoom != null && supportZoom.ZoomEnabled) ? BarItemVisibility.Always : BarItemVisibility.Never;
        }
    }
}
