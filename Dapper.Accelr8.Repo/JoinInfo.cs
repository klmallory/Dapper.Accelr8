using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Accelr8.Repo.Contracts.Readers;
using Dapper.Accelr8.Repo.Parameters;

namespace Dapper.Accelr8.Repo
{
    public class JoinInfo
    {
        public Func<IEntityReader> Reader { get; set; }
        public Action<object, dynamic> SetOnParent { get; set; }
        public Type IdType { get; set; }
        public Type EntityType { get; set; }
        public string TableName { get; set; }
        public string Alias { get; set; }
        public bool Outer { get; set; }
        public JoinQueryElement[] JoinQuery { get; set; }
    }
}
