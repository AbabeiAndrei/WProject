using System;

namespace WProject.GenericLibrary.Helpers.Extensions
{
    public static class ReflexionEx
    {
        public static object GetProperty(this object obj, string propertyName)
        {
            return GetProperty<object>(obj,propertyName);
        }

        public static T GetProperty<T>(this object obj, string propertyName)
        {
            if(obj == null)
                throw new NullReferenceException("Obj cannot be null");

            var mpi = obj.GetType().GetProperty(propertyName);

            if(mpi == null)
                throw new Exception("UNKNOW PROPERTY NAME");

            if(!mpi.CanRead)
                throw new Exception("PROPERTY CANNOT BE READED");

            return (T)mpi.GetValue(obj);


        }
    }
}
