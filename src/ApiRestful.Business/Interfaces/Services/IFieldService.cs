using ApiRestful.Business.Models;
using ApiRestful.Business.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestful.Business.Interfaces.Services
{
    public interface IFieldService : IDisposable
    {
        Task<IEnumerable<Field>> All();
        Task<Field> Show(Guid id);
        Task<bool> Add(Field field);
        Task<bool> Update(Field field);
        Task<bool> Remove(Guid id);
    }
}
