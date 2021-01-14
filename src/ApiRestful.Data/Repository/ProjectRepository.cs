using Microsoft.EntityFrameworkCore;
using ApiRestful.Business.Interfaces;
using ApiRestful.Business.Models;
using ApiRestful.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestful.Data.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(MyDbContext context) : base (context) {}

        public async Task<Project> GetFieldsInProject(Guid id) => await
                    Db.Projects.AsNoTracking()
                    .Include(c => c.Fields)
                    .FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Project> GetReportModelsInProject(Guid id) => await
                    Db.Projects.AsNoTracking()
                    .Include(c => c.ReportModels)
                    .FirstOrDefaultAsync(c => c.Id == id);
        public async Task<Project> GetAllInProject(Guid id) => await
                    Db.Projects.AsNoTracking()
                    .Include(c => c.ReportModels)
                    .Include(c => c.Fields)
                    .FirstOrDefaultAsync(c => c.Id == id);
        public async Task<IEnumerable<Project>> GetAllProjects() => await
                    Db.Projects.AsNoTracking()
                    .Include(c => c.ReportModels)
                    .Include(c => c.Fields)
                    .ToListAsync();

    }
}
