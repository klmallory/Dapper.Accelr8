using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapper.Accelr8.Repo.Parameters
{
    public enum Operator
    {
        None,
        Equals,
        NotEquals,
        Greater,
        GreaterOrEquals,
        Lesser,
        LesserOrEquals,
        EndsLike,
        StartsLike,
        Like,
        In,
        IsNull,
        IsNotNull,
        Between,
        BetweenExclusive
    }
}
