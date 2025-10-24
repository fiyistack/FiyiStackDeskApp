using FiyiStackDeskApp.Areas.FiyiStackDeskApp.VersionControlBack.Entities;
using System.Data;

/*
 * 
 * Coded by fiyistack.com
 * Copyright © 2025
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 */

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.VersionControlBack.Interfaces
{
    public interface IVersionControlRepository
    {
        IQueryable<VersionControl> AsQueryable();

        #region Queries
        int Count();

        VersionControl? GetByVersionControlId(int versioncontrolId);

        List<VersionControl?> GetAll();

        List<VersionControl?> GetAllByVersionControlId(List<int> lstVersionControlChecked);

        List<VersionControl> GetAllByVersionControlIdForModal(string textToSearch);
        #endregion

        #region Non-Queries
        bool Add(VersionControl versioncontrol);

        bool Update(VersionControl versioncontrol);

        bool DeleteByVersionControlId(int versioncontrol);
        #endregion
    }
}
