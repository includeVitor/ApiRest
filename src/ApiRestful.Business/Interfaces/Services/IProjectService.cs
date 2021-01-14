using ApiRestful.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestful.Business.Interfaces.Services
{
    public interface IProjectService : IDisposable
    {
        Task<IEnumerable<Project>> All();
        Task<Project> Show(Guid id);
        Task<bool> Add(Project project);
        Task<bool> Update(Project project);
        Task<bool> Remove(Guid id);
    }
}
