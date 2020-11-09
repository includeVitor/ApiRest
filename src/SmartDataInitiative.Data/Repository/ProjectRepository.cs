using Microsoft.EntityFrameworkCore;
using SmartDataInitiative.Business.Interfaces;
using SmartDataInitiative.Business.Models;
using SmartDataInitiative.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDataInitiative.Data.Repository
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
