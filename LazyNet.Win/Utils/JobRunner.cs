using System;
using System.Linq;
using System.Configuration;
using System.Drawing;
using System.Globalization;
using System.Management;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using SqlMethods = System.Data.Linq.SqlClient.SqlMethods;

namespace Dekart.LazyNet.Win
{
    static class JobRunner
    {
        // ReSharper disable InconsistentNaming
        const int ERROR_SUCCESS = 0;
        const int ERROR_INTERNAL_ERROR = 1359;
        // ReSharper restore InconsistentNaming

        static readonly DateTime Now = DateTime.Now;

        public static int RunBySchedule()
        {
            LogHelper.WriteLine(Environment.NewLine + $">>> start job {Now:G}");

            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["XpoDefault.ConnectionString"].ConnectionString;
                //connectionString = DbUtils.ChangeApplicationName(connectionString, AssemblyVersion.AssemblyProduct);
                // xpo default
                XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionString, AutoCreateOption.SchemaAlreadyExists);

                var query = (from device in new XPQuery<Device>(XpoDefault.Session) where device.DeletionMark == false && device.DeviceType == DeviceTypeEnum.Printer && device.DeviceState == DeviceStateEnum.Operated select device);
                //query = query.Where(x => x.IP == @"172.16.2.101");
                var pc = new XPQuery<PrinterCounter>(XpoDefault.Session);
                foreach (var device in query)
                {
                    if (!string.IsNullOrEmpty(device.IP) && !ContainsWords(device.Name, "Zebra"))
                    {
                        LogHelper.WriteLine($"{DateTime.Now:G} Processing to {device.Name}:{device.IP}");
                        try
                        {
                            if (!NetHelper.IsHostAccessible(device.IP))
                            {
                                LogHelper.WriteLine($"{DateTime.Now:G} !!! host unaccessible");
                                continue;
                            }

                            string totalCountStr;
                            var address = $"http://{device.IP}";
                            if (ContainsWords(device.Name, "Canon", "MF4660"))
                            {
                                totalCountStr = CanonMf4660(device.Name, address);
                            }
                            else if (ContainsWords(device.Name, "AR-M205"))
                            {
                                totalCountStr = SharpArM205(device.Name, address);
                            }
                            else if (ContainsWords(device.Name, "HP", "LaserJet", "M521"))
                            {
                                totalCountStr = HpLaserJetM521(device.Name, address);
                            }
                            else if (ContainsWords(device.Name, "HP", "LaserJet", "M525") ||
                                ContainsWords(device.Name, "HP", "LaserJet", "M604"))
                            {
                                totalCountStr = HpLaserJetM525(device.Name, address);
                            }
                            else if (ContainsWords(device.Name, "hp", "LaserJet", "4250"))
                            {
                                totalCountStr = HpLaserJet4250(device.Name, address);
                            }
                            else if (ContainsWords(device.Name, "HP", "LaserJet", "P2055"))
                            {
                                totalCountStr = HpLaserJetP2055(device.Name, address);
                            }
                            else if (ContainsWords(device.Name, "HP", "LaserJet", "P3015"))
                            {
                                totalCountStr = HpLaserJetP3015(device.Name, address);
                            }
                            else if (ContainsWords(device.Name, "HP", "LaserJet", "M1212"))
                            {
                                totalCountStr = HpLaserJetM1212(device.Name, address);
                            }
                            else if (ContainsWords(device.Name, "EPSON", "L655"))
                            {
                                totalCountStr = EpsonL655(device.Name, address);
                            }
                            else
                            {
                                LogHelper.WriteLine($"{DateTime.Now:G} !!! unsupported model");
                                continue;
                            }
                            if (string.IsNullOrEmpty(totalCountStr))
                            {
                                LogHelper.WriteLine($"{DateTime.Now:G} !!! can\'t get printer counter");
                            }
                            else
                            {
                                var totalCount = decimal.Parse(totalCountStr.Replace(',', '.'), CultureInfo.InvariantCulture);
                                var preCounter = pc.Where(x => x.Device.Id == device.Id && SqlMethods.DateDiffDay(x.CreatedOn, Now) > 0).OrderByDescending(x => x.CreatedOn).FirstOrDefault();
                                var nowCounter = pc.FirstOrDefault(x => x.Device.Id == device.Id && SqlMethods.DateDiffDay(x.CreatedOn, Now) == 0) ?? new PrinterCounter
                                {
                                    Device = device
                                };
                                nowCounter.DayCount = totalCount - (preCounter?.TotalCount ?? 0);
                                nowCounter.TotalCount = totalCount;
                                nowCounter.CreatedOn = Now;
                                nowCounter.Save();
                                LogHelper.WriteLine($"{DateTime.Now:G} OK - {totalCount}");
                            }
                        }
                        catch (Exception exc)
                        {
                            LogHelper.WriteLine($"{DateTime.Now:G} !!! {exc.Message}");
                        }
                    }
                    else if (!string.IsNullOrEmpty(device.HostName))
                    {
                        LogHelper.WriteLine($"{DateTime.Now:G} Processing to {device.Name} at {device.HostName}");

                        string printerName, hostName = device.HostName.Trim('\\');
                        var l = hostName.IndexOf("\\", StringComparison.Ordinal);
                        if (l > -1)
                        {
                            printerName = hostName.Substring(l + 1);
                            hostName = hostName.Substring(0, l);
                        }
                        else
                        {
                            LogHelper.WriteLine($"{DateTime.Now:G} !!! invalid host name");
                            continue;
                        }

                        try
                        {
                            if (!NetHelper.IsHostAccessible(hostName))
                            {
                                LogHelper.WriteLine($"{DateTime.Now:G} !!! host unaccessible");
                                continue;
                            }

                            ManagementScope scope;
                            if (string.Equals(hostName, Environment.MachineName, StringComparison.InvariantCultureIgnoreCase))
                            {
                                scope = new ManagementScope($@"\\{hostName}\ROOT\CIMV2");
                            }
                            else
                            {
                                var username = WinHelper.ScheduleUserId;
                                var domain = Environment.UserDomainName;
                                var n = username.IndexOf('\\');
                                if (n > -1)
                                {
                                    domain = username.Substring(0, n);
                                    username = username.Substring(n + 1);
                                }
                                var conOpt = new ConnectionOptions
                                {
                                    Impersonation = ImpersonationLevel.Impersonate,
                                    EnablePrivileges = true,
                                    Username = username,
                                    Password = WinHelper.SchedulePassword,
                                    Authority = $"ntlmdomain:{domain}"
                                };
                                scope = new ManagementScope($@"\\{hostName}\ROOT\CIMV2", conOpt);

                            }
                            scope.Connect();
                            var isConnected = scope.IsConnected;
                            if (isConnected)
                            {
                                var lastCounter = pc.Where(x => x.Device.Id == device.Id).OrderByDescending(x => x.CreatedOn).FirstOrDefault();

                                var dateTime = GetDmtfFromDateTime(lastCounter?.CreatedOn ?? DateTime.Today.AddMonths(-1));
                                var contents = "";
                                var totalCount = 0m;

                                //SelectQuery query = new SelectQuery("Select * from Win32_NTLogEvent Where Logfile = 'Application' and TimeGenerated >='" + dateTime + "'");
                                SelectQuery selectQuery = new SelectQuery("Select * from Win32_NTLogEvent Where Logfile = 'Microsoft-Windows-PrintService/Operational' and EventCode = 307 and TimeGenerated >='" + dateTime + "'");
                                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, selectQuery);
                                ManagementObjectCollection logs = searcher.Get();
                                if (logs.Count == 0)
                                {
                                    selectQuery = new SelectQuery("Select * from Win32_NTLogEvent Where Logfile = 'System' and SourceName = 'Print' and EventCode = 10 and TimeGenerated >='" + dateTime + "'");
                                    searcher = new ManagementObjectSearcher(scope, selectQuery);
                                    logs = searcher.Get();
                                }
                                foreach (var log in logs)
                                {
                                    decimal eventCount = 0;
                                    var timeWritten = GetDateTimeFromDmtfDate(log["TimeWritten"].ToString());
                                    var message = StringsHelper.EnsureNotNull((string)log["Message"]);

                                    if (message.IndexOf(printerName, StringComparison.OrdinalIgnoreCase) == -1 &&
                                        message.IndexOf(device.Name, StringComparison.OrdinalIgnoreCase) == -1)
                                    {
                                        continue;
                                    }
                                    contents = StringsHelper.AppendToString(contents, $"Message : {log["Message"]}");
                                    contents = StringsHelper.AppendToString(contents, $"ComputerName : {log["ComputerName"]}");
                                    contents = StringsHelper.AppendToString(contents, $"Type : {log["Type"]}");
                                    contents = StringsHelper.AppendToString(contents, $"User : {log["User"]}");
                                    contents = StringsHelper.AppendToString(contents, $"EventCode : {log["EventCode"]}");
                                    contents = StringsHelper.AppendToString(contents, $"Category : {log["Category"]}");
                                    contents = StringsHelper.AppendToString(contents, $"SourceName : {log["SourceName"]}");
                                    contents = StringsHelper.AppendToString(contents, $"RecordNumber : {log["RecordNumber"]}");
                                    contents = StringsHelper.AppendToString(contents, $"TimeWritten : {GetDateTimeFromDmtfDate(log["TimeWritten"].ToString())}" + Environment.NewLine);
                                    LogHelper.WriteToFile($"{device.Name} {Now:yyyyMMddHHmmss}.txt", contents);

                                    var search = new[] { "Страниц напечатано: ", "число страниц: ", "Pages printed: " };
                                    foreach (var s in search)
                                    {
                                        var i = message.IndexOf(s, StringComparison.OrdinalIgnoreCase);
                                        if (i > -1)
                                        {
                                            var str = message.Substring(i + s.Length);
                                            i = str.IndexOf(".", StringComparison.CurrentCultureIgnoreCase);
                                            if (i > -1)
                                            {
                                                str = str.Substring(0, i);
                                            }
                                            eventCount = decimal.Parse(str, CultureInfo.InvariantCulture);
                                            break;
                                        }
                                    }

                                    var nowCounter = pc.FirstOrDefault(x => x.Device.Id == device.Id && SqlMethods.DateDiffDay(x.CreatedOn, timeWritten) == 0) ?? new PrinterCounter
                                    {
                                        Device = device
                                    };

                                    var time = nowCounter.CreatedOn < timeWritten ? timeWritten : nowCounter.CreatedOn;
                                    var preCounter = pc.Where(x => x.Device.Id == device.Id && x.Id != nowCounter.Id && x.CreatedOn <= time);

                                    nowCounter.DayCount += Math.Max(eventCount, 1);
                                    nowCounter.TotalCount = preCounter.Sum(x => x.DayCount) + nowCounter.DayCount;
                                    nowCounter.CreatedOn = time;
                                    nowCounter.Save();

                                    totalCount += nowCounter.DayCount;
                                }
                                LogHelper.WriteLine($"{DateTime.Now:G} OK - {totalCount}");
                            }
                        }
                        catch (Exception exc)
                        {
                            LogHelper.WriteLine($"{DateTime.Now:G} !!! {exc.Message}");
                        }
                    }
                }

