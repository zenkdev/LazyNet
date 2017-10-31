// Developer Express Code Central Example:
// How to create an IP address editor with the capability of cycling through every part of an IP address
// 
// If you need an IP address editor with a spin edit capable to change values in
// cycle from 0 to 255 for every single part of an IP address this example explains
// how to obtain it. This editor corresponds to a descendant of the TimeEdit
// control and its behavior is based on storing an IP address as a value of type
// DateTime. The IP address is simply transformed to a value of type Int64 and
// assigned to the Ticks property of the DateTime value. The ability to cycle
// through IP address parts is achieved by assigning a mask of type "d.h.m.s" (Day,
// Hour, Minute, Second) and changing the low and high cycle bounds in theTimeEdit
// descendant to 0 and 255 respectively.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E2443

// Developer Express Code Central Example:
// How to create an IP address editor with the capability of cycling through every part of an IP address
// 
// If you need an IP address editor with a spin edit capable to change values in
// cycle from 0 to 255 for every single part of an IP address this example explains
// how to obtain it. This editor corresponds to a descendant of the TimeEdit
// control and its behavior is based on storing an IP address as a value of type
// DateTime. The IP address is simply transformed to a value of type Int64 and
// assigned to the Ticks property of the DateTime value. The ability to cycle
// through IP address parts is achieved by assigning a mask of type "d.h.m.s" (Day,
// Hour, Minute, Second) and changing the low and high cycle bounds in theTimeEdit
// descendant to 0 and 255 respectively.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E2443

using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using DevExpress.Data.Mask;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Registrator;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;

