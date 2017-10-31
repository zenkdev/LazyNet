using System;
using System.Linq;
using DevExpress.Xpo;
using DevExpress.XtraReports.UI;

namespace Dekart.LazyNet.Win.QuickReports
{
    public partial class PrintingCosts : XtraReport
    {
        public PrintingCosts()
        {
            InitializeComponent();

            Name = "Печать расход";
        }

        #region Overrides of XtraReportBase

        #endregion

        private string TryGetTotalCount(Device device)
        {
            var printerCounters = new XPQuery<PrinterCounter>(XpoDefault.Session);
            var query = (from printerCounter in printerCounters
                         where printerCounter.Device.Id == device.Id
                         orderby printerCounter.CreatedOn descending
                         select printerCounter
                );
            var pc = query.FirstOrDefault();

            return pc == null || pc.TotalCount == 0 ? "" : pc.TotalCount.ToString("N0");
        }

        private string TryGetDayCount(Device device)
        {
            var dateTime = DateTime.Today.AddMonths(-1);
            var printerCounters = new XPQuery<PrinterCounter>(XpoDefault.Session);
            var query = (from printerCounter in printerCounters
                         where printerCounter.Device.Id == device.Id && printerCounter.CreatedOn > dateTime
                         select printerCounter
                );
            decimal dayCount = 0;
            if (query.Any())
            {
                var sum = query.Sum(x => x.DayCount);
                var max = query.Max(x => x.CreatedOn.Date);
                var min = query.Min(x => x.CreatedOn.Date);
                var int32 = Convert.ToInt32(max.Subtract(min).TotalDays);
                dayCount = int32 != 0 ? sum / int32 : sum;
            }

            return dayCount == 0 ? "" : dayCount.ToString("N0");
        }

        private void КоличествоВсего_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var device = GetCurrentRow() as Device;
            if (device == null)
            {
                e.Cancel = true;
                return;
            }

            var cell = (XRTableCell)sender;
            cell.Text = TryGetTotalCount(device);
        }

        private void КоличествоДень_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var device = GetCurrentRow() as Device;
            if (device == null)
            {
                e.Cancel = true;
                return;
            }

            var cell = (XRTableCell)sender;
            cell.Text = TryGetDayCount(device);
        }
    }
}
