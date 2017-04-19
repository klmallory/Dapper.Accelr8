using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Accelr8.Repo.PInvoke;

namespace System
{
    public static class SafeComparisons
    {
        public static int SafeCompare<T>(this Nullable<T> o1, Nullable<T> o2) where T : struct, IComparable<T>
        {
            if (!o1.HasValue && !o2.HasValue)
                return 0;
            if (!o1.HasValue && o2.HasValue)
                return 1;
            if (o1.HasValue && !o2.HasValue)
                return -1;

            return o1.GetValueOrDefault().CompareTo(o2.GetValueOrDefault());
        }

        public static int SafeCompare(this byte[] array1, byte[] array2)
        {
            if (array1 == null && array2 == null)
                return 0;

            if (array1 == null && array2 != null)
                return -1;

            if (array1 != null && array2 == null)
                return 1;

            return Msvcrt.memcmp(array1, array2, array1.Length);
        }
    }
}
