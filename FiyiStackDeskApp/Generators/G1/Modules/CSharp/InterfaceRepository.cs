namespace FiyiStackDeskApp.Generators.G1.Modules.CSharp
{
    public static partial class CSharp
    {
        public static string InterfaceRepository(G1ConfigurationComponent GeneratorConfigurationComponent, Areas.FiyiStackDeskApp.TableBack.Entities.Table Table)
        {
            try
            {
                string Content =
                $@"using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Entities;
using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.DTOs;
using System.Data;

{Library.Security.WaterMark(Library.Security.EWaterMarkFor.CSharp)}

namespace {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Interfaces
{{
    public interface I{Table.Name}Repository
    {{
        IQueryable<{Table.Name}> AsQueryable();

        #region Async Queries
        Task<int> CountAsync();

        Task<{Table.Name}?> GetOneBy{Table.Name}IdAsync(int {Table.Name.ToLower()}Id);

        Task<List<{Table.Name}>> GetAllAsync();

        Task<List<{Table.Name}>> GetAllBy{Table.Name}IdCheckedAsync(List<int> lstINTID);

        Task<paginated{Table.Name}DTO> GetAllBy{Table.Name}IdPaginatedAsync(string textToSearch,
            bool strictSearch,
            int pageIndex,
            int pageSize);
        #endregion

        #region Async Non-Queries
        Task<bool> AddAsync({Table.Name} {Table.Name.ToLower()});

        Task<bool> AddRangeAsync(List<{Table.Name}> lst{Table.Name});

        Task<bool> UpdateAsync({Table.Name} {Table.Name.ToLower()});

        Task<bool> DeleteOneBy{Table.Name}IdAsync(int {Table.Name.ToLower()}Id);

        Task<bool> DeleteAll{Table.Name}Async();

        Task<bool> DeleteManyBy{Table.Name}IdAsync(List<{Table.Name}> lst{Table.Name});
        #endregion

        #region Methods for DataTable
        DataTable GetAllBy{Table.Name}IdInDataTable(List<int> lst{Table.Name}Checked);

        DataTable GetAllInDataTable();
        #endregion
    }}
}}
";

                return Content;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
