using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using Dekart.LazyNet.Helpers;
using DevExpress.Data.Filtering;
using DevExpress.Utils;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

namespace Dekart.LazyNet
{
    public static class DataHelper
    {
        static User _currentUser;
        /// <summary>
        /// Gets or sets the current user
        /// </summary>
        public static User CurrentUser
        {
            get { return _currentUser; }
            set
            {
                if (Equals(_currentUser, value)) return;
                _currentUser = value;
            }
        }

        /// <summary>
        /// Gets the current user identifier
        /// </summary>
        public static int CurrentUserId { get { return CurrentUser != null ? CurrentUser.Id : 0; } }

        static IDictionary<string, PhotoLibraryItem[]> _photoLibrary;

        public static IDictionary<string, PhotoLibraryItem[]> PhotoLibrary
        {
            get { return _photoLibrary ?? (_photoLibrary = GetPhotoLibrary()); }
        }

        static IDictionary<string, PhotoLibraryItem[]> GetPhotoLibrary()
        {
            // ReSharper disable once CollectionNeverUpdated.Local
            var collection = new XPCollection<PhotoLibrary>();
            var keys = collection.GroupBy(a => a.Group).OrderBy(g => g.Key).Select(g => g.Key).ToList();
            return keys.ToDictionary(key => key, key => collection.Where(b => b.Group == key).OrderBy(b => b.Name).Select(b => new PhotoLibraryItem { Name = b.Name, Photo = b.Photo }).ToArray());
        }

        public static void ResetPhotoLibrary()
        {
            _photoLibrary = null;
        }

        public static object AddDeviceToMap(object map, int id, int x1, int y1, int x2, int y2, Session session)
        {
            var mapToLazyObject = new MapToDevice(session)
            {
                Map = session.GetObjectByKey<Map>(map),
                Device = session.GetObjectByKey<Device>(id),
                X1 = x1,
                Y1 = y1,
                X2 = x2,
                Y2 = y2
            };

            var unitOfWork = session as UnitOfWork;
            if (unitOfWork != null)
            {
                unitOfWork.CommitChanges();
            }

            return mapToLazyObject.Id;
        }

        public static void MoveMapToDevice(object tag, int x1, int y1, int x2, int y2, Session session)
        {
            var mapToLazyObject = session.GetObjectByKey<MapToDevice>(tag);
            mapToLazyObject.X1 = x1;
            mapToLazyObject.Y1 = y1;
            mapToLazyObject.X2 = x2;
            mapToLazyObject.Y2 = y2;

            var unitOfWork = session as UnitOfWork;
            if (unitOfWork != null)
            {
                unitOfWork.CommitChanges();
            }
        }

        public static List<RoomDataItem> GetRoomDataItems(Session session = null)
        {
            if (session == null)
            {
                session = new Session();
            }

            var items = new List<RoomDataItem>
            {
                new RoomDataItem
                {
                    Id = 0,
                    Parent = -1,
                    Name = ConstStrings.All,
                    Oid = Guid.Empty,
                    Data = ToInt32(session.Evaluate<Device>(CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("DeletionMark=0")))
                }
            };

            try
            {
                // ReSharper disable once CollectionNeverUpdated.Local
                var rooms = new XPCollection<Room>(session);
                items.AddRange(from room in rooms
                               where !room.DeletionMark
                               orderby room.SortOrder, room.Name
                               let obj = session.Evaluate<Device>(CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("Room=? And DeletionMark=0", room))
                               select new RoomDataItem
                               {
                                   Id = room.Id,
                                   Parent = room.Parent ?? 0,
                                   Name = room.Name,
                                   Oid = room.Oid,
                                   Data = ToInt32(obj)
                               });
            }
            catch (Exception exc)
            {
                Logger.Error(exc.Message, exc);
            }

            return items;
        }

        public static Room GetRootRoom(Session session = null)
        {
            if (session == null)
            {
                session = new Session();
            }

            var rooms = new XPCollection<Room>(session, CriteriaOperator.Parse("DeletionMark=0"), new SortProperty("Parent", SortingDirection.Ascending))
            {
                TopReturnedObjects = 1
            };

            return rooms.Count == 0 ? CreateNewRoom(null, session) : rooms[0];
        }

