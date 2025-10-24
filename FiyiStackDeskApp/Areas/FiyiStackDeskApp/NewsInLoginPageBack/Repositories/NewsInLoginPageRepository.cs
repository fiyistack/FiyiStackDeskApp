using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.NewsInLoginPageBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.NewsInLoginPageBack.Interfaces;
using FiyiStackDeskApp.DatabaseContexts;
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

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.NewsInLoginPageBack.Repositories
{
    public class NewsInLoginPageRepository : INewsInLoginPageRepository
    {
        protected readonly FiyiStackDeskAppDbContext _context;

        public NewsInLoginPageRepository(FiyiStackDeskAppDbContext context)
        {
            _context = context;
        }

        public IQueryable<NewsInLoginPage> AsQueryable()
        {
            try
            {
                return _context.NewsInLoginPage.AsQueryable();
            }
            catch (Exception) { throw; }
        }

        #region Queries
        public int Count()
        {
            try
            {
                return _context.NewsInLoginPage.Count();
            }
            catch (Exception) { throw; }
        }

        public NewsInLoginPage? GetByNewsInLoginPageId(int newsinloginpageId)
        {
            try
            {
                NewsInLoginPage NewsInLoginPage = _context.NewsInLoginPage
                                .FirstOrDefault(x => x.NewsInLoginPageId == newsinloginpageId);
                return NewsInLoginPage;
            }
            catch (Exception) { throw; }
        }

        public NewsInLoginPage? GetLastNews()
        {
            try
            {
                NewsInLoginPage? lastNews = _context.NewsInLoginPage
                                .OrderByDescending(x => x.DateTimeLastModification)
                                .FirstOrDefault();
                return lastNews;
            }
            catch (Exception) { throw; }
        }

        public List<NewsInLoginPage?> GetAll()
        {
            try
            {
                return _context.NewsInLoginPage.ToList();
            }
            catch (Exception) { throw; }
        }

        public List<NewsInLoginPage> GetAllByNewsInLoginPageIdForModal(string textToSearch)
        {
            try
            {
                var query = from newsinloginpage in _context.NewsInLoginPage
                            select new { NewsInLoginPage = newsinloginpage };

                // Extraemos los resultados en listas separadas
                List<NewsInLoginPage> lstNewsInLoginPage = query.Select(result => result.NewsInLoginPage)
                        .Where(x => x.NewsInLoginPageId.ToString().Contains(textToSearch))
                        .OrderByDescending(p => p.DateTimeLastModification)
                        .ToList();

                return lstNewsInLoginPage;
            }
            catch (Exception) { throw; }
        }

        public List<NewsInLoginPage?> GetAllByNewsInLoginPageId(List<int> lstNewsInLoginPageChecked)
        {
            try
            {
                List<NewsInLoginPage?> lstNewsInLoginPage = [];

                foreach (int NewsInLoginPageId in lstNewsInLoginPageChecked)
                {
                    NewsInLoginPage newsinloginpage = _context.NewsInLoginPage.Where(x => x.NewsInLoginPageId == NewsInLoginPageId).FirstOrDefault();

                    if (newsinloginpage != null)
                    {
                        lstNewsInLoginPage.Add(newsinloginpage);
                    }
                }

                return lstNewsInLoginPage;
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Non-Queries
        public bool Add(NewsInLoginPage newsinloginpage)
        {
            try
            {
                EntityEntry<NewsInLoginPage> NewsInLoginPageToAdd = _context.NewsInLoginPage.Add(newsinloginpage);

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }

        public bool Update(NewsInLoginPage newsinloginpage)
        {
            try
            {
                _context.NewsInLoginPage.Update(newsinloginpage);

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }

        public bool DeleteByNewsInLoginPageId(int newsinloginpageId)
        {
            try
            {
                AsQueryable()
                        .Where(x => x.NewsInLoginPageId == newsinloginpageId)
                        .ExecuteDelete();

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }
        #endregion
    }
}
