namespace FiyiStackDeskApp.Generators.G1.Modules.CSharp
{
    public static partial class CSharp
    {
        public static string EntityConfiguration(G1ConfigurationComponent GeneratorConfigurationComponent, Areas.FiyiStackDeskApp.TableBack.Entities.Table Table)
        {
            try
            {
                string Content =
                $@"using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Entities;

{Library.Security.WaterMark(Library.Security.EWaterMarkFor.CSharp)}

namespace {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.EntitiesConfiguration
{{
    public class {Table.Name}Configuration : IEntityTypeConfiguration<{Table.Name}>
    {{
        public void Configure(EntityTypeBuilder<{Table.Name}> entity)
        {{
            try
            {{
                //{Table.Name}Id
                entity.HasKey(e => e.{Table.Name}Id);
                entity.Property(e => e.{Table.Name}Id)
                    .ValueGeneratedOnAdd();

                {GeneratorConfigurationComponent.G1FieldChainer.PropertiesForEntityConfiguration}
            }}
            catch (Exception) {{ throw; }}
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
