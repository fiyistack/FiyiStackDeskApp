using FiyiStackDeskApp.Areas.System.FailureBack.Entities;
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

namespace FiyiStackDeskApp.Areas.System.FailureBack.Interfaces
{
    public interface IFailureRepository
    {
        IQueryable<Failure> AsQueryable();

        #region Queries
        int Count();

        Failure? GetByFailureId(int failureId);

        List<Failure?> GetAll();

        List<Failure?> GetAllByFailureId(List<int> lstFailureChecked);

        List<Failure> GetAllByFailureIdForModal(string textToSearch);
        #endregion

        #region Non-Queries
        bool Add(Failure failure);

        bool Update(Failure failure);

        bool DeleteByFailureId(int failure);
        #endregion
    }
}
