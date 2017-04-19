using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class ObjectExtensions
    {
        public static string SafeToString(this object value)
        {
            if (value == null)
                return null;

            return value.ToString();
        }

        public static int? SafeToInt32(this object value)
        {
            try
            {
                if (value == null)
                    return null;

                return Convert.ToInt32(value);
            }
            catch (FormatException) { }
            catch (InvalidCastException) { }
            catch (OverflowException) { }

            return null;
        }

        public static long? SafeToInt64(this object value)
        {
            try
            {
                if (value == null)
                    return null;

                return Convert.ToInt64(value);
            }
            catch (FormatException) { }
            catch (InvalidCastException) { }
            catch (OverflowException) { }

            return null;
        }

        public static DateTime? SafeToDateTime(this object value)
        {
            try
            {
                if (value == null)
                    return null;

                return Convert.ToDateTime(value);
            }
            catch (FormatException) { }
            catch (InvalidCastException) { }
            catch (OverflowException) { }

            return null;
        }
        public static bool? SafeToBoolean(this object value)
        {
            try
            {
                if (value == null)
                    return null;

                return Convert.ToBoolean(value);
            }
            catch (FormatException) { }
            catch (InvalidCastException) { }
            catch (OverflowException) { }

            return null;
        }
        public static Guid? SafeToGuid(this object value)
        {
            try
            {
                if (value == null || !(value is Guid))
                    return null;

                return (Guid)value;
            }
            catch (FormatException) { }
            catch (InvalidCastException) { }
            catch (OverflowException) { }

            return null;
        }

        public static IList<T> SafeToList<T>(this object value)
        {
            if (value == null)
                return null;

            if (value is IEnumerable || value.GetType().IsArray)
                return (value as IEnumerable).OfType<T>().ToList();

            throw new InvalidCastException(
                string.Format("type {0} could not be converted to type {1}", 
                value.GetType(), 
                typeof(IList<>).MakeGenericType(typeof(T))));
        }

        public static T[] SafeToArray<T>(this object value)
        {
            if (value == null)
                return null;

            if (value is IEnumerable || value.GetType().IsArray)
                return (value as IEnumerable).OfType<T>().ToArray();

            throw new InvalidCastException(
                string.Format("type {0} could not be converted to type {1}",
                value.GetType(),
                typeof(IList<>).MakeGenericType(typeof(T))));
        }

        public static byte[] SafeToBytes(this object value)
        {
            if (value == null)
                return null;

            if (value is string)
                return Convert.FromBase64String(value as string);
            else if (value is byte[])
                return value as byte[];
            else
                throw new InvalidCastException
                    ("type of value parameter: {0} could not be converted to type of byte[].".FormatParams(value.GetType()));
        }
    }
}
