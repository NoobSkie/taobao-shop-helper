using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace J.SLS.Database
{
    internal static class ErrorMessages
    {
        internal const string NotHandledException = "The exception have not been handled.";
        internal const string PreconditionAssertFailed = "Pre-condition assert failed.";
        internal const string DBConnectionStringIsNullOrEmpty = "DBConnectionString is null or empty in current LHDBAccess instance.";
        internal const string CommandTextIsNullOrEmpty = "The command sql text is null or empty, it cann't be executed.";
        internal const string CommandTextIsErrorMessage = "The command sql text is error, it cann't be executed.";
        internal const string TableNameIsEmpty = "TableName cannot be null or empty";
        internal const string SqlParameterNotMatchValues = "The privided parameters don't match the command sql's arguments.";
        internal const string NotSupportedDatabaseType = "Cann't supportted the database type.";
        internal const string NullReferenceException = "object is null or empty, it can not be executed";
        internal const string AddEntityErrorMessage = "Add entity object failure";
        internal const string SelectEntityErrorMessage = "Select entity object failure";
        internal const string ExecDbCommandErrorMessage = "Operating database failure";
        internal const string PrimaryKeyConflict = "Primary key conflict.";
        internal const string IndexConflict = "Primary key conflict.";
        internal const string PrimaryKeyIsNull = "Primary key cannot be null.";
        internal const string CommiteError = "Commit transaction failure.";
        internal const string ResultNotUniqueMessage = "Select Entity by key is not unique";
        internal const string EntityMappingError = "Entity Mapping Error";
        internal const string EntityReadOnly = "Entity is ReadOnly";
        internal const string TransactionCommited = "This transaction was commited";
    }
}
