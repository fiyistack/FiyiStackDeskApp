using FiyiStackDeskApp.Areas.FiyiStackDeskApp.NewsInLoginPageBack.Entities;
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

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.NewsInLoginPageBack.Interfaces
{
    public interface INewsInLoginPageRepository
    {
        IQueryable<NewsInLoginPage> AsQueryable();

        #region Queries
        int Count();

        NewsInLoginPage? GetByNewsInLoginPageId(int newsinloginpageId);

        NewsInLoginPage? GetLastNews();

        List<NewsInLoginPage?> GetAll();

        List<NewsInLoginPage?> GetAllByNewsInLoginPageId(List<int> lstNewsInLoginPageChecked);

        List<NewsInLoginPage> GetAllByNewsInLoginPageIdForModal(string textToSearch);
        #endregion

        #region Non-Queries
        bool Add(NewsInLoginPage newsinloginpage);

        bool Update(NewsInLoginPage newsinloginpage);

        bool DeleteByNewsInLoginPageId(int newsinloginpage);
        #endregion
    }
}