        public static Room CreateNewRoom(int? parent, Session session = null)
        {
            if (session == null)
            {
                session = new Session();
            }
            var room = new Room(session) { Parent = parent, Name = ConstStrings.NewRoom };
            room.Save();

            return room;
        }

        public static void UpdateRoom(int id, string name)
        {
            try
            {
                var session = new Session();
                var room = session.GetObjectByKey<Room>(id);
                if (room != null)
                {
                    room.Name = name;
                    room.Save();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public static void UpdateRoom(int id, int? parent)
        {
            try
            {
                var session = new Session();
                var room = session.GetObjectByKey<Room>(id);
                if (room != null)
                {
                    room.Parent = parent;
                    room.Save();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public static void DeleteRoom(int id)
        {
            try
            {
                var session = new Session();
                var room = session.GetObjectByKey<Room>(id);
                if (room != null)
                {
                    room.SafeDelete();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public static List<MapDataItem> GetMapDataItems(Session session = null)
        {
            if (session == null)
            {
                session = new Session();
            }

            var items = new List<MapDataItem>();
            var maps = new XPCollection<Map>(session, null, new SortProperty("Name", SortingDirection.Ascending));

            try
            {
                items.AddRange(from map in maps
                               let obj = session.Evaluate<MapToDevice>(CriteriaOperator.Parse("Count()"), CriteriaOperator.Parse("Map=? And Device.DeletionMark=0", map))
                               select new MapDataItem
                               {
                                   Id = map.Id,
                                   Name = map.Name,
                                   Oid = map.Oid,
                                   Data = ToInt32(obj)
                               });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return items;
        }

        public static List<ImageListBoxItemData> GetMapListBoxItems(Images images, Session session = null)
        {
            if (session == null)
            {
                session = new Session();
            }

            var items = new List<ImageListBoxItemData>();

            try
            {
                var query1 = new XPQuery<Device>(session);
                var query2 = new XPQuery<MapToDevice>(session);
                var devices = (from device in query1
                               join mapToDevice in query2 on device.Id equals mapToDevice.Device.Id
                               where !device.DeletionMark && mapToDevice == null
                               select device)
                    .ToList();

                foreach (var device in devices)
                {
                    var item = new ImageListBoxItemData(device.Id, device.ObjectName, device.PictureExists);
                    item.ImageIndex = images.Add(item.Picture);
                    items.Add(item);
                }
            }
            catch (Exception exc)
            {
                Logger.Error(exc.Message, exc);
            }

            return items;
        }

        public static Map CreateNewMap(Session session = null)
        {
            if (session == null)
            {
                session = new Session();
            }
            var map = new Map(session) { Name = ConstStrings.NewMap };
            map.Save();

            return map;
        }

        public static void UpdateMap(int id, string caption, string filename = null)
        {
            try
            {
                var session = new Session();
                var map = session.GetObjectByKey<Map>(id);
                if (map != null)
                {
                    map.Name = caption;
                    if (!String.IsNullOrEmpty(filename))
                    {
                        map.Picture = Image.FromFile(filename);
                        map.Save();
                    }
                    map.Save();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public static void DeleteMap(int id)
        {
            try
            {
                var session = new Session();
                var room = session.GetObjectByKey<Map>(id);
                if (room != null)
                {
                    room.Delete();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public static List<Manufacturer> GetManufacturers(Session session = null)
        {
            if (session == null)
            {
                session = new Session();
            }

            return new XPCollection<Manufacturer>(session).ToList();
        }

        public const string URL = "https://standards.ieee.org/develop/regauth/oui/oui.txt";

        public static List<Manufacturer> UpdateManufacturers(Session session = null, bool commitChanges = true)
        {
            if (session == null)
            {
                session = new Session();
            }

            var list = GetManufacturers(session);

            var waitHandle = new ManualResetEvent(false);
            var downloader = new FileDownloader();
            downloader.DownloadCompleted += (ss, ee) => waitHandle.Set();
            downloader.Download(URL, Path.GetTempPath());
            waitHandle.WaitOne(15000);

            if (File.Exists(downloader.DownloadingTo))
            {
                var text = File.ReadAllText(downloader.DownloadingTo);
                File.Delete(downloader.DownloadingTo);

                if (!String.IsNullOrEmpty(text))
                {
                    var strings = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    if (strings.Length > 1)
                    {
                        var createdOn = DateTime.Now;
                        foreach (var s in strings)
                        {
                            if (s.Contains("Generated:"))
                            {
                                createdOn = DateTime.Parse(s.Replace("Generated:", "").Trim());
                            }

                            if (s.Contains("(base 16)"))
                            {
                                var compArgs = s.Split(new[] { '\t', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                                var mac = compArgs[0].Replace("(base 16)", "").Trim().ToUpper();
                                var name = compArgs[1].Trim();
                                var manufacturer = list.FirstOrDefault(m => m.MAC == mac);
                                if (manufacturer == null)
                                {
                                    manufacturer = new Manufacturer(session)
                                    {
                                        CreatedOn = createdOn,
                                        MAC = mac,
                                        Name = name
                                    };
                                    manufacturer.Save();
                                    list.Add(manufacturer);
                                }
                            }
                        }
                    }
                }
            }

            var unitOfWork = session as UnitOfWork;
            if (unitOfWork != null && commitChanges)
            {
                unitOfWork.CommitChanges();
            }

            return list;
        }

        public static int ToInt32(object value)
        {
            if (value != null && value != DBNull.Value && !string.IsNullOrEmpty(value.ToString()))
                return Convert.ToInt32(value);
            return 0;
        }

        public static int ToInt32(this Room value)
        {
            if (value != null)
                return value.Id;
            return 0;
        }

        public static string ToString2(this Room value)
        {
            if (value != null)
                return value.Name;
            return string.Empty;
        }
        public static byte[] ToBytes(this Stream stream)
        {
            if (stream is MemoryStream)
                return ((MemoryStream)stream).GetBuffer();
            return null;
        }

        public static List<RadminPhoneBookRecord> GetPhoneBook(Session session = null)
        {
            const int maxRefreshScreen = 25; //Максимальное количество обнавлений раз в сикунду
            const int screenMode = 0; // Вид экрана: 0 - обычн, 1 - полн, 2 - с масштаб, 3 - полн с масштаб
            const string voiceChatName = "User"; //"Имя или псевдомим (Голосовой чат)"
            const string voiceChatNameInfo = ""; //Поле "Информация о пользователе (Голосовой чат)"
            const string textChatName = "User"; //"Имя или псевдомим (Текстовой чат чат)"
            const string textChatNameInfo = ""; //Поле "Информация о пользователе (Голосовой чат)"
            const int port = 4899; //Номер порта по каторуму подключаються
            const string nameHostKerberos = ""; //Имя хоста для аутификации по Kerberos

            if (session == null)
            {
                session = new Session();
            }

            var phoneBook = new List<RadminPhoneBookRecord>();

            foreach (var computer in new XPCollection<Device>(session, CriteriaOperator.Parse("DeletionMark=0 And DeviceType=?", DeviceTypeEnum.Computer)))
            {
                var room = computer.Room;
                AddRoomToPhoneBook(room, phoneBook);

                var record = new RadminPhoneBookRecord
                {
                    MaxRefreshScreen = maxRefreshScreen,
                    ScreenMode = screenMode,
                    VoiceChatName = voiceChatName,
                    VoiceChatNameInfo = voiceChatNameInfo,
                    TextChatName = textChatName,
                    TextChatNameInfo = textChatNameInfo,
                    HostName = computer.HostName ?? computer.IP,
                    RecordName = computer.ObjectName,
                    Port = port,
                    NameHostKerberos = nameHostKerberos,
                    Id = computer.Id + 10000,
                    Parent = room.ToInt32(),
                    RecordMode = RadminPhoneBookRecordMode.Computer
                };

                phoneBook.Add(record);
            }

            return phoneBook;
        }

        static void AddRoomToPhoneBook(Room room, List<RadminPhoneBookRecord> phoneBook)
        {
            if (room == null || phoneBook.Any(pb => pb.Id == room.Id)) return;

            AddRoomToPhoneBook(room.GetParent(), phoneBook);

            var record = new RadminPhoneBookRecord
            {
                RecordName = room.Name,
                Id = room.Id,
                Parent = room.Parent ?? 0,
                RecordMode = RadminPhoneBookRecordMode.Group
            };

            phoneBook.Add(record);
        }
    }
}