using System;
using System.ComponentModel;
using System.Configuration;
using System.Linq.Expressions;

namespace Dekart.LazyNet
{
    public interface IFilterTreeSettings
    {
        FilterInfoList StaticFilters { get; set; }
        FilterInfoList CustomFilters { get; set; }
        ApplicationSettingsBase Settings { get; }
    }
    
    public class FilterTreeSettings<TSettings> : IFilterTreeSettings where TSettings : ApplicationSettingsBase
    {
        readonly TSettings _settings;
        readonly PropertyDescriptor _customFiltersProperty;
        readonly PropertyDescriptor _staticFiltersProperty;

        public FilterTreeSettings(TSettings settings, Expression<Func<TSettings, FilterInfoList>> getStaticFiltersExpression, Expression<Func<TSettings, FilterInfoList>> getCustomFiltersExpression)
        {
            _settings = settings;
            _staticFiltersProperty = GetProperty(getStaticFiltersExpression);
            _customFiltersProperty = GetProperty(getCustomFiltersExpression);
        }
        FilterInfoList IFilterTreeSettings.CustomFilters
        {
            get { return GetFilters(_customFiltersProperty); }
            set { SetFilters(_customFiltersProperty, value); }
        }
        FilterInfoList IFilterTreeSettings.StaticFilters
        {
            get { return GetFilters(_staticFiltersProperty); }
            set { SetFilters(_staticFiltersProperty, value); }
        }

        ApplicationSettingsBase IFilterTreeSettings.Settings { get { return _settings; } }

        PropertyDescriptor GetProperty(Expression<Func<TSettings, FilterInfoList>> expression)
        {
            if (expression != null)
                return TypeDescriptor.GetProperties(_settings)[GetPropertyName(expression)];
            return null;
        }
        FilterInfoList GetFilters(PropertyDescriptor property)
        {
            return property != null ? (FilterInfoList)property.GetValue(_settings) : null;
        }
        void SetFilters(PropertyDescriptor property, FilterInfoList value)
        {
            if (property != null)
                property.SetValue(_settings, value);
        }
        static string GetPropertyName(Expression<Func<TSettings, FilterInfoList>> expression)
        {
            MemberExpression memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                throw new ArgumentException("expression");
            }
            return memberExpression.Member.Name;
        }
    }
}