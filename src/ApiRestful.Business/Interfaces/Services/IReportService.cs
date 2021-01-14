using ApiRestful.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestful.Business.Interfaces.Services
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
