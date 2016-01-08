using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapper.Accelr8.Repo.Extensions
{
    public static class EnumExtensions
    {
        public static IDictionary<baseType, string> ToDataList<enumType, baseType>(this enumType en) where enumType : Type
        {
            if (!en.IsEnum)
                return new Dictionary<baseType, string>();

            var data = new Dictionary<baseType, string>();

            foreach (var e in Enum.GetValues(en))
                data.Add((baseType)e, e.ToString());

            return data;
        }
    }
}
