using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dapper.Accelr8.Repo
{
    public interface IAccelr8Locator
    {
        object Resolve(Type type);
        object Resolve(Type type, string name);
        I Resolve<I>();
        I Resolve<I>(string name);
    }
}
