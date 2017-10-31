using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraLayout.Utils;
using Microsoft.Win32.TaskScheduler;

namespace Dekart.LazyNet.SQLBackup2Remote.Forms
{
    public partial class AddScheduleForm : AddFormBase
    {
        public AddScheduleForm(Form parent, ScheduleData editObject, IDXMenuManager manager)
            : base(parent, editObject, manager)
        {
            InitializeComponent();
        }

        protected override bool TestButtonVisible => false;

        /// <summary>Schedule</summary>
        public ScheduleData Schedule => EditObject as ScheduleData;

        protected override void CreateNewObject()
        {
            base.CreateNewObject();
            EditObject = new ScheduleData { Recurrence = 0, StartBoundary = DateTime.Now, RepeatEvery = 1, DaysOfWeek = DaysOfTheWeek.AllDays };
        }

        protected override void InitData()
        {
            ceDaily.Checked = Schedule.Recurrence == 0;
            ceWeekly.Checked = Schedule.Recurrence == 1;
            ceMonthly.Checked = Schedule.Recurrence > 1;
            if (ceDaily.Checked)
            {
                seRepeatDays.Value = Schedule.RepeatEvery;
            }
            if (ceWeekly.Checked)
            {
                seRepeatWeeks.Value = Schedule.RepeatEvery;
                ceMon.Checked = (Schedule.DaysOfWeek & DaysOfTheWeek.Monday) != 0;
                ceTue.Checked = (Schedule.DaysOfWeek & DaysOfTheWeek.Tuesday) != 0;
                ceWed.Checked = (Schedule.DaysOfWeek & DaysOfTheWeek.Wednesday) != 0;
                ceThu.Checked = (Schedule.DaysOfWeek & DaysOfTheWeek.Thursday) != 0;
                ceFri.Checked = (Schedule.DaysOfWeek & DaysOfTheWeek.Friday) != 0;
                ceSat.Checked = (Schedule.DaysOfWeek & DaysOfTheWeek.Saturday) != 0;
                ceSun.Checked = (Schedule.DaysOfWeek & DaysOfTheWeek.Sunday) != 0;
            }
            if (ceMonthly.Checked)
            {
                var months = cbMonthsOfYear.Properties.GetItems();
                months[0].CheckState = (Schedule.MonthsOfYear & MonthsOfTheYear.January) != 0 ? CheckState.Checked : CheckState.Unchecked;
                months[1].CheckState = (Schedule.MonthsOfYear & MonthsOfTheYear.February) != 0 ? CheckState.Checked : CheckState.Unchecked;
                months[2].CheckState = (Schedule.MonthsOfYear & MonthsOfTheYear.March) != 0 ? CheckState.Checked : CheckState.Unchecked;
                months[3].CheckState = (Schedule.MonthsOfYear & MonthsOfTheYear.April) != 0 ? CheckState.Checked : CheckState.Unchecked;
                months[4].CheckState = (Schedule.MonthsOfYear & MonthsOfTheYear.May) != 0 ? CheckState.Checked : CheckState.Unchecked;
                months[5].CheckState = (Schedule.MonthsOfYear & MonthsOfTheYear.June) != 0 ? CheckState.Checked : CheckState.Unchecked;
                months[6].CheckState = (Schedule.MonthsOfYear & MonthsOfTheYear.July) != 0 ? CheckState.Checked : CheckState.Unchecked;
                months[7].CheckState = (Schedule.MonthsOfYear & MonthsOfTheYear.August) != 0 ? CheckState.Checked : CheckState.Unchecked;
                months[8].CheckState = (Schedule.MonthsOfYear & MonthsOfTheYear.September) != 0 ? CheckState.Checked : CheckState.Unchecked;
                months[9].CheckState = (Schedule.MonthsOfYear & MonthsOfTheYear.October) != 0 ? CheckState.Checked : CheckState.Unchecked;
                months[10].CheckState = (Schedule.MonthsOfYear & MonthsOfTheYear.November) != 0 ? CheckState.Checked : CheckState.Unchecked;
                months[11].CheckState = (Schedule.MonthsOfYear & MonthsOfTheYear.December) != 0 ? CheckState.Checked : CheckState.Unchecked;

                var days = cbDayOfMonth.Properties.GetItems();
                for (var n = 0; n < 30; n++)
                {
                    days[n].CheckState = Schedule.DaysOfMonth != null && Schedule.DaysOfMonth.Any(i => i == n + 1) ? CheckState.Checked : CheckState.Unchecked;
                }
                days[31].CheckState = Schedule.RunOnLastDayOfMonth ? CheckState.Checked : CheckState.Unchecked;
            }

            deStartBoundary.DateTime = Schedule.StartBoundary.Date;
            teStartBoundary.Time = Schedule.StartBoundary;

            tcgMain.ShowTabHeader = DefaultBoolean.False;
        }

