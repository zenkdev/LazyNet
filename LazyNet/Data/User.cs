using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using Dekart.LazyNet.Helpers;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

namespace Dekart.LazyNet
{
    /// <summary>User</summary>
    public class User : LazyNetBaseObject
    {
        /// <summary>ctor</summary>
        public User() : base(Session.DefaultSession) { }
        /// <summary>ctor</summary>
        public User(Session session) : base(session) { }

        /// <summary> Gets or sets the department </summary>
        [Size(200), Display(Name = @"Отдел")]
        public string Department
        {
            get { return GetPropertyValue<string>("Department"); }
            set { SetPropertyValue("Department", value); }
        }

        /// <summary> Gets or sets the title </summary>
        [Size(200), Display(Name = @"Должность")]
        public string Title
        {
            get { return GetPropertyValue<string>("Title"); }
            set { SetPropertyValue("Title", value); }
        }

        /// <summary>
        /// Gets or set user first name
        /// </summary>
        [Display(Name = @"Имя"), Size(100)]
        public string FirstName
        {
            get { return GetPropertyValue<string>("FirstName"); }
            set { SetPropertyValue("FirstName", value); }
        }

        /// <summary>
        /// Gets or set user middle name
        /// </summary>
        [Display(Name = @"Инициалы"), Size(50)]
        public string MiddleName
        {
            get { return GetPropertyValue<string>("MiddleName"); }
            set { SetPropertyValue("MiddleName", value); }
        }

        /// <summary>
        /// Gets or set user last name
        /// </summary>
        [Display(Name = @"Фамилия"), Size(100)]
        public string LastName
        {
            get { return GetPropertyValue<string>("LastName"); }
            set { SetPropertyValue("LastName", value); }
        }

        /// <summary>
        /// Gets or set user full name
        /// </summary>
        [Display(Name = @"Полное имя"), Size(250)]
        public string FullName
        {
            get { return GetPropertyValue<string>("FullName"); }
            set { SetPropertyValue("FullName", value); }
        }

        /// <summary> Gets or sets user name </summary>
        [Indexed(Unique = true), Size(50)]
        public string UserName
        {
            get { return GetPropertyValue<string>("UserName"); }
            set { SetPropertyValue("UserName", value); }
        }

        /// <summary> Gets or sets the password </summary>
        [Size(50)]
        public string Password
        {
            get { return GetPropertyValue<string>("Password"); }
            set { SetPropertyValue("Password", value); }
        }

        /// <summary> Gets or sets the admin flag </summary>
        public bool IsAdmin
        {
            get { return GetPropertyValue<bool>("IsAdmin"); }
            set { SetPropertyValue("IsAdmin", value); }
        }
        /// <summary> Gets or sets the user state </summary>
        [Display(Name = @"Статус")]
        public UserStateEnum UserState
        {
            get { return GetPropertyValue<UserStateEnum>("UserState"); }
            set { SetPropertyValue("UserState", value); }
        }

        /// <summary> Gets or sets the work phone </summary>
        [Size(50)]
        public string WorkPhone
        {
            get { return GetPropertyValue<string>("WorkPhone"); }
            set { SetPropertyValue("WorkPhone", value); }
        }

        /// <summary> Gets or sets the mobile phone </summary>
        [Size(50)]
        public string MobilePhone
        {
            get { return GetPropertyValue<string>("MobilePhone"); }
            set { SetPropertyValue("MobilePhone", value); }
        }

        /// <summary> Gets or sets the email </summary>
        [Display(Name = @"Электронная почта"), Indexed(Unique = true), Size(100)]
        public string Email
        {
            get { return GetPropertyValue<string>("Email"); }
            set { SetPropertyValue("Email", value); }
        }

        /// <summary> Gets or sets the birthday </summary>
        public DateTime? BirthDate
        {
            get { return GetPropertyValue<DateTime?>("BirthDate"); }
            set { SetPropertyValue("BirthDate", value); }
        }

        /// <summary> Gets or sets the gender </summary>
        public UserGender Gender
        {
            get { return GetPropertyValue<UserGender>("Gender"); }
            set { SetPropertyValue("Gender", value); }
        }

        /// <summary> Gets or sets the hire date </summary>
        public DateTime? HireDate
        {
            get { return GetPropertyValue<DateTime?>("HireDate"); }
            set { SetPropertyValue("HireDate", value); }
        }

        /// <summary>Photo</summary>
        [ValueConverter(typeof(ImageValueConverter))]
        public Image Photo
        {
            get { return GetDelayedPropertyValue<Image>("Photo"); }
            set { SetDelayedPropertyValue("Photo", value); }
        }

        /// <summary> Note </summary>
        [Size(SizeAttribute.Unlimited)]
        public string Note
        {
            get { return GetPropertyValue<string>("Note"); }
            set { SetPropertyValue("Note", value); }
        }

        [Aggregated, DevExpress.Xpo.Association("User-Device", typeof(Device))]
        public XPCollection<Device> Devices
        {
            get
            {
                var collection = GetCollection<Device>("Devices");
                collection.DeleteObjectOnRemove = false;
                return collection;
            }
        }

        public Image PhotoExists
        {
            get
            {
                if (Photo == null) return ImagesHelper.UnknownUser;
                return Photo;
            }
        }

        public override bool AllowDelete { get { return false; } }

        /// <summary> Safe deletes object </summary>
        public override bool SafeDelete()
        {
            UserState = UserStateEnum.Terminated;
            Save();
            return true;
        }

        public override string ObjectName { get { return FullName; } }

    }

    public enum UserGender { Male = 0, Female = 1 }

    public enum UserStateEnum
    {
        [Display(Name = @"Штатный")]
        Salaried = 0,
        [Display(Name = @"В отпуске")]
        OnLeave = 1,
        [Display(Name = @"Внештатный")]
        Freelancer = 2,
        [Display(Name = @"Уволен")]
        Terminated = 10
    }

}
