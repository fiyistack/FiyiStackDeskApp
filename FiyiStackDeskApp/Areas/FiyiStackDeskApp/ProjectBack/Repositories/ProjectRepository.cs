using FiyiStackDeskApp.Areas.FiyiStackDeskApp.ProjectBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.ProjectBack.Interfaces;
using FiyiStackDeskApp.DatabaseContexts;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

namespace FiyiStackDeskApp.Areas.FiyiStackDeskApp.ProjectBack.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        protected readonly FiyiStackDeskAppDbContext _context;

        public ProjectRepository(FiyiStackDeskAppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Project> AsQueryable()
        {
            try
            {
                return _context.Project.AsQueryable();
            }
            catch (Exception) { throw; }
        }

        #region Queries
        public int Count()
        {
            try
            {
                return _context.Project.Count();
            }
            catch (Exception) { throw; }
        }

        public Project? GetByProjectId(int projectId)
        {
            try
            {
                Project Project = _context.Project
                                .FirstOrDefault(x => x.ProjectId == projectId);
                return Project;
            }
            catch (Exception) { throw; }
        }

        public Project? GetByName(string name)
        {
            try
            {
                Project Project = _context.Project
                                .FirstOrDefault(x => x.Name == name);
                return Project;
            }
            catch (Exception) { throw; }
        }

        public List<Project?> GetAll()
        {
            try
            {
                return _context.Project.ToList();
            }
            catch (Exception) { throw; }
        }

        public List<Project> GetAllByProjectIdForModal(string textToSearch)
        {
            try
            {
                var query = from project in _context.Project
                            select new { Project = project };

                // Extraemos los resultados en listas separadas
                List<Project> lstProject = query.Select(result => result.Project)
                        .Where(x => x.ProjectId.ToString().Contains(textToSearch))
                        .OrderByDescending(p => p.DateTimeLastModification)
                        .ToList();

                return lstProject;
            }
            catch (Exception) { throw; }
        }

        public List<Project?> GetAllByProjectId(List<int> lstProjectChecked)
        {
            try
            {
                List<Project?> lstProject = [];

                foreach (int ProjectId in lstProjectChecked)
                {
                    Project project = _context.Project.Where(x => x.ProjectId == ProjectId).FirstOrDefault();

                    if (project != null)
                    {
                        lstProject.Add(project);
                    }
                }

                return lstProject;
            }
            catch (Exception) { throw; }
        }

        public List<Project> GetAllByUserIdByName(int userId, string name)
        {
            IQueryable<Project> Query = _context.Project
                    .Where(p => p.UserCreationId == userId);

            if (!string.IsNullOrEmpty(name))
            {
                Query = Query.Where(p => p.Name.Contains(name));
            }

            return Query.ToList();
        }

        public List<Project> GetAllByUserId(int userId)
        {
            try
            {
                return _context.Project
                        .Where(p => p.UserCreationId == userId)
                        .ToList();
            }
            catch (Exception) { throw; }
        }

        public List<Project> GetAllByUserIdByNameInSearchBar(int userId, string textToSearch)
        {
            try
            {
                IQueryable<Project> Query = _context.Project
                        .Where(p => p.UserCreationId == userId);

                if (!string.IsNullOrEmpty(textToSearch))
                {
                    Query = Query.Where(p => p.Name.Contains(textToSearch));
                }

                return Query.ToList();
            }
            catch (Exception) { throw; }
        }
        #endregion

        #region Non-Queries
        public bool Add(Project project)
        {
            try
            {
                EntityEntry<Project> ProjectToAdd = _context.Project.Add(project);

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }

        public int AddReturnId(Project project)
        {
            try
            {
                EntityEntry<Project> ProjectToAdd = _context.Project.Add(project);

                _context.SaveChanges();

                return ProjectToAdd.Entity.ProjectId;
            }
            catch (Exception) { throw; }
        }

        public bool Update(Project project)
        {
            try
            {
                _context.Project.Update(project);

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }

        public bool DeleteByProjectId(int projectId)
        {
            try
            {
                AsQueryable()
                        .Where(x => x.ProjectId == projectId)
                        .ExecuteDelete();

                bool result = _context.SaveChanges() > 0;

                return result;
            }
            catch (Exception) { throw; }
        }
        #endregion
    }
}
