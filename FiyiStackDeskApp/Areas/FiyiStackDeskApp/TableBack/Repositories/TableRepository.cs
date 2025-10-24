using FiyiStackDeskApp.Areas.CMS.UserBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.ProjectBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.TableBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.TableBack.Interfaces;
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

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.TableBack.Repositories
{
    public class TableRepository : ITableRepository
    {
        protected readonly FiyiStackDeskAppDbContext _context;

        public TableRepository(FiyiStackDeskAppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Table> AsQueryable()
        {
            try
            {
                return _context.Table.AsQueryable();
            }
            catch (Exception) { throw; }
        }

        #region Queries
        public int Count()
        {
            try
            {
                return _context.Table.Count();
            }
            catch (Exception) { throw; }
        }

        public Table? GetByTableId(int tableId)
        {
            try
            {
                Table Table = _context.Table
                                .FirstOrDefault(x => x.TableId == tableId);

                return Table;
            }
            catch (Exception) { throw; }
        }

        public Table? GetByDatabaseIdByAreaByNameByScheme(int databaseId, string area, string name, string scheme)
        {
                       try
            {
                Table? table = _context.Table
                                    .FirstOrDefault(x => x.DataBaseId == databaseId &&
                                                    x.Area == area &&
                                                    x.Name == name &&
                                                    x.Scheme == scheme);
                return table;
            }
            catch (Exception) { throw; }
        }

        public List<Table?> GetAll()
        {
            try
            {
                return _context.Table.ToList();
            }
            catch (Exception) { throw; }
        }

        public List<Table> GetAllByTableIdForModal(string textToSearch)
        {
            try
            {
                var query = from table in _context.Table
                            select new { Table = table };

                // Extraemos los resultados en listas separadas
                List<Table> lstTable = query.Select(result => result.Table)
                        .Where(x => x.TableId.ToString().Contains(textToSearch))
                        .OrderByDescending(p => p.DateTimeLastModification)
                        .ToList();

                return lstTable;
            }
            catch (Exception) { throw; }
        }

        public List<Table?> GetAllByTableId(List<int> lstTableChecked)
        {
            try
            {
                List<Table?> lstTable = [];

                foreach (int TableId in lstTableChecked)
                {
                    Table table = _context.Table.Where(x => x.TableId == TableId).FirstOrDefault();

                    if (table != null)
                    {
                        lstTable.Add(table);
                    }
                }

                return lstTable;
            }
            catch (Exception) { throw; }
        }

        public List<Table> GetAllByDatabaseIdByName(int databaseId, string name)
        {
            IQueryable<Table> Query = _context.Table
                    .Where(p => p.DataBaseId == databaseId);

            if (!string.IsNullOrEmpty(name))
            {
                Query = Query.Where(p => p.Name.Contains(name));
            }

            return Query.ToList();
        }

        public List<Table> GetAllByDatabaseId(int databaseId)
        {
            List<Table> lstTable = _context.Table
                    .Where(p => p.DataBaseId == databaseId)
                    .ToList();

            return lstTable;
        }

        public List<Table> GetAllByDatabaseIdByNameInSearchBar(int dataBaseId, string textToSearch)
        {
            try
            {
                IQueryable<Table> Query = _context.Table
                    .Where(p => p.DataBaseId == dataBaseId);

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
        public bool Add(Table table)
        {
            try
            {
                EntityEntry<Table> TableToAdd = _context.Table.Add(table);

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }

        public int AddReturnId(Table table)
        {
            try
            {
                EntityEntry<Table> TableToAdd = _context.Table.Add(table);

                _context.SaveChanges();

                return TableToAdd.Entity.TableId;
            }
            catch (Exception) { throw; }
        }

        public bool Update(Table table)
        {
            try
            {
                _context.Table.Update(table);

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }

        public bool DeleteByTableId(int tableId)
        {
            try
            {
                AsQueryable()
                        .Where(x => x.TableId == tableId)
                        .ExecuteDelete();

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }
        #endregion
    }
}
