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
    public class ReportModelService : BaseService, IReportModelService
    {
        private readonly IReportModelRepository _reportModelRepository;

        public ReportModelService(INotify notify, 
                                  IReportModelRepository reportModelRepository) : base(notify)
        {
            _reportModelRepository = reportModelRepository;
        }

        public async Task<IEnumerable<ReportModel>> All() => await _reportModelRepository.All();

        public async Task<ReportModel> Show(Guid id) => await _reportModelRepository.GetById(id);

        public async Task<bool> Add(ReportModel reportModel)
        {
            if (!ExecuteValidation(new ReportModelValidation(), reportModel)) return false;

            if (_reportModelRepository.Find(p => p.Name == reportModel.Name && p.Id == reportModel.Id).Result.Any())
            {
                Notify("Já existe um modelo de report com esse nome");
                return false;
            }

            await _reportModelRepository.Add(reportModel);
            return true;
        }
        public Task<bool> Update(ReportModel reportModel)
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
