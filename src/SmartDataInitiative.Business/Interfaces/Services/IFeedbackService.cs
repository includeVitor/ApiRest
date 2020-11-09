using SmartDataInitiative.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartDataInitiative.Business.Interfaces.Services
{
    public interface IFeedbackService : IDisposable
    {
        Task<IEnumerable<Feedback>> All();
        Task<Feedback> Show(Guid id);
        Task<bool> Add(Feedback feedback);
        Task<bool> Update(Feedback feedback);
        Task<bool> Remove(Guid id);
    }
}
