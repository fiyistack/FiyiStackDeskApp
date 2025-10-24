using FiyiStackDeskApp.Areas.FiyiStackDeskApp.ProjectBack.Entities;
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

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.ProjectBack.Interfaces
{
    public interface IProjectRepository
    {
        IQueryable<Project> AsQueryable();

        #region Queries
        int Count();

        Project? GetByProjectId(int projectId);

        Project? GetByName(string name);

        List<Project?> GetAll();

        List<Project?> GetAllByProjectId(List<int> lstProjectChecked);

        List<Project> GetAllByProjectIdForModal(string textToSearch);

        List<Project> GetAllByUserIdByName(int userId, string name);

        List<Project> GetAllByUserId(int userId);

        List<Project> GetAllByUserIdByNameInSearchBar(int userId, string textToSearch);
        #endregion

        #region Non-Queries
        bool Add(Project project);

        int AddReturnId(Project project);

        bool Update(Project project);

        bool DeleteByProjectId(int project);
        #endregion
    }
}
