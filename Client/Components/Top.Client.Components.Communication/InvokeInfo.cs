using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Runtime.Serialization;
using System.IO;
using System.Text;
using System.Reflection;
using System.Collections.Generic;

namespace Top.Client.Components.Communication
{
    [DataContract, KnownType("GetParameterTypes")]
    public class InvokeInfo
    {
        // Fields
        private string _name;
        private object[] _parameters;

        // Methods
        public InvokeInfo()
        {
        }

        public InvokeInfo(string name, params object[] parameters)
            : this()
        {
            this._name = name;
            this._parameters = parameters;
        }

        private static MethodInfo GetMethod(Type t, string name, object[] parameters)
        {
            MethodInfo method;
            try
            {
                method = t.GetMethod(name);
            }
            catch (Exception)
            {
                return null;
            }
            return method;
            try
            {
                if (parameters == null)
                {
                    return null;
                }
                int length = parameters.Length;
                if (length < 1)
                {
                    return null;
                }
                Type[] types = new Type[length];
                for (int i = 0; i < length; i++)
                {
                    if (parameters[i] == null)
                    {
                        return null;
                    }
                    types[i] = parameters[i].GetType();
                }
                method = t.GetMethod(name, types);
            }
            catch (Exception)
            {
            }
            return method;
        }

        public static Type[] GetParameterTypes()
        {
            return new Type[] { 
            //typeof(BoardStructure), typeof(WorkspaceStructure), typeof(BaseChartStructure), typeof(Dictionary<string, string>), typeof(List<SystemParams>), typeof(EMUserDefaultInfoType), typeof(MessageStructure), typeof(EMMessageState), typeof(DataTableStructure), typeof(BusinessObjectType), typeof(List<string>), typeof(UserStructure), typeof(SubscribeMessageByEmail), typeof(Dictionary<Guid, int>), typeof(List<Guid>), typeof(UserGroup), 
            //typeof(RDataTable), typeof(PackageInfo), typeof(PluginStructure), typeof(GlobalFilter), typeof(LicenseInfo), typeof(DataConnectionStructure), typeof(Category), typeof(ChartDrillDown), typeof(List<BaseGridWidth>), typeof(EMDataTableType), typeof(Dictionary<string, RDataTable>), typeof(ObjectChangedMessage), typeof(FileUploadInfo), typeof(StyleStructure)
         };
        }

        public object Invoke(object obj)
        {
            return Invoke(obj, obj, this._name, this._parameters);
        }

        public static object Invoke(object obj, string name, object[] parameters)
        {
            return Invoke(obj, obj, name, parameters);
        }

        private static object Invoke(object site, object obj, string name, object[] parameters)
        {
            Type type;
            PropertyInfo property;
            FieldInfo field;
            if ((obj == null) || string.IsNullOrEmpty(name))
            {
                throw new Exception("Parameter Error！");
            }
            int index = name.IndexOf('.');
            if (index < 0)
            {
                if (parameters != null)
                {
                    int num2 = 0;
                    int length = parameters.Length;
                    while (num2 < length)
                    {
                        InvokeInfo info = parameters[num2] as InvokeInfo;
                        if (info != null)
                        {
                            parameters[num2] = info.Invoke(site);
                        }
                        num2++;
                    }
                }
                type = obj.GetType();
                MethodInfo info2 = GetMethod(type, name, parameters);
                if ((info2 != null) && info2.IsPublic)
                {
                    return info2.Invoke(obj, parameters);
                }
                property = type.GetProperty(name);
                if ((property != null) && property.CanRead)
                {
                    return property.GetValue(obj, parameters);
                }
                if ((parameters == null) || (parameters.Length == 0))
                {
                    field = type.GetField(name);
                    if ((field != null) && field.IsPublic)
                    {
                        return field.GetValue(obj);
                    }
                }
                throw new Exception("Parameter Error,not find \"" + name + "\"");
            }
            if (index > 0)
            {
                type = obj.GetType();
                string str = name.Substring(0, index);
                property = type.GetProperty(str);
                object obj2 = null;
                if ((property != null) && property.CanRead)
                {
                    obj2 = property.GetValue(obj, null);
                }
                else
                {
                    field = type.GetField(str);
                    if ((field != null) && field.IsPublic)
                    {
                        obj2 = field.GetValue(obj);
                    }
                }
                if (obj2 == null)
                {
                    throw new Exception("Parameter Error,not find +\"" + name + "\"");
                }
                obj = obj2;
            }
            return Invoke(site, obj, name.Substring(index + 1), parameters);
        }

        public static InvokeInfo Parse(string s)
        {
            return Parse(s, null);
        }

        public static InvokeInfo Parse(string s, IEnumerable<Type> knownTypes)
        {
            if (!string.IsNullOrEmpty(s))
            {
                MemoryStream stream = null;
                try
                {
                    try
                    {
                        stream = new MemoryStream(Encoding.UTF8.GetBytes(s), false);
                        DataContractSerializer serializer = new DataContractSerializer(typeof(InvokeInfo), knownTypes);
                        return (serializer.ReadObject(stream) as InvokeInfo);
                    }
                    catch (Exception)
                    {
                    }
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                }
            }
            return null;
        }

        public override string ToString()
        {
            return this.ToString(null);
        }

        public string ToString(IEnumerable<Type> knownTypes)
        {
            MemoryStream stream = null;
            try
            {
                try
                {
                    stream = new MemoryStream();
                    new DataContractSerializer(typeof(InvokeInfo), knownTypes).WriteObject(stream, this);
                    return Encoding.UTF8.GetString(stream.GetBuffer(), 0, (int)stream.Length);
                }
                catch (Exception)
                {
                }
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            return null;
        }

        // Properties
        [DataMember]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        [DataMember]
        public object[] Parameters
        {
            get
            {
                return this._parameters;
            }
            set
            {
                this._parameters = value;
            }
        }

        public static InvokeInfo userIID
        {
            get
            {
                return new InvokeInfo("userIID", new object[0]);
            }
        }
    }
}
