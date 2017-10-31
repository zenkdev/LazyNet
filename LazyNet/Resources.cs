using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.XtraTreeList.Nodes;

namespace Dekart.LazyNet
{
    public static class TagResources
    {
        public const string Devices = "Devices";
        public const string NewDevice = "NewDevice";
        public const string FindDevices = "ScanNetwork";
        public const string OpenWeb = "OpenWeb";
        public const string OpenRadmin = "OpenRadmin";
        public const string OpenRomViewer = "OpenRomViewer";
        public const string OpenMstsc = "OpenMstsc";
        public const string Ping = "Ping";
        public const string Tracert = "Tracert";
        public const string SystemInfo = "SystemInfo";

        public const string Maps = "Maps";
        public const string BringToFront = "BringToFront";
        public const string SendToBack = "SendToBack";
        public const string MapBackground = "MapBackground";

        public const string Users = "Users";
        public const string NewUser = "NewUser";

        public const string Repairs = "Repairs";
        public const string NewRepair = "NewRepair";

        public const string Software = "Software";
        public const string NewSoftware = "NewSoftware";

        public const string DeleteItem = "DeleteItem";
        public const string EditItem = "EditItem";

        public const string UserEdit = "UserEdit";

        public const string ShowList = "ShowList";
        public const string ShowCards = "ShowCards";

        public const string CloseSearch = "CloseSearch";
        public const string ClearFilter = "ClearFilter";
        public const string NameColumn = "NameColumn";
        public const string SKUColumn = "SKUColumn";
        public const string SerialColumn = "SerialColumn";
        public const string UserColumn = "UserColumn";
        public const string IPColumn = "IPColumn";
        public const string MACColumn = "MACColumn";
        public const string ResetColumnsToDefault = "ResetColumns";
        public const string DateFilterMenu = "DateFilterMenu";

        public const string MenuSaveAs = "SaveAs";
        public const string SearchTools = "SearchTools";
    }

    public class DragSelection
    {
        public int[] Rows;
    }

    public enum FolderPaneVisibilityEnum
    {
        Normal,
        Minimized,
        Off
    }

    public enum DataPaneStateEnum
    {
        Right = 0,
        Bottom = 1,
        Off = 2
    }
    public enum DragCursorTypeEnum
    {
        None,
        Copy,
        Move,
        Delete
    }

    /// <summary>Close detail form delegate</summary>
    public delegate void CloseDetailForm(DialogResult result);

    /// <summary>Get session callback delegate</summary>
    public delegate UnitOfWork GetSessionCallback();

    public delegate void DataSourceChangedEventHandler(object sender, DataSourceChangedEventArgs e);
    
    public class DataSourceChangedEventArgs : EventArgs
    {
        public DataSourceChangedEventArgs(string caption, object data, int? count = null)
        {
            Caption = caption;
            Data = data;
            Count = count;
        }
        public string Caption { get; }
        public object Data { get; }
        public int? Count { get; }
    }

    public class UcTreeDragDropEventArgs : EventArgs
    {
        public UcTreeDragDropEventArgs(TreeListNode node, DragSelection selection, object data)
        {
            Node = node;
            Selection = selection;
            Data = data;
        }
        public TreeListNode Node { get; private set; }
        public DragSelection Selection { get; private set; }
        public object Data { get; private set; }
    }

    public delegate void UcTreeDragDropEventHandler(object sender, UcTreeDragDropEventArgs e);

