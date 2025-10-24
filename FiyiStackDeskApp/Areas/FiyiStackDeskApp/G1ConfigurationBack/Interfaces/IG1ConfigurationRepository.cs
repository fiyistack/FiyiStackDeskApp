using FiyiStackDeskApp.Areas.FiyiStackDeskApp.G1ConfigurationBack.Entities;

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

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.G1ConfigurationBack.Interfaces
{
    public interface IG1ConfigurationRepository
    {
        IQueryable<G1Configuration> AsQueryable();

        #region Queries
        int Count();

        G1Configuration? GetByConfigurationId(int configurationId);

        G1Configuration? GetByProjectId(int projectId);

        List<G1Configuration?> GetAll();

        List<G1Configuration?> GetAllByConfigurationId(List<int> lstConfigurationChecked);

        List<G1Configuration> GetAllByConfigurationIdForModal(string textToSearch);
        #endregion

        #region Non-Queries
        bool Add(G1Configuration configuration);

        bool Update(G1Configuration configuration);

        bool DeleteByConfigurationId(int configuration);

        void DeleteByProjectId(int projectId);
        #endregion
    }
}
