using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using FiyiStackDeskApp.Areas.CMS.UserBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.DataTypeBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.DataTypeBack.Interfaces;
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

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.DataTypeBack.Repositories
{
    public class DataTypeRepository : IDataTypeRepository
    {
        protected readonly FiyiStackDeskAppDbContext _context;

        public DataTypeRepository(FiyiStackDeskAppDbContext context)
        {
            _context = context;
        }

        public IQueryable<DataType> AsQueryable()
        {
            try
            {
                return _context.DataType.AsQueryable();
            }
            catch (Exception) { throw; }
        }

        #region Queries
        public int Count()
        {
            try
            {
                return _context.DataType.Count();
            }
            catch (Exception) { throw; }
        }

        public DataType? GetByDataTypeId(int datatypeId)
        {
            try
            {
                //Look in cache first
                DataType DataType = _context.DataType
                               .FirstOrDefault(x => x.DataTypeId == datatypeId);
                return DataType;
            }
            catch (Exception) { throw; }
        }

        public List<DataType?> GetAll()
        {
            try
            {
                return _context.DataType.ToList();
            }
            catch (Exception) { throw; }
        }

        public List<DataType> GetAllByDataTypeIdForModal(string textToSearch)
        {
            try
            {
                var query = from datatype in _context.DataType
                            select new { DataType = datatype };

                // Extraemos los resultados en listas separadas
                List<DataType> lstDataType = query.Select(result => result.DataType)
                        .Where(x => x.DataTypeId.ToString().Contains(textToSearch))
                        .OrderByDescending(p => p.DateTimeLastModification)
                        .ToList();

                return lstDataType;
            }
            catch (Exception) { throw; }
        }

        public List<DataType?> GetAllByDataTypeId(List<int> lstDataTypeChecked)
        {
            try
            {
                List<DataType?> lstDataType = [];

                foreach (int DataTypeId in lstDataTypeChecked)
                {
                    DataType datatype = _context.DataType.Where(x => x.DataTypeId == DataTypeId).FirstOrDefault();

                    if (datatype != null)
                    {
                        lstDataType.Add(datatype);
                    }
                }

                return lstDataType;
            }
            catch (Exception) { throw; }
        }

        public DataTable GetList(string firstTextItem)
        {
            try
            {
                //Create DataTable with "Value" and "Text" columns
                DataTable DataTable = new();
                DataTable.Columns.Add("Value", typeof(string));
                DataTable.Columns.Add("Text", typeof(string));

                //Add first row to  Agregar la primera fila con el parámetro FirstTextItem
                DataRow firstRow = DataTable.NewRow();
                firstRow["Value"] = "0";
                firstRow["Text"] = (firstTextItem ?? string.Empty).Trim();
                DataTable.Rows.Add(firstRow);

                // Consultar los DataType activos y proyectar a Value/Text
                var dataTypeRows = _context.DataType
                    .Select(dt => new
                    {
                        Value = dt.DataTypeId.ToString(),
                        Text = dt.Name ?? ""
                    })
                    .OrderBy(x => x.Text)
                    .ToList();

                // Agregar filas al DataTable
                foreach (var row in dataTypeRows)
                {
                    DataRow dataRow = DataTable.NewRow();
                    dataRow["Value"] = row.Value;
                    dataRow["Text"] = row.Text;
                    DataTable.Rows.Add(dataRow);
                }

                return DataTable;
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Non-Queries
        public bool Add(DataType datatype)
        {
            try
            {
                EntityEntry<DataType> DataTypeToAdd = _context.DataType.Add(datatype);

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }

        public bool Update(DataType datatype)
        {
            try
            {
                _context.DataType.Update(datatype);

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }

        public bool DeleteByDataTypeId(int datatypeId)
        {
            try
            {
                AsQueryable()
                        .Where(x => x.DataTypeId == datatypeId)
                        .ExecuteDelete();

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }
        #endregion
    }
}
