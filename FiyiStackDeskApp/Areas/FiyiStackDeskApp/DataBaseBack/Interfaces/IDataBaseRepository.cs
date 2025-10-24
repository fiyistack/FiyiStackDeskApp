using FiyiStackDeskApp.Areas.FiyiStackDeskApp.DataBaseBack.Entities;

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

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.DataBaseBack.Interfaces
{
    public interface IDataBaseRepository
    {
        IQueryable<DataBase> AsQueryable();

        #region Queries
        int Count();

        DataBase? GetByDataBaseId(int databaseId);

        DataBase GetByProjectIdByName(int projectId, string databaseName);

        List<DataBase?> GetAll();

        List<DataBase?> GetAllByDataBaseId(List<int> lstDataBaseChecked);

        List<DataBase> GetAllByDataBaseIdForModal(string textToSearch);

        List<DataBase> GetAllByProjectIdByName(int projectId, string databaseName);

        List<DataBase> GetAllByProjectId(int projectId);

        List<DataBase> GetAllByProjectIdByNameInSearchBar(int projectId, string text);
        #endregion

        #region Non-Queries
        bool Add(DataBase database);

        int AddReturnId(DataBase dataBase);

        bool Update(DataBase database);

        bool DeleteByDataBaseId(int database);
        #endregion
    }
}