                LogHelper.SaveToFile();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLine(ConstStrings.RunJobFailure);
                LogHelper.WriteError(ex, true);
                return ERROR_INTERNAL_ERROR;
            }

            return ERROR_SUCCESS;
        }
        private static string GetDmtfFromDateTime(DateTime dateTime)
        {
            return ManagementDateTimeConverter.ToDmtfDateTime(dateTime);
        }
        private static DateTime GetDateTimeFromDmtfDate(string dateTime)
        {
            return ManagementDateTimeConverter.ToDateTime(dateTime);
        }
        private static string CanonMf4660(string device, string address)
        {
            const string search = "<B>Total</B>";

            var form = new Form { Size = Size.Empty };

            try
            {
                var webBrowser = new WebBrowser();
                form.Controls.Add(webBrowser);
                form.Show();
                webBrowser.Navigate(address + "/_top.html");
                do
                {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(300);
                } while (webBrowser.ReadyState != WebBrowserReadyState.Complete);
                if (webBrowser.Document != null)
                {
                    foreach (HtmlElement el in webBrowser.Document.GetElementsByTagName("a"))
                    {
                        if (el.OuterHtml.Contains("login()"))
                        {
                            el.InvokeMember("Click");
                            System.Threading.Thread.Sleep(500);
                            break;
                        }
                    }
                    do
                    {
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(300);
                    } while (webBrowser.ReadyState != WebBrowserReadyState.Complete);

                    address += "/_counter.html";
                    webBrowser.Navigate(address);
                    LogHelper.WriteLine($"  Connecting to {address}");
                    do
                    {
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(300);
                    } while (webBrowser.ReadyState != WebBrowserReadyState.Complete);

                    var window = webBrowser.Document?.Window?.Frames?[1];
                    if (window?.Document?.Body != null)
                    {
                        var contents = window.Document.Body.InnerHtml;
                        LogHelper.WriteToFile($"{device} {Now:yyyyMMddHHmmss}.txt", contents);

                        var i = contents.IndexOf(search, StringComparison.Ordinal);
                        if (i >= 0)
                        {
                            var s1 = contents.Substring(i + search.Length);
                            var n = s1.IndexOf("<B>", StringComparison.Ordinal);
                            if (n >= 0)
                            {
                                var s2 = s1.Substring(n + "<B>".Length);
                                return s2.Substring(0, s2.IndexOf("</B>", StringComparison.Ordinal));
                            }
                        }
                    }
                }
            }
            finally
            {
                form.Close();
            }

            return "";
        }

        private static string SharpArM205(string device, string address)
        {
            const string search = @"<H2><!--Total Counts-->Общий счетчик : ";

            var form = new Form { Size = Size.Empty };

            try
            {
                var webBrowser = new WebBrowser();
                form.Controls.Add(webBrowser);
                form.Show();
                address += "/machine_status.html";
                webBrowser.Navigate(address);
                LogHelper.WriteLine($"  Connecting to {address}");
                do
                {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(300);
                } while (webBrowser.ReadyState != WebBrowserReadyState.Complete);

                var contents = StringsHelper.EnsureNotNull(webBrowser.Document?.Body?.InnerHtml);
                LogHelper.WriteToFile($"{device} {Now:yyyyMMddHHmmss}.txt", contents);

                var i = contents.IndexOf(search, StringComparison.Ordinal);
                if (i >= 0)
                {
                    var s = contents.Substring(i + search.Length);
                    return s.Substring(0, s.IndexOf("</H2>", StringComparison.Ordinal));
                }
            }
            finally
            {
                form.Close();
            }
            return "";
        }

        private static string HpLaserJetM1212(string device, string address)
        {
            const string search1 = @"<td class=""labelFont"">Черный картридж:</td>";
            const string search2 = @"<td class=""itemFont"">";

            var webClient = new WebClient { Encoding = Encoding.UTF8 };
            webClient.Headers.Add("Accept-Language:en-US,en");
            address += "/SSI/info_configuration.htm";
            LogHelper.WriteLine($"  Connecting to {address}");

            var contents = webClient.DownloadString(address);
            LogHelper.WriteToFile($"{device} {Now:yyyyMMddHHmmss}.txt", contents);

            var i = contents.IndexOf(search1, StringComparison.Ordinal);
            if (i >= 0)
            {
                var s1 = contents.Substring(i);
                var n = s1.IndexOf(search2, StringComparison.Ordinal);
                if (n >= 0)
                {
                    var s2 = s1.Substring(n + search2.Length);
                    return s2.Substring(0, s2.IndexOf("</td>", StringComparison.Ordinal));
                }
            }
            return "";
        }

        private static string HpLaserJetP3015(string device, string address)
        {
            const string search1 = @"<caption class=""hpTableCaption"" id=""msg-1847"">";
            const string search2 = @"<div class=""hpPageText"">";

            var webClient = new WebClient { Encoding = Encoding.UTF8 };
            webClient.Headers.Add("Accept-Language:en-US,en");
            address += "/hp/device/this.LCDispatcher?nav=hp.Usage";
            LogHelper.WriteLine($"  Connecting to {address}");

            var contents = webClient.DownloadString(address);
            LogHelper.WriteToFile($"{device} {Now:yyyyMMddHHmmss}.txt", contents);

            var i = contents.IndexOf(search1, StringComparison.Ordinal);
            if (i >= 0)
            {
                var s1 = contents.Substring(i);
                var n = s1.IndexOf(@"</table>", StringComparison.Ordinal);
                if (n >= 0)
                {
                    var s2 = s1.Substring(0, n);
                    var m = s2.IndexOf(search2, StringComparison.Ordinal);
                    while (m > -1)
                    {
                        s2 = s2.Substring(m + search2.Length);
                        m = s2.IndexOf(search2, StringComparison.Ordinal);
                    }
                    return s2.Substring(0, s2.IndexOf("</div>", StringComparison.Ordinal)).Replace(",", "");
                }
            }
            return "";
        }

        private static string HpLaserJetP2055(string device, string address)
        {
            const string search1 = @"<td class=""labelFont"">Всего напечатано страниц:</td>";
            const string search2 = @"<td class=""itemFont"">";

            var webClient = new WebClient { Encoding = Encoding.UTF8 };
            webClient.Headers.Add("Accept-Language:en-US,en");
            address += "/hp/device/info_configuration.htm";
            LogHelper.WriteLine($"  Connecting to {address}");

            var contents = webClient.DownloadString(address);
            LogHelper.WriteToFile($"{device} {Now:yyyyMMddHHmmss}.txt", contents);

            var i = contents.IndexOf(search1, StringComparison.Ordinal);
            if (i >= 0)
            {
                var s = contents.Substring(i);
                var n = s.IndexOf(search2, StringComparison.Ordinal);
                if (n >= 0)
                {
                    var s2 = s.Substring(n + search2.Length);
                    return s2.Substring(0, s2.IndexOf("</td>", StringComparison.Ordinal));
                }
            }
            return "";
        }

        private static string HpLaserJet4250(string device, string address)
        {
            const string search1 = @"TOTAL PRINTER USAGE";
            const string search2 = @"<span  class=""hpPageText"" >";

            var webClient = new WebClient { Encoding = Encoding.UTF8 };
            webClient.Headers.Add("Accept-Language:en-US,en");
            address += "/hp/device/this.LCDispatcher?nav=hp.Usage";
            LogHelper.WriteLine($"  Connecting to {address}");

            var contents = webClient.DownloadString(address);
            LogHelper.WriteToFile($"{device} {Now:yyyyMMddHHmmss}.txt", contents);

            var i = contents.IndexOf(search1, StringComparison.Ordinal);
            if (i >= 0)
            {
                var s1 = contents.Substring(i);
                var n = s1.IndexOf(search2, StringComparison.Ordinal);
                if (n >= 0)
                {
                    var s2 = s1.Substring(n + search2.Length);
                    return s2.Substring(0, s2.IndexOf("</span>", StringComparison.Ordinal));
                }
            }
            return "";
        }

        private static string HpLaserJetM525(string device, string address)
        {
            const string search = @"<td id=""UsagePage.EquivalentImpressionsTable.Print.Total"" class=""align-right"">";

            var webClient = new WebClient { Encoding = Encoding.UTF8 };
            webClient.Headers.Add("Accept-Language:en-US,en");
            address += "/hp/device/InternalPages/Index?id=UsagePage";
            LogHelper.WriteLine($"  Connecting to {address}");

            var contents = webClient.DownloadString(address);
            LogHelper.WriteToFile($"{device} {Now:yyyyMMddHHmmss}.txt", contents);

            var i = contents.IndexOf(search, StringComparison.Ordinal);
            if (i >= 0)
            {
                var s = contents.Substring(i + search.Length);
                return s.Substring(0, s.IndexOf("</td>", StringComparison.Ordinal)).Replace(",", "");
            }
            return "";
        }

        private static string HpLaserJetM521(string device, string address)
        {
            const string search1 = "Всего экв. оттисков (A4/Letter):";
            const string search2 = @"<td class=""itemFont"">";

            var webClient = new WebClient { Encoding = Encoding.UTF8 };
            webClient.Headers.Add("Accept-Language:en-US,en");
            address += "/info_configuration.html";
            LogHelper.WriteLine($"  Connecting to {address}");

            var contents = webClient.DownloadString(address);
            LogHelper.WriteToFile($"{device} {Now:yyyyMMddHHmmss}.txt", contents);

            var i = contents.IndexOf(search1, StringComparison.Ordinal);
            if (i >= 0)
            {
                var s1 = contents.Substring(i);
                var n = s1.IndexOf(search2, StringComparison.Ordinal);
                if (n >= 0)
                {
                    var s2 = s1.Substring(n + search2.Length);
                    return s2.Substring(0, s2.IndexOf("</td>", StringComparison.Ordinal));
                }
            }
            return "";
        }

        private static string EpsonL655(string device, string address)
        {
            const string search1 = "Total Number of Pages&nbsp;:";
            const string search2 = @"<div class=""preserve-white-space"">";

            var webClient = new WebClient { Encoding = Encoding.UTF8 };
            webClient.Headers.Add("Accept-Language:en-US,en");
            address += "/PRESENTATION/ADVANCED/INFO_MENTINFO/TOP";
            LogHelper.WriteLine($"  Connecting to {address}");

            var contents = webClient.DownloadString(address);
            LogHelper.WriteToFile($"{device} {Now:yyyyMMddHHmmss}.txt", contents);

            var i = contents.IndexOf(search1, StringComparison.Ordinal);
            if (i >= 0)
            {
                var s1 = contents.Substring(i);
                var n = s1.IndexOf(search2, StringComparison.Ordinal);
                if (n >= 0)
                {
                    var s2 = s1.Substring(n + search2.Length);
                    return s2.Substring(0, s2.IndexOf("</div>", StringComparison.Ordinal));
                }
            }
            return "";
        }

        private static bool ContainsWords(string str, params string[] words)
        {
            if (string.IsNullOrEmpty(str))
            {
                return false;
            }

            return words.All(word => str.IndexOf(word, StringComparison.OrdinalIgnoreCase) != -1);
        }
    }
}
