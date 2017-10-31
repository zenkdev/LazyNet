using System;
using System.Drawing;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.XtraEditors;

namespace Dekart.LazyNet.Win
{
    class LabelTabController
    {
        readonly LabelControl[] _labels;
        public LabelTabController(object eValue, params LabelControl[] list)
        {
            _labels = list;
            EditValue = eValue;
            foreach (LabelControl lb in list)
                lb.Click += (s, e) => EditValue = ((LabelControl)s).Tag;
        }
        object _editValueCore;
        public object EditValue
        {
            get { return _editValueCore; }
            set
            {
                if (Equals(_editValueCore, value)) return;
                _editValueCore = value;
                RaiseEditValueChanged();
                foreach (LabelControl lc in _labels)
                {
                    if (EditValue.Equals(lc.Tag))
                    {
                        lc.Font = new Font(lc.Font.FontFamily, 10, FontStyle.Bold);
                        lc.Appearance.ForeColor = CommonColors.GetQuestionColor(UserLookAndFeel.Default);
                    }
                    else
                    {
                        lc.Appearance.Reset();
                        lc.Font = new Font(lc.Font.FontFamily, 10, FontStyle.Regular);
                    }
                }
            }
        }
        public event EventHandler EditValueChanged;
        void RaiseEditValueChanged()
        {
            EventHandler handler = EditValueChanged;
            if (handler != null)
                handler(EditValue, EventArgs.Empty);
        }
    }
}