using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DevExpress.Data.Filtering;

namespace Dekart.LazyNet
{
    public class FilterControlBase : ControlBase
    {
        readonly IFilterTreeSettings _settings;
        FilterItemBase _selectedItem;

        public FilterControlBase() { }
        public FilterControlBase(IFilterTreeSettings settings)
        {
            _settings = settings;
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            Init();
        }
        static FilterControlBase()
        {
            var enums = typeof(UserStateEnum).Assembly.GetTypes().Where(t => t.IsEnum);
            foreach (Type e in enums)
                EnumProcessingHelper.RegisterEnum(e);
        }

        public ObservableCollection<FilterItemBase> StaticFilters { get; protected set; }
        public ObservableCollection<FilterItemBase> CustomFilters { get; protected set; }

        public FilterItemBase SelectedItem
        {
            get { return _selectedItem; }
            protected set
            {
                if (_selectedItem == value) return;
                _selectedItem = value;
                OnSelectedItemChanged();
            }
        }

        protected virtual void OnSelectedItemChanged()
        {
        }

        public virtual void Init()
        {
            StaticFilters = CreateFilterItems(_settings.StaticFilters);
            CustomFilters = CreateFilterItems(_settings.CustomFilters);
            SelectedItem = StaticFilters.FirstOrDefault();
        }

        public IList Get—hildren(object dataItem)
        {
            if (dataItem == this)
            {
                return new List<object> { StaticFilters, CustomFilters };
            }
            // ReSharper disable once CanBeReplacedWithTryCastAndCheckForNull
            if (dataItem is ObservableCollection<FilterItemBase>)
                return (IList)dataItem;
            return null;
        }

        public virtual void New() { }

        public virtual void Modify(FilterItem item) { }

        public virtual void Delete(FilterItem item) { }

        protected ObservableCollection<FilterItemBase> CreateFilterItems(IEnumerable<FilterInfo> filters)
        {
            if (filters == null)
                return new ObservableCollection<FilterItemBase>();
            return new ObservableCollection<FilterItemBase>(filters.Select(x => CreateFilterItem(x.Name, CriteriaOperator.Parse(x.FilterCriteria), x.ImageUri)));
        }

        protected FilterItemBase CreateFilterItem(string name, CriteriaOperator filterCriteria, string imageUri)
        {
            return FilterItem.Create(name, filterCriteria);
        }

        protected void AddNewCustomFilter(FilterItemBase filterItem)
        {
            var existing = CustomFilters.FirstOrDefault(fi => fi.Name == filterItem.Name);
            if (existing != null)
            {
                CustomFilters.Remove(existing);
            }
            CustomFilters.Add(filterItem);
            SaveCustomFilters();
        }

        protected void DeleteCustomFilter(FilterItemBase filterItem)
        {
            CustomFilters.Remove(filterItem);
            SaveCustomFilters();
        }

        protected void SaveCustomFilters()
        {
            _settings.CustomFilters = SaveToSettings(CustomFilters);
            _settings.Settings.Save();
        }
        
        FilterInfoList SaveToSettings(ObservableCollection<FilterItemBase> filters)
        {
            return new FilterInfoList(filters.Select(fi => new FilterInfo { Name = fi.Name, FilterCriteria = CriteriaOperator.ToString(fi.FilterCriteria) }));
        }
    }
}