using FiyiStackDeskApp.Areas.CMS.UserBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.G1ConfigurationBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.G1ConfigurationBack.EntitiesConfiguration;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.G1ConfigurationBack.Interfaces;
using FiyiStackDeskApp.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Caching.Memory;
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

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.G1ConfigurationBack.Repositories
{
    public class G1ConfigurationRepository : IG1ConfigurationRepository
    {
        protected readonly FiyiStackDeskAppDbContext _context;

        public G1ConfigurationRepository(FiyiStackDeskAppDbContext context)
        {
            _context = context;
        }

        public IQueryable<G1Configuration> AsQueryable()
        {
            try
            {
                return _context.G1Configuration.AsQueryable();
            }
            catch (Exception) { throw; }
        }

        #region Queries
        public int Count()
        {
            try
            {
                return _context.G1Configuration.Count();
            }
            catch (Exception) { throw; }
        }

        public G1Configuration? GetByConfigurationId(int configurationId)
        {
            try
            {
                G1Configuration Configuration = _context.G1Configuration
                                .FirstOrDefault(x => x.G1ConfigurationId == configurationId);

                return Configuration;
            }
            catch (Exception) { throw; }
        }

        public G1Configuration? GetByProjectId(int projectId)
        {
            try
            {
                G1Configuration? configuration = _context.G1Configuration
                                .FirstOrDefault(x => x.ProjectId == projectId);
                return configuration;
            }
            catch (Exception) { throw; }
        }

        public List<G1Configuration?> GetAll()
        {
            try
            {
                return _context.G1Configuration.ToList();
            }
            catch (Exception) { throw; }
        }

        public List<G1Configuration> GetAllByConfigurationIdForModal(string textToSearch)
        {
            try
            {
                var query = from configuration in _context.G1Configuration
                            select new { Configuration = configuration };

                // Extraemos los resultados en listas separadas
                List<G1Configuration> lstConfiguration = query.Select(result => result.Configuration)
                        .Where(x => x.G1ConfigurationId.ToString().Contains(textToSearch))
                        .OrderByDescending(p => p.DateTimeLastModification)
                        .ToList();

                return lstConfiguration;
            }
            catch (Exception) { throw; }
        }

        public List<G1Configuration?> GetAllByConfigurationId(List<int> lstConfigurationChecked)
        {
            try
            {
                List<G1Configuration?> lstConfiguration = [];

                foreach (int ConfigurationId in lstConfigurationChecked)
                {
                    G1Configuration configuration = _context.G1Configuration.Where(x => x.G1ConfigurationId == ConfigurationId).FirstOrDefault();

                    if (configuration != null)
                    {
                        lstConfiguration.Add(configuration);
                    }
                }

                return lstConfiguration;
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Non-Queries
        public bool Add(G1Configuration configuration)
        {
            try
            {
                EntityEntry<G1Configuration> ConfigurationToAdd = _context.G1Configuration.Add(configuration);

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }

        public bool Update(G1Configuration configuration)
        {
            try
            {
                _context.G1Configuration.Update(configuration);

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }

        public bool DeleteByConfigurationId(int configurationId)
        {
            try
            {
                AsQueryable()
                        .Where(x => x.G1ConfigurationId == configurationId)
                        .ExecuteDelete();

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }

        public void DeleteByProjectId(int projectId)
        {
            try
            {
                AsQueryable()
                        .Where(x => x.ProjectId == projectId)
                        .ExecuteDelete();

                _context.SaveChanges();
            }
            catch (Exception) { throw; }
        }
        #endregion
    }
}
