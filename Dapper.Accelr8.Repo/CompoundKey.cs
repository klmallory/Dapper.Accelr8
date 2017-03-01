using Dapper.Accelr8.Repo.PInvoke;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Dapper.Accelr8.Repo
{
    public struct CompoundKey :
        IEqualityComparer<CompoundKey>, 
        IEquatable<CompoundKey>, 
        IComparable<CompoundKey>, 
        IComparable
    {
        public IComparable[] Keys;

        public int CompareTo(object obj)
        {
            if (obj == null || !(obj is CompoundKey))
                return -1;
            
            var c = (CompoundKey)obj;

            return CompareTo(c);
        }

        public int CompareTo(CompoundKey other)
        {
            if (other.Keys == null && this.Keys == null)
                return 0;

            if (other.Keys == null && this.Keys != null)
                return -1;

            if (other.Keys != null && this.Keys == null)
                return 1;

            if (other.Keys.Length < Keys.Length)
                return -1;

            if (other.Keys.Length > Keys.Length)
                return 1;

            for(var i = 0; i <Keys.Length; i++)
            {
                var r = Keys[i].CompareTo(other.Keys[i]);

                if (r != 0)
                    return r;
            }

            return 0;
        }

        public bool Equals(CompoundKey other)
        {
            if (other.Keys == null && this.Keys == null)
                return true;

            if (other.Keys == null || this.Keys == null)
                return false;

            if (other.Keys.Length == 0 && other.Keys.Length == 0)
                return true;

            if (other.Keys.Length != Keys.Length)
                return false;

            for (var i = 0; i < Keys.Length; i++)
            {
                if (other.Keys[i] != Keys[i])
                    return false;
            }
            return true;
        }

        public bool Equals(CompoundKey x, CompoundKey y)
        {
            return x.Equals(y);      
        }

        public int GetHashCode(CompoundKey obj)
        {
            return obj.GetHashCode();
        }
    }
}
