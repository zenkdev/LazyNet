using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

namespace Dekart.LazyNet.Helpers
{
    public static class SessionHelper
    {
        public static Exception CommitSession(UnitOfWork session, IExceptionProcesser exceptionProcesser)
        {
            try
            {
                session.CommitChanges();
                return null;
            }
            catch (Exception e)
            {
                if (exceptionProcesser != null)
                {
                    exceptionProcesser.Process(e);
                    return e;
                }
                throw;
            }
        }
        public static object GetObject(object obj, Session session)
        {
            var xpObject = obj as IXPSimpleObject;
            if (xpObject == null) return null;
            while (xpObject.Session != session && xpObject.Session is NestedUnitOfWork)
                xpObject = ((NestedUnitOfWork)xpObject.Session).GetParentObject(xpObject);
            if (xpObject.Session == session) return xpObject;
            XPClassInfo targetClassInfo = session.GetClassInfo(xpObject.GetType());
            return session.GetObjectByKey(targetClassInfo, xpObject.Session.GetKeyValue(xpObject));
        }
        public static T GetObject<T>(T obj, Session session)
        {
            return (T)GetObject((object)obj, session);
        }
        public static object GetObjectByKey(Type classType, object objectKey, Session session)
        {
            return session.GetObjectByKey(classType, objectKey) ?? GetObjectByKeyCore(classType, objectKey, session);
        }
        public static T GetObjectByKey<T>(object objectKey, Session session)
        {
            return (T)GetObjectByKey(typeof(T), objectKey, session);
        }

        static object GetObjectByKeyCore(Type classType, object objectKey, Session session)
        {
            NestedUnitOfWork nested = session as NestedUnitOfWork;
            Session parent = nested != null ? nested.Parent : session;
            object parentObject = parent.GetObjectByKey(classType, objectKey);
            if (parentObject == null)
            {
                foreach (PersistentBase item in parent.GetObjectsToSave())
                {
                    if (item.IsDeleted) continue;
                    if (parent.GetKeyValue(item).Equals(objectKey))
                    {
                        parentObject = item;
                        break;
                    }
                }
            }
            if (parentObject == null) return null;
            return nested == null ? parentObject : nested.GetNestedObject(parentObject);
        }
    }
}
