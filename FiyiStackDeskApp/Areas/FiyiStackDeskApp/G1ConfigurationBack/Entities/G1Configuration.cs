

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

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.G1ConfigurationBack.Entities
{
    public class G1Configuration
    {
        
        public int G1ConfigurationId { get; set; }

        public bool Active { get; set; }
        public DateTime DateTimeCreation { get; set; }
        public DateTime DateTimeLastModification { get; set; }
        public int UserCreationId { get; set; }
        public int UserLastModificationId { get; set; }

        public int ProjectId { get; set; }

        public bool WantCSharp { get; set; }
        public bool WantMSSQLServer { get; set; }

        public bool DeleteFiles { get; set; }
        public bool DeleteTable { get; set; }
        public bool DeleteField { get; set; }
        
        public bool WantDTO { get; set; }
        public bool WantEntity { get; set; }
        public bool WantEntityConfiguration { get; set; }
        public bool WantInterfaces { get; set; }
        public bool WantRepository { get; set; } 
        public bool WantBlazorPages { get; set; }
        public bool WantService { get; set; }
    }
}