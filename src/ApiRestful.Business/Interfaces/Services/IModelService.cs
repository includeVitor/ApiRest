using ApiRestful.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestful.Business.Interfaces.Services
{
    public interface IModelService : IDisposable
    {
        Task<IEnumerable<Model>> All();
        Task<Model> Show(Guid id);
        Task<bool> Add(Model model);
        Task<bool> Update(Model model);
        Task<bool> Remove(Guid id);
    }
}
