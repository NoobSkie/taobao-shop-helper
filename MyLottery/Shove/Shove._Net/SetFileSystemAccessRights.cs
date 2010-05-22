namespace Shove._Net
{
    using System;
    using System.Collections;
    using System.Management;
    using System.Runtime.InteropServices;
    using System.Text;

    public class SetFileSystemAccessRights
    {
        private static string GetFileSystem(string diskName)
        {
            string str = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select filesystem from Win32_LogicalDisk where name='" + diskName + ":'");
            foreach (ManagementObject obj2 in searcher.Get())
            {
                PropertyDataCollection.PropertyDataEnumerator enumerator2 = obj2.Properties.GetEnumerator();

                while (enumerator2.MoveNext())
                {
                    str = enumerator2.Current.Value.ToString();
                }
                continue;
            }
            return str;
        }

        private static int SetDACL(string filePath, string userName, bool isNew)
        {
            int cbSid = 100;
            byte[] sid = new byte[0x1c];
            StringBuilder referencedDomainName = new StringBuilder(0xff);
            int cbReferencedDomainName = 0xff;
            int peUse = 0xff;
            if (!LookupAccountName(null, userName, sid, ref cbSid, referencedDomainName, ref cbReferencedDomainName, ref peUse))
            {
                return -1;
            }
            ManagementPath path = new ManagementPath();
            path.Server = ".";
            path.NamespacePath = @"root\cimv2";
            path.RelativePath = "Win32_LogicalFileSecuritySetting.Path='" + filePath + "'";
            ManagementObject obj2 = new ManagementObject(path);
            ManagementBaseObject obj3 = obj2.InvokeMethod("GetSecurityDescriptor", null, null);
            if (((uint)obj3.Properties["ReturnValue"].Value) != 0)
            {
                return -2;
            }
            ManagementBaseObject obj4 = (ManagementBaseObject)obj3.Properties["Descriptor"].Value;
            ManagementBaseObject[] objArray = (ManagementBaseObject[])obj4.Properties["Dacl"].Value;
            ManagementBaseObject[] objArray2 = new ManagementBaseObject[objArray.Length + (isNew ? 0 : 1)];
            if (isNew)
            {
                int index = 0;
                for (int i = 0; i < objArray.Length; i++)
                {
                    ManagementBaseObject obj5 = objArray[i];
                    ManagementBaseObject obj6 = (ManagementBaseObject)obj5.Properties["Trustee"].Value;
                    if (!(obj6.Properties["Name"].Value.ToString().Trim().ToLower() == userName.Trim().ToLower()))
                    {
                        objArray2[index] = objArray[i];
                        index++;
                    }
                }
            }
            else
            {
                for (int j = 0; j < objArray.Length; j++)
                {
                    objArray2[j] = objArray[j];
                }
            }
            ManagementBaseObject obj7 = (ManagementBaseObject)objArray[0].Clone();
            ManagementBaseObject obj8 = (ManagementBaseObject)obj7.Properties["Trustee"].Value;
            obj8.Properties["Domain"].Value = referencedDomainName.ToString();
            obj8.Properties["Name"].Value = userName;
            obj8.Properties["SID"].Value = sid;
            obj8.Properties["SidLength"].Value = 0x1c;
            obj7.Properties["Trustee"].Value = obj8;
            obj7.Properties["AccessMask"].Value = 0x12019f;
            obj7.Properties["AceFlags"].Value = 3;
            obj7.Properties["AceType"].Value = 0;
            objArray2[objArray.Length + (isNew ? -1 : 0)] = obj7;
            obj4.Properties["Dacl"].Value = objArray2;
            obj2.Scope.Options.EnablePrivileges = true;
            ManagementBaseObject methodParameters = obj2.GetMethodParameters("SetSecurityDescriptor");
            methodParameters["Descriptor"] = obj4;
            obj3 = obj2.InvokeMethod("SetSecurityDescriptor", methodParameters, null);
            return 0;
        }


        [DllImport("advapi32.dll")]
        public static extern bool LookupAccountName(string lpSystemName, string lpAccountName, byte[] sid, ref int cbSid, StringBuilder ReferencedDomainName, ref int cbReferencedDomainName, ref int peUse);
        private static bool FindTrustee(string filePath, string userName)
        {
            ArrayList list = new ArrayList();
            ManagementPath path = new ManagementPath();
            path.Server = ".";
            path.NamespacePath = @"root\cimv2";
            path.RelativePath = "Win32_LogicalFileSecuritySetting.Path='" + filePath + "'";
            ManagementBaseObject obj3 = new ManagementObject(path).InvokeMethod("GetSecurityDescriptor", null, null);
            if (((uint)obj3.Properties["ReturnValue"].Value) != 0)
            {
                throw new Exception("获取文件描述符失败");
            }
            ManagementBaseObject obj4 = (ManagementBaseObject)obj3.Properties["Descriptor"].Value;
            ManagementBaseObject[] objArray = (ManagementBaseObject[])obj4.Properties["Dacl"].Value;
            for (int i = 0; i < objArray.Length; i++)
            {
                list.Add(((ManagementBaseObject)objArray[i].Properties["Trustee"].Value).Properties["Name"].Value);
            }
            return list.Contains(userName);
        }

        public static int Set(string Dir, string UserName)
        {
            if (GetFileSystem(Dir.Substring(0, 1)) != "NTFS")
            {
                return -1;
            }
            SetDACL(Dir, UserName, FindTrustee(Dir, UserName));
            return 0;
        }
    }
}

