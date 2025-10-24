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

        #region Sync Queries
        int Count();

        {Table.Name}? GetOneBy{Table.Name}Id(int {Table.Name.ToLower()}Id);

        List<{Table.Name}?> GetAll();

        List<{Table.Name}?> GetAllBy{Table.Name}IdChecked(List<int> lst{Table.Name}IdChecked);

        List<{Table.Name}> GetAllBy{Table.Name}IdForModal(string textToSearch);

        paginated{Table.Name}DTO GetAllBy{Table.Name}IdPaginated(string textToSearch,
            bool strictSearch,
            int pageIndex,
            int pageSize);
        #endregion

        #region Async Queries
        Task<int> CountAsync();

        Task<{Table.Name}?> GetOneBy{Table.Name}IdAsync(int {Table.Name.ToLower()}Id);

        Task<List<{Table.Name}>> GetAllAsync();
        #endregion

        #region Sync Non-Queries
        bool Add({Table.Name} {Table.Name.ToLower()});

        bool Update({Table.Name} {Table.Name.ToLower()});

        bool DeleteOneBy{Table.Name}Id(int {Table.Name.ToLower()});
        #endregion

        #region Async Non-Queries
        Task<bool> AddAsync({Table.Name} {Table.Name.ToLower()});

        Task<bool> UpdateASync({Table.Name} {Table.Name.ToLower()});

        Task<bool> DeleteOneBy{Table.Name}IdAsync(int {Table.Name.ToLower()}Id);
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
