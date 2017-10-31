using System;
using System.Collections;
using System.Linq;

namespace Dekart.LazyNet
{
    public class DetailsCollection : CollectionBase
    {
        readonly MainFormBase _owner;

        /// <summary>ctor</summary>
        public DetailsCollection(MainFormBase owner)
        {
            _owner = owner;
        }

        /// <summary>Gets the detail</summary>
        public DetailBase this[int index]
        {
            get { return List.Count > index ? List[index] as DetailBase : null; }
        }

        /// <summary>Gets the detail</summary>
        public DetailBase this[Guid id]
        {
            get { return List.Cast<DetailBase>().FirstOrDefault(detail => detail.Id == id); }
        }

        /// <summary>Is detail exists</summary>
        DetailBase IsDetailExist(DetailBase value)
        {
            return List.Cast<DetailBase>().FirstOrDefault(detail => detail.Id == value.Id);
        }

        /// <summary>Is detail exists</summary>
        public bool IsDetailExist(Guid id)
        {
            foreach (DetailBase detail in List)
                if (detail.Id == id && !detail.IsDisposed)
                {
                    _owner.ActiveDetail = detail;
                    return true;
                }
            return false;
        }

        /// <summary>Is dirty detail exists</summary>
        public bool IsDirtyDetailExist()
        {
            return List.Cast<DetailBase>().Any(detail => detail.Dirty);
        }

        /// <summary>Adds the detail</summary>
        public void Add(DetailBase value)
        {
            var existDetail = IsDetailExist(value);
            if (existDetail == null)
            {
                List.Add(value);
                _owner.ActiveDetail = value;
            }
            else
            {
                value.Dispose();
                _owner.ActiveDetail = existDetail;
            }
            _owner.CalcCloseAllDetails();
        }

        /// <summary>Removes the detail</summary>
        public void Remove(DetailBase value)
        {
            int index = List.IndexOf(value);

            if (List.Contains(value))
                List.Remove(value);

            if (index != -1 && List.Count > 0)
            {
                if (index >= List.Count)
                    index = List.Count - 1;
                _owner.ActiveDetail = (DetailBase)List[index];
            }
            else
                _owner.ActiveDetail = null;

            if (value != null)
                value.Dispose();
            _owner.CalcCloseAllDetails();
        }

        /// <summary>Removes all details</summary>
        public void RemoveAll(bool closeEditing)
        {
            for (var i = List.Count - 1; i >= 0; i--)
            {
                var temp = this[i];
                if (temp.Dirty && !closeEditing) continue;
                List.RemoveAt(i);
                temp.Dispose();
            }
            _owner.ActiveDetail = null;
            _owner.CalcCloseAllDetails();
        }

    }
}