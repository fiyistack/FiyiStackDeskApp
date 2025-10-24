namespace FiyiStackDeskApp.Generators.G1.Modules.CSharp
{
    public static partial class CSharp
    {
        public static string InterfaceExportationService(G1ConfigurationComponent GeneratorConfigurationComponent, Areas.FiyiStackDeskApp.TableBack.Entities.Table Table)
        {
            try
            {
                string Content =
                $@"using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Entities;
using System.Data;

{Library.Security.WaterMark(Library.Security.EWaterMarkFor.CSharp)}

namespace {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Interfaces
{{
    public interface I{Table.Name}ExportationService
    {{
        void ExportToExcel(string path, DataTable dt{Table.Name});

        void ExportToCSV(string path, List<{Table.Name}> lst{Table.Name});

        void ExportToPDF(string path, List<{Table.Name}> lst{Table.Name});
    }}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
