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
using Microsoft.Extensions.Caching.Memory;
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

        #region Sync Queries
        public int Count()
        {{
            try
            {{
                return _dbContext.{Table.Name}.Count();
            }}
            catch (Exception) {{ throw; }}
        }}

        public {Table.Name}? GetOneBy{Table.Name}Id(int {Table.Name.ToLower()}Id)
        {{
            try
            {{
                {Table.Name}? {Table.Name} = _dbContext.{Table.Name}
                                .FirstOrDefault(x => x.{Table.Name}Id == {Table.Name.ToLower()}Id);

                return {Table.Name};
            }}
            catch (Exception) {{ throw; }}
        }}

        public List<{Table.Name}?> GetAll()
        {{
            try
            {{
                return _dbContext.{Table.Name}.ToList();
            }}
            catch (Exception) {{ throw; }}
        }}

        public List<{Table.Name}> GetAllBy{Table.Name}IdForModal(string textToSearch)
        {{
            try
            {{
                var query = from {Table.Name.ToLower()} in _dbContext.{Table.Name}
                            select new {{ {Table.Name} = {Table.Name.ToLower()} }};

                List<{Table.Name}> lst{Table.Name} = query.Select(result => result.{Table.Name})
                        .Where(x => x.{Table.Name}Id.ToString().Contains(textToSearch))
                        .OrderByDescending(p => p.DateTimeLastModification)
                        .ToList();

                return lst{Table.Name};
            }}
            catch (Exception) {{ throw; }}
        }}

        public List<{Table.Name}?> GetAllBy{Table.Name}IdChecked(List<int> lst{Table.Name}IdChecked)
        {{
            try
            {{
                List<{Table.Name}?> lst{Table.Name} = [];

                foreach (int {Table.Name}Id in lst{Table.Name}IdChecked)
                {{
                    {Table.Name} {Table.Name.ToLower()} = _dbContext.{Table.Name}.Where(x => x.{Table.Name}Id == {Table.Name}Id).FirstOrDefault();

                    if ({Table.Name.ToLower()} != null)
                    {{
                        lst{Table.Name}.Add({Table.Name.ToLower()});
                    }}
                }}

                return lst{Table.Name};
            }}
            catch (Exception) {{ throw; }}
        }}

        public paginated{Table.Name}DTO GetAllBy{Table.Name}IdPaginated(string textToSearch,
            bool strictSearch,
            int pageIndex,
            int pageSize)
        {{
            try
            {{
                //textToSearch: ""novillo matias  com"" -> words: {{novillo,matias,com}}
                string[] words = Regex
                    .Replace(textToSearch
                    .Trim(), @""\s+"", "" "")
                    .Split("" "");

                int Total{Table.Name} = _dbContext.{Table.Name}.Count();

                List<{Table.Name}> lst{Table.Name} = _dbContext.{Table.Name}
                        .AsQueryable()
                        .Where(x => strictSearch ?
                            words.All(word => x.{Table.Name}Id.ToString().Contains(word)) :
                            words.Any(word => x.{Table.Name}Id.ToString().Contains(word)))
                        .OrderByDescending(x => x.DateTimeLastModification)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

                List<User?> lstUserCreation = [];
                List<User?> lstUserLastModification = [];

                foreach ({Table.Name} {Table.Name.ToLower()} in lst{Table.Name})
                {{
                    User UserCreation = _dbContext.User
                        .AsQueryable()
                        .Where(x => x.UserCreationId == {Table.Name.ToLower()}.UserCreationId)
                        .FirstOrDefault() ?? new();

                    lstUserCreation.Add(UserCreation);

                    User UserLastModification = _dbContext.User
                       .AsQueryable()
                       .Where(x => x.UserLastModificationId == {Table.Name.ToLower()}.UserLastModificationId)
                       .FirstOrDefault() ?? new();

                    lstUserLastModification.Add(UserLastModification);
                }}

                return new paginated{Table.Name}DTO
                {{
                    lst{Table.Name} = lst{Table.Name},
                    lstUserCreation = lstUserCreation,
                    lstUserLastModification = lstUserLastModification,
                    TotalItems = Total{Table.Name},
                    PageIndex = pageIndex,
                    PageSize = pageSize
                }};
            }}
            catch (Exception) {{ throw; }}
        }}
        #endregion

        #region Async Queries        
        public async Task<int> CountAsync()
        {{
            try
            {{
                return await _dbContext.{Table.Name}.CountAsync();
            }}
            catch (Exception) {{ throw; }}
        }}

        public async Task<{Table.Name}?> GetOneBy{Table.Name}IdAsync(int {Table.Name.ToLower()}Id)
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
        #endregion

        #region Sync Non-Queries
        public bool Add({Table.Name} {Table.Name.ToLower()})
        {{
            try
            {{
                EntityEntry<{Table.Name}> {Table.Name}ToAdd = _dbContext.{Table.Name}.Add({Table.Name.ToLower()});

                bool result = _dbContext.SaveChanges() > 0;

                return result;
            }}
            catch (Exception) {{ throw; }}
        }}

        public bool Update({Table.Name} {Table.Name.ToLower()})
        {{
            try
            {{
                _dbContext.{Table.Name}.Update({Table.Name.ToLower()});

                bool result = _dbContext.SaveChanges() > 0;

                return result;
            }}
            catch (Exception) {{ throw; }}
        }}

        public bool DeleteOneBy{Table.Name}Id(int {Table.Name.ToLower()}Id)
        {{
            try
            {{
                AsQueryable()
                        .Where(x => x.{Table.Name}Id == {Table.Name.ToLower()}Id)
                        .ExecuteDelete();

                bool result = _dbContext.SaveChanges() > 0;

                return result;
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

        public async Task<bool> UpdateASync({Table.Name} {Table.Name.ToLower()})
        {{
            try
            {{
                _dbContext.{Table.Name}.Update({Table.Name.ToLower()});

                bool result = await _dbContext.SaveChangesAsync() > 0;

                return result;
            }}
            catch (Exception) {{ throw; }}
        }}

        public async Task<bool> DeleteOneBy{Table.Name}IdAsync(int {Table.Name.ToLower()}Id)
        {{
            try
            {{
                await AsQueryable()
                            .Where(x => x.{Table.Name}Id == {Table.Name.ToLower()}Id)
                            .ExecuteDeleteAsync();

                bool result = await _dbContext.SaveChangesAsync() > 0;

                return result;
            }}
            catch (Exception) {{ throw; }}
        }}
        #endregion

        #region Methods for DataTable
        public DataTable GetAllBy{Table.Name}IdInDataTable(List<int> lst{Table.Name}Checked)
        {{
            try
            {{
                DataTable DataTable = new();
                DataTable.Columns.Add(""{Table.Name}Id"", typeof(string));
                {GeneratorConfigurationComponent.G1FieldChainer.PropertiesForRepository_DataTable1}

                foreach (int {Table.Name}Id in lst{Table.Name}Checked)
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
