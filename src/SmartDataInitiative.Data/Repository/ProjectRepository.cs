using Microsoft.EntityFrameworkCore;
using SmartDataInitiative.Business.Interfaces;
using SmartDataInitiative.Business.Models;
using SmartDataInitiative.Data.Context;
using System;
using System.Threading.Tasks;

namespace SmartDataInitiative.Data.Repository
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(MyDbContext context) : base (context) {}

        public async Task<Project> GetAllFields(Guid id)
        {
            return await 
                    Db.Projects.AsNoTracking()
                    .Include(c => c.Fields)
                    .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Project> GetAllReportModels(Guid id)
        {
            return await
                    Db.Projects.AsNoTracking()
                    .Include(c => c.ReportModels)
                    .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