namespace Dekart.LazyNet
{
    [ToolboxItem(true)]
    public class IPAddressEdit : TimeEdit
    {
        static IPAddressEdit()
        {
            RepositoryItemIPAddressEdit.Register();
        }
        public IPAddressEdit()
        {
            fOldEditValue = fEditValue = new DateTime(0);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new RepositoryItemIPAddressEdit Properties
        {
            get
            {
                return base.Properties as RepositoryItemIPAddressEdit;
            }
        }
        public override string EditorTypeName
        {
            get
            {
                return RepositoryItemIPAddressEdit.IPAddressEditName;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override object EditValue
        {
            get
            {
                if (Properties.ExportMode == ExportMode.DisplayText)
                    return Properties.GetDisplayText(null, base.EditValue);

                if (base.EditValue is DateTime && IPAddressHelper.IsConvertible((DateTime)base.EditValue))
                    return IPAddressHelper.ToIPAddress((DateTime)base.EditValue);

                if (base.EditValue is IPv4Addr)
                    return base.EditValue;

                // ReSharper disable once CanBeReplacedWithTryCastAndCheckForNull
                if (base.EditValue is string)
                    return new IPv4Addr((string)base.EditValue);

                return IPv4Addr.Empty;
            }
            set
            {
                if (value is IPv4Addr)
                    base.EditValue = value;
                else
                {
                    var str = value as string;
                    if (!string.IsNullOrEmpty(str))
                        base.EditValue = new IPv4Addr(str);
                    else if (value is DateTime && IPAddressHelper.IsConvertible((DateTime)value))
                        base.EditValue = IPAddressHelper.ToIPAddress((DateTime)value);
                    else
                        base.EditValue = IPv4Addr.Empty;
                }
            }
        }
        [Browsable(false)]
        public new DateTime Time
        {
            get
            {
                return base.Time;
            }
            set
            {
                base.Time = value;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string IPAddress
        {
            get
            {
                var str = EditValue.ToString();
                return str == IPv4Addr.Empty.ToString() ? "" : str;
            }
            set { EditValue = value; }
        }

        protected override MaskManager CreateMaskManager(MaskProperties mask)
        {
            var patchedMask = new IPAddressEditMaskProperties();
            patchedMask.Assign(mask);
            patchedMask.EditMask = Properties.GetFormatMaskAccessFunction(mask.EditMask, mask.Culture);

            return patchedMask.CreatePatchedMaskManager();
        }
    }

    public class RepositoryItemIPAddressEdit : RepositoryItemTimeEdit
    {
        internal const string IPAddressEditName = "IPAddressEdit";

        static RepositoryItemIPAddressEdit()
        {
            Register();
        }
        public RepositoryItemIPAddressEdit()
        {
            // ReSharper disable once DoNotCallOverridableMethodsInConstructor
            UpdateFormats();
        }

        public static void Register()
        {
            EditorRegistrationInfo.Default.Editors.Add(new EditorClassInfo(IPAddressEditName,
              typeof(IPAddressEdit), typeof(RepositoryItemIPAddressEdit),
                typeof(BaseSpinEditViewInfo), new ButtonEditPainter(), true));
        }

        public override string EditorTypeName
        {
            get
            {
                return IPAddressEditName;
            }
        }

        [Browsable(false)]
        public override FormatInfo EditFormat
        {
            get
            {
                return base.EditFormat;
            }
        }
        [Browsable(false)]
        public override FormatInfo DisplayFormat
        {
            get
            {
                return base.DisplayFormat;
            }
        }
        [Browsable(false)]
        public override MaskProperties Mask
        {
            get
            {
                return base.Mask;
            }
        }
        [Browsable(false)]
        public new virtual string EditMask
        {
            get
            {
                return "d.h.m.s";
            }
        }

        protected override bool IsEmptyValue(object editValue)
        {
            if (IPv4Addr.Empty.Equals(editValue))
                return true;
            return base.IsEmptyValue(editValue);
        }

        protected virtual void UpdateFormats()
        {
            EditFormat.FormatString = EditMask;
            DisplayFormat.FormatString = EditMask;
            Mask.EditMask = EditMask;
        }
        public override string GetDisplayText(FormatInfo format, object editValue)
        {
            if (editValue is DateTime && IPAddressHelper.IsConvertible((DateTime)editValue))
                return IPAddressHelper.ToIPAddress((DateTime)editValue).ToString();

            if (editValue is IPv4Addr || editValue is string)
                return editValue.ToString();

            return GetDisplayText(null, IPv4Addr.Empty);
        }
        protected internal virtual string GetFormatMaskAccessFunction(string editMask, CultureInfo managerCultureInfo)
        {
            return GetFormatMask(editMask, managerCultureInfo);
        }
    }

    public static class IPAddressHelper
    {
        public static DateTime ToDateTime(IPv4Addr ip)
        {
            byte[] ipParts = ip.ToByteArray();
            string ipStr = ipParts.Aggregate("", (current, t) => current + string.Format("{0:d3}", t));

            return new DateTime(long.Parse(ipStr));
        }
        public static long ToInt64(IPv4Addr ip)
        {
            byte[] ipParts = ip.ToByteArray();
            return ipParts.Aggregate<byte, long>(0, (current, t) => (current << 8) + t);
        }

        public static IPv4Addr ToIPAddress(DateTime dt)
        {
            if (dt.Ticks == 0)
                return IPv4Addr.Empty;

            string ip = "";

            string strIP = dt.Ticks.ToString();
            while (strIP.Length < 12)
                strIP = "0" + strIP;

            while (strIP != "")
            {
                ip += short.Parse(strIP.Substring(0, 3)) + ".";
                strIP = strIP.Remove(0, 3);
            }
            ip = ip.Remove(ip.Length - 1);

            return new IPv4Addr(ip);
        }

        public static bool IsConvertible(DateTime dt)
        {
            if (dt.Ticks > 255255255255)
                return false;

            return true;
        }
    }

    // ReSharper disable once InconsistentNaming
    public class IPv4Addr
    {
        private readonly byte _ip1;
        private readonly byte _ip2;
        private readonly byte _ip3;
        private readonly byte _ip4;

        public IPv4Addr()
        {
            _ip1 = 0;
            _ip2 = 0;
            _ip3 = 0;
            _ip4 = 0;
        }
        public IPv4Addr(string ipAddress)
        {
            string[] ip = ipAddress.Split('.');

            _ip1 = Convert.ToByte(ip[0]);
            _ip2 = Convert.ToByte(ip[1]);
            _ip3 = Convert.ToByte(ip[2]);
            _ip4 = Convert.ToByte(ip[3]);
        }
        public IPv4Addr(byte addressPart1, byte addressPart2, byte addressPart3, byte addressPart4)
        {
            _ip1 = addressPart1;
            _ip2 = addressPart2;
            _ip3 = addressPart3;
            _ip4 = addressPart4;
        }

        public override string ToString()
        {
            return String.Format("{0}.{1}.{2}.{3}", _ip1, _ip2, _ip3, _ip4);
        }

        public string[] ToStringArray()
        {
            return new[] { _ip1.ToString(), _ip2.ToString(), _ip3.ToString(), _ip4.ToString() };
        }

        public byte[] ToByteArray()
        {
            return new[] { _ip1, _ip2, _ip3, _ip4 };
        }

        public override bool Equals(object obj)
        {
            if (obj is IPv4Addr)
                return ToString() == obj.ToString();
            // ReSharper disable once CanBeReplacedWithTryCastAndCheckForNull
            if (obj is string)
                return ToString() == (string)obj;
            if (obj is DateTime && IPAddressHelper.IsConvertible((DateTime)obj))
                return ToString() == IPAddressHelper.ToIPAddress((DateTime)obj).ToString();
            return false;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static IPv4Addr Empty = new IPv4Addr(0, 0, 0, 0);
    }

    public class IPAddressEditMaskProperties : TimeEditMaskProperties
    {
        public virtual MaskManager CreatePatchedMaskManager()
        {
            var managerCultureInfo = Culture ?? CultureInfo.CurrentCulture;
            var editMask = EditMask ?? string.Empty;

            return new IPAddressMaskManager(editMask, false, managerCultureInfo, true);
        }
    }

    public class IPAddressMaskManager : DateTimeMaskManagerCore
    {
        public IPAddressMaskManager(string mask, bool isOperatorMask, CultureInfo culture, bool allowNull)
            : base(mask, isOperatorMask, culture, allowNull)
        {
            fFormatInfo = new IPAddressMaskFormatInfo(mask, fInitialDateTimeFormatInfo);
        }

        public override void SetInitialEditText(string initialEditText)
        {
            KillCurrentElementEditor();
            DateTime? initialEditValue = new DateTime(0);

            if (!string.IsNullOrEmpty(initialEditText))
                try
                {
                    initialEditValue = IPAddressHelper.ToDateTime(new IPv4Addr(initialEditText));
                }
                catch
                {
                    // ignored
                }

            SetInitialEditValue(initialEditValue);
        }
    }

    public class IPAddressMaskFormatInfo : DateTimeMaskFormatInfo
    {
        public IPAddressMaskFormatInfo(string mask, DateTimeFormatInfo dateTimeFormatInfo)
            : base(mask, dateTimeFormatInfo)
        {
            for (int i = 0; i < Count; i++)
            {
                if (innerList[i] is DateTimeMaskFormatElement_d)
                    innerList[i] = new IPAddressMaskFormatElement("d", dateTimeFormatInfo, 1);

                if (innerList[i] is DateTimeMaskFormatElement_h12)
                    innerList[i] = new IPAddressMaskFormatElement("h", dateTimeFormatInfo, 2);

                if (innerList[i] is DateTimeMaskFormatElement_Min)
                    innerList[i] = new IPAddressMaskFormatElement("m", dateTimeFormatInfo, 3);

                if (innerList[i] is DateTimeMaskFormatElement_s)
                    innerList[i] = new IPAddressMaskFormatElement("s", dateTimeFormatInfo, 4);
            }
        }
    }

    public class IPAddressMaskFormatElement : DateTimeNumericRangeFormatElementEditable
    {
        readonly int _ipAddressPart;

        public IPAddressMaskFormatElement(string mask, DateTimeFormatInfo datetimeFormatInfo, int ipAddressPartNumber)
            : base(mask, datetimeFormatInfo, DateTimePart.Time)
        {
            _ipAddressPart = ipAddressPartNumber - 1;
        }

        public override DateTimeElementEditor CreateElementEditor(DateTime editedDateTime)
        {
            return new DateTimeNumericRangeElementEditor(GetIpAddressPart(editedDateTime, _ipAddressPart), 0, 255, 1, 3);
        }

        public override DateTime ApplyElement(int result, DateTime editedDateTime)
        {
            string[] ipSplitted = IPAddressHelper.ToIPAddress(editedDateTime).ToStringArray();

            for (int i = 0; i < ipSplitted.Length; i++)
            {
                if (i == _ipAddressPart)
                    ipSplitted[i] = String.Format("{0:d3}", result);
                else
                    ipSplitted[i] = String.Format("{0:d3}", Convert.ToInt16(ipSplitted[i]));
            }

            return IPAddressHelper.ToDateTime(new IPv4Addr(String.Join(".", ipSplitted)));
        }

        public override string Format(DateTime formattedDateTime)
        {
            return GetIpAddressPart(formattedDateTime, _ipAddressPart).ToString();
        }

        protected virtual int GetIpAddressPart(DateTime dt, int partNumber)
        {
            if (partNumber < 0 || partNumber > 3)
                throw new Exception("Given part number is out of IPv4 address parts");

            string[] ipSplitted = IPAddressHelper.ToIPAddress(dt).ToStringArray();
            return Convert.ToInt16(ipSplitted[partNumber]);
        }
    }
}
