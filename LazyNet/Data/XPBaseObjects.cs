using System;
using System.ComponentModel;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

namespace Dekart.LazyNet
{
    [NonPersistent]
    public class LazyNetBaseObject : ExtendedXPBaseObject
    {
        /// <summary>Ctor</summary>
        protected LazyNetBaseObject(Session session) : base(session) { }

        /// <summary>AfterConstruction override</summary>
        public override void AfterConstruction()
        {
            base.AfterConstruction();

            Oid = Guid.NewGuid();
            CreatedOn = UpdatedOn = DateTime.Now;
        }

        /// <summary>OnSavingOverride override</summary>
        protected override void OnSavingOverride()
        {
            base.OnSavingOverride();
            UpdatedOn = DateTime.Now;
        }

        /// <summary>TriggerObjectChanged override</summary>
        protected override void TriggerObjectChanged(ObjectChangeEventArgs args)
        {
            try
            {
                if (!string.IsNullOrEmpty(args.PropertyName))
                {
                    var mi = ClassInfo.FindMember(args.PropertyName);
                    if (mi?.ReferenceType != null)
                    {
                        base.TriggerObjectChanged(new ObjectChangeEventArgs(args.Session, args.Object, args.Reason, args.PropertyName + "!", args.OldValue, args.NewValue));
                    }
                }
                base.TriggerObjectChanged(args);
            }
            catch (ObjectDisposedException)
            {
            }
        }

        /// <summary> Gets or sets object identifier </summary>
        [Key(true)]
        public int Id
        {
            get { return GetPropertyValue<int>("Id"); }
            set { SetPropertyValue("Id", value); }
        }

        /// <summary>
        /// Gets or sets created on
        /// </summary>
        [DbType("datetime2")]
        public DateTime CreatedOn
        {
            get { return GetPropertyValue<DateTime>("CreatedOn"); }
            set { SetPropertyValue("CreatedOn", value); }
        }

        /// <summary>
        /// Gets or sets updated on
        /// </summary>
        [DbType("datetime2")]
        public DateTime UpdatedOn
        {
            get { return GetPropertyValue<DateTime>("UpdatedOn"); }
            set { SetPropertyValue("UpdatedOn", value); }
        }

        /// <summary>
        /// Gets or sets object unique identifier
        /// </summary>
        [Indexed(Unique = true)]
        public Guid Oid
        {
            get { return GetPropertyValue<Guid>("Oid"); }
            set { SetPropertyValue("Oid", value); }
        }

        /// <summary>
        /// Gets allow delete flag
        /// </summary>
        public virtual bool AllowDelete => true;

        /// <summary>
        /// Safe deletes object
        /// </summary>
        /// <returns></returns>
        public virtual bool SafeDelete() { return false; }

    }

    [NonPersistent]
    public abstract class ExtendedXPBaseObject : XPBaseObject
    {
        /// <summary>Ctor</summary>
        protected ExtendedXPBaseObject(Session session) : base(session) { }

        /// <summary>Ctor</summary>
        protected ExtendedXPBaseObject() : base(Session.DefaultSession) { }

        /// <summary>
        /// Gets the current object name
        /// </summary>
        public virtual string ObjectName => string.Empty;

        /// <summary>Disable DoEndEditAction</summary>
        protected override void DoEndEditAction() { }

        protected sealed override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);

            if (IsLoading) return;
            if (string.IsNullOrEmpty(propertyName)) return;
            if (oldValue != null && newValue != null && oldValue == newValue) return;

            OnChangedOverride(propertyName, oldValue, newValue);
        }

        protected sealed override XPCollection CreateCollection(XPMemberInfo property)
        {
            var collection = base.CreateCollection(property);
            if (property.IsAggregated) collection.DeleteObjectOnRemove = true;
            collection.ListChanged += (sender, e) => OnCollectionChangedOverride(collection, e);
            return collection;
        }

        protected sealed override XPCollection<T> CreateCollection<T>(XPMemberInfo property)
        {
            var collection = base.CreateCollection<T>(property);
            if (property.IsAggregated) collection.DeleteObjectOnRemove = true;
            collection.ListChanged += (sender, e) => OnCollectionChangedOverride(collection, e);
            return collection;
        }

        protected sealed override void OnSaving()
        {
            base.OnSaving();
            if (IsDeleted || Session is NestedUnitOfWork) return;
            OnSavingOverride();
            Saved?.Invoke(this, new EventArgs());
        }

        protected virtual void OnSavingOverride() { }

        protected virtual void OnChangedOverride(string propertyName, object oldValue, object newValue) { }

        protected virtual void OnCollectionChangedOverride(XPBaseCollection collection, ListChangedEventArgs e) { }

        public event EventHandler Saved;

    }
}
