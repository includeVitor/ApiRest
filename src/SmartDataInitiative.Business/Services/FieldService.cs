using SmartDataInitiative.Business.Interfaces;
using SmartDataInitiative.Business.Interfaces.Services;
using SmartDataInitiative.Business.Models;
using SmartDataInitiative.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartDataInitiative.Business.Services
{
    public class FieldService : BaseService, IFieldService
    {
        private readonly IFieldRepository _fieldRepository;

        public FieldService(INotify notify,
                            IFieldRepository fieldRepository) : base(notify)
        {
            _fieldRepository = fieldRepository;
        }

        public async Task<IEnumerable<Field>> All() => await _fieldRepository.All();

        public async Task<Field> Show(Guid id) => await _fieldRepository.GetById(id);

        public async Task<bool> Add(Field field)
        {
            if (!ExecuteValidation(new FieldValidation(), field)) return false;

            if (_fieldRepository.Find(f => f.Name == field.Name && f.ProjectId == field.ProjectId).Result.Any())
            {
                Notify("Já existe outra aréa com esse nome");
                return false;
            }

            await _fieldRepository.Add(field);
            return true;
        }

        public async Task<bool> Update(Field field)
        {
            if (!ExecuteValidation(new FieldValidation(), field)) return false;

            if (_fieldRepository.Find(f => f.Name == field.Name && f.ProjectId == field.ProjectId).Result.Any())
            {
                Notify("Já existe outra aréa com esse nome");
                return false;
            }

            await _fieldRepository.Update(field);
            return true;
        }

        public async Task<bool> Remove(Guid id){ 
            
            await _fieldRepository.Remove(id);  
            return true; 
        }

        public void Dispose()
        {
            _fieldRepository?.Dispose();
        }
    }
}
