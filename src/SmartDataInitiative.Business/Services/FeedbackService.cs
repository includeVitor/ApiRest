using SmartDataInitiative.Business.Interfaces;
using SmartDataInitiative.Business.Interfaces.Services;
using SmartDataInitiative.Business.Models;
using SmartDataInitiative.Business.Models.Validations;
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

        public async Task<Feedback> Show(Guid id) => await _feedbackRepository.GetFieldInFeedback(id);

        public async Task<bool> Add(Feedback feedback)
        {
            if (!ExecuteValidation(new FeebackValidation(), feedback)) return false;

            await _feedbackRepository.Add(feedback);
            return true;
        }

        public async Task<bool> Update(Feedback feedback)
        {
            if (!ExecuteValidation(new FeebackValidation(), feedback)) return false;

            await _feedbackRepository.Update(feedback);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            await _feedbackRepository.Remove(id);
            return true;
        }

        public void Dispose()
        {
            _feedbackRepository?.Dispose();
        }


    }
}
