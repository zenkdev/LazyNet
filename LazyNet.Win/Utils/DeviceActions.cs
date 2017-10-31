using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Dekart.LazyNet.Helpers;
using DevExpress.Data.Filtering;
using DevExpress.Xpo;

namespace Dekart.LazyNet.Win
{
    public static class DeviceActions
    {
        public static void SaveAsRemoteOfficeAddressBook(Stream stream)
        {
            try
            {
                var session = new Session();

                using (var writer = new XmlTextWriter(stream, Encoding.Unicode))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("address_book");
                    writer.WriteAttributeString("version", "4602");
                    writer.WriteStartElement("groups");

                    SaveRemoteOfficeGroup(DataHelper.GetRoomDataItems(session), 0, writer);

                    writer.WriteEndElement();

                    writer.WriteStartElement("connections");

                    foreach (var computer in new XPCollection<Device>(session, CriteriaOperator.Parse("DeletionMark=0 And DeviceType=?", DeviceTypeEnum.Computer)))
                    {
                        writer.WriteStartElement("connection");
                        writer.WriteAttributeString("parent_group_id", String.Format("{{{0}}}", computer.Room.Oid));

                        writer.WriteElementString("Caption", computer.ObjectName);
                        writer.WriteElementString("PeerIP", computer.IP);
                        writer.WriteElementString("PeerHost", computer.HostName);
                        writer.WriteElementString("Port", "5650");
                        writer.WriteElementString("RenderMode", "1");
                        writer.WriteElementString("CPUUsage", "0"); // Низкая
                        writer.WriteElementString("ColorDepth", "5");
                        writer.WriteElementString("Pwd", "+H84dUqgG0k");
                        writer.WriteElementString("AdvMouseSroll", "true");
                        writer.WriteElementString("ConstProportions", "true");
                        writer.WriteElementString("SavePass", "false");
                        writer.WriteElementString("AutoLogin", "false");
                        writer.WriteElementString("Flags", "0");
                        writer.WriteElementString("ChacheMode", "0");
                        writer.WriteElementString("LocalCursorMode", "0");
                        writer.WriteElementString("RemoteCursorMode", "0");
                        writer.WriteElementString("UseCascadeConnect", "false");
                        writer.WriteElementString("CascadeHost", "");
                        writer.WriteElementString("InternalID", String.Format("{{{0}}}", computer.Oid));
                        writer.WriteElementString("LoginList", "");
                        writer.WriteElementString("DomainList", "");
                        writer.WriteElementString("blank_screen_text", "");
                        writer.WriteElementString("fps", "15");
                        writer.WriteElementString("allow_callback", "false");
                        writer.WriteElementString("mac", "");
                        writer.WriteElementString("lock_on_disconnect", "false");
                        writer.WriteElementString("display_index", "-1");
                        writer.WriteElementString("disable_dnd", "false");
                        writer.WriteElementString("window_width", "0");
                        writer.WriteElementString("window_height", "0");
                        writer.WriteElementString("window_left", "0");
                        writer.WriteElementString("window_top", "0");
                        writer.WriteElementString("rdp_user", "");
                        writer.WriteElementString("rdp_password", "");
                        writer.WriteElementString("rdp_save_password", "false");
                        writer.WriteElementString("rdp_screen_width", "800");
                        writer.WriteElementString("rdp_screen_height", "600");
                        writer.WriteElementString("rdp_color_mode", "16");
                        writer.WriteElementString("rdp_full_screen", "false");
                        writer.WriteElementString("rdp_themes", "false");
                        writer.WriteElementString("rdp_allow_animation", "false");
                        writer.WriteElementString("rdp_bitmap_caching", "false");
                        writer.WriteElementString("rdp_desktop_background", "false");
                        writer.WriteElementString("rdp_show_window_content", "false");
                        writer.WriteElementString("rdp_port", "3389");
                        writer.WriteElementString("rdp_stretch", "false");
                        writer.WriteElementString("rdp_host", "");
                        writer.WriteElementString("SpinToolbar", "false");
                        writer.WriteElementString("FastCloseWindow", "true");
                        writer.WriteElementString("ShowFPS", "true");
                        writer.WriteElementString("NoIpServer", "false");
                        writer.WriteElementString("NoIpId", "");
                        writer.WriteElementString("NoipUseMainNoIP", "false");
                        writer.WriteElementString("black_screen_text_color", "16777215");
                        writer.WriteElementString("black_screen_text_size", "14");
                        writer.WriteElementString("black_screen_text_horalign", "1");
                        writer.WriteElementString("black_screen_text_veralign", "2");
                        writer.WriteElementString("black_screen_lock_control", "false");
                        writer.WriteElementString("view_only_disable_lock", "false");
                        writer.WriteElementString("sort_index", "0");
                        writer.WriteElementString("comment_text", computer.PlainText);
                        writer.WriteElementString("comment_registry", "false");
                        writer.WriteElementString("ftp_local_last_path", "");
                        writer.WriteElementString("ftp_remote_last_path", "");
                        writer.WriteElementString("capture_sound", "false");
                        writer.WriteElementString("sound_volume", "25");
                        writer.WriteElementString("av_mode", "0");
                        writer.WriteElementString("av_device_audio", "true");
                        writer.WriteElementString("av_device_video", "false");
                        writer.WriteElementString("av_quality", "0");
                        writer.WriteElementString("av_minimize_window", "false");
                        writer.WriteElementString("av_show_local_video_source", "false");
                        writer.WriteElementString("av_show_remote_video_source", "false");
                        writer.WriteElementString("user_name_list", "");
                        writer.WriteElementString("enable_user_name", "false");
                        writer.WriteElementString("cur_user_index", "-1");
                        writer.WriteElementString("av_auto_connect_on_open", "false");
                        writer.WriteElementString("set_timer_start_timer", "30.12.1899");
                        writer.WriteElementString("set_timer_message", "");
                        writer.WriteElementString("set_timer_no_close_on_top", "false");
                        writer.WriteElementString("server_version", "0");
                        writer.WriteElementString("WindowCoordInited", "false");
                        writer.WriteElementString("DoNotSaveWindowPos", "false");
                        writer.WriteElementString("HideErrorMessages", "false");
                        writer.WriteElementString("FullScreenModeToAllMonitors", "false");
                        writer.WriteElementString("pinsession", "false");
                        writer.WriteElementString("pinsessionname", "");
                        writer.WriteElementString("ipv6", "false");
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();


                    writer.WriteEndElement();
                    writer.WriteEndDocument();

                    writer.Flush();
                }
            }
            catch (Exception exc)
            {
                Logger.Error(exc.Message, exc);
            }
        }

