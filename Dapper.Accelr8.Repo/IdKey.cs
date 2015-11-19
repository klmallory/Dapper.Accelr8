using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Transactions;
using Dapper.Accelr8.Repo.Contracts.Writers;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.PInvoke;

namespace Dapper.Accelr8.Repo
{
    public struct IdKey : IComparable<IdKey>
    {
        static int ByteArrayCompare(byte[] b1, byte[] b2)
        {
            if (b1.Length > b2.Length)
                return 1;
            else if (b1.Length < b2.Length)
                return -1;

            return Msvcrt.memcmp(b1, b2, b1.Length);
        }

        public IdKey(object id, int typeHashCode)
            : this()
        {
            var key = BitConverter.GetBytes(typeHashCode);
            Key = key.Concat(BitConverter.GetBytes(id.GetHashCode())).ToArray();
        }

        public byte[] Key { get; private set; }

        public int CompareTo(IdKey other)
        {
            return ByteArrayCompare(Key, other.Key);
        }
    }
}
