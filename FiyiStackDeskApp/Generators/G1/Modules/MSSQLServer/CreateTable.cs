using System.Data;
using Dapper;
using FiyiStackDeskApp.Generators.G1;
using Microsoft.Data.SqlClient;

namespace FiyiStackDeskApp.Generators.G1.Modules.MSSQLServer
{
    public static partial class MSSQLServer
    {
        public static void CreateTable(G1ConfigurationComponent GeneratorConfigurationComponent, string DataBaseName, string TableArea, string TableName, string TableScheme)
        {
            try
            {
                string NonQuery = 
                    $@"USE [{DataBaseName}]
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

--Last modification on: {DateTime.Now}

CREATE TABLE [{TableScheme}].[{TableArea}.{TableName}] (
    [{TableName}Id] [bigint] IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_{TableArea}{TableName}] PRIMARY KEY CLUSTERED ([{TableName}Id] ASC) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
ON [PRIMARY])
ON[PRIMARY]"; 

                NonQuery.Replace("\r", "").Replace("\n", "");

                using SqlConnection sqlConnection = new(GeneratorConfigurationComponent.ChosenDatabase.ConnectionStringForMSSQLServer);
                var dataReader = sqlConnection.ExecuteReader(NonQuery, commandType: CommandType.Text);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
