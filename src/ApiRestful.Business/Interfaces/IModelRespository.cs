using ApiRestful.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRestful.Business.Interfaces
{
    public interface IModelRespository : IRepository<Model>
    {
        Task<IEnumerable<Model>> GetModelsByReportModel(Guid ReportModelId);
        Task<Model> GetReportModelInModel(Guid Id);

        Task<Model> GetAllInModel(Guid id);
        Task<IEnumerable<Model>> GetAllModels();

    }
}
