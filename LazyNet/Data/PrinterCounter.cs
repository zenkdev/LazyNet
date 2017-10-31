using System;
using DevExpress.Xpo;

namespace Dekart.LazyNet
{
    public class PrinterCounter : XPBaseObject
    {
        public PrinterCounter() : base(Session.DefaultSession) { }
        public PrinterCounter(Session session) : base(session) { }

        [Key(true)]
        public int Id
        {
            get { return GetPropertyValue<int>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        public DateTime CreatedOn
        {
            get { return GetPropertyValue<DateTime>("CreatedOn"); }
            set { SetPropertyValue("CreatedOn", value); }
        }

        public Device Device
        {
            get { return GetPropertyValue<Device>("Device"); }
            set { SetPropertyValue("Device", value); }
        }

        [DbType("MONEY")]
        public decimal DayCount
        {
            get { return GetPropertyValue<decimal>("DayCount"); }
            set { SetPropertyValue("DayCount", value); }
        }

        [DbType("MONEY")]
        public decimal TotalCount
        {
            get { return GetPropertyValue<decimal>("TotalCount"); }
            set { SetPropertyValue("TotalCount", value); }
        }
    }
}
