using SmartDataInitiative.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartDataInitiative.Business.Interfaces
{
    public interface IModelRespository : IRepository<Model>
    {

        Task<IEnumerable<Model>> GetAllModelsByReport(Guid id);

    }
}
