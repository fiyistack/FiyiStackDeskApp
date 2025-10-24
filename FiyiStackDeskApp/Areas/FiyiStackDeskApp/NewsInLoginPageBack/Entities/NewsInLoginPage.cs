

/*
 * 
 * Coded by fiyistack.com
 * Copyright © 2025
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 */

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.NewsInLoginPageBack.Entities
{
    public class NewsInLoginPage
    {
        
        public int NewsInLoginPageId { get; set; }

        public DateTime DateTimeCreation { get; set; }

        public DateTime DateTimeLastModification { get; set; }

        public int UserCreationId { get; set; }

        public int UserLastModificationId { get; set; }

        public string? New { get; set; }
    }
}