    public class RoomDataItem
    {
        public int Id { get; set; }
        public int Parent { get; set; }
        public string Name { get; set; }
        public Guid Oid { get; set; }
        public int Data { get; set; }
    }
    public class MapDataItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid Oid { get; set; }
        public int Data { get; set; }
    }
    public class ImageListBoxItemData
    {
        public ImageListBoxItemData(int id, string name, Image picture)
        {
            Id = id;
            Name = name;
            Picture = picture;
            ImageIndex = -1;
        }
        public int Id { get; private set; }

        public string Name { get; private set; }

        public Image Picture { get; private set; }

        public int ImageIndex { get; set; }
    }
    public class PhotoLibraryItem
    {
        public string Name { get; set; }
        public Image Photo { get; set; }
    }
    public class FindDeviceItem
    {
        public DeviceTypeEnum DeviceType { get; set; }
        public string Name { get; set; }
        public string HostName { get; set; }
        public string IP { get; set; }
        public string MAC { get; set; }
        public string Manufacturer { get; set; }
        public bool UpdateIP { get; set; }
    }
    public class RadminPhoneBookRecord
    {
        private string _voiceChatName;
        private string _voiceChatNameInfo;
        private string _textChatName;
        private string _textChatNameInfo;
        private string _hostName;
        private string _recordName;
        private string _nameHostKerberos;
        public int MaxRefreshScreen { get; set; }
        public RadminPhoneBookScreenMode ScreenMode { get; set; }

        public string VoiceChatName
        {
            get { return _voiceChatName; }
            set
            {
                _voiceChatName = value?.TrimEnd('\x0');
            }
        }

        public string VoiceChatNameInfo
        {
            get { return _voiceChatNameInfo; }
            set
            {
                _voiceChatNameInfo = value?.TrimEnd('\x0');
            }
        }

        public string TextChatName
        {
            get { return _textChatName; }
            set
            {
                _textChatName = value?.TrimEnd('\x0');
            }
        }

        public string TextChatNameInfo
        {
            get { return _textChatNameInfo; }
            set
            {
                _textChatNameInfo = value?.TrimEnd('\x0');

            }
        }

        public string HostName
        {
            get { return _hostName; }
            set
            {
                _hostName = value?.TrimEnd('\x0');

            }
        }

        public string RecordName
        {
            get { return _recordName; }
            set
            {
                _recordName = value?.TrimEnd('\x0');

            }
        }

        public int Port { get; set; }

        public string NameHostKerberos
        {
            get { return _nameHostKerberos; }
            set
            {
                _nameHostKerberos = value?.TrimEnd('\x0');

            }
        }

        public int Id { get; set; }
        public int Parent { get; set; }
        public RadminPhoneBookRecordMode RecordMode { get; set; }
        public static RadminPhoneBookRecord CreateFromReader(BinaryReader reader)
        {
            // ReSharper disable once UseObjectOrCollectionInitializer
            var record = new RadminPhoneBookRecord();
            //Максимальное количество обнавлений раз в сикунду
            record.MaxRefreshScreen = reader.ReadInt32(); // +0000
            //Вид экрана
            record.ScreenMode = (RadminPhoneBookScreenMode)reader.ReadInt32(); // +0004
            //Пустые поля
            reader.ReadBytes(144); // +0008
            //Поле "Имя или псевдомим (Голосовой чат)"
            record.VoiceChatName = Encoding.Unicode.GetString(reader.ReadBytes(64)); // +0152
            //Поле "Информация о пользователе (Голосовой чат)"
            record.VoiceChatNameInfo = Encoding.Unicode.GetString(reader.ReadBytes(1024)); // +0216
            //Поле "Имя или псевдомим (Текстовый чат)"
            record.TextChatName = Encoding.Unicode.GetString(reader.ReadBytes(64)); // +1240
            //Поле "Информация о пользователе (Текстовый чат)"
            record.TextChatNameInfo = Encoding.Unicode.GetString(reader.ReadBytes(1024)); // +1304
            //Пустые поля
            reader.ReadBytes(2576); // +2328
            //Ip адрес или dns имя к катору нужно подключиться
            record.HostName = Encoding.Unicode.GetString(reader.ReadBytes(200)); // +4904
            //Имя записи
            record.RecordName = Encoding.Unicode.GetString(reader.ReadBytes(200)); // +5104
            //Записуем порт
            record.Port = reader.ReadInt32(); // +5304
            //Пустые поля
            reader.ReadBytes(398); // +5308
            //Имя хоста для аутификации по Kerberos
            record.NameHostKerberos = Encoding.Unicode.GetString(reader.ReadBytes(200)); // +5706
            //Пустые поля
            reader.ReadBytes(206); // +5906
            // Код записи
            record.Id = reader.ReadInt32(); // +6112
            //Пустые поля
            reader.ReadInt32(); // +6116
            // Код родителя
            record.Parent = reader.ReadInt32(); // +6120
            // Тип записи
            record.RecordMode = (RadminPhoneBookRecordMode)reader.ReadInt32(); // +6124
            //Пустые поля
            reader.ReadBytes(10); // +6128

            return record;
        }
        public void Write(BinaryWriter writer)
        {
            //Максимальное количество обнавлений раз в сикунду
            writer.Write((uint)MaxRefreshScreen); // +0000
            //Вид экрана
            writer.Write((uint)ScreenMode); // +0004
            //Пустые поля
            writer.Write(new byte[144]); // +0008
            //Поле "Имя или псевдомим (Голосовой чат)"
            WriteString(writer, VoiceChatName, 32); // +0152
            //Поле "Информация о пользователе (Голосовой чат)"
            WriteString(writer, VoiceChatNameInfo, 512); // +0216
            //Поле "Имя или псевдомим (Текстовой чат)"
            WriteString(writer, TextChatName, 32); // +1240
            //Поле "Информация о пользователе (Текстовый чат)"
            WriteString(writer, TextChatNameInfo, 512); // +1304
            //Пустые поля
            writer.Write(new byte[2576]); // +2328
            //Ip адрес или dns имя к катору нужно подключиться
            WriteString(writer, HostName, 100); // +4904
            //Имя записис
            WriteString(writer, RecordName, 100); // +5104
            //Записуем порт
            writer.Write((uint)Port); // +5304
            //Пустые поля
            writer.Write(new byte[398]); // +5308
            //Имя хоста для аутификации по Kerberos
            WriteString(writer, NameHostKerberos, 100); // +5706
            //Пустые поля
            writer.Write(new byte[206]); // +5906
            // Код записи
            writer.Write((uint)Id); // +6112
            //Пустые поля
            writer.Write((uint)0); // +6116
            // Код родителя
            writer.Write((uint)Parent); // +6120
            // Тип записи
            writer.Write((uint)RecordMode); // +6124
            //Пустые поля
            writer.Write(new byte[10]); // +6128
        }

        static void WriteString(BinaryWriter writer, string str, int length)
        {
            str = str ?? "";
            for (var i = 0; i < (length - 1); i++)
            {
                writer.Write(i < str.Length ? (short)str[i] : (short)0);
            }
            writer.Write((short)0);
        }
    }

    // Вид экрана: 0 - обычн, 1 - полн, 2 - с масштаб, 3 - полн с масштаб
    public enum RadminPhoneBookScreenMode
    {
        Default = 0,
        Full = 1,
        Scale = 2,
        FullScale = 3
    }

    public enum RadminPhoneBookRecordMode
    {
        Computer = 0,
        Group = 1
    }
}
