using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Collections
{
    public static class CollectionExtensions
    {
        public static object ByKey (this KeyValuePair<string, object>[] array, string key)
        {
            return array.FirstOrDefault(a => a.Key == key).Value;
        }

    }
}
