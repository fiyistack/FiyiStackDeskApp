using Dapper;
using FiyiStackDeskApp.Library.G1;
using System.Data;

namespace FiyiStackDeskApp.Library.MSSQLServer
{
    public class Table
    {
        public bool DoesTableExist(string ConnectionString, string TableArea, string TableName, string Scheme)
        {
            try
            {
                bool ExistTable = false;
                DataTable DataTable = new DataTable();

                DynamicParameters dp = new DynamicParameters();
                dp.Add("TableArea", TableArea, DbType.String, ParameterDirection.Input);
                dp.Add("TableName", TableName, DbType.String, ParameterDirection.Input);
                dp.Add("Scheme", Scheme, DbType.String, ParameterDirection.Input);

                DataTable = DapperConnector.ExecuteStoredProcedureToDataTable(ConnectionString, "[dbo].[CommonFunctions.MSSQLServer.ExistTable]", dp);

                if (DataTable.Rows.Count > 0)
                {
                    ExistTable = Convert.ToInt32(DataTable.Rows[0][0].ToString()) == 0 ? false : true;
                }
                else { throw new Exception("The stored procedure ExistTable does not return anything"); }

                return ExistTable;
            }
            catch (Exception) { throw; }
        }
    }
}
