using System;
using DevExpress.XtraBars;

namespace Dekart.LazyNet.Win
{
    class DataPaneManager
    {
        readonly ModulesNavigator _modulesNavigator;
        readonly BarSubItem _bsiDataPane;
        DataPaneStateEnum _dataPaneState;
        public DataPaneManager(ModulesNavigator modulesNavigator, BarSubItem bsItem)
        {
            _modulesNavigator = modulesNavigator;
            modulesNavigator.CurrentModuleChanged += modulesNavigator_CurrentModuleChanged;
            _bsiDataPane = bsItem;
            _bsiDataPane.ItemLinks[0].Item.ItemClick += OnDataPaneItemItemClick;
            _bsiDataPane.ItemLinks[1].Item.ItemClick += OnDataPaneItemItemClick;
            _bsiDataPane.ItemLinks[2].Item.ItemClick += OnDataPaneItemItemClick;
        }

        IDataPaneModule _dataPaneModule;
        void modulesNavigator_CurrentModuleChanged(object sender, EventArgs e)
        {
            if (_dataPaneModule != null)
                _dataPaneModule.DataPaneChanged -= dataPaneModule_DataPaneChanged;
            UpdateStateFromModule();
            _dataPaneModule = _modulesNavigator.CurrentModule as IDataPaneModule;
            if (_dataPaneModule != null)
                _dataPaneModule.DataPaneChanged += dataPaneModule_DataPaneChanged;
        }
        void dataPaneModule_DataPaneChanged(object sender, EventArgs e)
        {
            UpdateStateFromModule();
        }

        public DataPaneStateEnum DataPaneState
        {
            get { return _dataPaneState; }
            set
            {
                _dataPaneState = value;
                ((BarCheckItem)_bsiDataPane.ItemLinks[0].Item).Checked = _dataPaneState== DataPaneStateEnum.Right;
                ((BarCheckItem)_bsiDataPane.ItemLinks[1].Item).Checked = _dataPaneState == DataPaneStateEnum.Bottom;
                ((BarCheckItem)_bsiDataPane.ItemLinks[2].Item).Checked = _dataPaneState == DataPaneStateEnum.Off;
                var dataPaneModule = _modulesNavigator.CurrentModule as IDataPaneModule;
                if (dataPaneModule != null)
                    dataPaneModule.DataPaneState = DataPaneState;
            }
        }

        void OnDataPaneItemItemClick(object sender, ItemClickEventArgs e)
        {
            var val = _bsiDataPane.ItemLinks.IndexOf(e.Link);
            DataPaneState = (DataPaneStateEnum)val;
        }
        void UpdateStateFromModule()
        {
            var dataPaneModule = _modulesNavigator.CurrentModule as IDataPaneModule;
            if (dataPaneModule != null)
                DataPaneState = dataPaneModule.DataPaneState;
            _bsiDataPane.Enabled = (dataPaneModule != null && dataPaneModule.DataPaneEnabled);
        }
    }
    
}
