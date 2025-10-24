using FiyiStackDeskApp.Generators.G1.Languages;
using Microsoft.Extensions.DependencyInjection;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.G1ConfigurationBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.ProjectBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.TableBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.DataBaseBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.FieldBack.Entities;

namespace FiyiStackDeskApp.Generators.G1
{
    public static class G1
    {
        public static string Start(ServiceProvider serviceProvider,
            G1Configuration Configuration,
            G1FieldChainer fieldChainerNET8BlazorMSSQLServerCodeFirst,
            Project ProjectChosen,
            DataBase DataBaseChosen,
            List<Table> lstTableInFiyiStack,
            List<Table> lstTableToGenerate,
            List<Field> lstFieldToGenerate)
        {
            G1ConfigurationComponent GeneratorConfigurationComponent = new G1ConfigurationComponent(Configuration,
            fieldChainerNET8BlazorMSSQLServerCodeFirst,
            ProjectChosen,
            DataBaseChosen,
            lstTableInFiyiStack,
            lstTableToGenerate,
            lstFieldToGenerate);

            try
            {
                string LogText = $@"Empezando...
{GeneratorConfigurationComponent.LstTableToGenerate.Count} tablas a trabajar
{GeneratorConfigurationComponent.LstFieldToGenerate.Count} columnas a trabajar
";

                LogText += $"{Environment.NewLine}{Environment.NewLine}";

                if (GeneratorConfigurationComponent.G1Configuration.WantMSSQLServer)
                {
                    LogText += $"Entrando al lenguaje MS SQL Server{Environment.NewLine}";
                    LogText += MSSQLServer.Start(GeneratorConfigurationComponent, serviceProvider);
                }

                LogText += $"{Environment.NewLine}{Environment.NewLine}";

                if (GeneratorConfigurationComponent.G1Configuration.WantCSharp)
                {
                    LogText += $"Entrando al lenguaje C#{Environment.NewLine}";
                    LogText += CSharp.Start(GeneratorConfigurationComponent, serviceProvider);
                }

                return LogText;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
