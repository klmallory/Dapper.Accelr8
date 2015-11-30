using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Dapper.Accelr8.Repo
{
    public class ExecutionContext
    {

        public ExecutionContext()
        {
            _keys = new Stack<int>();
        }

        object _syncRoot = new Object();

        Stack<int> _keys { get; set; }

        public void Add(int hashcode)
        {
            lock (_syncRoot)
                _keys.Push(hashcode);
        }

        public bool ContainsKey(int hashcode)
        {
            lock (_syncRoot)
                return _keys.Contains(hashcode);
        }
    }
}
