using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Dapper.Accelr8.Repo.PInvoke
{
    public static class Msvcrt
    {
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int memcmp(byte[] b1, byte[] b2, long count);
    }
}
