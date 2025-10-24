namespace FiyiStackDeskApp.Generators.G1.Modules.CSharp
{
    public static partial class CSharp
    {
        public static string DTO(G1ConfigurationComponent GeneratorConfigurationComponent, Areas.FiyiStackDeskApp.TableBack.Entities.Table Table)
        {
            try
            {
                string Content =
                $@"using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.CMS.UserBack.Entities;
using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Entities;

{Library.Security.WaterMark(Library.Security.EWaterMarkFor.CSharp)}

namespace {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.DTOs
{{
    public class paginated{Table.Name}DTO
    {{
        public List<{Table.Name}?> lst{Table.Name} {{ get; set; }}
        public List<User?> lstUserCreation {{ get; set; }}
        public List<User?> lstUserLastModification {{ get; set; }}

        //FOREIGN LISTS (TABLES)
        {GeneratorConfigurationComponent.G1FieldChainer.ForeignLists_DTO}

        public int TotalRegisters {{ get; set; }}
        public int PageIndex {{ get; set; }}
        public int PageSize {{ get; set; }}

        public int TotalPages => (int)Math.Ceiling(TotalRegisters / (double)PageSize);

        public bool HasPreviousPage => PageIndex > 1;

        public bool HasNextPage => PageIndex < TotalPages;
    }}
}}";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
