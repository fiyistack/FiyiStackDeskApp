using FiyiStackDeskApp.Areas.CMS.UserBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.DataBaseBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.DataBaseBack.Interfaces;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.ProjectBack.Entities;
using FiyiStackDeskApp.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data;
using System.Text.RegularExpressions;

/*
 * GUID:e6c09dfe-3a3e-461b-b3f9-734aee05fc7b
 * 
 * Coded by fiyistack.com
 * Copyright © 2025
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 */

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.DataBaseBack.Repositories
{
    public class DataBaseRepository : IDataBaseRepository
    {
        protected readonly FiyiStackDeskAppDbContext _context;

        public DataBaseRepository(FiyiStackDeskAppDbContext context)
        {
            _context = context;
        }

        public IQueryable<DataBase> AsQueryable()
        {
            try
            {
                return _context.DataBase.AsQueryable();
            }
            catch (Exception) { throw; }
        }

        #region Queries
        public int Count()
        {
            try
            {
                return _context.DataBase.Count();
            }
            catch (Exception) { throw; }
        }

        public DataBase? GetByDataBaseId(int databaseId)
        {
            try
            {
                DataBase Database = _context.DataBase
                               .FirstOrDefault(x => x.DataBaseId == databaseId);
                return Database;
            }
            catch (Exception) { throw; }
        }

        public DataBase GetByProjectIdByName(int projectId, string databaseName)
        {
            try
            {
                DataBase Database = _context.DataBase
                               .FirstOrDefault(x => x.ProjectId == projectId && x.Name == databaseName);
                return Database;
            }
            catch (Exception) { throw; }
        }

        public List<DataBase?> GetAll()
        {
            try
            {
                return _context.DataBase.ToList();
            }
            catch (Exception) { throw; }
        }

        public List<DataBase> GetAllByDataBaseIdForModal(string textToSearch)
        {
            try
            {
                var query = from database in _context.DataBase
                            select new { DataBase = database };

                // Extraemos los resultados en listas separadas
                List<DataBase> lstDataBase = query.Select(result => result.DataBase)
                        .Where(x => x.DataBaseId.ToString().Contains(textToSearch))
                        .OrderByDescending(p => p.DateTimeLastModification)
                        .ToList();

                return lstDataBase;
            }
            catch (Exception) { throw; }
        }

        public List<DataBase?> GetAllByDataBaseId(List<int> lstDataBaseChecked)
        {
            try
            {
                List<DataBase?> lstDataBase = [];

                foreach (int DataBaseId in lstDataBaseChecked)
                {
                    DataBase database = _context.DataBase.Where(x => x.DataBaseId == DataBaseId).FirstOrDefault();

                    if (database != null)
                    {
                        lstDataBase.Add(database);
                    }
                }

                return lstDataBase;
            }
            catch (Exception) { throw; }
        }

        public List<DataBase> GetAllByProjectIdByName(int projectId, string databaseName)
        {
            try
            {
                IQueryable<DataBase> Query = _context.DataBase
                        .Where(p => p.ProjectId == projectId);

                if (!string.IsNullOrEmpty(databaseName))
                {
                    Query = Query.Where(p => p.Name.Contains(databaseName));
                }

                return Query.ToList();
            }
            catch (Exception) { throw; }
        }

        public List<DataBase> GetAllByProjectId(int projectId)
        {
            try
            {
                List<DataBase> lstDatabase = _context.DataBase
                    .Where(p => p.ProjectId == projectId).ToList();

                return lstDatabase;
            }
            catch (Exception) { throw; }
        }

        public List<DataBase> GetAllByProjectIdByNameInSearchBar(int projectId, string textToSearch)
        {
            try
            {
                IQueryable<DataBase> Query = _context.DataBase
                        .Where(x => x.ProjectId == projectId);

                if (!string.IsNullOrEmpty(textToSearch))
                {
                    Query = Query.Where(x => x.Name.Contains(textToSearch));
                }

                return Query.ToList();
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Non-Queries
        public bool Add(DataBase database)
        {
            try
            {
                EntityEntry<DataBase> DataBaseToAdd = _context.DataBase.Add(database);

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }

        public int AddReturnId(DataBase dataBase)
        {
            try
            {
                EntityEntry<DataBase> DatabaseToAdd = _context.DataBase.Add(dataBase);

                _context.SaveChanges();

                return DatabaseToAdd.Entity.DataBaseId;
            }
            catch (Exception) { throw; }
        }

        public bool Update(DataBase database)
        {
            try
            {
                _context.DataBase.Update(database);

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }

        public bool DeleteByDataBaseId(int databaseId)
        {
            try
            {
                AsQueryable()
                        .Where(x => x.DataBaseId == databaseId)
                        .ExecuteDelete();

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }
        #endregion
    }
}
