using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapper.Accelr8.Repo.Parameters
{
    public struct OrderBy
    {
        public string TableAlias;
        public string FieldName;
        public bool Descending;
    }
}
