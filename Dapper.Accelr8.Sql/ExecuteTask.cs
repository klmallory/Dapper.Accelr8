using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;


namespace Dapper.Accelr8.Sql
{
    public class ExecuteTask<EntityType>
        where EntityType : class, IEntity
    {
        public ExecuteTask(int index)
        {
            Index = index;
            Queries = new List<QueryElement>();
            Joins = new List<Join>();
            Params = new Dictionary<string, object>();
        }

        public int Index { get; set; }
        public ActionType TaskType { get; set; }
        public EntityType Entity { get; set; }
        public List<QueryElement> Queries { get; set; }
        public List<Join> Joins { get; set; }
        public string Script { get; set; }
        public IDictionary<string, object> Params { get; set; }
    }
}