        public static void SaveAsRadminPhoneBook(Stream stream)
        {
            const int recordSizeBytes = 6138; // Размер одной записи
            const int blockSize = 128; // Количество записей в блоке

            var count = 0;

            try
            {
                var phoneBook = DataHelper.GetPhoneBook();

                using (var writer = new BinaryWriter(stream))
                {
                    //Вписываем перый бит (Определяющий формат)
                    writer.Write((uint)4);
                    //Количество удаленных записей
                    writer.Write((uint)0);
                    //Вписываем нули (Пока не знаю за что эта секция отвечает)
                    writer.Write((uint)0);
                    //Вписываем в эту секкцию обизательные и не изменные параметры
                    //Размер одной записи
                    writer.Write((uint)recordSizeBytes);
                    //Количество записей в блоке
                    writer.Write((uint)blockSize);
                    //Вписывае количество записей в книге 
                    writer.Write((uint)phoneBook.Count);
                    //Конец заголовка
                    writer.Write((byte)1);

                    foreach (var record in phoneBook)
                    {
                        if (count % blockSize == 0)
                        {
                            //Байты отвечающие за запиши должны равняться 0x01
                            for (var i = 0; i < blockSize; i++)
                            {
                                writer.Write((byte)(count / blockSize * blockSize + i < phoneBook.Count ? 1 : 0));
                            }
                        }
                        record.Write(writer);
                        count++;
                    }

                    writer.Close();
                }
            }
            catch (Exception exc)
            {
                Logger.Error(exc.Message, exc);
            }
        }

