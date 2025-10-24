using Dapper;
using System.Data;

namespace FiyiStackDeskApp.Library.G1.MSSQLServer
{
    public class Field
    {
        public static bool DoesFieldExist(string ConnectionString, string TableArea, string TableName, string SchemeName, string FieldName)
        {
            try
            {
                bool ExistField = false;
                DataTable DataTable = new();

                DynamicParameters dp = new();
                dp.Add("TableArea", TableArea, DbType.String, ParameterDirection.Input);
                dp.Add("TableName", TableName, DbType.String, ParameterDirection.Input);
                dp.Add("SchemeName", SchemeName, DbType.String, ParameterDirection.Input);
                dp.Add("FieldName", FieldName, DbType.String, ParameterDirection.Input);

                DataTable = DapperConnector.ExecuteStoredProcedureToDataTable(ConnectionString, "[dbo].[CommonFunctions.MSSQLServer.ExistField]", dp);

                if (DataTable.Rows.Count > 0)
                {
                    ExistField = Convert.ToInt32(DataTable.Rows[0][0].ToString()) != 0;
                }
                else { throw new Exception("The stored procedure [dbo].[CommonFunctions.MSSQLServer.ExistField] does not return anything"); }

                return ExistField;
            }
            catch (Exception) { throw; }
        }
    }
}
