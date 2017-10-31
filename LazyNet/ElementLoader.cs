using System;
using System.Reflection;
using Dekart.LazyNet.Helpers;

namespace Dekart.LazyNet
{
    public static class ElementLoader
    {
        public static void LoadResourcesForMainForm(object element)
        {
            SetPropertyPathValue(element, "Icon", ImagesHelper.AppIcon);

            SetPropertyPathValue(element, "nbgDevices.Caption", ConstStrings.Devices);
            SetPropertyPathValue(element, "nbgUsers.Caption", ConstStrings.Users);
            SetPropertyPathValue(element, "nbgRepairs.Caption", ConstStrings.Repairs);
            SetPropertyPathValue(element, "nbgMaps.Caption", ConstStrings.Maps);
            SetPropertyPathValue(element, "nbgSoftware.Caption", ConstStrings.Software);

            SetPropertyPathValue(element, "bsiNavigation.Hint", ConstStrings.NavigationDescription);
            SetPropertyPathValue(element, "bbiDate.Hint", ConstStrings.SearchCreatedDescription);
            SetPropertyPathValue(element, "bbiClearFilter.Hint", ConstStrings.SearchClearDescription);
            SetPropertyPathValue(element, "bsiColumns.Hint", ConstStrings.SearchColumnsDescription);
            SetPropertyPathValue(element, "bbiResetColumnsToDefault.Hint", ConstStrings.SearchResetDescription);
            SetPropertyPathValue(element, "bbiCloseSearch.Hint", ConstStrings.SearchCloseDescription);
        }

        #region internal
        internal static void SetPropertyPathValue(object obj, string path, object value)
        {
            var pathParts = path.Split('.');
            if (pathParts.Length == 0) return;
            var target = obj;
            for (var i = 0; i < pathParts.Length - 1; ++i)
            {
                if (target == null) break;
                target = GetMemberValue(target, pathParts[i]);
            }
            if (target != null)
                SetMemberValue(target, pathParts[pathParts.Length - 1], value);
        }
        static object GetMemberValue(object obj, string memberName, Type objType = null)
        {
            var objectType = objType ?? obj.GetType();
            var declaredPropertyInfo = objectType.GetProperty(memberName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly);
            if (declaredPropertyInfo != null)
                return declaredPropertyInfo.GetValue(obj, null);
            var fieldInfo = objectType.GetField(memberName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if (fieldInfo != null)
                return fieldInfo.GetValue(obj);
            try
            {
                var propertyInfo = objectType.GetProperty(memberName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                if (propertyInfo != null)
                    return propertyInfo.GetValue(obj, null);
            }
            catch (AmbiguousMatchException) { }
            if (objectType.BaseType != null)
                return GetMemberValue(obj, memberName, objectType.BaseType);
            return null;
        }
        static void SetMemberValue(object obj, string memberName, object value, Type objType = null)
        {
            var objectType = objType ?? obj.GetType();
            var declaredPropertyInfo = objectType.GetProperty(memberName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly);
            if (declaredPropertyInfo != null)
            {
                declaredPropertyInfo.SetValue(obj, value, null);
                return;
            }
            var fieldInfo = objectType.GetField(memberName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            if (fieldInfo != null)
            {
                fieldInfo.SetValue(obj, value);
                return;
            }
            try
            {
                var propertyInfo = objectType.GetProperty(memberName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(obj, value, null);
                    return;
                }
            }
            catch (AmbiguousMatchException) { }
            if (objectType.BaseType != null)
            {
                SetMemberValue(obj, memberName, objectType.BaseType);
            }
        }
        #endregion

    }
}
