using FiyiStackDeskApp.Areas.FiyiStackDeskApp.DataTypeBack.Entities;
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

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.DataTypeBack.Interfaces
{
    public interface IDataTypeRepository
    {
        IQueryable<DataType> AsQueryable();

        #region Queries
        int Count();

        DataType? GetByDataTypeId(int datatypeId);

        List<DataType?> GetAll();

        List<DataType?> GetAllByDataTypeId(List<int> lstDataTypeChecked);

        List<DataType> GetAllByDataTypeIdForModal(string textToSearch);

        DataTable GetList(string firstTextItem);
        #endregion

        #region Non-Queries
        bool Add(DataType datatype);

        bool Update(DataType datatype);

        bool DeleteByDataTypeId(int datatype);
        #endregion
    }
}
