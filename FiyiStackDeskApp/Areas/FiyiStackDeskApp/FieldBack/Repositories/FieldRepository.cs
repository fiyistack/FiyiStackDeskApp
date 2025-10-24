using FiyiStackDeskApp.Areas.CMS.UserBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.FieldBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.FieldBack.Interfaces;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.ProjectBack.Entities;
using FiyiStackDeskApp.DatabaseContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Caching.Memory;
using System.Data;
using System.Text.RegularExpressions;

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

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.FieldBack.Repositories
{
    public class FieldRepository : IFieldRepository
    {
        protected readonly FiyiStackDeskAppDbContext _context;

        public FieldRepository(FiyiStackDeskAppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Field> AsQueryable()
        {
            try
            {
                return _context.Field.AsQueryable();
            }
            catch (Exception) { throw; }
        }

        #region Queries
        public int Count()
        {
            try
            {
                return _context.Field.Count();
            }
            catch (Exception) { throw; }
        }

        public Field? GetByFieldId(int fieldId)
        {
            try
            {
                Field Field = _context.Field
                                .FirstOrDefault(x => x.FieldId == fieldId);
                return Field;
            }
            catch (Exception) { throw; }
        }

        public Field? GetByTableIdByName(int tableId, string name)
        {
            try
            {
                Field? field = _context.Field
                                .FirstOrDefault(x => x.TableId == tableId && x.Name == name);
                return field;
            }
            catch (Exception) { throw; }
        }

        public List<Field?> GetAll()
        {
            try
            {
                return _context.Field.ToList();
            }
            catch (Exception) { throw; }
        }

        public List<Field> GetAllByFieldIdForModal(string textToSearch)
        {
            try
            {
                var query = from field in _context.Field
                            select new { Field = field };

                // Extraemos los resultados en listas separadas
                List<Field> lstField = query.Select(result => result.Field)
                        .Where(x => x.FieldId.ToString().Contains(textToSearch))
                        .OrderByDescending(p => p.DateTimeLastModification)
                        .ToList();

                return lstField;
            }
            catch (Exception) { throw; }
        }

        public List<Field?> GetAllByFieldId(List<int> lstFieldChecked)
        {
            try
            {
                List<Field?> lstField = [];

                foreach (int FieldId in lstFieldChecked)
                {
                    Field field = _context.Field.Where(x => x.FieldId == FieldId).FirstOrDefault();

                    if (field != null)
                    {
                        lstField.Add(field);
                    }
                }

                return lstField;
            }
            catch (Exception) { throw; }
        }

        public List<Field> GetAllByTableIdByName(int tableId, string name)
        {
            IQueryable<Field> Query = _context.Field
                    .Where(p => p.TableId == tableId);

            if (!string.IsNullOrEmpty(name))
            {
                Query = Query.Where(p => p.Name.Contains(name));
            }

            return Query.ToList();
        }

        public List<Field> GetAllByTableId(int tableId)
        {
            try
            {
                List<Field> lstField = _context.Field
                        .Where(x => x.TableId == tableId)
                        .ToList();

                return lstField;
            }
            catch (Exception) { throw; }
        }

        public List<Field> GetAllByTableIdByNameInSearchBar(int tableId, string textToSearch)
        {
            try
            {
                IQueryable<Field> Query = _context.Field
                    .Where(p => p.TableId == tableId);

                if (!string.IsNullOrEmpty(textToSearch))
                {
                    Query = Query.Where(x => x.Name.Contains(textToSearch));
                }

                return Query.ToList();
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Non-Queries
        public bool Add(Field field)
        {
            try
            {
                EntityEntry<Field> FieldToAdd = _context.Field.Add(field);

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }

        public bool Update(Field field)
        {
            try
            {
                _context.Field.Update(field);

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }

        public bool DeleteByFieldId(int fieldId)
        {
            try
            {
                AsQueryable()
                        .Where(x => x.FieldId == fieldId)
                        .ExecuteDelete();

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }

        public bool DeleteByTableId(int tableId)
        {
            try
            {
                AsQueryable()
                        .Where(x => x.TableId == tableId)
                        .ExecuteDelete();

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }
        #endregion
    }
}
