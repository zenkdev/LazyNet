using System.Windows.Forms;
using DevExpress.Utils.Menu;

namespace Dekart.LazyNet.SQLBackup2Remote.Forms
{
    public partial class AddCustomSQLScript : AddFormBase
    {
        public AddCustomSQLScript(Form parent, string sql, string caption, IDXMenuManager manager)
            : base(parent, sql, manager)
        {
            InitializeComponent();

            Text = caption;
        }

        protected override bool TestButtonVisible { get { return false; } }

        public string SQL { get { return (string)EditObject; } }

        protected override void InitData()
        {
            memoEdit1.Text = SQL;
        }

        protected override void SaveData()
        {
            EditObject = memoEdit1.Text;
        }

    }
}
