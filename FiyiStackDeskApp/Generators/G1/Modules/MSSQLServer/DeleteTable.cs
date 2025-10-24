using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace FiyiStackDeskApp.Generators.G1.Modules.MSSQLServer
{
    public static partial class MSSQLServer
    {
        public static void DeleteTable(string ConnectionString, string DataBaseName, string SchemeName, string AreaName, string TableName)
        {
            try
            {
                string NonQuery =
                    $"USE [{DataBaseName}] " +
                    $"DROP TABLE [{SchemeName}].[{AreaName}.{TableName}]";

                NonQuery.Replace("\r", "").Replace("\n", "");

                using SqlConnection sqlConnection = new(ConnectionString);
                var dataReader = sqlConnection.ExecuteReader(NonQuery, commandType: CommandType.Text);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
