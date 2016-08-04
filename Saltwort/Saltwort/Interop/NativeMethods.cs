using System;
using System.Runtime.InteropServices;

namespace Saltwort.Interop
{
    public class NativeMethods
    {
        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWow64Process(
              [In] IntPtr hProcess,
              [Out] out bool wow64Process
            );
    }
}