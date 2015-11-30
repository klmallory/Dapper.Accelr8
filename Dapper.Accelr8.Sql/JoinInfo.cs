using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Repo.Contracts.Readers;
using Dapper.Accelr8.Repo.Parameters;

namespace Dapper.Accelr8.Sql
{
    public class JoinInfo
    {
        public Func<IEntityReader> Reader { get; set; }
        public Func<object, dynamic, object> Load { get; set; }
        public string TableName { get; set; }
        public string Alias { get; set; }
        public bool Outer { get; set; }
        public JoinQueryElement[] JoinQuery { get; set; }
    }
}
