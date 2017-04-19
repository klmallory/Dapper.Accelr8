using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Contracts;
using System.Data;

namespace Dapper.Accelr8.Sql
{
    public class TableInfo : ITableInfo
    {
        protected static object _syncRoot = new object();
        protected static Dictionary<string, object> _readers = new Dictionary<string, object>();
        protected static bool _cacheReaders = true;
        protected ILoc8 Loc8r { get; set; }

        public TableInfo(ILoc8 loc8r)
        {
            Columns = new Dictionary<int, string>();
            Joins = new JoinInfo[0];

            Loc8r = loc8r;
        }

        public TableInfo(bool uniqueId, string tableName, string tableAlias, IDictionary<int, string> columnNames, string schema)
        {
            UniqueId = uniqueId;
            TableName = tableName;
            TableAlias = tableAlias;
            Columns = columnNames;
            Schema = schema;
        }

        public bool UniqueId { get; set; }
        public string TableName { get; set; }
        public string TableAlias { get; set; }
        public string Schema { get; set; }
        public IDictionary<int, string> Columns { get; set; }
        public IDictionary<int, string> IdColumns { get; set; }
        public JoinInfo[] Joins { get; set; }
    }
}
