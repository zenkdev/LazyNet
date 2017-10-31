using System.Configuration;
using Dekart.LazyNet.Helpers;

namespace Dekart.LazyNet
{
    [SettingsProvider(typeof(XpoSettingsProvider))]
    public class AppSettings : ApplicationSettingsBase
    {
        public static AppSettings Default { get; } = ((AppSettings)(Synchronized(new AppSettings())));

        [UserScopedSetting]
        [DefaultSettingValue(@"<ArrayOfFilterInfo xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <FilterInfo>
    <Name>Руководители</Name>
    <FilterCriteria>Contains([Title], 'руководител') Or Contains([Title], 'директор')</FilterCriteria>
  </FilterInfo>
  <FilterInfo>
    <Name>Сотрудники</Name>
    <FilterCriteria>Not Contains([Title], 'руководител') And Not Contains([Title], 'директор')</FilterCriteria>
  </FilterInfo>
</ArrayOfFilterInfo>")]
        public FilterInfoList UsersCustomFilters
        {
            get { return ((FilterInfoList) (this["UsersCustomFilters"])); }
            set { this["UsersCustomFilters"] = value; }
        }

        [DefaultSettingValue(@"<ArrayOfFilterInfo xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <FilterInfo>
    <Name>Активные</Name>
    <FilterCriteria>[UserState] = ##Enum#Dekart.LazyNet.UserStateEnum,Salaried# Or [UserState] = ##Enum#Dekart.LazyNet.UserStateEnum,Freelancer# Or [UserState] = ##Enum#Dekart.LazyNet.UserStateEnum,OnLeave#</FilterCriteria>
  </FilterInfo>
  <FilterInfo>
    <Name>Штатные</Name>
    <FilterCriteria>[UserState] = ##Enum#Dekart.LazyNet.UserStateEnum,Salaried#</FilterCriteria>
  </FilterInfo>
  <FilterInfo>
    <Name>Внештатные</Name>
    <FilterCriteria>[UserState] = ##Enum#Dekart.LazyNet.UserStateEnum,Freelancer#</FilterCriteria>
  </FilterInfo>
  <FilterInfo>
    <Name>В отпуске</Name>
    <FilterCriteria>[UserState] = ##Enum#Dekart.LazyNet.UserStateEnum,OnLeave#</FilterCriteria>
  </FilterInfo>
  <FilterInfo>
    <Name>Уволенные</Name>
    <FilterCriteria>[UserState] = ##Enum#Dekart.LazyNet.UserStateEnum,Terminated#</FilterCriteria>
  </FilterInfo>
  <FilterInfo>
    <Name>Все</Name>
  </FilterInfo>
</ArrayOfFilterInfo>")]
        [UserScopedSetting]
        public FilterInfoList UsersStaticFilters
        {
            get { return ((FilterInfoList) (this["UsersStaticFilters"])); }
            set { this["UsersStaticFilters"] = value; }
        }

        [DefaultSettingValue(@"<ArrayOfFilterInfo xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <FilterInfo>
    <Name>За текущий год</Name>
    <FilterCriteria>IsOutlookIntervalEarlierThisYear([CreatedOn])</FilterCriteria>
  </FilterInfo>
  <FilterInfo>
    <Name>За текущий месяц</Name>
    <FilterCriteria>IsOutlookIntervalEarlierThisMonth([CreatedOn])</FilterCriteria>
  </FilterInfo>
</ArrayOfFilterInfo>")]
        [UserScopedSetting]
        public FilterInfoList RepairsCustomFilters
        {
            get { return ((FilterInfoList) (this["RepairsCustomFilters"])); }
            set { this["RepairsCustomFilters"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue(@"<ArrayOfFilterInfo xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <FilterInfo>
    <Name>Все</Name>
  </FilterInfo>
  <FilterInfo>
    <Name>Гарантийные ремонты</Name>
    <FilterCriteria>[RepairType] = ##Enum#Dekart.LazyNet.RepairTypeEnum,WarrantyRepair#</FilterCriteria>
  </FilterInfo>
  <FilterInfo>
    <Name>Платные ремонты</Name>
    <FilterCriteria>[RepairType] = ##Enum#Dekart.LazyNet.RepairTypeEnum,PaidRepair#</FilterCriteria>
  </FilterInfo>
  <FilterInfo>
    <Name>Плановое обслуживание</Name>
    <FilterCriteria>[RepairType] = ##Enum#Dekart.LazyNet.RepairTypeEnum,ScheduledMaintenance#</FilterCriteria>
  </FilterInfo>
  <FilterInfo>
    <Name>Замена картриджей</Name>
    <FilterCriteria>[RepairType] = ##Enum#Dekart.LazyNet.RepairTypeEnum,CartridgeReplacement#</FilterCriteria>
  </FilterInfo>
  <FilterInfo>
    <Name>Другое</Name>
    <FilterCriteria>[RepairType] = ##Enum#Dekart.LazyNet.RepairTypeEnum,Other#</FilterCriteria>
  </FilterInfo>
</ArrayOfFilterInfo>")]
        public FilterInfoList RepairsStaticFilters
        {
            get { return (FilterInfoList) this["RepairsStaticFilters"]; }
            set { this["RepairsStaticFilters"] = value; }
        }

        [DefaultSettingValue(@"<ArrayOfFilterInfo xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <FilterInfo>
    <Name>Продукты Microsoft</Name>
    <FilterCriteria>Contains([Name], 'Windows') Or Contains([Name], 'Office')</FilterCriteria>
  </FilterInfo>
</ArrayOfFilterInfo>")]
        [UserScopedSetting]
        public FilterInfoList SoftwareCustomFilters
        {
            get { return (FilterInfoList) this["SoftwareCustomFilters"]; }
            set { this["SoftwareCustomFilters"] = value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue(@"<ArrayOfFilterInfo xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <FilterInfo>
    <Name>Все</Name>
  </FilterInfo>
  <FilterInfo>
    <Name>Только активные</Name>
    <FilterCriteria>[ExpiredOn] Is Null Or IsOutlookIntervalLaterThisYear([ExpiredOn]) Or IsOutlookIntervalBeyondThisYear([ExpiredOn])</FilterCriteria>
  </FilterInfo>
  <FilterInfo>
    <Name>Только закончившиеся</Name>
    <FilterCriteria>IsOutlookIntervalEarlierThisYear([ExpiredOn]) Or IsOutlookIntervalPriorThisYear([ExpiredOn])</FilterCriteria>
  </FilterInfo>
</ArrayOfFilterInfo>")]
        public FilterInfoList SoftwareStaticFilters
        {
            get { return (FilterInfoList) this["SoftwareStaticFilters"]; }
            set { this["SoftwareStaticFilters"] = value; }
        }
    }
}