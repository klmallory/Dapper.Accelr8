using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Accelr8.Repo.Parameters
{
    public struct QueryElement
    {
        public bool OpenBlock;
        public bool UseOr;
        public string TableAlias;
        public string FieldName;
        public Operator Operator;
        public string[] ParamNames;
        public object Value;
        public object[] ValueArray;
        public bool CloseBlock;

        public IList<string> GetUniqueParameters(string paramType)
        {
            var alias = TableAlias;
            var name = FieldName;

            if (ParamNames != null && ParamNames.Length > 0)
                return ParamNames.Select(p => "@" + p).ToList();
            else
                return ValueArray.ToList()
                    .Select
                    (a => "@" + alias + "_" + name + "_" + paramType).ToList(); //+ "_" + count++
        }

        public string GetUniqueParameter(string paramType)
        {
            if (Operator == Operator.In)
            {
                if (ParamNames != null && ParamNames.Length > 0)
                    return string.Join(", @", ParamNames).TrimEnd(',', ' ', '@');
                else
                {
                    var s = string.Empty;
                    for (var i = 0; i < ValueArray.Length; i++)
                    {
                        s += "@" + TableAlias + "_" + FieldName + "_" + paramType + ","; //+ "_" + i
                    }
                    return s.TrimEnd(',');
                }
            }
            else
            {
                if (ParamNames != null && ParamNames.Length > 0)
                    return "@" + ParamNames[0];
                else
                    return "@" + TableAlias + "_" + FieldName + "_" + paramType;
            }
        }
    }
}
