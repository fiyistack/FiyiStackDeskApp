using FiyiStackDeskApp.Areas.FiyiStackDeskApp.FieldBack.Entities;

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

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.FieldBack.Interfaces
{
    public interface IFieldRepository
    {
        IQueryable<Field> AsQueryable();

        #region Queries
        int Count();

        Field? GetByFieldId(int fieldId);

        Field? GetByTableIdByName(int tableId, string name);

        List<Field?> GetAll();

        List<Field?> GetAllByFieldId(List<int> lstFieldChecked);

        List<Field> GetAllByFieldIdForModal(string textToSearch);

        List<Field> GetAllByTableIdByName(int tableId, string name);

        List<Field> GetAllByTableId(int tableId);

        List<Field> GetAllByTableIdByNameInSearchBar(int tableId, string text);
        #endregion

        #region Non-Queries
        bool Add(Field field);

        bool Update(Field field);

        bool DeleteByFieldId(int field);

        bool DeleteByTableId(int tableId);
        #endregion
    }
}
