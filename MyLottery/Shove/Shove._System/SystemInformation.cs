namespace Shove._System
{
    using System;
    using System.Management;

    public class SystemInformation
    {
        public static string GetBIOSSerialNumber()
        {
            return GetWMIInfo("SerialNumber", "Win32_BIOS");
        }

        public static string GetCPUSerialNumber()
        {
            return GetWMIInfo("ProcessorId", "Win32_Processor");
        }

        public static string GetHardDiskSerialNumber()
        {
            return GetWMIInfo("SerialNumber", "Win32_PhysicalMedia");
        }

        public static string GetNetCardMACAddress()
        {
            return GetWMIInfo("MACAddress", "Win32_NetworkAdapter WHERE ((MACAddress Is Not NULL) AND (Manufacturer <> 'Microsoft'))");
        }

        public static string GetWMIInfo(string sInfoType, string sWin32_Database)
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select " + sInfoType + " From " + sWin32_Database);
                string str = "";
                foreach (ManagementObject obj2 in searcher.Get())
                {
                    str = obj2[sInfoType].ToString().Trim();
                }
                return str;
            }
            catch
            {
                return "";
            }
        }
    }
}

