namespace FiyiStackDeskApp.Generators.G1.Modules.CSharp
{
    public static partial class CSharp
    {
        public static string Entity(G1ConfigurationComponent GeneratorConfigurationComponent, Areas.FiyiStackDeskApp.TableBack.Entities.Table Table)
        {
            try
            {
                string Content =
                $@"

{Library.Security.WaterMark(Library.Security.EWaterMarkFor.CSharp)}

namespace {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Entities
{{
    public class {Table.Name}
    {{
        {GeneratorConfigurationComponent.G1FieldChainer.PropertiesForEntity}
    
        public string ToStringOnlyValuesForHTML()
        {{
                return $@""<tr>
                    {GeneratorConfigurationComponent.G1FieldChainer.PropertiesInHTMLForEntity}
                    </tr>"";
        }}
    }}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
