using System;
using Dekart.LazyNet.Properties;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Repository;

namespace Dekart.LazyNet.Helpers
{
    public static class EditorsHelpers
    {
        public static RepositoryItemImageComboBox CreateEnumImageComboBox<TEnum>(RepositoryItemImageComboBox edit = null, RepositoryItemCollection collection = null, Converter<TEnum, string> displayTextConverter = null)
        {
            return CreatEdit(edit, collection, e => e.Items.AddEnum(displayTextConverter));
        }
        public static TEdit CreatEdit<TEdit>(TEdit edit = null, RepositoryItemCollection collection = null, Action<TEdit> initialize = null)
            where TEdit : RepositoryItem, new()
        {
            edit = edit ?? new TEdit();
            if (collection != null) collection.Add(edit);
            if (initialize != null)
                initialize(edit);
            return edit;
        }
        public static RepositoryItemDateEdit CreatDateEdit(RepositoryItemDateEdit edit = null, RepositoryItemCollection collection = null)
        {
            return CreatEdit(edit, collection);
        }

        public static void InitDeviceTypeComboBox(RepositoryItemImageComboBox edit)
        {
            edit.Items.Clear();
            foreach (DeviceTypeEnum type in Enum.GetValues(typeof(DeviceTypeEnum)))
                edit.Items.Add(new ImageComboBoxItem(StringsHelper.EnumDisplayText(type), type, (int)type));
            edit.SmallImages = ImagesHelper.DeviceImages;
            edit.LargeImages = ImagesHelper.DeviceLargeImages;
        }

        public static void InitGenderComboBox(RepositoryItemImageComboBox edit)
        {
            var iCollection = new ImageCollection();
            iCollection.AddImage(Resources.Mr);
            iCollection.AddImage(Resources.Ms);
            edit.Items.Clear();
            edit.Items.Add(new ImageComboBoxItem(ConstStrings.Male, UserGender.Male, 0));
            edit.Items.Add(new ImageComboBoxItem(ConstStrings.Female, UserGender.Female, 1));
            edit.SmallImages = iCollection;
        }

        public static void AddLocalizedEnum<T>(this ImageComboBoxItemCollection items)
        {
            items.AddEnum<T>(v => StringsHelper.EnumDisplayText(v));
        }

        private static ConditionValidationRule _ruleIsNotBlank;

        public static ConditionValidationRule RuleIsNotBlank
        {
            get
            {
                return _ruleIsNotBlank ?? (_ruleIsNotBlank = new ConditionValidationRule
                {
                    ConditionOperator = ConditionOperator.IsNotBlank,
                    ErrorText = ConstStrings.RuleIsNotBlankWarning,
                    ErrorType = ErrorType.Critical
                });
            }
        }
    }
}
