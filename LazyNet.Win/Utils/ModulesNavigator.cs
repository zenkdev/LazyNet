using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;

namespace Dekart.LazyNet.Win
{
    public class ModulesNavigator
    {
        readonly MainFormBase _parent;
        readonly PanelControl _panel;

        public ModulesNavigator(MainFormBase parent, PanelControl panel)
        {
            _parent = parent;
            _panel = panel;
        }

        public event EventHandler CurrentModuleChanged;

        public void ChangeModule(NavBarGroup group, object moduleData)
        {
            bool allowSetVisiblePage = true;
            var groupObject = group.Tag as NavBarGroupTagObject;
            if (groupObject == null) return;
            List<RibbonPage> deferredPagesToShow = new List<RibbonPage>();
            foreach (RibbonPage page in _parent.Ribbon.Pages)
            {
                if (!string.IsNullOrEmpty(string.Format("{0}", page.Tag)))
                {
                    bool isPageVisible = groupObject.Name.Equals(page.Tag);
                    if (isPageVisible != page.Visible && isPageVisible)
                        deferredPagesToShow.Add(page);
                    else
                        page.Visible = isPageVisible;
                    if (isPageVisible)
                        page.Text = ConstStrings.HomePageText;
                }
                if (page.Visible && allowSetVisiblePage)
                {
                    _parent.Ribbon.SelectedPage = page;
                    allowSetVisiblePage = false;
                }
            }
            var firstShow = groupObject.Module == null;
            if (firstShow)
            {
                var constructorInfoObj = groupObject.ModuleType.GetConstructor(Type.EmptyTypes);
                if (constructorInfoObj != null)
                {
                    groupObject.Module = constructorInfoObj.Invoke(null) as ModuleBase;
                    if (groupObject.Module != null)
                    {
                        groupObject.Module.InitModule(moduleData, new UnitOfWork());
                        groupObject.Module.SetParent(_parent);
                    }
                }
            }

            foreach (RibbonPage page in deferredPagesToShow)
            {
                page.Visible = true;
            }
            foreach (RibbonPage page in _parent.Ribbon.Pages)
            {
                if (page.Visible)
                {
                    _parent.Ribbon.SelectedPage = page;
                    break;
                }
            }
            if (groupObject.Module != null)
            {
                if (_panel.Controls.Count > 0)
                {
                    var currentModule = _panel.Controls[0] as ModuleBase;
                    if (currentModule != null)
                        currentModule.HideModule();
                }
                _panel.Controls.Clear();
                _panel.Controls.Add(groupObject.Module);
                groupObject.Module.Dock = DockStyle.Fill;
                groupObject.Module.ShowModule(firstShow);
            }
            var handler = CurrentModuleChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public ModuleBase CurrentModule
        {
            get
            {
                if (_panel.Controls.Count == 0) return null;
                return _panel.Controls[0] as ModuleBase;
            }
        }
        public string GetModuleName()
        {
            if (string.IsNullOrEmpty(CurrentModule.PartName)) return CurrentModule.ModuleName;
            return string.Format("<b>{0}</b>", CurrentModule.ModuleName);
        }
        public string GetModulePartName()
        {
            if (string.IsNullOrEmpty(CurrentModule.PartName)) return null;
            return string.Format(" - {0}", CurrentModule.PartName);
        }
    }

    public class NavBarGroupTagObject
    {
        readonly string _name;
        readonly Type _moduleType;

        public NavBarGroupTagObject(string name, Type moduleType)
        {
            _name = name;
            _moduleType = moduleType;
            Module = null;
        }
        public string Name { get { return _name; } }
        public Type ModuleType { get { return _moduleType; } }
        public ModuleBase Module { get; set; }
    }
}
