using SmartDataInitiative.Business.Interfaces;
using SmartDataInitiative.Business.Interfaces.Services;
using SmartDataInitiative.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDataInitiative.Business.Services
{
    public class ModelService : BaseService, IModelService
    {
        private readonly IModelRespository _modelRepository;


        public ModelService(INotify notify, 
                            IModelRespository modelRepository) : base(notify)
        {
            _modelRepository = modelRepository;
        }

        public async Task<IEnumerable<Model>> All() => await _modelRepository.All();

        public async Task<Model> Show(Guid id) => await _modelRepository.GetById(id);

        public async Task<bool> Add(Model model)
        {
            if (!ExecuteValidation(new ModelValidation(), model)) return false;

            if(_modelRepository.Find(m => m.Name == model.Name && m.ReportModelId == model.ReportModelId).Result.Any())
            {
                Notify("Já existe modelo com esse nome");
                return false;
            }

            await _modelRepository.Add(model);
            return true;
        }
        public async Task<bool> Update(Model model)
        {
            if (!ExecuteValidation(new ModelValidation(), model)) return false;

            if (_modelRepository.Find(m => m.Name == model.Name && m.ReportModelId == model.ReportModelId).Result.Any())
            {
                Notify("Já existe modelo com esse nome");
                return false;
            }

            await _modelRepository.Update(model);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            await _modelRepository.Remove(id);
            return true;
        }

        public void Dispose()
        {
            _modelRepository?.Dispose();
        }

    }
}
