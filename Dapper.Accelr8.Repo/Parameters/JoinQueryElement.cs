using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper.Accelr8.Repo.Parameters;

namespace Dapper.Accelr8.Repo.Parameters
{
    public struct Join
    {
        public bool Outer;
        public string JoinTable;
        public string JoinAlias;
        public string[] JoinFiedNames;
        public string SplitOnColumnName;
        public JoinQueryElement[] JoinOnQueries;
        public Func<object, dynamic, object> Load;
    }

    public struct JoinQueryElement
    {
        public bool OpenBlock;
        public bool UseOr;
        public Operator Operator;
        public string ParentTableAlias;
        public string ParentField;
        public string JoinField;
        public bool CloseBlock;
    }
}
