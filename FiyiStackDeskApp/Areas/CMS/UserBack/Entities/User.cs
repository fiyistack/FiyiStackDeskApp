/*
 * 
 * Coded by fiyistack.com
 * Copyright © 2025
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 */

namespace FiyiStackDeskApp.Areas.CMS.UserBack.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public bool Active { get; set; }
        public DateTime DateTimeCreation { get; set; }
        public DateTime DateTimeLastModification { get; set; }
        public int UserCreationId { get; set; }
        public int UserLastModificationId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}