        private static void SaveRemoteOfficeGroup(List<RoomDataItem> items, int parent, XmlTextWriter writer)
        {
            var @where = items.Where(i => i.Parent == parent);
            foreach (var dataItem in @where)
            {
                writer.WriteStartElement("group");
                writer.WriteAttributeString("id", String.Format("{{{0}}}", dataItem.Oid));

                var p = items.Where(i => dataItem.Parent> 0 && i.Id == dataItem.Parent).Select(i => (Guid?)i.Oid).FirstOrDefault();
                writer.WriteAttributeString("parent_group_id", p == null ? "" : String.Format("{{{0}}}", p));

                writer.WriteElementString("caption", dataItem.Name);

                writer.WriteEndElement();

                SaveRemoteOfficeGroup(items, dataItem.Id, writer);
            }
        }

        public static bool CanConnect(this Device device)
        {
            return device != null && !(!NetHelper.IsHostNameValid(device.HostName) && !NetHelper.IsIPAddressValid(device.IP));
        }

        public static void OpenWeb(this Device device)
        {
            if (!CanConnect(device)) return;

            var str = device.HostName;
            if (!NetHelper.IsHostNameValid(str))
            {
                str = device.IP;
                if (!NetHelper.IsIPAddressValid(str)) return;
            }

            ObjectHelper.ShowWebSite(String.Format("http://{0}", str));
        }

        public static void Ping(this Device device)
        {
            if (!CanConnect(device)) return;

            var str = device.HostName;
            if (!NetHelper.IsHostNameValid(str))
            {
                str = device.IP;
                if (!NetHelper.IsIPAddressValid(str)) return;
            }

            var process = new Process
            {
                StartInfo = { FileName = "cmd.exe", Arguments = String.Format("/k ping {0}", str) }
            };
            process.Start();
        }

        public static void Tracert(this Device device)
        {
            if (!CanConnect(device)) return;

            var str = device.HostName;
            if (!NetHelper.IsHostNameValid(str))
            {
                str = device.IP;
                if (!NetHelper.IsIPAddressValid(str)) return;
            }

            var process = new Process
            {
                StartInfo = { FileName = "cmd.exe", Arguments = String.Format("/k tracert {0}", str) }
            };
            process.Start();
        }

        public static void OpenMstsc(this Device device)
        {
            if (!CanConnect(device)) return;

            var str = device.HostName;
            if (!NetHelper.IsHostNameValid(str))
            {
                str = device.IP;
                if (!NetHelper.IsIPAddressValid(str)) return;
            }

            var process = new Process
            {
                StartInfo =
                {
                    FileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "mstsc.exe"),
                    Arguments = String.Format("/v {0}", str)
                }
            };
            process.Start();
        }

        public static void OpenRadmin(this Device device)
        {
            if (!CanConnect(device)) return;

            var str = device.HostName;
            if (!NetHelper.IsHostNameValid(str))
            {
                str = device.IP;
                if (!NetHelper.IsIPAddressValid(str)) return;
            }

            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), @"Radmin Viewer 3\Radmin.exe");
            if (!File.Exists(path))
                path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"Radmin Viewer 3\Radmin.exe");
            var process = new Process
            {
                StartInfo =
                {
                    FileName = path,
                    Arguments = String.Format("/connect:{0}", str)
                }
            };
            process.Start();
        }

        public static void OpenRomViewer(this Device device)
        {
            if (!CanConnect(device)) return;

            var str = device.HostName;
            if (!NetHelper.IsHostNameValid(str))
            {
                str = device.IP;
                if (!NetHelper.IsIPAddressValid(str)) return;
            }

            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), @"LiteManager Pro - Viewer\ROMViewer.exe");
            if (!File.Exists(path))
                path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"LiteManager Pro - Viewer\ROMViewer.exe");
            var process = new Process
            {
                StartInfo =
                {
                    FileName = path,
                    Arguments = String.Format("/name:{0} /fullcontrol", str)
                }
            };
            process.Start();
        }
    }
}
