using SmartDataInitiative.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartDataInitiative.Business.Interfaces.Services
{
    public interface IReportService : IDisposable
    {
        Task<IEnumerable<Report>> All();
        Task<Report> Show(Guid id);
        Task<bool> Add(Report report);
        Task<bool> Update(Report report);
        Task<bool> Remove(Guid id);

    }
}
