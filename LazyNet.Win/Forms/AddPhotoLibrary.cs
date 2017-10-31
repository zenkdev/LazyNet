using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Utils.Menu;
using DevExpress.Xpo;

namespace Dekart.LazyNet.Win
{
    public partial class AddPhotoLibrary : AddFormBase
    {
        readonly string _fileName;

        public AddPhotoLibrary(Form parent, Session session, string fileName, IDXMenuManager manager)
            : base(parent, session, null, manager)
        {
            _fileName = fileName;
            InitializeComponent();
        }

        public PhotoLibrary PhotoLibrary
        {
            get { return EditObject as PhotoLibrary; }
        }

        protected override void CreateNewObject()
        {
            base.CreateNewObject();
            EditObject = new PhotoLibrary(Session);
        }

        protected override void InitData()
        {
            var xps = new XPCollection<PhotoLibrary>();
            mruCategory.Properties.Items.Clear();
            mruCategory.Properties.Items.AddRange((from a in xps
                group a by a.Group
                into g
                orderby g.Key
                select g.Key).ToList<string>());
            teName.Text = Path.GetFileNameWithoutExtension(_fileName);
            mruCategory.SelectedIndex = 0;
            pictureEdit1.Image = ImagesHelper.ModifyImage(Image.FromFile(_fileName), 0x7d, 0x7d);
        }

        protected override void InitValidation()
        {
            base.InitValidation();
            ValidationProvider.SetValidationRule(teName, EditorsHelpers.RuleIsNotBlank);
        }

        protected override void SaveData()
        {
            PhotoLibrary.Name = teName.Text;
            PhotoLibrary.Group = mruCategory.Text;
            PhotoLibrary.Photo = pictureEdit1.Image;
            PhotoLibrary.Save();
        }
    }
}