using FiyiStackDeskApp.Areas.System.FailureBack.Entities;
using FiyiStackDeskApp.Areas.System.FailureBack.Interfaces;
using FiyiStackDeskApp.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Caching.Memory;
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

namespace FiyiStackDeskApp.Areas.System.FailureBack.Repositories
{
    public class FailureRepository : IFailureRepository
    {
        protected readonly FiyiStackDeskAppDbContext _context;

        public FailureRepository(FiyiStackDeskAppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Failure> AsQueryable()
        {
            try
            {
                return _context.Failure.AsQueryable();
            }
            catch (Exception) { throw; }
        }

        #region Queries
        public int Count()
        {
            try
            {
                return _context.Failure.Count();
            }
            catch (Exception) { throw; }
        }

        public Failure? GetByFailureId(int failureId)
        {
            try
            {
                Failure Failure = _context.Failure
                                .FirstOrDefault(x => x.FailureId == failureId);
                return Failure;
            }
            catch (Exception) { throw; }
        }

        public List<Failure?> GetAll()
        {
            try
            {
                return _context.Failure.ToList();
            }
            catch (Exception) { throw; }
        }

        public List<Failure> GetAllByFailureIdForModal(string textToSearch)
        {
            try
            {
                var query = from failure in _context.Failure
                            select new { Failure = failure };

                // Extraemos los resultados en listas separadas
                List<Failure> lstFailure = query.Select(result => result.Failure)
                        .Where(x => x.FailureId.ToString().Contains(textToSearch))
                        .OrderByDescending(p => p.DateTimeLastModification)
                        .ToList();

                return lstFailure;
            }
            catch (Exception) { throw; }
        }

        public List<Failure?> GetAllByFailureId(List<int> lstFailureChecked)
        {
            try
            {
                List<Failure?> lstFailure = [];

                foreach (int FailureId in lstFailureChecked)
                {
                    Failure failure = _context.Failure.Where(x => x.FailureId == FailureId).FirstOrDefault();

                    if (failure != null)
                    {
                        lstFailure.Add(failure);
                    }
                }

                return lstFailure;
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Non-Queries
        public bool Add(Failure failure)
        {
            try
            {
                EntityEntry<Failure> FailureToAdd = _context.Failure.Add(failure);

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }

        public bool Update(Failure failure)
        {
            try
            {
                _context.Failure.Update(failure);

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }

        public bool DeleteByFailureId(int failureId)
        {
            try
            {
                AsQueryable()
                        .Where(x => x.FailureId == failureId)
                        .ExecuteDelete();

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }
        #endregion
    }
}
