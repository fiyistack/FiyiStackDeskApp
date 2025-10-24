using FiyiStackDeskApp.Areas.CMS.UserBack.Entities;

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

namespace FiyiStackDeskApp.Areas.CMS.UserBack.Interfaces
{
    public interface IUserRepository
    {
        IQueryable<User> AsQueryable();

        #region Queries
        int Count();

        User? GetByUserId(int userId);

        User? GetByFantasyNameByEmailByPassword(string fantasyNameOrEmail, string password);

        List<User> GetAll();

        List<User?> GetAllByUserId(List<int> lstUserChecked);

        List<User> GetAllByUserIdForModal(string textToSearch);
        #endregion

        #region Non-Queries
        bool Add(User user);

        bool Update(User user);

        bool DeleteByUserId(int user);
        #endregion
    }
}
