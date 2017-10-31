using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.Controls;

namespace Dekart.LazyNet.Helpers
{
    public static class ImagesHelper
    {
        static ImageCollection _deviceImages;
        static ImageCollection _deviceLargeImages;
        static Icon _appIcon;
        static Image _user, _device;

        public static ImageCollection DeviceImages
        {
            get { return _deviceImages ?? (_deviceImages = ImageHelper.CreateImageCollectionFromResources("Dekart.LazyNet.Resources.Images.icon-device-16.png", typeof(ImagesHelper).Assembly, new Size(16, 16))); }
        }
        public static ImageCollection DeviceLargeImages
        {
            get { return _deviceLargeImages ?? (_deviceLargeImages = ImageHelper.CreateImageCollectionFromResources("Dekart.LazyNet.Resources.Images.icon-device-32.png", typeof(ImagesHelper).Assembly, new Size(32, 32))); }
        }
        public static Icon AppIcon
        {
            get { return _appIcon ?? (_appIcon = ResourceImageHelper.CreateIconFromResources("Dekart.LazyNet.AppIcon.ico", typeof(ImagesHelper).Assembly)); }
        }
        public static Image UnknownDevice
        {
            get { return _device ?? (_device = ResourceImageHelper.CreateImageFromResources("Dekart.LazyNet.Resources.Unknown-device.png", typeof(ImagesHelper).Assembly)); }
        }
        public static Image UnknownUser
        {
            get { return _user ?? (_user = ResourceImageHelper.CreateImageFromResources("Dekart.LazyNet.Resources.Unknown-user.png", typeof (ImagesHelper).Assembly)); }
        }

        /// <summary>
        /// Modifies the width or height of an image.
        /// </summary>
        /// <param name="original">Original image.</param>
        /// <param name="width">New width or null for auto.</param>
        /// <param name="height">New heigth or null for auto.</param>
        public static Image ModifyImage(Image original, int? width, int? height)
        {
            if (original == null) throw new ArgumentNullException("original");

            int w;
            int h;

            // convert size to new dimensions

            // checks what need to resize image
            if (width == null && height == null)
                return (Image)original.Clone();
            if (width == null && height == original.Height)
                return (Image)original.Clone();
            if (width == original.Width && height == null)
                return (Image)original.Clone();
            if (width == original.Width && height == original.Height)
                return (Image)original.Clone();

            // Calculate missing width or height
            if (width == null)
                w = (int)((height / (double)original.Height) * original.Width);
            else
                w = width.Value;

            if (height == null)
                h = (int)((width / (double)original.Width) * original.Height);
            else
                h = height.Value;

            var oThumbNail = new Bitmap(w, h, original.PixelFormat);
            var oGraphic = Graphics.FromImage(oThumbNail);

            oGraphic.CompositingQuality = CompositingQuality.HighQuality;
            oGraphic.SmoothingMode = SmoothingMode.HighQuality;
            oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

            var oRectangle = new Rectangle(0, 0, w, h);

            oGraphic.DrawImage(original, oRectangle);

            oGraphic.Dispose();

            return oThumbNail;
        }

        /// <summary>Gets the cursor</summary>
        public static Cursor GetCursor(string name)
        {
            if (String.IsNullOrEmpty(name)) return Cursors.Default;

            try
            {
                return CursorsHelper.LoadFromResource(String.Format("Dekart.LazyNet.Resources.Cursors.{0}.ico", name), typeof(ImagesHelper).Assembly);
            }
            catch
            {
                throw new ArgumentException(string.Format(ConstStrings.ResourceImageNotFoundError, name));
            }
        }
    }
}