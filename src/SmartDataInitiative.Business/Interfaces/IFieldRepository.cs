using SmartDataInitiative.Business.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartDataInitiative.Business.Interfaces
{
    public interface IFieldRepository : IRepository<Field>
    {
        Task<IEnumerable<Field>> GetAllReportsByField(Guid id);
        Task<IEnumerable<Field>> GetAllFeedbacksByField(Guid id);

    }
}
