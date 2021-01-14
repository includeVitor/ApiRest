using ApiRestful.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiRestful.Business.Interfaces
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {
        Task<Feedback> GetFieldInFeedback(Guid id);
        Task<IEnumerable<Feedback>> GetFeedbacksByField(Guid FieldId);
        Task<IEnumerable<Feedback>> GetFeedbacks();

    }
}
