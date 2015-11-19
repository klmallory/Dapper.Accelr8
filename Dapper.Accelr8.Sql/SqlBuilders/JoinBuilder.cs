using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper.Accelr8.Repo.Parameters;


namespace Dapper.Accelr8.Sql
{
    public class JoinBuilder
    {

        protected static readonly string genericJoinClause = @"join {0} [{1}] on {2}{1}.[{3}] {4}{5} "; //2 is open bracket, 5 is close bracket.
        protected static readonly string genericAndClause = @"and {0}[{1}].[{2}] {3}{4} "; //0 is open bracket //1 is alias
        protected static readonly string genericOrClause = @"or {0}[{1}].[{2}] {3}{4} "; //0 is open bracket //1 is alias

        public virtual string BuildJoins(IList<Join> joins)
        {
            var sb = new StringBuilder();

            var count = 0;
            var amount = joins.Count;
            foreach (var e in joins)
            {
                sb.Append(BuildJoin(e, count));
                if (count < amount - 1)
                    sb.Append(Environment.NewLine);
                count++;
            }

            return sb.ToString();
        }

        public virtual string BuildJoin(Join join, int count)
        {
            var s = string.Empty;
            var outer = join.Outer ? "left outer " : "";

            int c = 0;
            foreach (var j in join.JoinOnQueries)
            {
                var o = QueryBuilder.OperatorFormats[j.Operator];
                var v = string.Format(@"[{0}].[{1}]", j.ParentTableAlias, j.ParentField);
                var openBlock = j.OpenBlock ? @"(" : string.Empty;
                var closeBlock = j.CloseBlock ? @")" : string.Empty;

                if (c == 0)
                    s += outer + string.Format(genericJoinClause, join.JoinTable, join.JoinAlias, openBlock, j.JoinField, string.Format(o, v), closeBlock);
                else
                {
                    var form = j.UseOr ? genericOrClause : genericAndClause;

                    s += string.Format(form, openBlock, join.JoinAlias, j.JoinField, string.Format(o, v), closeBlock);
                    s += Environment.NewLine;
                }

                c++;
            }

            return s;
        }

    }
}
