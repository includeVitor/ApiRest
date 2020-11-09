using SmartDataInitiative.Business.Interfaces;
using SmartDataInitiative.Business.Interfaces.Services;
using SmartDataInitiative.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartDataInitiative.Business.Services
{
    public class FeedbackService : BaseService, IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        public FeedbackService(INotify notify, 
                               IFeedbackRepository feedbackRepository) : base(notify)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<IEnumerable<Feedback>> All() => await _feedbackRepository.All();

        public async Task<Feedback> Show(Guid id) => await _feedbackRepository.GetById(id);

        public Task<bool> Update(Feedback feedback)
        {
            throw new NotImplementedException();
        }


        public Task<bool> Add(Feedback feedback)
        {
            throw new NotImplementedException();
        }


        public Task<bool> Remove(Guid id)
        {
            throw new NotImplementedException();
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }


    }
}
