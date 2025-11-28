namespace FiyiStackDeskApp.Generators.G1.Modules.CSharp
{
    public static partial class CSharp
    {
        public static string InterfaceImportationService(G1ConfigurationComponent GeneratorConfigurationComponent, Areas.FiyiStackDeskApp.TableBack.Entities.Table Table)
        {
            try
            {
                string Content =
                $@"using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Entities;

{Library.Security.WaterMark(Library.Security.EWaterMarkFor.CSharp)}

namespace {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Interfaces
{{
    public interface I{Table.Name}ImportationService
    {{
        List<{Table.Name}> ImportExcel(string path, long userId);
    }}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
