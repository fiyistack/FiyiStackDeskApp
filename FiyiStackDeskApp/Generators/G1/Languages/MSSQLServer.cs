using FiyiStackDeskApp.Areas.FiyiStackDeskApp.TableBack.Interfaces;
using FiyiStackDeskApp.Library.G1.MSSQLServer;
using Microsoft.Extensions.DependencyInjection;

namespace FiyiStackDeskApp.Generators.G1.Languages
{
    public static class MSSQLServer
    {
        public static string Start(G1ConfigurationComponent GeneratorConfigurationComponent, ServiceProvider serviceProvider)
        {
            string LogText = "";

            ITableRepository _tableRepository = serviceProvider.GetRequiredService<ITableRepository>();

            #region Table
            LogText += $"Entrando en la estructura de la tabla. {GeneratorConfigurationComponent.LstTableToGenerate.Count} tablas para trabajar con {Environment.NewLine}";

            Action<Areas.FiyiStackDeskApp.TableBack.Entities.Table> TableGenerator = (TableToGenerate) =>
            {
                try
                {
                    LogText += $"Buscando [{TableToGenerate.Scheme}].[{TableToGenerate.Area}.{TableToGenerate.Name}] {Environment.NewLine}";
                    Library.MSSQLServer.Table MSSQLServerTable = new();

                    //Search the table, if it is not found, create it. If it is found and the configuration says to delete it, delete it and create it again
                    if (!MSSQLServerTable.DoesTableExist(GeneratorConfigurationComponent.ChosenDatabase.ConnectionStringForMSSQLServer, TableToGenerate.Area, TableToGenerate.Name, TableToGenerate.Scheme))
                    {
                        LogText += $"[{TableToGenerate.Scheme}].[{TableToGenerate.Area}.{TableToGenerate.Name}] no encontrada. Creandola {Environment.NewLine}";

                        Modules.MSSQLServer.MSSQLServer.CreateTable(GeneratorConfigurationComponent,
                            GeneratorConfigurationComponent.ChosenDatabase.Name,
                            TableToGenerate.Area,
                            TableToGenerate.Name,
                            TableToGenerate.Scheme);

                        LogText += $"[{TableToGenerate.Scheme}].[{TableToGenerate.Area}.{TableToGenerate.Name}] creada correctamente";
                    }
                    else
                    {
                        if (GeneratorConfigurationComponent.G1Configuration.DeleteTable == true)
                        {
                            LogText += $"[{TableToGenerate.Scheme}].[{TableToGenerate.Area}.{TableToGenerate.Name}] encontrada. Eliminandola y creandola nuevamente {Environment.NewLine}";

                            Modules.MSSQLServer.MSSQLServer.DeleteTable(GeneratorConfigurationComponent.ChosenDatabase.ConnectionStringForMSSQLServer,
                                GeneratorConfigurationComponent.ChosenDatabase.Name,
                                TableToGenerate.Scheme,
                                TableToGenerate.Area,
                                TableToGenerate.Name);

                            Modules.MSSQLServer.MSSQLServer.CreateTable(GeneratorConfigurationComponent,
                            GeneratorConfigurationComponent.ChosenDatabase.Name,
                            TableToGenerate.Area,
                            TableToGenerate.Name,
                            TableToGenerate.Scheme);

                            LogText += $"[{TableToGenerate.Scheme}].[{TableToGenerate.Area}.{TableToGenerate.Name}] creada correctamente {Environment.NewLine}";
                        }
                    }
                }
                catch (Exception ex) { throw ex; }
            };

            foreach (Areas.FiyiStackDeskApp.TableBack.Entities.Table TableToGenerate in GeneratorConfigurationComponent.LstTableToGenerate)
            {
                TableGenerator(TableToGenerate);
            }
            #endregion

            #region Field
            LogText += $"Entrando en la estructura de la columna. {GeneratorConfigurationComponent.LstFieldToGenerate.Count} columnas para trabajar con {Environment.NewLine}";
            Action<Areas.FiyiStackDeskApp.FieldBack.Entities.Field> FieldGenerator = (FieldToGenerate) =>
            {
                try
                {
                    LogText += $"Buscando {FieldToGenerate.Name} {Environment.NewLine}";

                    Field MSSQLServerField = new();

                    Areas.FiyiStackDeskApp.TableBack.Entities.Table Table = _tableRepository.GetByTableId(FieldToGenerate.TableId);

                    //Search the field, if it is not found, create it. If it is found and the configuration says to delete it, delete it and create it again
                    if (!Field.DoesFieldExist(GeneratorConfigurationComponent.ChosenDatabase.ConnectionStringForMSSQLServer, Table.Area, Table.Name, Table.Scheme, FieldToGenerate.Name))
                    {
                        LogText += $"{FieldToGenerate.Name} no encontrada. Creandola {Environment.NewLine}";

                        Modules.MSSQLServer.MSSQLServer.CreateField(GeneratorConfigurationComponent,
                            GeneratorConfigurationComponent.ChosenDatabase.Name,
                            Table.Area,
                            Table.Name,
                            Table.Scheme,
                            FieldToGenerate);

                        LogText += $"{FieldToGenerate.Name} creada correctamente {Environment.NewLine}";
                    }
                    else
                    {
                        if (GeneratorConfigurationComponent.G1Configuration.DeleteField == true)
                        {
                            LogText += $"{FieldToGenerate.Name} encontrada. Eliminandola y creandola nuevamente {Environment.NewLine}";

                            Modules.MSSQLServer.MSSQLServer.DeleteField(GeneratorConfigurationComponent.ChosenDatabase.ConnectionStringForMSSQLServer,
                                GeneratorConfigurationComponent.ChosenDatabase.Name,
                                Table.Scheme,
                                Table.Area,
                                Table.Name,
                                FieldToGenerate.Name);

                            Modules.MSSQLServer.MSSQLServer.CreateField(GeneratorConfigurationComponent,
                            GeneratorConfigurationComponent.ChosenDatabase.Name,
                            Table.Area,
                            Table.Name,
                            Table.Scheme,
                            FieldToGenerate);

                            LogText += $"{FieldToGenerate.Name} creada correctamente {Environment.NewLine}";
                        }
                    }
                }
                catch (Exception ex) { throw ex; }
            };

            foreach (Areas.FiyiStackDeskApp.FieldBack.Entities.Field FieldToGenerate in GeneratorConfigurationComponent.LstFieldToGenerate)
            {
                Areas.FiyiStackDeskApp.TableBack.Entities.Table TableToGenerate = _tableRepository.GetByTableId(FieldToGenerate.TableId);
                FieldGenerator(FieldToGenerate);
            }
            #endregion

            return LogText;
        }
    }
}
