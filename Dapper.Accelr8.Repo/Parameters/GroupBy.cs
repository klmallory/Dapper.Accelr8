using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapper.Accelr8.Repo.Parameters
{
    public struct GroupBy
    {
        public string TableAlias;
        public string FieldName;
        public string Function;

        public string GetUniqueParameter()
        {
            return "@group" + Function + this.GetHashCode();
        }
    }
}
