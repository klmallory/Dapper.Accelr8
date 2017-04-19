using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
   public static class StringExtensions
    {
       public static string FormatParams(this string format, params object[] arguments)
       {
           if (format == null)
               return null;

           return string.Format(format, arguments);
       }
    }
}
