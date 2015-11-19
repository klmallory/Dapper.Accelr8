using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapper.Accelr8.Repo.Parameters
{
    public enum AggregateType
    {
        Average,
        Count,
        CountBig,
        Grouping,
        GroupingId,
        Max,
        Min,
        Sum,
        STDev,
        STDevP,
        Var,
        VarP,
        Check
    }

    public struct Aggregate
    {
        public AggregateType AggregateType;
        public TableFieldKey Field;
        public string ResultAlias;
        public bool Distinct;
        public Over? OverClause;
    }

    public struct Over 
    {
        public string Rows;
        public TableFieldKey Partition;
        public OrderBy[] OrderBy;
    }

    public struct Having
    {
        public bool OpenBlock;
        public bool UseOr;
        public Aggregate Aggregate;
        public Operator Operator;
        public object Value;
        public object[] ValueArray;
        public bool CloseBlock;
        public string GetUniqueParameter()
        {
            if (Operator == Operator.In)
            {
                var s = string.Empty;
                for (var i = 0; i < ValueArray.Length; i++)
                {
                    s += "@having" + Aggregate.Field.TableAlias + "_" + Aggregate.Field.FieldName + i + ",";
                }

                return s.TrimEnd(',');
            }
            else
                return "@having" + Aggregate.Field.TableAlias + "_" + Aggregate.Field.FieldName;
        }
    }
}
