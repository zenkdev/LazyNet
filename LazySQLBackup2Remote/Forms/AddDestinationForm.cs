using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Dekart.LazyNet.SQLBackup2Remote.Forms
{
    public partial class AddDestinationForm : XtraForm
    {
        readonly Form _parent;
        public AddDestinationForm(Form parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public int DestinationType { get; private set; }

        /// <summary>OnLoad override</summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_parent == null) return;
            Location = new Point(_parent.Left + (_parent.Width - Width) / 2, _parent.Top + (_parent.Height - Height) / 2);
        }

        /// <summary>ProcessCmdKey override</summary>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (msg.WParam.ToInt32() == (int)Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        void SbFolderDestinationClick(object sender, EventArgs e)
        {
            DestinationType = 0;
            DialogResult = DialogResult.OK;
        }

        void SbFtpServerClick(object sender, EventArgs e)
        {
            DestinationType = 1;
            DialogResult = DialogResult.OK;
        }
    }
}
