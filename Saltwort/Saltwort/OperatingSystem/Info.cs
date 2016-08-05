using System.Automation.Interop;
using System.Diagnostics;

namespace System.Automation.OperatingSystem
{
    public class Info
    {
        public static string OSArch
        {
            get
            {
                if (IntPtr.Size == 8 || InternalCheckIsWow64())
                    return "X64";
                return "X86";
            }
        }

        public static bool IsWow64
        {
            get
            {
                if (IntPtr.Size == 8 || InternalCheckIsWow64())
                    return true;
                return false;
            }
        }

        private static bool InternalCheckIsWow64()
        {
            if ((Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) ||
                Environment.OSVersion.Version.Major >= 6)
            {
                using (Process p = Process.GetCurrentProcess())
                {
                    bool retVal;
                    if (!NativeMethods.IsWow64Process(p.Handle, out retVal))
                    {
                        return false;
                    }
                    return retVal;
                }
            }
            else
            {
                return false;
            }
        }


        public static bool IsXPOrHigher()
        {
            System.OperatingSystem os = Environment.OSVersion;
            return (os.Platform == PlatformID.Win32NT) && ((os.Version.Major > 5) || ((os.Version.Major == 5) && (os.Version.Minor >= 1)));
        }

        static bool IsWinVistaOrHigher()
        {
            System.OperatingSystem os = Environment.OSVersion;
            return (os.Platform == PlatformID.Win32NT) && (os.Version.Major >= 6);
        }

    }
}