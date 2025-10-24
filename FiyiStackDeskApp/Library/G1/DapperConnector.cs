using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace FiyiStackDeskApp.Library.G1
{
    public static class DapperConnector
    {
        public static DataTable ExecuteStoredProcedureToDataTable(string ConnectionString, string StoredProcedure, DynamicParameters DynamicParameters = null)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    var DataTable = new DataTable();

                    var dataReader = sqlConnection.ExecuteReader(StoredProcedure, commandType: CommandType.StoredProcedure, param: DynamicParameters);

                    DataTable.Load(dataReader);

                    return DataTable;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

