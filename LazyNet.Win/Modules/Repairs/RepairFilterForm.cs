namespace Dekart.LazyNet.Win.Modules
{
    class RepairFilterForm : FilterFormBase
    {
        public RepairFilterForm(FilterItemBase filterItem)
            : base(filterItem)
        {
        }

        protected override void BuildFilterColumns()
        {
            var builder = new FilterColumnCollectionBuilder<Repair>(filterControl.FilterColumns);
            builder
                .AddDateTimeColumn(e => e.CreatedOn, "Дата ремонта")
                .AddLookupColumn(e => e.RepairType)
                .AddColumn(e => e.Device)
                .AddColumn(e => e.Customer)
                .AddColumn(e => e.Amount);
        }

    }
}
