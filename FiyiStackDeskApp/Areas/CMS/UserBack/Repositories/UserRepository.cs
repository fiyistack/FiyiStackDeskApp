using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using FiyiStackDeskApp.Areas.CMS.UserBack.Entities;
using FiyiStackDeskApp.Areas.CMS.UserBack.Entities;
using FiyiStackDeskApp.Areas.CMS.UserBack.Interfaces;
using FiyiStackDeskApp.DatabaseContexts;
using System.Text.RegularExpressions;
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

namespace FiyiStackDeskApp.Areas.CMS.UserBack.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly FiyiStackDeskAppDbContext _context;

        public UserRepository(FiyiStackDeskAppDbContext context)
        {
            _context = context;
        }

        public IQueryable<User> AsQueryable()
        {
            try
            {
                return _context.User.AsQueryable();
            }
            catch (Exception) { throw; }
        }

        #region Queries
        public int Count()
        {
            try
            {
                return _context.User.Count();
            }
            catch (Exception) { throw; }
        }

        public User? GetByUserId(int userId)
        {
            try
            {
                User User = _context.User
                                .FirstOrDefault(x => x.UserId == userId);
                return User;
            }
            catch (Exception) { throw; }
        }

        public User? GetByFantasyNameByEmailByPassword(string email, string password)
        {
            try
            {
                User? user = _context.User
                    .Where(x => x.Email == email)
                    .Where(x => x.Password == password)
                    .FirstOrDefault();
                return user;
            }
            catch (Exception) { throw; }
        }

        public List<User?> GetAll()
        {
            try
            {
                return _context.User.ToList();
            }
            catch (Exception) { throw; }
        }

        public List<User> GetAllByUserIdForModal(string textToSearch)
        {
            try
            {
                var query = from user in _context.User
                            select new { User = user };

                // Extraemos los resultados en listas separadas
                List<User> lstUser = query.Select(result => result.User)
                        .Where(x => x.UserId.ToString().Contains(textToSearch))
                        .OrderByDescending(p => p.DateTimeLastModification)
                        .ToList();

                return lstUser;
            }
            catch (Exception) { throw; }
        }

        public List<User?> GetAllByUserId(List<int> lstUserChecked)
        {
            try
            {
                List<User?> lstUser = [];

                foreach (int UserId in lstUserChecked)
                {
                    User user = _context.User.Where(x => x.UserId == UserId).FirstOrDefault();

                    if (user != null)
                    {
                        lstUser.Add(user);
                    }
                }

                return lstUser;
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Non-Queries
        public bool Add(User user)
        {
            try
            {
                EntityEntry<User> UserToAdd = _context.User.Add(user);

                bool result = _context.SaveChanges() > 0;

                int AddedUserId = UserToAdd.Entity.UserId;

                return result;
            }
            catch (Exception) { throw; }
        }

        public bool Update(User user)
        {
            try
            {

                //BUG : When updating an entity, if it is already being tracked by the context, it can cause issues with state management.
                var trackedEntity = _context.User.Local.FirstOrDefault(x => x.UserId == user.UserId);
                if (trackedEntity != null)
                {
                    _context.Entry(trackedEntity).State = EntityState.Detached;
                }

                _context.User.Update(user);
                return _context.SaveChanges() > 0;
            }
            catch (Exception) { throw; }
        }

        public bool DeleteByUserId(int userId)
        {
            try
            {
                AsQueryable()
                        .Where(x => x.UserId == userId)
                        .ExecuteDelete();

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }
        #endregion
    }
}
