using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Runtime.InteropServices;
using DevExpress.Xpo;

namespace Dekart.LazyNet.Helpers
{
    public static class AdHelper
    {
        static string _domainName;

        public static bool IsCurrentUserAdmin()
        {
            try
            {
                // set up domain context
                var ctx = new PrincipalContext(ContextType.Domain);

                // find the group in question
                var group = GroupPrincipal.FindByIdentity(ctx, "Domain Admins") ?? GroupPrincipal.FindByIdentity(ctx, "Администраторы домена");
                return @group != null && @group.GetMembers().OfType<UserPrincipal>().Any(theUser => !theUser.IsAccountLockedOut() && theUser.SamAccountName == Environment.UserName);
            }
            catch
            {
                return false;
            }
        }

        public static User CreateWindowsUser(Session session, string userAccount, bool isAdmin)
        {
            var user = new User(session) {UserName = userAccount, UserState = UserStateEnum.Salaried, IsAdmin = isAdmin};

            string email, firstName, lastName, phone, title, mobile, office;
            if (GetUserPropertiesFromAD(userAccount, out email, out firstName, out lastName, out phone, out mobile, out title, out office))
            {
                var fullName = firstName;
                if (!string.IsNullOrWhiteSpace(lastName))
                {
                    fullName = string.Format("{0} {1}", lastName, fullName);
                }

                user.Email = email;
                user.FirstName = firstName;
                user.LastName = lastName;
                user.FullName = fullName;
                user.WorkPhone = phone;
                user.MobilePhone = mobile;
                user.Department = office;
                user.Title = title;
            }
            user.Save();

            return user;
        }

