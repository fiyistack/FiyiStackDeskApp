namespace FiyiStackDeskApp.Generators.G1.Modules.CSharp
{
    public static partial class CSharp
    {
        public static string ImportationService(G1ConfigurationComponent GeneratorConfigurationComponent, Areas.FiyiStackDeskApp.TableBack.Entities.Table Table)
        {
            try
            {
                GeneratorConfigurationComponent.G1FieldChainer.iForImportInService = 7;

                string Content =
                $@"using ClosedXML.Excel;
using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Entities;
using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Interfaces;

namespace {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Services
{{
    public class {Table.Name}ImportationService : I{Table.Name}ImportationService
    {{
        public List<{Table.Name}> ImportExcel(string path, long userId)
        {{
            List<{Table.Name}> lst{Table.Name} = [];

            var WorkBook = new XLWorkbook(path);
            var Rows = WorkBook.Worksheet(1).RangeUsed()!.RowsUsed();

            foreach (var row in Rows)
            {{
                var rowNumber = row.RowNumber();

                if (rowNumber > 1)
                {{
                    {GeneratorConfigurationComponent.G1FieldChainer.Properties_ForImport1}

                    {Table.Name} {Table.Name} = new()
                    {{
                        {Table.Name}Id = 0,
                        Active = true,
                        DateTimeCreation = DateTime.Now,
                        DateTimeLastModification = DateTime.Now,
                        UserCreationId = userId,
                        UserLastModificationId = userId,
                        {GeneratorConfigurationComponent.G1FieldChainer.Properties_ForImport2}
                    }};

                    lst{Table.Name}.Add({Table.Name});
                }}
            }}

            return lst{Table.Name};
        }}
    }}
}}
";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
