using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using FiyiStackDeskApp.Areas.CMS.UserBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.VersionControlBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.VersionControlBack.Interfaces;
using System.Text.RegularExpressions;
using System.Data;
using FiyiStackDeskApp.DatabaseContexts;

/*
 * 
 * Coded by fiyistack.com
 * Copyright © 2025
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 */

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.VersionControlBack.Repositories
{
    public class VersionControlRepository : IVersionControlRepository
    {
        protected readonly FiyiStackDeskAppDbContext _context;

        public VersionControlRepository(FiyiStackDeskAppDbContext context)
        {
            _context = context;
        }

        public IQueryable<VersionControl> AsQueryable()
        {
            try
            {
                return _context.VersionControl.AsQueryable();
            }
            catch (Exception) { throw; }
        }

        #region Queries
        public int Count()
        {
            try
            {
                return _context.VersionControl.Count();
            }
            catch (Exception) { throw; }
        }

        public VersionControl? GetByVersionControlId(int versioncontrolId)
        {
            try
            {
                VersionControl VersionControl = _context.VersionControl
                                                            .FirstOrDefault(x => x.VersionControlId == versioncontrolId);
                return VersionControl;
            }
            catch (Exception) { throw; }
        }

        public List<VersionControl?> GetAll()
        {
            try
            {
                return _context.VersionControl.ToList();
            }
            catch (Exception) { throw; }
        }

        public List<VersionControl> GetAllByVersionControlIdForModal(string textToSearch)
        {
            try
            {
                var query = from versioncontrol in _context.VersionControl
                            select new { VersionControl = versioncontrol };

                // Extraemos los resultados en listas separadas
                List<VersionControl> lstVersionControl = query.Select(result => result.VersionControl)
                        .Where(x => x.VersionControlId.ToString().Contains(textToSearch))
                        .OrderByDescending(p => p.DateTimeLastModification)
                        .ToList();

                return lstVersionControl;
            }
            catch (Exception) { throw; }
        }

        public List<VersionControl?> GetAllByVersionControlId(List<int> lstVersionControlChecked)
        {
            try
            {
                List<VersionControl?> lstVersionControl = [];

                foreach (int VersionControlId in lstVersionControlChecked)
                {
                    VersionControl versioncontrol = _context.VersionControl.Where(x => x.VersionControlId == VersionControlId).FirstOrDefault();

                    if (versioncontrol != null)
                    {
                        lstVersionControl.Add(versioncontrol);
                    }
                }

                return lstVersionControl;
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Non-Queries
        public bool Add(VersionControl versioncontrol)
        {
            try
            {
                EntityEntry<VersionControl> VersionControlToAdd = _context.VersionControl.Add(versioncontrol);

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }

        public bool Update(VersionControl versioncontrol)
        {
            try
            {
                _context.VersionControl.Update(versioncontrol);

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }

        public bool DeleteByVersionControlId(int versioncontrolId)
        {
            try
            {
                AsQueryable()
                        .Where(x => x.VersionControlId == versioncontrolId)
                        .ExecuteDelete();

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }
        #endregion
    }
}