        public static bool GetUserPropertiesFromAD(string userAccount, out string email, out string firstName, out string lastName, out string phone, out string mobile, out string title, out string office)
        {
            string str3;
            email = "";
            firstName = "";
            lastName = "";
            phone = "";
            title = "";
            mobile = "";
            office = "";

            string str;
            var index = userAccount.IndexOf(@"\", StringComparison.Ordinal);
            if (index < 0)
            {
                if (string.IsNullOrEmpty(Environment.UserDomainName))
                {
                    return false;
                }
                _domainName = Environment.UserDomainName;
                str = userAccount;
            }
            else
            {
                str = userAccount.Substring(index + 1);
                _domainName = userAccount.Substring(0, index);
            }
            return GetUserPropertiesInternal("(&(objectCategory=person)(objectClass=user)(SAMAccountName=" + str + "))", out str3, out email, out firstName, out lastName, out phone, out mobile, out title, out office);
        }

        public static bool GetUserPropertiesFromADByEmail(string email, out string username, out string firstName, out string lastName, out string phone, out string mobile, out string title, out string office, string domainName = null)
        {
            string str2;
            string ldapSearchString = "(&(objectCategory=person)(objectClass=user)(mail=" + email + "))";
            if (domainName != null)
            {
                _domainName = domainName;
            }
            return GetUserPropertiesInternal(ldapSearchString, out username, out str2, out firstName, out lastName, out phone, out mobile, out title, out office);
        }

        static bool GetUserPropertiesInternal(string ldapSearchString, out string username, out string email, out string firstName, out string lastName, out string phone, out string mobile, out string title, out string office)
        {
            SearchResult result;
            username = "";
            email = "";
            firstName = "";
            lastName = "";
            phone = "";
            title = "";
            mobile = "";
            office = "";

            try
            {
                result = GetADSearcherObject(ldapSearchString, "mail", "givenName", "sn", "telephoneNumber", "title", "mobile", "sAMAccountName").FindOne();
            }
            catch (COMException)
            {
                result = null;
            }
            if (result == null)
            {
                return false;
            }
            Exception ex = null;
            try
            {
                username = result.Properties["sAMAccountName"][0].ToString();
            }
            catch (Exception exception3)
            {
                ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "sAMAccountName"), exception3);
            }
            try
            {
                email = result.Properties["mail"][0].ToString();
            }
            catch (Exception exception4)
            {
                ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "mail"), exception4);
            }
            try
            {
                firstName = result.Properties["givenName"][0].ToString();
            }
            catch (Exception exception5)
            {
                ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "givenName"), exception5);
            }
            try
            {
                lastName = result.Properties["sn"][0].ToString();
            }
            catch (Exception exception6)
            {
                ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "sn"), exception6);
            }
            try
            {
                phone = result.Properties["telephoneNumber"][0].ToString();
            }
            catch (Exception exception7)
            {
                ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "telephoneNumber"), exception7);
            }
            //try
            //{
            //    office = result.Properties["physicalDeliveryOfficeName"][0].ToString();
            //}
            //catch (Exception exception8)
            //{
            //    ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "physicalDeliveryOfficeName"), exception8);
            //}
            //try
            //{
            //    adLanguage = result.Properties["preferredLanguage"][0].ToString();
            //}
            //catch (Exception exception9)
            //{
            //    ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "preferredLanguage"), exception9);
            //}
            //try
            //{
            //    company = result.Properties["company"][0].ToString();
            //}
            //catch (Exception exception10)
            //{
            //    ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "company"), exception10);
            //}
            try
            {
                office = ExtractValue(result.Path, "OU");
            }
            catch (Exception exception9)
            {
                ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "OU"), exception9);
            }
            try
            {
                title = result.Properties["title"][0].ToString();
            }
            catch (Exception exception10)
            {
                ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "title"), exception10);
            }
            try
            {
                mobile = result.Properties["mobile"][0].ToString();
            }
            catch (Exception exception11)
            {
                ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "mobile"), exception11);
            }
            if (ex != null)
            {
                Logger.Error(ex.Message, ex);
            }
            return true;
        }

        public static bool GetComputerPropertiesFromAD(string name, out string managedBy, out string operatingSystemFull, out string room)
        {
            managedBy = "";
            operatingSystemFull = "";
            room = "";

            string str, str1;
            var index = name.IndexOf(@".", StringComparison.Ordinal);
            if (index < 0)
            {
                if (string.IsNullOrEmpty(Environment.UserDomainName))
                {
                    return false;
                }
                _domainName = Environment.UserDomainName;
                str = name;
            }
            else
            {
                str = name.Substring(0, index);
                _domainName = name.Substring(index + 1);
            }
            string operatingSystem, operatingSystemServicePack, operatingSystemVersion;

            if (GetComputerPropertiesFromAD("(&(objectCategory=computer)(name=" + str + "))", out str1, out managedBy, out operatingSystem, out operatingSystemServicePack, out operatingSystemVersion, out room))
            {
                operatingSystemFull = operatingSystem;
                if (operatingSystemServicePack.Trim() != "" && operatingSystemFull.Trim() != "")
                {
                    operatingSystemFull = string.Format("{0} {1}", operatingSystemFull, operatingSystemServicePack);
                }
                if (operatingSystemVersion.Trim() != "" && operatingSystemFull.Trim() != "")
                {
                    operatingSystemFull = string.Format("{0} v{1}", operatingSystemFull, operatingSystemVersion);
                }

                return true;
            }

            return false;
        }

        public static bool GetComputerPropertiesFromAD(string ldapSearchString, out string hostName, out string managedBy, out string operatingSystemFull, out string room)
        {
            operatingSystemFull = string.Empty;

            string operatingSystem, operationSystemServicePack, operatingSystemVersion;
            if (GetComputerPropertiesFromAD(ldapSearchString, out hostName, out managedBy, out operatingSystem, out operationSystemServicePack, out operatingSystemVersion, out room))
            {
                operatingSystemFull = operatingSystem;
                if (operationSystemServicePack.Trim() != "" && operatingSystemFull.Trim() != "")
                {
                    operatingSystemFull = string.Format("{0} {1}", operatingSystemFull, operationSystemServicePack);
                }
                if (operatingSystemVersion.Trim() != "" && operatingSystemFull.Trim() != "")
                {
                    operatingSystemFull = string.Format("{0} v{1}", operatingSystemFull, operatingSystemVersion);
                }

                return true;
            }

            return false;
        }

        // ReSharper disable once FunctionComplexityOverflow
        static bool GetComputerPropertiesFromAD(string ldapSearchString, out string hostName, out string managedBy, out string operatingSystem, out string operatingSystemServicePack, out string operatingSystemVersion, out string room)
        {
            SearchResult result;
            hostName = "";
            managedBy = "";
            operatingSystem = "";
            operatingSystemServicePack = "";
            operatingSystemVersion = "";
            room = "";

            try
            {
                result = GetADSearcherObject(ldapSearchString, "dNSHostName", "managedBy", "operatingSystem", "operatingSystemServicePack", "operatingSystemVersion").FindOne();
            }
            catch (COMException)
            {
                result = null;
            }
            if (result == null)
            {
                return false;
            }
            Exception ex = null;
            try
            {
                hostName = result.Properties["dNSHostName"][0].ToString();
            }
            catch (Exception exception2)
            {
                ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "dNSHostName"), exception2);
            }
            try
            {
                SearchResult result2;
                var ldapSearchString2 = "(&(objectCategory=person)(objectClass=user)(distinguishedName=" + result.Properties["managedBy"][0] + "))";
                try
                {
                    result2 = GetADSearcherObject(ldapSearchString2, "sAMAccountName").FindOne();
                }
                catch (COMException)
                {
                    result2 = null;
                }
                if (result2 != null)
                {
                    try
                    {
                        managedBy = result2.Properties["sAMAccountName"][0].ToString();
                    }
                    catch (Exception exception3)
                    {
                        ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "sAMAccountName"), exception3);
                    }
                }
            }
            catch (Exception exception3)
            {
                ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "managedBy"), exception3);
            }
            try
            {
                operatingSystem = result.Properties["operatingSystem"][0].ToString();
            }
            catch (Exception exception4)
            {
                ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "operatingSystem"), exception4);
            }
            try
            {
                operatingSystemServicePack = result.Properties["operatingSystemServicePack"][0].ToString();
            }
            catch (Exception exception5)
            {
                ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "operatingSystemServicePack"), exception5);
            }
            try
            {
                operatingSystemVersion = result.Properties["operatingSystemVersion"][0].ToString();
            }
            catch (Exception exception6)
            {
                ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "operatingSystemVersion"), exception6);
            }
            try
            {
                room = ExtractValue(result.Path, "OU");
            }
            catch (Exception exception6)
            {
                ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "OU"), exception6);
            }
            if (ex != null)
            {
                Logger.Error(ex.Message, ex);
            }
            return true;
        }

        public static bool GetPrinterPropertiesFromAD(string name, out string printerName, out string managedBy, out string printShareName, out string room)
        {
            SearchResult result;

            managedBy = "";
            printerName = "";
            printShareName = "";
            room = "";

            string str, str1 = "";
            var index = name.IndexOf(@".", StringComparison.Ordinal);
            if (index < 0)
            {
                if (string.IsNullOrEmpty(Environment.UserDomainName))
                {
                    return false;
                }
                _domainName = Environment.UserDomainName;
                str = name;
            }
            else
            {
                str = name.Substring(0, index);
                _domainName = name.Substring(index + 1);
            }

            try
            {
                result = GetADSearcherObject("(&(objectCategory=printQueue)(name=" + str + "))", "printerName", "managedBy", "printShareName", "shortServerName").FindOne();
            }
            catch (COMException)
            {
                result = null;
            }
            if (result == null)
            {
                return false;
            }
            Exception ex = null;
            try
            {
                printerName = result.Properties["printerName"][0].ToString();
            }
            catch (Exception exception2)
            {
                ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "printerName"), exception2);
            }
            try
            {
                managedBy = result.Properties["managedBy"][0].ToString();
            }
            catch (Exception exception3)
            {
                ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "managedBy"), exception3);
            }
            try
            {
                printShareName = result.Properties["printShareName"][0].ToString();
            }
            catch (Exception exception4)
            {
                ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "printShareName"), exception4);
            }
            try
            {
                str1 = result.Properties["shortServerName"][0].ToString();
            }
            catch (Exception exception5)
            {
                ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "shortServerName"), exception5);
            }
            try
            {
                room = ExtractValue(result.Path, "OU");
            }
            catch (Exception exception6)
            {
                ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "OU"), exception6);
            }
            if (ex != null)
            {
                Logger.Error(ex.Message, ex);
            }

            printShareName = string.Format("\\\\{0}\\{1}", str1, printShareName);

            return true;
        }

        static DirectorySearcher GetADSearcherObject(string ldapFilterString, params string[] propertiesToLoad)
        {
            var directoryEntry = _domainName != null ? GetDirectoryEntry(_domainName) : new DirectoryEntry();
            var searcher = new DirectorySearcher(directoryEntry)
            {
                ClientTimeout = new TimeSpan(0, 0, 2),
                Filter = ldapFilterString
            };
            foreach (var property in propertiesToLoad)
            {
                searcher.PropertiesToLoad.Add(property);
            }
            return searcher;
        }

        static DirectoryEntry GetDirectoryEntry(string domainName)
        {
            return new DirectoryEntry { Path = "LDAP://" + domainName };
        }

        static string ExtractValue(string source, string key)
        {
            if (string.IsNullOrWhiteSpace(source)) return null;

            var pairs = source.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            return (from pair in pairs select pair.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries) into namevalue where namevalue.Length == 2 && string.Equals(namevalue[0], key) select namevalue[1]).FirstOrDefault();
        }

        public static List<string> GetListOfDomainComputers(string domainName)
        {
            _domainName = domainName ?? Environment.UserDomainName;

            SearchResultCollection searchCollection;

            try
            {
                searchCollection = GetADSearcherObject("(objectClass=computer)", "name").FindAll();
            }
            catch (COMException)
            {
                searchCollection = null;
            }

            var ret = new List<string>();
            if (searchCollection == null) return ret;

            foreach (SearchResult result in searchCollection)
            {
                Exception ex = null;
                try
                {
                    ret.Add(result.Properties["name"][0].ToString());
                }
                catch (Exception exception1)
                {
                    ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "name"), exception1);
                }
                if (ex != null)
                {
                    Logger.Error(ex.Message, ex);
                }
            }

            return ret;
        }
        public static List<string> GetListOfDomainPrinters(string domainName)
        {
            _domainName = domainName ?? Environment.UserDomainName;

            SearchResultCollection searchCollection;

            try
            {
                searchCollection = GetADSearcherObject("(objectCategory=printQueue)", "name").FindAll();
            }
            catch (COMException)
            {
                searchCollection = null;
            }

            var ret = new List<string>();
            if (searchCollection == null) return ret;

            foreach (SearchResult result in searchCollection)
            {
                Exception ex = null;
                try
                {
                    ret.Add(result.Properties["name"][0].ToString());
                }
                catch (Exception exception1)
                {
                    ex = new Exception(string.Format(ConstStrings.InvalidPropertyError, "name"), exception1);
                }
                if (ex != null)
                {
                    Logger.Error(ex.Message, ex);
                }
            }

            return ret;
        }
    }
}
