using ApiRestful.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRestful.Business.Interfaces
{
    public interface IFieldRepository : IRepository<Field>
    {
        Task<Field> GetReportsInField(Guid id);
        Task<Field> GetFeedbacksInField(Guid id);
        Task<IEnumerable<Field>> GetFieldsByProject(Guid ProjectId);
        Task<Field> GetAllInField(Guid id);
        Task<IEnumerable<Field>> GetAllFields();

    }
}

