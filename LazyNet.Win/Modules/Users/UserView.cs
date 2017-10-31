using System.Linq;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraRichEdit;

namespace Dekart.LazyNet.Win.Modules
{
    public partial class UserView : ControlBase
    {
        public UserView()
        {
            InitializeComponent();
            lcContact.Tag = 0; lcDevices.Tag = 1; lcNotes.Tag = 2;
            new LabelTabController(0, lcContact, lcDevices, lcNotes).EditValueChanged += (s, e) =>
            {
                lciContact.Visibility = 0.Equals(s) ? LayoutVisibility.Always : LayoutVisibility.Never;
                lciDevices.Visibility = 1.Equals(s) ? LayoutVisibility.Always : LayoutVisibility.Never;
                lciNotes.Visibility = 2.Equals(s) ? LayoutVisibility.Always : LayoutVisibility.Never;
            };
            lcEmail.ForeColor = ColorHelper.HyperLinkTextColor;
            Init(null, null);
        }

        public void Init(User user, string toolTip)
        {
            if (user != null)
            {
                pictureEdit.Image = user.PhotoExists;
                sliName.Text = user.FullName;
                lcTitle.Text = user.Title;
                lcDepartment.Text = user.Department;
                lciDepartment.Visibility = !string.IsNullOrEmpty(user.Department) ? LayoutVisibility.Always : LayoutVisibility.Never;
                lcWorkPhone.Text = user.WorkPhone;
                if (user.BirthDate.HasValue)
                {
                    lciBirthDate.Visibility = LayoutVisibility.Always;
                    lcBirthDate.Text = user.BirthDate.Value.ToShortDateString();
                }
                else lciBirthDate.Visibility = LayoutVisibility.Never;
                lciWorkPhone.Visibility = !string.IsNullOrEmpty(user.WorkPhone) ? LayoutVisibility.Always : LayoutVisibility.Never;
                lcMobilePhone.Text = user.MobilePhone;
                lciMobilePhone.Visibility = !string.IsNullOrEmpty(user.MobilePhone) ? LayoutVisibility.Always : LayoutVisibility.Never;
                lcEmail.Text = user.Email;
                lciEmail.Visibility = !string.IsNullOrEmpty(user.Email) ? LayoutVisibility.Always : LayoutVisibility.Never;
                richEditControl.HtmlText = user.Note;
                gcDevices.DataSource = user.Devices.Where(d=>!d.DeletionMark);
            }
            else
            {
                pictureEdit.Image = null;
                sliName.Text = @" ";
                lcTitle.Text = richEditControl.HtmlText = string.Empty;
                lciDepartment.Visibility = lciBirthDate.Visibility = lciWorkPhone.Visibility = lciMobilePhone.Visibility =
                    lciEmail.Visibility = LayoutVisibility.Never;
                gcDevices.DataSource = null;
            }
            if (!string.IsNullOrEmpty(toolTip))
            {
                pictureEdit.ToolTip = toolTip;
                pictureEdit.Cursor = Cursors.Hand;
            }
            else pictureEdit.Cursor = Cursors.Default;
            Refresh();
        }

        public float ZoomFactor
        {
            get { return richEditControl.Views.SimpleView.ZoomFactor; }
            set { richEditControl.Views.SimpleView.ZoomFactor = value; }
        }

        public RichEditControl RichEdit { get { return richEditControl; } }
    }
}
