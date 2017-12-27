using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;

namespace Dekart.LazyNet.SQLBackup2Remote.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddSchedule.xaml
    /// </summary>
    public partial class AddSchedule : Window
    {
        readonly ScheduleData _schedule;

        public AddSchedule(ScheduleData schedule)
        {
            InitializeComponent();
            _schedule = schedule;
            if (_schedule == null)
            {
                _schedule = new ScheduleData { Recurrence = 0, StartBoundary = DateTime.Now, RepeatEvery = 1, DaysOfWeek = DaysOfTheWeek.AllDays };
            }
            for (var m = 1; m <= 12; m++)
            {
                MonthsOfYearComboBox.Items.Add(new DateTime(2000, m, 1).ToString("MMMM"));
            }
            for (var d = 1; d <= 30; d++)
            {
                DaysOfMonthComboBox.Items.Add(d.ToString());
            }
            DaysOfMonthComboBox.Items.Add("Last day of month");
        }

        public ScheduleData Schedule => _schedule;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Owner != null)
            {
                Left = Owner.Left + (Owner.Width - Width) / 2;
                Top = Owner.Top + (Owner.Height - Height) / 2;
            }

            DailyRadioButton.IsChecked = Schedule.Recurrence == 0;
            WeeklyRadioButton.IsChecked = Schedule.Recurrence == 1;
            MonthlyRadioButton.IsChecked = Schedule.Recurrence > 1;
            if (DailyRadioButton.IsChecked == true)
            {
                ScheduleTabControl.SelectedIndex = 0;

                RepeatDaysIntegerUpDown.Value = Schedule.RepeatEvery;
            }
            else if (WeeklyRadioButton.IsChecked == true)
            {
                ScheduleTabControl.SelectedIndex = 1;

                RepeatWeeksIntegerUpDown.Value = Schedule.RepeatEvery;
                MondayCheckBox.IsChecked = (Schedule.DaysOfWeek & DaysOfTheWeek.Monday) != 0;
                TuesdayCheckBox.IsChecked = (Schedule.DaysOfWeek & DaysOfTheWeek.Tuesday) != 0;
                WednesdayCheckBox.IsChecked = (Schedule.DaysOfWeek & DaysOfTheWeek.Wednesday) != 0;
                ThursdayCheckBox.IsChecked = (Schedule.DaysOfWeek & DaysOfTheWeek.Thursday) != 0;
                FridayCheckBox.IsChecked = (Schedule.DaysOfWeek & DaysOfTheWeek.Friday) != 0;
                SundayCheckBox.IsChecked = (Schedule.DaysOfWeek & DaysOfTheWeek.Saturday) != 0;
                SundayCheckBox.IsChecked = (Schedule.DaysOfWeek & DaysOfTheWeek.Sunday) != 0;
            }
            else if (MonthlyRadioButton.IsChecked == true)
            {
                ScheduleTabControl.SelectedIndex = 2;

                var selectedMonths = new ArrayList();
                if ((Schedule.MonthsOfYear & MonthsOfTheYear.January) != 0)
                {
                    selectedMonths.Add(new DateTime(2000, 1, 1).ToString("MMMM"));
                }
                if ((Schedule.MonthsOfYear & MonthsOfTheYear.February) != 0)
                {
                    selectedMonths.Add(new DateTime(2000, 2, 1).ToString("MMMM"));
                }
                if ((Schedule.MonthsOfYear & MonthsOfTheYear.March) != 0)
                {
                    selectedMonths.Add(new DateTime(2000, 3, 1).ToString("MMMM"));
                }
                if ((Schedule.MonthsOfYear & MonthsOfTheYear.April) != 0)
                {
                    selectedMonths.Add(new DateTime(2000, 4, 1).ToString("MMMM"));
                }
                if ((Schedule.MonthsOfYear & MonthsOfTheYear.May) != 0)
                {
                    selectedMonths.Add(new DateTime(2000, 5, 1).ToString("MMMM"));
                }
                if ((Schedule.MonthsOfYear & MonthsOfTheYear.June) != 0)
                {
                    selectedMonths.Add(new DateTime(2000, 6, 1).ToString("MMMM"));
                }
                if ((Schedule.MonthsOfYear & MonthsOfTheYear.July) != 0)
                {
                    selectedMonths.Add(new DateTime(2000, 7, 1).ToString("MMMM"));
                }
                if ((Schedule.MonthsOfYear & MonthsOfTheYear.August) != 0)
                {
                    selectedMonths.Add(new DateTime(2000, 8, 1).ToString("MMMM"));
                }
                if ((Schedule.MonthsOfYear & MonthsOfTheYear.September) != 0)
                {
                    selectedMonths.Add(new DateTime(2000, 9, 1).ToString("MMMM"));
                }
                if ((Schedule.MonthsOfYear & MonthsOfTheYear.October) != 0)
                {
                    selectedMonths.Add(new DateTime(2000, 10, 1).ToString("MMMM"));
                }
                if ((Schedule.MonthsOfYear & MonthsOfTheYear.November) != 0)
                {
                    selectedMonths.Add(new DateTime(2000, 11, 1).ToString("MMMM"));
                }
                if ((Schedule.MonthsOfYear & MonthsOfTheYear.December) != 0)
                {
                    selectedMonths.Add(new DateTime(2000, 12, 1).ToString("MMMM"));
                }
                MonthsOfYearComboBox.SelectedItemsOverride = selectedMonths;

                var selectedDays = new ArrayList();
                for (var d = 1; d <= 30; d++)
                {
                    if(Schedule.DaysOfMonth != null && Schedule.DaysOfMonth.Contains(d))
                    {
                        selectedDays.Add(d.ToString());
                    }
                }
                if(Schedule.RunOnLastDayOfMonth)
                {
                    selectedDays.Add("Last day of month");
                }
                DaysOfMonthComboBox.SelectedItemsOverride = selectedDays;
            }

            StartBoundaryDatePicker.Value = Schedule.StartBoundary.Date;
            StartBoundaryTimePicker.Value = Schedule.StartBoundary;

        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if (DailyRadioButton.IsChecked == true)
            {
                ScheduleTabControl.SelectedIndex = 0;
            }
            else if (WeeklyRadioButton.IsChecked == true)
            {
                ScheduleTabControl.SelectedIndex = 1;
            }
            else if (MonthlyRadioButton.IsChecked == true)
            {
                ScheduleTabControl.SelectedIndex = 2;
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (DailyRadioButton.IsChecked == true)
            {
                Schedule.Recurrence = 0;
                Schedule.RepeatEvery = Convert.ToInt16(RepeatDaysIntegerUpDown.Value);
            }
            else if (WeeklyRadioButton.IsChecked == true)
            {
                Schedule.Recurrence = 1;
                Schedule.RepeatEvery = Convert.ToInt16(RepeatWeeksIntegerUpDown.Value);

                DaysOfTheWeek daysOfWeek = 0;
                if (MondayCheckBox.IsChecked == true) daysOfWeek |= DaysOfTheWeek.Monday;
                if (TuesdayCheckBox.IsChecked == true) daysOfWeek |= DaysOfTheWeek.Tuesday;
                if (WednesdayCheckBox.IsChecked == true) daysOfWeek |= DaysOfTheWeek.Wednesday;
                if (ThursdayCheckBox.IsChecked == true) daysOfWeek |= DaysOfTheWeek.Thursday;
                if (FridayCheckBox.IsChecked == true) daysOfWeek |= DaysOfTheWeek.Friday;
                if (SaturdayCheckBox.IsChecked == true) daysOfWeek |= DaysOfTheWeek.Saturday;
                if (SundayCheckBox.IsChecked == true) daysOfWeek |= DaysOfTheWeek.Sunday;

                Schedule.DaysOfWeek = daysOfWeek;
            }
            else if (MonthlyRadioButton.IsChecked == true)
            {
                Schedule.Recurrence = 2;
                MonthsOfTheYear monthsOfYear = 0;
                if (MonthsOfYearComboBox.SelectedItems.Contains(new DateTime(2000, 1, 1).ToString("MMMM")))
                {
                    monthsOfYear |= MonthsOfTheYear.January;
                }
                if (MonthsOfYearComboBox.SelectedItems.Contains(new DateTime(2000, 2, 1).ToString("MMMM")))
                {
                    monthsOfYear |= MonthsOfTheYear.February;
                }
                if (MonthsOfYearComboBox.SelectedItems.Contains(new DateTime(2000, 3, 1).ToString("MMMM")))
                {
                    monthsOfYear |= MonthsOfTheYear.March;
                }
                if (MonthsOfYearComboBox.SelectedItems.Contains(new DateTime(2000, 4, 1).ToString("MMMM")))
                {
                    monthsOfYear |= MonthsOfTheYear.April;
                }
                if (MonthsOfYearComboBox.SelectedItems.Contains(new DateTime(2000, 5, 1).ToString("MMMM")))
                {
                    monthsOfYear |= MonthsOfTheYear.May;
                }
                if (MonthsOfYearComboBox.SelectedItems.Contains(new DateTime(2000, 6, 1).ToString("MMMM")))
                {
                    monthsOfYear |= MonthsOfTheYear.June;
                }
                if (MonthsOfYearComboBox.SelectedItems.Contains(new DateTime(2000, 7, 1).ToString("MMMM")))
                {
                    monthsOfYear |= MonthsOfTheYear.July;
                }
                if (MonthsOfYearComboBox.SelectedItems.Contains(new DateTime(2000, 8, 1).ToString("MMMM")))
                {
                    monthsOfYear |= MonthsOfTheYear.August;
                }
                if (MonthsOfYearComboBox.SelectedItems.Contains(new DateTime(2000, 9, 1).ToString("MMMM")))
                {
                    monthsOfYear |= MonthsOfTheYear.September;
                }
                if (MonthsOfYearComboBox.SelectedItems.Contains(new DateTime(2000, 10, 1).ToString("MMMM")))
                {
                    monthsOfYear |= MonthsOfTheYear.October;
                }
                if (MonthsOfYearComboBox.SelectedItems.Contains(new DateTime(2000, 11, 1).ToString("MMMM")))
                {
                    monthsOfYear |= MonthsOfTheYear.November;
                }
                if (MonthsOfYearComboBox.SelectedItems.Contains(new DateTime(2000, 12, 1).ToString("MMMM")))
                {
                    monthsOfYear |= MonthsOfTheYear.December;
                }
                Schedule.MonthsOfYear = monthsOfYear;
                var daysOfMonth = new List<int>();
                for (var d = 1; d <= 30; d++)
                {
                    if (DaysOfMonthComboBox.SelectedItems.Contains(d.ToString()))
                    {
                        daysOfMonth.Add(d);
                    }
                }
                Schedule.DaysOfMonth.Clear();
                Schedule.DaysOfMonth.AddRange(daysOfMonth);
                Schedule.RunOnLastDayOfMonth = DaysOfMonthComboBox.SelectedItems.Contains("Last day of month");
            }

            Schedule.StartBoundary = StartBoundaryDatePicker.Value.Value.Date.Add(StartBoundaryTimePicker.Value.Value.TimeOfDay);

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
