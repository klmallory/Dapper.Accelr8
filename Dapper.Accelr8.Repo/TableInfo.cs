using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Accelr8.Repo.Contracts.Readers;
using Dapper.Accelr8.Repo.Contracts.Writers;

namespace Dapper.Accelr8.Repo
{
    public class TableInfo
    {
        public TableInfo()
        {
            FieldNames = new string[0];
            Joins = new JoinInfo[0];
        }

        public TableInfo(bool uniqueId, string idField, string tableName, string tableAlias, string[] fieldNames)
        {
            UniqueId = uniqueId;
            IdField = idField;
            TableName = tableName;
            TableAlias = tableAlias;
            FieldNames = fieldNames;
        }

        public bool UniqueId { get; set; }
        public string IdField { get; set; }
        public string TableName { get; set; }
        public string TableAlias { get; set; }
        public string[] FieldNames { get; set; }
        public JoinInfo[] Joins { get; set; }
    }
}
