﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper.Accelr8.Repo.Parameters;


namespace Dapper.Accelr8.Sql
{
    public class QueryBuilder
    {
        public static Dictionary<Operator, string> OperatorFormats
             = new Dictionary<Operator, string>()
             {
                 {Operator.None, "{0}" },
                 {Operator.Equals, "= {0}"},
                 {Operator.NotEquals, "= {0}"},
                 {Operator.Greater, "> {0}"},
                 {Operator.GreaterOrEquals, ">= {0}"},
                 {Operator.Lesser, "< {0}"},
                 {Operator.LesserOrEquals, "<= {0}"},
                 {Operator.EndsLike, "like ({0})"},
                 {Operator.StartsLike, "like ({0})"},
                 {Operator.Like, "like ({0})"},
                 {Operator.In, "in ({0})"},
                 {Operator.IsNull, "is null"},
                 {Operator.IsNotNull, "is not null"},
                 {Operator.Between, ">= {0} and {1} >= "},
                 {Operator.BetweenExclusive, ">= {0} and {1} >= "}
             };

        protected static readonly string genericWhereClause = @"where {0}[{1}].[{2}] {3}{4} "; //0 is open bracket, 1 is alias, 3 is operator and value, 4 is close bracket
        protected static readonly string genericAndClause = @"and {0}[{1}].[{2}] {3}{4} "; //0 is open bracket, 1 is alias
        protected static readonly string genericOrClause = @"or {0}[{1}].[{2}] {3}{4} "; //0 is open bracket, 1 is alias

        public virtual string BuildQueryElements(IList<QueryElement> elements, int taskIndex)
        {
            var sb = new StringBuilder();
            int count = 0;
            foreach (var e in elements)
                sb.Append(BuildQueryElement(e, ref count, taskIndex));

            return sb.ToString();
        }

        public virtual string BuildQueryElement(QueryElement e, ref int count, int taskIndex)
        {
            var template = count == 0 ? genericWhereClause :
                e.UseOr ? genericOrClause : genericAndClause;

            var openBlock = e.OpenBlock ? "(" : string.Empty;
            var closeBlock = e.CloseBlock ? ")" : string.Empty;
            var o = OperatorFormats[e.Operator];

            string p = string.Empty;

            if (e.Operator == Operator.In)
                foreach (var u in e.GetUniqueParameters("q"))
                    p += u + "_" + taskIndex + "_" + count++ + ", ";
            else
                p = e.GetUniqueParameter("q") + "_" + taskIndex + "_" + count++;

            var valOp = string.Format(o, p.TrimEnd(',', ' '));

            return string.Format(template, openBlock, e.TableAlias, e.FieldName, valOp, closeBlock);
        }
    }
}
