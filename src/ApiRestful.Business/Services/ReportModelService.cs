using ApiRestful.Business.Interfaces;
using ApiRestful.Business.Interfaces.Services;
using ApiRestful.Business.Models;
using ApiRestful.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestful.Business.Services
{
    public class ReportModelService : BaseService, IReportModelService
    {
        private readonly IReportModelRepository _reportModelRepository;
        private readonly IModelRespository _modelRespository;
        private readonly IReportRepository _reportRepository;

        public ReportModelService(INotify notify,
                                  IReportModelRepository reportModelRepository,
                                  IModelRespository modelRespository, 
                                  IReportRepository reportRepository) : base(notify)
        {
            _reportModelRepository = reportModelRepository;
            _modelRespository = modelRespository;
            _reportRepository = reportRepository;
        }

        public async Task<IEnumerable<ReportModel>> All() => await _reportModelRepository.All();

        public async Task<ReportModel> Show(Guid id) => await _reportModelRepository.GetAllInReportModel(id);

        public async Task<bool> Add(ReportModel reportModel)
        {
            if (!ExecuteValidation(new ReportModelValidation(), reportModel)) return false;

            if (_reportModelRepository.Find(p => p.Name == reportModel.Name).Result.Any())
            {
                Notify("Já existe um modelo de report com esse nome");
                return false;
            }

            await _reportModelRepository.Add(reportModel);
            return true;
        }

        public async Task<bool> Update(ReportModel reportModel)
        {
            if (!ExecuteValidation(new ReportModelValidation(), reportModel)) return false;

            if (_reportModelRepository.Find(p => p.Name == reportModel.Name && p.Id != reportModel.Id).Result.Any())
            {
                Notify("Já existe um modelo de report com esse nome");
                return false;
            }

            await _reportModelRepository.Update(reportModel);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            var models = await _modelRespository.GetModelsByReportModel(id);

            if (models != null)
            {
                foreach (var model in models)
                {
                    await _modelRespository.Remove(model.Id);
                }
            }


            var reports = await _reportRepository.GetReportsByField(id);

            if (reports != null)
            {
                foreach (var report in reports)
                {
                    await _reportRepository.Remove(report.Id);
                }
            }


            await _reportModelRepository.Remove(id);
            return true;
        }
        public void Dispose()
        {
            _reportModelRepository?.Dispose();
        }
    }
}
