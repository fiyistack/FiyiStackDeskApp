using FiyiStackDeskApp.Areas.FiyiStackDeskApp.ProjectBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.TableBack.Entities;
using System.Data;

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

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.TableBack.Interfaces
{
    public interface ITableRepository
    {
        IQueryable<Table> AsQueryable();

        #region Queries
        int Count();

        Table? GetByTableId(int tableId);

        Table? GetByDatabaseIdByAreaByNameByScheme(int databaseId, string area, string name, string scheme);

        List<Table?> GetAll();

        List<Table?> GetAllByTableId(List<int> lstTableChecked);

        List<Table> GetAllByTableIdForModal(string textToSearch);

        List<Table> GetAllByDatabaseIdByName(int databaseId, string name);

        List<Table> GetAllByDatabaseId(int databaseId);

        List<Table> GetAllByDatabaseIdByNameInSearchBar(int dataBaseId, string text);
        #endregion

        #region Non-Queries
        bool Add(Table table);

        int AddReturnId(Table table);

        bool Update(Table table);

        bool DeleteByTableId(int table);
        #endregion
    }
}