        protected override void SaveData()
        {
            if (ceDaily.Checked)
            {
                Schedule.Recurrence = 0;
                Schedule.RepeatEvery = Convert.ToInt16(seRepeatDays.Value);
            }
            else if (ceWeekly.Checked)
            {
                Schedule.Recurrence = 1;
                Schedule.RepeatEvery = Convert.ToInt16(seRepeatWeeks.Value);

                DaysOfTheWeek daysOfWeek = 0;
                if (ceMon.Checked) daysOfWeek |= DaysOfTheWeek.Monday;
                if (ceTue.Checked) daysOfWeek |= DaysOfTheWeek.Tuesday;
                if (ceWed.Checked) daysOfWeek |= DaysOfTheWeek.Wednesday;
                if (ceThu.Checked) daysOfWeek |= DaysOfTheWeek.Thursday;
                if (ceFri.Checked) daysOfWeek |= DaysOfTheWeek.Friday;
                if (ceSat.Checked) daysOfWeek |= DaysOfTheWeek.Saturday;
                if (ceSun.Checked) daysOfWeek |= DaysOfTheWeek.Sunday;

                Schedule.DaysOfWeek = daysOfWeek;
            }
            else
            {
                Schedule.Recurrence = 2;
                MonthsOfTheYear monthsOfYear = 0;
                var months = cbMonthsOfYear.Properties.GetItems();
                if (months[0].CheckState == CheckState.Checked) monthsOfYear |= MonthsOfTheYear.January;
                if (months[1].CheckState == CheckState.Checked) monthsOfYear |= MonthsOfTheYear.February;
                if (months[2].CheckState == CheckState.Checked) monthsOfYear |= MonthsOfTheYear.March;
                if (months[3].CheckState == CheckState.Checked) monthsOfYear |= MonthsOfTheYear.April;
                if (months[4].CheckState == CheckState.Checked) monthsOfYear |= MonthsOfTheYear.May;
                if (months[5].CheckState == CheckState.Checked) monthsOfYear |= MonthsOfTheYear.June;
                if (months[6].CheckState == CheckState.Checked) monthsOfYear |= MonthsOfTheYear.July;
                if (months[7].CheckState == CheckState.Checked) monthsOfYear |= MonthsOfTheYear.August;
                if (months[8].CheckState == CheckState.Checked) monthsOfYear |= MonthsOfTheYear.September;
                if (months[9].CheckState == CheckState.Checked) monthsOfYear |= MonthsOfTheYear.October;
                if (months[10].CheckState == CheckState.Checked) monthsOfYear |= MonthsOfTheYear.November;
                if (months[11].CheckState == CheckState.Checked) monthsOfYear |= MonthsOfTheYear.December;
                Schedule.MonthsOfYear = monthsOfYear;
                var daysOfMonth = new List<int>();
                var days = cbDayOfMonth.Properties.GetItems();
                for (var n = 0; n < 30; n++)
                {
                    if (days[n].CheckState == CheckState.Checked)
                    {
                        daysOfMonth.Add(n + 1);
                    }
                }
                Schedule.DaysOfMonth.Clear();
                Schedule.DaysOfMonth.AddRange(daysOfMonth);
                Schedule.RunOnLastDayOfMonth = days[31].CheckState == CheckState.Checked;
            }

            Schedule.StartBoundary = deStartBoundary.DateTime.Date.Add(teStartBoundary.Time.TimeOfDay);
        }

        void CeDailyCheckedChanged(object sender, EventArgs e)
        {
            if (ceDaily.Checked)
            {
                lcgDaily.Visibility = LayoutVisibility.Always;
                lcgWeekly.Visibility = LayoutVisibility.Never;
                lcgMonthly.Visibility = LayoutVisibility.Never;
            }
            else if (ceWeekly.Checked)
            {
                lcgDaily.Visibility = LayoutVisibility.Never;
                lcgWeekly.Visibility = LayoutVisibility.Always;
                lcgMonthly.Visibility = LayoutVisibility.Never;
            }
            else
            {
                lcgDaily.Visibility = LayoutVisibility.Never;
                lcgWeekly.Visibility = LayoutVisibility.Never;
                lcgMonthly.Visibility = LayoutVisibility.Always;
            }
        }
    }
}
