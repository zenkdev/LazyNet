namespace Dekart.LazyNet.Win.Modules
{
    class UserFilterForm : FilterFormBase
    {
        public UserFilterForm(FilterItemBase filterItem) : base(filterItem)
        {
        }

        protected override void BuildFilterColumns()
        {
            var builder = new FilterColumnCollectionBuilder<User>(filterControl.FilterColumns);
            builder
                .AddColumn(e => e.Department)
                .AddColumn(e => e.Title)
                .AddLookupColumn(e => e.UserState)
                //.AddDateTimeColumn(e => e.OrderDate)
                .AddColumn(e => e.Email);
        }

    }
}
