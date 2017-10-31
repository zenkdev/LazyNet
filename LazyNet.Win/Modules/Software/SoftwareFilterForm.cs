namespace Dekart.LazyNet.Win.Modules
{
    class SoftwareFilterForm : FilterFormBase
    {
        public SoftwareFilterForm(FilterItemBase filterItem)
            : base(filterItem)
        {
        }

        protected override void BuildFilterColumns()
        {
            var builder = new FilterColumnCollectionBuilder<SoftwareObject>(filterControl.FilterColumns);
            builder
                .AddColumn(e => e.SKU)
                .AddColumn(e => e.Name)
                .AddColumn(e => e.Company)
                .AddDateTimeColumn(e => e.BuyedOn)
                .AddDateTimeColumn(e => e.ExpiredOn)
                //.AddLookupColumn(e => e.ShipMethod)
                .AddColumn(e => e.Used)
                .AddColumn(e => e.Available);
        }

    }
}
