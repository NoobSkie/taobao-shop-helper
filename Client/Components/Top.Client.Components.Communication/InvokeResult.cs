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
using Top.Client.Components.DataObject;

namespace Top.Client.Components.Communication
{
    [KnownType("GetResultTypes"), DataContract]
    public class InvokeResult
    {
        // Fields
        private CommunicateException _error;
        private object _result;

        // Methods
        public static Type[] GetResultTypes()
        {
            return new Type[] { 
            //typeof(RDataTable), typeof(List<ApplicationLanguage>), typeof(BoardStructure), typeof(WorkspaceStructure), typeof(BaseChartStructure), typeof(List<SystemParams>), typeof(List<SystemFavorite>), typeof(DataTableStructure), typeof(AppNewlyFilesResult), typeof(AppDownloadFile), typeof(AppUserParameters), typeof(ManagementTree), typeof(List<FDataConnection>), typeof(List<TableField>), typeof(List<GlobalFilter>), typeof(GlobalFilter), 
            //typeof(List<Plugin>), typeof(MessageStructure), typeof(ChartResultData), typeof(Dictionary<string, RDataTable>), typeof(List<string>), typeof(SubscribeMessageByEmail), typeof(UserGroup), typeof(PluginStructure), typeof(List<FilterDataTypeStructure>), typeof(Category), typeof(List<Guid>), typeof(List<DataConnectionProvider>), typeof(DataConnectionStructure), typeof(CustomerInformation), typeof(PackageInfo), typeof(EMUserDefaultInfoType), 
            //typeof(ChartClass), typeof(List<BaseGridWidth>), typeof(List<CanNotPublishInformation>), typeof(EmbedExtendedDataConnection), typeof(List<EmbedExtendedDataConnection>), typeof(Users), typeof(UserStructure), typeof(FDataTable), typeof(FileUploadInfo), typeof(StyleStructure), typeof(EMLoginMode)
         };
        }

        // Properties
        [DataMember]
        public CommunicateException Error
        {
            get
            {
                return this._error;
            }
            set
            {
                this._error = value;
            }
        }

        [DataMember]
        public object Result
        {
            get
            {
                return this._result;
            }
            set
            {
                this._result = value;
            }
        }
    }
}
