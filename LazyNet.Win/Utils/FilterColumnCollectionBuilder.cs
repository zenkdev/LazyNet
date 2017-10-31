using System;
using System.Linq.Expressions;
using Dekart.LazyNet.Helpers;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraEditors.Repository;

namespace Dekart.LazyNet.Win
{
    class FilterColumnCollectionBuilder<TEntity>
    {
        readonly FilterColumnCollection _filterColumns;
        public FilterColumnCollectionBuilder()
        {
            _filterColumns = new FilterColumnCollection();
        }
        public FilterColumnCollectionBuilder(FilterColumnCollection filterColumns)
        {
            _filterColumns = filterColumns;
        }
        public FilterColumnCollection Build()
        {
            return _filterColumns;
        }
        public FilterColumnCollectionBuilder<TEntity> AddColumn<T>(Expression<Func<TEntity, T>> expression, RepositoryItem repositoryItem = null, FilterColumnClauseClass clauseClass = FilterColumnClauseClass.String)
        {
            if (repositoryItem == null)
            {
                if (typeof(T) == typeof(bool) || (typeof(T) == typeof(bool?)))
                {
                    repositoryItem = EditorsHelpers.CreatEdit<RepositoryItemCheckEdit>();
                    clauseClass = FilterColumnClauseClass.Generic;
                }
                if ((typeof(T) == typeof(double)) || (typeof(T) == typeof(double?)) || (typeof(T) == typeof(decimal)) || (typeof(T) == typeof(decimal?)))
                {
                    repositoryItem = EditorsHelpers.CreatEdit<RepositoryItemSpinEdit>();
                    clauseClass = FilterColumnClauseClass.Generic;
                }
                if (typeof(T) == typeof(int) || (typeof(T) == typeof(int?)))
                {
                    var spinEdit = EditorsHelpers.CreatEdit<RepositoryItemSpinEdit>();
                    spinEdit.IsFloatValue = false;
                    repositoryItem = spinEdit;
                    clauseClass = FilterColumnClauseClass.Generic;
                }
            }
            _filterColumns.Add(CreateColumn(expression, null, null, repositoryItem, clauseClass));
            return this;
        }
        public FilterColumnCollectionBuilder<TEntity> AddColumn<T>(Expression<Func<TEntity, T>> expression, string caption, RepositoryItem repositoryItem = null, FilterColumnClauseClass clauseClass = FilterColumnClauseClass.String)
        {
            if (repositoryItem == null)
            {
                if (typeof(T) == typeof(bool) || (typeof(T) == typeof(bool?)))
                {
                    repositoryItem = EditorsHelpers.CreatEdit<RepositoryItemCheckEdit>();
                    clauseClass = FilterColumnClauseClass.Generic;
                }
                if ((typeof(T) == typeof(double)) || (typeof(T) == typeof(double?)) || (typeof(T) == typeof(decimal)) || (typeof(T) == typeof(decimal?)))
                {
                    repositoryItem = EditorsHelpers.CreatEdit<RepositoryItemSpinEdit>();
                    clauseClass = FilterColumnClauseClass.Generic;
                }
                if (typeof(T) == typeof(int) || (typeof(T) == typeof(int?)))
                {
                    var spinEdit = EditorsHelpers.CreatEdit<RepositoryItemSpinEdit>();
                    spinEdit.IsFloatValue = false;
                    repositoryItem = spinEdit;
                    clauseClass = FilterColumnClauseClass.Generic;
                }
            }
            _filterColumns.Add(CreateColumn(expression, caption, null, repositoryItem, clauseClass));
            return this;
        }
        public FilterColumnCollectionBuilder<TEntity> AddLookupColumn<T>(Expression<Func<TEntity, T>> expression)
        {
            return AddColumn(expression, EditorsHelpers.CreateEnumImageComboBox<T>(), FilterColumnClauseClass.Lookup);
        }
        public FilterColumnCollectionBuilder<TEntity> AddDateTimeColumn<T>(Expression<Func<TEntity, T>> expression)
        {
            return AddColumn(expression, EditorsHelpers.CreatDateEdit(), FilterColumnClauseClass.DateTime);
        }
        public FilterColumnCollectionBuilder<TEntity> AddDateTimeColumn<T>(Expression<Func<TEntity, T>> expression, string caption)
        {
            return AddColumn(expression, caption, EditorsHelpers.CreatDateEdit(), FilterColumnClauseClass.DateTime);
        }
        UnboundFilterColumn CreateColumn<T>(Expression<Func<TEntity, T>> expression, string caption, string fieldName, RepositoryItem repositoryItem, FilterColumnClauseClass clauseClass)
        {
            var member = (expression.Body as MemberExpression).Member;
            if (string.IsNullOrEmpty(fieldName))
                fieldName = GetFieldName<T>(expression);
            if (string.IsNullOrEmpty(caption))
                caption = GetDisplayName(member);
            return CreateColumn<T>(caption, fieldName, repositoryItem, clauseClass);
        }
        UnboundFilterColumn CreateColumn<T>(string caption, string fieldName, RepositoryItem repositoryItem, FilterColumnClauseClass clauseClass)
        {
            return new UnboundFilterColumn(caption, fieldName, typeof(T), repositoryItem, clauseClass);
        }
        string GetFieldName<T>(Expression<Func<TEntity, T>> expression)
        {
            var sb = new System.Text.StringBuilder();
            MemberExpression me = expression.Body as MemberExpression;
            while (me != null)
            {
                if (sb.Length > 0)
                    sb.Insert(0, ".");
                sb.Insert(0, me.Member.Name);
                me = me.Expression as MemberExpression;
            }
            return sb.ToString();
        }
        string GetDisplayName(System.Reflection.MemberInfo member)
        {
            string displayName = member.Name;
            if (CheckDisplayNameAttribute<System.ComponentModel.DataAnnotations.DisplayAttribute>(member, a => a.GetName(), ref displayName))
                return displayName;
            if (CheckDisplayNameAttribute<System.ComponentModel.DisplayNameAttribute>(member, a => a.DisplayName, ref displayName))
                return displayName;
            return displayName;
        }
        bool CheckDisplayNameAttribute<TAttribute>(System.Reflection.MemberInfo member, Func<TAttribute, string> accessor, ref string displayName)
            where TAttribute : Attribute
        {
            var displayAttributes = member.GetCustomAttributes(typeof(TAttribute), true);
            if (displayAttributes.Length > 0)
            {
                displayName = accessor((TAttribute)displayAttributes[0]);
                return true;
            }
            return false;
        }
    }
}