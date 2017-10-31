using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;

namespace Dekart.LazyNet.SQLBackup2Remote.Helpers
{
    public class MRUArrayList : ArrayList
    {
        // ReSharper disable once InconsistentNaming
        const int MAX_RECENT_FILES = 9;

        readonly Control _container;
        readonly Image _imgChecked, _imgUncheked, _glyph;
        public event EventHandler LabelClicked;
        readonly bool _indexedList;
        readonly bool _showDescription;
        public MRUArrayList(Control cont, Image iChecked, Image iUnchecked, Image glyph, bool indexedList, bool showDescription)
            : this(cont, iChecked, iUnchecked)
        {
            _glyph = glyph;
            _indexedList = indexedList;
            _showDescription = showDescription;
        }

        public MRUArrayList(Control cont, Image iChecked, Image iUnchecked)
        {
            _indexedList = true;
            _imgChecked = iChecked;
            _imgUncheked = iUnchecked;
            _container = cont;
        }
        int GetLastAppMenuFileLabelIndex()
        {
            for (var i = _container.Controls.Count - 1; i >= 0; i--)
            {
                if (_container.Controls[i] is AppMenuFileLabel)
                    return i + 1;
            }
            return 0;
        }
        public void InsertElement(object value)
        {
            var names = value.ToString().Split(',');
            var name = names[0];
            var checkedLabel = false;
            if (names.Length > 1) checkedLabel = names[1].ToLower().Equals("true");
            foreach (Control c in _container.Controls)
            {
                var ml = c as AppMenuFileLabel;
                if (ml == null || !ml.Tag.Equals(name)) continue;

                checkedLabel = ml.Checked;
                Remove(name);
                ml.LabelClick -= OnLabelClick;
                ml.Dispose();
                break;
            }
            var access = true;
            if (Count >= MAX_RECENT_FILES)
                access = RemoveLastElement();
            if (access)
            {
                Insert(0, name);
                var ml = new AppMenuFileLabel();
                int index = GetLastAppMenuFileLabelIndex();
                _container.Controls.Add(ml);
                _container.Controls.SetChildIndex(ml, index);
                ml.Tag = name;
                if (_showDescription)
                {
                    ml.Text = GetFileName(name);
                    ml.Description = name;
                }
                else
                    ml.Text = GetFileName(name);
                ml.Glyph = _glyph;
                ml.Checked = checkedLabel;
                ml.AutoHeight = true;
                ml.Dock = DockStyle.Top;
                ml.Image = _imgUncheked;
                ml.SelectedImage = _imgChecked;
                ml.LabelClick += OnLabelClick;
                if (_indexedList)
                    SetElementsRange();
            }
        }
        void OnLabelClick(object sender, EventArgs e)
        {
            LabelClicked?.Invoke(((AppMenuFileLabel)sender).Tag.ToString(), e);
        }

        bool RemoveLastElement()
        {
            for (int i = 0; i < _container.Controls.Count; i++)
            {
                var ml = _container.Controls[i] as AppMenuFileLabel;
                if (ml != null && !ml.Checked)
                {
                    Remove(ml.Tag);
                    ml.LabelClick -= OnLabelClick;
                    ml.Dispose();
                    return true;
                }
            }
            return false;
        }
        string GetFileName(object obj)
        {
            var fi = new FileInfo(obj.ToString());
            return fi.Name;
        }
        void SetElementsRange()
        {
            int i = 0;
            foreach (Control c in _container.Controls)
            {
                var ml = c as AppMenuFileLabel;
                if (ml == null)
                    continue;
                ml.Caption = $"&{_container.Controls.Count - i}";
                i++;
            }
        }
        public bool GetLabelChecked(string name)
        {
            return (from ml in _container.Controls.OfType<AppMenuFileLabel>() where ml.Tag.Equals(name) select ml.Checked).FirstOrDefault();
        }

        public void Init(string content, string defaultItem = null)
        {
            if (string.IsNullOrEmpty(content))
            {
                if (!string.IsNullOrEmpty(defaultItem))
                {
                    InsertElement(defaultItem);
                }
                return;
            }

            var sr = new StringReader(content);
            _container.SuspendLayout();
            var list = new List<string>();
            for (var s = sr.ReadLine(); s != null; s = sr.ReadLine())
                list.Add(s);
            for (var i = list.Count - 1; i >= 0; i--)
            {
                InsertElement(list[i]);
            }
            sr.Close();
            _container.ResumeLayout();
        }
    }
}