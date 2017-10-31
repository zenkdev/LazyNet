using System.Windows.Forms;
using Dekart.LazyNet.Helpers;
using DevExpress.Utils.Menu;
using DevExpress.Xpo;

namespace Dekart.LazyNet.Win
{
    public partial class AddMovement : AddFormBase
    {
        public AddMovement(Form parent, UnitOfWork session, LazyNetBaseObject editObject, IDXMenuManager manager)
            : base(parent, session, editObject, manager)
        {
            InitializeComponent();
        }

        /// <summary>Movement</summary>
        public Movement Movement { get { return EditObject as Movement; } }

        /// <summary>CreateNewObject</summary>
        protected override void CreateNewObject()
        {
            base.CreateNewObject();
            EditObject = new Movement(Session);
        }

        protected override void InitValidation()
        {
            base.InitValidation();

            ValidationProvider.SetValidationRule(deCreatedOn, EditorsHelpers.RuleIsNotBlank);
        }

        /// <summary>InitData</summary>
        protected override void InitData()
        {
            deCreatedOn.EditValue = Movement.CreatedOn;
            leSrcRoom.EditValue = Movement.OldRoom.ToInt32();
            leDstRoom.EditValue = Movement.NewRoom.ToInt32();
            meNote.Text = Movement.Note;

            leSrcRoom.Properties.DataSource = leDstRoom.Properties.DataSource = new XPCollection<Room>(Session) { CriteriaString = "DeletionMark=0" };
        }

        /// <summary>SaveData</summary>
        protected override void SaveData()
        {
            Movement.CreatedOn = deCreatedOn.DateTime;
            Movement.OldRoom = leSrcRoom.EditValue == null ? null : Session.GetObjectByKey<Room>(leSrcRoom.EditValue);
            Movement.NewRoom = leDstRoom.EditValue == null ? null : Session.GetObjectByKey<Room>(leDstRoom.EditValue);
            Movement.Note = meNote.Text;
        }
    }
}
