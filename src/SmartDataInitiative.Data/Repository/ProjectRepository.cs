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

        public async Task<IEnumerable<Project>> GetAllFieldsByProject(Guid id) => await
                    Db.Projects.AsNoTracking()
                    .Include(c => c.Fields)
                    .Where(c => c.Id == id)
                    .ToListAsync();

        public async Task<IEnumerable<Project>> GetAllReportModelsByProject(Guid id) => await
                    Db.Projects.AsNoTracking()
                    .Include(c => c.ReportModels)
                    .Where(c => c.Id == id)
                    .ToListAsync();
    }
}
