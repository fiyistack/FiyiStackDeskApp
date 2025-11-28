namespace FiyiStackDeskApp.Generators.G1.Modules.CSharp
{
    public static partial class CSharp
    {
        public static string Repository(G1ConfigurationComponent GeneratorConfigurationComponent, Areas.FiyiStackDeskApp.TableBack.Entities.Table Table)
        {
            try
            {
                string Content =
                $@"using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.CMS.UserBack.Entities;
using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Entities;
using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.DTOs;
using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Interfaces;
using {GeneratorConfigurationComponent.ChosenProject.Name}.DatabaseContexts;
using System.Text.RegularExpressions;
using System.Data;

{Library.Security.WaterMark(Library.Security.EWaterMarkFor.CSharp)}

namespace {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Repositories
{{
    public class {Table.Name}Repository : I{Table.Name}Repository
    {{
        protected readonly {GeneratorConfigurationComponent.ChosenProject.Name}DbContext _dbContext;

        public {Table.Name}Repository({GeneratorConfigurationComponent.ChosenProject.Name}DbContext dbContext)
        {{
            _dbContext = dbContext;
        }}

        public IQueryable<{Table.Name}> AsQueryable()
        {{
            try
            {{
                return _dbContext.{Table.Name}.AsQueryable();
            }}
            catch (Exception) {{ throw; }}
        }}

        #region Async Queries        
        public async Task<int> CountAsync()
        {{
            try
            {{
                return await _dbContext.{Table.Name}.CountAsync();
            }}
            catch (Exception) {{ throw; }}
        }}

        public async Task<{Table.Name}?> GetOneBy{Table.Name}IdAsync(long {Table.Name.ToLower()}Id)
        {{
            try
            {{
                return await _dbContext.{Table.Name}
                                .FirstOrDefaultAsync(x => x.{Table.Name}Id == {Table.Name.ToLower()}Id);
            }}
            catch (Exception) {{ throw; }}
        }}

        public async Task<List<{Table.Name}>> GetAllAsync()
        {{
            try
            {{
                return await _dbContext.{Table.Name}.ToListAsync();
            }}
            catch (Exception) {{ throw; }}
        }}

        public async Task<List<{Table.Name}>> GetAllBy{Table.Name}IdCheckedAsync(List<long> lstLONG{Table.Name}IdChecked)
        {{
            try
            {{
                return await _dbContext.{Table.Name}
                                       .Where(x => lstLONG{Table.Name}IdChecked.Contains(x.{Table.Name}Id))
                                       .ToListAsync();
            }}
            catch (Exception) {{ throw; }}
        }}

        public async Task<List<{Table.Name}>> GetAllBy{Table.Name}IdForModalAsync(string textToSearch)
        {{
            try
            {{
                return await _dbContext.{Table.Name}
                                       .Where(x => x.{Table.Name}Id.ToString().Contains(textToSearch))
                                       .ToListAsync();
            }}
            catch (Exception) {{ throw; }}
        }}

        public async Task<paginated{Table.Name}DTO> GetAllBy{Table.Name}IdPaginatedAsync(string textToSearch,
            bool strictSearch,
            int pageIndex,
            int pageSize)
        {{
            try
            {{
                string[] words = Regex
                    .Replace(textToSearch
                    .Trim(), @""\s+"", "" "")
                    .Split("" "");

                int Total{Table.Name} = await _dbContext.{Table.Name}.CountAsync();

                List<{Table.Name}> lst{Table.Name} = await _dbContext.{Table.Name}
                    .AsQueryable()
                    .Where(x => strictSearch ?
                        words.All(word => x.{Table.Name}Id.ToString().Contains(word)) :
                        words.Any(word => x.{Table.Name}Id.ToString().Contains(word)))
                    .OrderByDescending(x => x.DateTimeLastModification)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();



                List<long> lstLONGUserCreationId = lst{Table.Name}
                    .Select(x => x.UserCreationId)
                    .ToList();

                List<long> lstLONGUserLastModificationId = lst{Table.Name}
                    .Select(x => x.UserLastModificationId)
                    .ToList();

                List<User> lstUserCreation = await _dbContext.User
                    .Where(x => lstLONGUserCreationId.Contains(x.UserCreationId))
                    .ToListAsync();

                List<User> lstUserLastModification = await _dbContext.User
                    .Where(x => lstLONGUserLastModificationId.Contains(x.UserLastModificationId))
                    .ToListAsync();

                return new paginated{Table.Name}DTO
                {{
                    lst{Table.Name} = lst{Table.Name},
                    lstUserCreation = lstUserCreation,
                    lstUserLastModification = lstUserLastModification,
                    TotalRegisters = Total{Table.Name},
                    PageIndex = pageIndex,
                    PageSize = pageSize
                }};
            }}
            catch (Exception) {{ throw; }}
        }}
        #endregion

        #region Async Non-Queries
        public async Task<bool> AddAsync({Table.Name} {Table.Name.ToLower()})
        {{
            try
            {{
                EntityEntry<{Table.Name}> {Table.Name}ToAdd = await _dbContext.{Table.Name}.AddAsync({Table.Name.ToLower()});

                bool result = await _dbContext.SaveChangesAsync() > 0;

                return result;
            }}
            catch (Exception) {{ throw; }}
        }}

        public async Task<bool> AddRangeAsync(List<{Table.Name}> lst{Table.Name})
        {{
            try
            {{
                await _dbContext.{Table.Name}.AddRangeAsync(lst{Table.Name});

                bool result = await _dbContext.SaveChangesAsync() > 0;

                return result;
            }}
            catch (Exception) {{ throw; }}
        }}

        public async Task<bool> UpdateAsync({Table.Name} {Table.Name.ToLower()})
        {{
            try
            {{
                _dbContext.{Table.Name}.Update({Table.Name.ToLower()});

                bool result = await _dbContext.SaveChangesAsync() > 0;

                return result;
            }}
            catch (Exception) {{ throw; }}
        }}

        public async Task<bool> DeleteOneBy{Table.Name}IdAsync(long {Table.Name.ToLower()}Id)
        {{
            try
            {{
                await _dbContext.{Table.Name}
                    .Where(x => x.{Table.Name}Id == {Table.Name.ToLower()}Id)
                    .ExecuteDeleteAsync();

                bool Result = await _dbContext.SaveChangesAsync() > 0;

                return Result;
            }}
            catch (Exception) {{ throw; }}
        }}

        public async Task<bool> DeleteAll{Table.Name}Async()
        {{
            try
            {{
                await _dbContext.{Table.Name}
                    .ExecuteDeleteAsync();

                return true;
            }}
            catch (Exception)
            {{
                throw;
            }}
        }}

        public async Task<bool> DeleteManyBy{Table.Name}IdAsync(List<{Table.Name}> lst{Table.Name})
        {{
            try
            {{
                _dbContext.{Table.Name}.RemoveRange(lst{Table.Name});

                int AffectedRows = await _dbContext.SaveChangesAsync();

                bool Result = AffectedRows > 0;

                return Result;
            }}
            catch (Exception) {{ throw; }}
        }}
        #endregion

        #region Methods for DataTable
        public DataTable GetAllBy{Table.Name}IdInDataTable(List<long> lst{Table.Name}Checked)
        {{
            try
            {{
                DataTable DataTable = new();
                DataTable.Columns.Add(""{Table.Name}Id"", typeof(string));
                {GeneratorConfigurationComponent.G1FieldChainer.PropertiesForRepository_DataTable1}

                foreach (long {Table.Name}Id in lst{Table.Name}Checked)
                {{
                    {Table.Name} {Table.Name.ToLower()} = _dbContext.{Table.Name}.Where(x => x.{Table.Name}Id == {Table.Name}Id).FirstOrDefault();

                    if ({Table.Name.ToLower()} != null)
                    {{
                        DataTable.Rows.Add(
                        {GeneratorConfigurationComponent.G1FieldChainer.PropertiesForRepository_DataTable}
                        );
                    }}
                }}                

                return DataTable;
            }}
            catch (Exception) {{ throw; }}
        }}

        public DataTable GetAllInDataTable()
        {{
            try
            {{
                List<{Table.Name}> lst{Table.Name} = _dbContext.{Table.Name}.ToList();

                DataTable DataTable = new();
                DataTable.Columns.Add(""{Table.Name}Id"", typeof(string));
                {GeneratorConfigurationComponent.G1FieldChainer.PropertiesForRepository_DataTable1}

                foreach ({Table.Name} {Table.Name.ToLower()} in lst{Table.Name})
                {{
                    DataTable.Rows.Add(
                        {GeneratorConfigurationComponent.G1FieldChainer.PropertiesForRepository_DataTable}
                        );
                }}

                return DataTable;
            }}
            catch (Exception) {{ throw; }}
        }}
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
