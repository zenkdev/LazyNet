using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Dekart.LazyNet.Drawing
{
    [Serializable]
    public class DrawablePicture
    {
        // The currently selected object. A more elaborate
        // application might use a selection list and make
        // this a collection.
        Drawable _selectedDrawable;
        // Initial mouse position when the object was selected.
        int _selectedMouseX, _selectedMouseY;

        /// <summary>
        /// The list where we will store objects.
        /// </summary>
        [XmlElement(typeof(Drawable)),
         XmlElement(typeof(DrawableLine)),
         XmlElement(typeof(DrawableRectangle)),
         XmlElement(typeof(DrawableEllipse)),
         XmlElement(typeof(DrawableStar)),
         XmlElement(typeof(DrawableImage)),
         XmlElement(typeof(DrawableDevice))]
        public List<Drawable> Drawables = new List<Drawable>();

        /// <summary>
        /// The background color.
        /// </summary>
        [XmlIgnore]
        public Color BackColor = SystemColors.Control;
        /// <summary>
        /// Property procedures to serialize and
        /// deserialize BackColor.
        /// </summary>
        [XmlAttribute("BackColor")]
        public int BackColorArgb
        {
            get { return BackColor.ToArgb(); }
            set { BackColor = Color.FromArgb(value); }
        }

        // Constructors.
        public DrawablePicture() { }

        public DrawablePicture(Color backColor)
        {
            BackColor = backColor;
        }

        public Drawable SelectedDrawable
        {
            get { return _selectedDrawable; }
            set
            {
                if (_selectedDrawable == value) return;

                // Mark the currently selected object
                // as not selected.
                if (_selectedDrawable != null)
                    _selectedDrawable.IsSelected = false;

                // Select the new object.
                _selectedDrawable = value;
                if (_selectedDrawable != null)
                    _selectedDrawable.IsSelected = true;

                if (SelectedDrawableChanged != null)
                    SelectedDrawableChanged(this, EventArgs.Empty);
            }
        }

        public event EventHandler SelectedDrawableChanged;

        /// <summary>
        /// Add a new Drawable object to the list.
        /// </summary>
        public void Add(Drawable dr)
        {
            Drawables.Add(dr);
        }


        /// <summary>
        /// Remove this object from the list.
        /// </summary>
        public void Remove(Drawable dr)
        {
            Drawables.Remove(dr);
        }

        /// <summary>
        /// Select the Drawable at this point. Highlight it
        /// and return it.
        /// </summary>
        public Drawable SelectObjectAt(int x, int y)
        {
            // Deselect the previously selected object.
            SelectedDrawable = null;

            // Find the object at this point (if any).
            // Search the list backwards so we find objects
            // at the top of the stack first.
            for (var i = Drawables.Count - 1; i >= 0; i -= 1)
            {
                var dr = Drawables[i];
                if (!dr.IsAt(x, y)) continue;
                SelectedDrawable = dr;
                _selectedMouseX = x;
                _selectedMouseY = y;
                break;
            }

            // Return the selected object.
            return SelectedDrawable;
        }

        /// <summary>
        /// Draw all the objects.
        /// </summary>
        public void Draw(Graphics gr, double zoomFactor = 1.0, int startX = 0, int startY = 0, bool showPreview=false)
        {
            // Clear the background.
            //gr.Clear(BackColor);
            //if (BackgroundPicture != null) gr.DrawImage(BackgroundPicture, new Rectangle(0, 0, BackgroundPicture.Width, BackgroundPicture.Height));
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Draw the objects.
            foreach (var dr in Drawables)
                dr.Draw(gr, zoomFactor, startX, startY, showPreview);
        }

        /// <summary>
        /// Move the selected drawable. The mouse has moved from
        /// (_selectedMouseX, _selectedMouseY) to (x, y).
        /// </summary>
        public void MoveSelectedDrawableToMouse(int x, int y, Size gridSize)
        {
            // Do nothing if nothing is selected.
            if (SelectedDrawable == null) return;

            // See how far we want it moved.
            var newDx = x - _selectedMouseX;
            var newDy = y - _selectedMouseY;

            System.Diagnostics.Debug.WriteLine("newDx={0},newDy={1}", newDx, newDy);
            // Move it.
            SelectedDrawable.MoveRelative(newDx, newDy);

            // Save the new mouse position.
            _selectedMouseX = x;
            _selectedMouseY = y;
        }

        /// <summary>
        /// Send the object to the back of the stack.
        /// </summary>
        public void SendToBack(Drawable dr)
        {
            if (dr == null) return;
            Drawables.Remove(dr);
            Drawables.Insert(0, dr);
        }

        /// <summary>
        /// Bring the object to the front of the stack.
        /// </summary>
        public void BringToFront(Drawable dr)
        {
            if (dr == null) return;
            Drawables.Remove(dr);
            Drawables.Insert(Drawables.Count, dr);
        }

        /// <summary>
        /// Delete the object.
        /// </summary>
        public void Delete(Drawable dr)
        {
            if (dr != null)
            {
                Drawables.Remove(dr);
            }
        }

        // Save the picture into the file.
        public void SavePicture(string filename)
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(DrawablePicture));
                var streamWriter = new StreamWriter(filename);
                xmlSerializer.Serialize(streamWriter, this);
                streamWriter.Close();
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(string.Concat(ex.Message, Environment.NewLine,
                                    "Show internal error?"), ConstStrings.SaveError,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show(ex.InnerException.ToString(), ConstStrings.InternalError, MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
        }

        // Laod the picture from the file.
        public static DrawablePicture LoadPicture(string filename)
        {
            try
            {
                var xmlSerializer = new XmlSerializer(typeof(DrawablePicture));
                var fileStream = new FileStream(filename, FileMode.Open);
                var newPicture = (DrawablePicture)xmlSerializer.Deserialize(fileStream);
                fileStream.Close();
                return newPicture;
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(string.Concat(ex.Message, Environment.NewLine,
                    "Show internal error?"), ConstStrings.LoadError,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show(ex.InnerException.ToString(), ConstStrings.InternalError,
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return null;
            }
        }

        // Return the bounds of all drawable objects.
        public Rectangle GetBounds()
        {
            if (Drawables.Count < 1) return new Rectangle(0, 0, 0, 0);

            var result = Drawables[0].GetBounds();
            return Drawables.Aggregate(result, (current, dr) => Rectangle.Union(current, dr.GetBounds()));
        }
    }
}
