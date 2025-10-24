

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

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.FieldBack.Entities
{
    public class Field
    {
        
        public int FieldId { get; set; }

        ///<summary>
        /// For auditing purposes
        ///</summary>
        public bool Active { get; set; }

        ///<summary>
        /// For auditing purposes
        ///</summary>
        public DateTime DateTimeCreation { get; set; }

        ///<summary>
        /// For auditing purposes
        ///</summary>
        public DateTime DateTimeLastModification { get; set; }

        ///<summary>
        /// For auditing purposes
        ///</summary>
        public int UserCreationId { get; set; }

        ///<summary>
        /// For auditing purposes
        ///</summary>
        public int UserLastModificationId { get; set; }

        public int TableId { get; set; }

        public int DataTypeId { get; set; }

        public string? Name { get; set; }

          
        public bool Nullable { get; set; }

        
        public string? HistoryUser { get; set; }

        
        public string? Regex { get; set; }

        
        public string? MinValue { get; set; }

        
        public string? MaxValue { get; set; }

        
        public string? ForeignTableName { get; set; }

        public string? ForeignColumnName { get; set; }
    }
}