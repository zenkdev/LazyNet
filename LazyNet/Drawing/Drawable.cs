using System;
using System.Drawing;
using System.Xml.Serialization;

namespace Dekart.LazyNet.Drawing
{
    [Serializable]
    public abstract class Drawable
    {
        // Drawing characteristics.
        [XmlIgnore]
        public Color ForeColor;
        [XmlIgnore]
        public Color FillColor;
        [XmlAttribute]
        public int LineWidth = 0;

        [XmlAttribute]
        public int X1;
        [XmlAttribute]
        public int Y1;
        [XmlAttribute]
        public int X2;
        [XmlAttribute]
        public int Y2;

        /// <summary>
        /// Indicates whether we should draw as selected.
        /// </summary>
        [XmlIgnore]
        public bool IsSelected = false;

        [XmlIgnore]
        public object Tag;

        // Constructors.
        protected Drawable()
        {
            ForeColor = Color.Black;
            FillColor = Color.White;
        }

        protected Drawable(Color foreColor, Color fillColor, int lineWidth = 0)
        {
            LineWidth = lineWidth;
            ForeColor = foreColor;
            FillColor = fillColor;
        }

        /// <summary>
        /// Property procedures to serialize and
        /// deserialize ForeColor and FillColor.
        /// </summary>
        [XmlAttribute("ForeColor")]
        public int ForeColorArgb
        {
            get { return ForeColor.ToArgb(); }
            set { ForeColor = Color.FromArgb(value); }
        }

        [XmlAttribute("BackColor")]
        public int FillColorArgb
        {
            get { return FillColor.ToArgb(); }
            set { FillColor = Color.FromArgb(value); }
        }

        #region "Methods to override"

        /// <summary>
        /// Draw the object on this Graphics surface.
        /// </summary>
        public abstract void Draw(Graphics gr, double zoomFactor, int startX, int startY, bool showPreview);

        /// <summary>
        /// return the object//s bounding rectangle.
        /// </summary>
        public abstract Rectangle GetBounds();

        /// <summary>
        /// return True if this point is on the object.
        /// </summary>
        public abstract bool IsAt(int x, int y);

        /// <summary>
        /// The user is moving one of the object//s points.
        /// </summary>
        public abstract void NewPoint(int x, int y);

        /// <summary>
        /// return True if the object is empty (e.g. a zero-length line).
        /// </summary>
        public abstract bool IsEmpty();

        /// <summary>
        /// Move the object a given distance.
        /// </summary>
        public void MoveRelative(int dx, int dy)
        {
            X1 += dx;
            Y1 += dy;
            X2 += dx;
            Y2 += dy;
        }
        #endregion

    }
}
