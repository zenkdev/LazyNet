using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.Utils.Design;
using DevExpress.Xpo;

namespace Dekart.LazyNet.Helpers
{
    class XpoSettingsProvider : SettingsProvider
    {
        UnitOfWork _session;

        public override string ApplicationName
        {
            get { return AssemblyVersion.AssemblyProduct; }
            set { }
        }

        public override void Initialize(string name, NameValueCollection col)
        {
            _session = new UnitOfWork();
            base.Initialize(ApplicationName, col);
        }

        // SetPropertyValue is invoked when ApplicationSettingsBase.Save is called
        // ASB makes sure to pass each provider only the values marked for that provider -
        // though in this sample, since the entire settings class was marked with a SettingsProvider
        // attribute, all settings in that class map to this provider
        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection propvals)
        {
            // Iterate through the settings to be stored
            // Only IsDirty=true properties should be included in propvals
            foreach (SettingsPropertyValue propval in propvals)
            {
                // NOTE: this provider allows setting to both user- and application-scoped
                // settings. The default provider for ApplicationSettingsBase - 
                // LocalFileSettingsProvider - is read-only for application-scoped setting. This 
                // is an example of a policy that a provider may need to enforce for implementation,
                // security or other reasons.
                GetSetting(propval.Property, propval.Name).Value = (string)propval.SerializedValue;
                Save();
            }
        }

        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection props)
        {

            // Create new collection of values
            var values = new SettingsPropertyValueCollection();

            // Iterate through the settings to be retrieved
            foreach (SettingsProperty setting in props)
            {
                var value = new SettingsPropertyValue(setting)
                {
                    IsDirty = false
                };
                if (!DesignTimeTools.IsDesignMode)
                    value.SerializedValue = GetSetting(setting, setting.Name).Value;
                values.Add(value);
            }
            return values;
        }

        // Helper method: fetches correct registry subkey.
        // HKLM is used for settings marked as application-scoped.
        // HKLU is used for settings marked as user-scoped.
        WinFormSetting GetSetting(SettingsProperty prop, string name)
        {
            var userScoped = IsUserScoped(prop);
            var userCriteria = userScoped ? CriteriaOperator.Parse("CreatedBy=?", DataHelper.CurrentUserId) : CriteriaOperator.Parse("IsNull(CreatedBy)");

            var wfSetting = _session.FindObject<WinFormSetting>(CriteriaOperator.And(CriteriaOperator.Parse("Name=?", name), userCriteria));
            if (wfSetting == null)
            {
                wfSetting = new WinFormSetting(_session) { Name = name };
                if (!userScoped)
                    wfSetting.CreatedBy = null;
                Save();
            }

            return wfSetting;
        }

        // Helper method: walks the "attribute bag" for a given property
        // to determine if it is user-scoped or not.
        // Note that this provider does not enforce other rules, such as 
        //   - unknown attributes
        //   - improper attribute combinations (e.g. both user and app - this implementation
        //     would say true for user-scoped regardless of existence of app-scoped)
        bool IsUserScoped(SettingsProperty prop)
        {
            return (from DictionaryEntry d in prop.Attributes select (Attribute)d.Value).OfType<UserScopedSettingAttribute>().Any();
        }

        public void Save()
        {
            SessionHelper.CommitSession(_session, new ExceptionProcesser(null));
        }
    }
}