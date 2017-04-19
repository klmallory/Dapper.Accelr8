using System.Collections.Generic;

namespace Dapper.Accelr8.Repo
{
    public interface ITableInfo
    {
        IDictionary<int, string> Columns { get; set; }
        IDictionary<int, string> IdColumns { get; set; }
        //JoinInfo[] Joins { get; set; }

        string Schema { get; set; }
        string TableAlias { get; set; }
        string TableName { get; set; }
        bool UniqueId { get; set; }
    }
}