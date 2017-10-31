using DevExpress.Data.Filtering;

namespace Dekart.LazyNet
{
    public class FilterItem : FilterItemBase
    {
        public static FilterItem Create(string name, CriteriaOperator filterCriteria)
        {
            return new FilterItem(name, filterCriteria);
        }
        protected FilterItem(string name, CriteriaOperator filterCriteria)
        {
            // ReSharper disable DoNotCallOverridableMethodsInConstructor
            Name = name;
            FilterCriteria = filterCriteria;
            // ReSharper restore DoNotCallOverridableMethodsInConstructor
        }
    }
    public abstract class FilterItemBase
    {
        public virtual string Name { get; set; }
        public virtual CriteriaOperator FilterCriteria { get; set; }
    }
}
