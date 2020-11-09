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
    public class ReportService : BaseService, IReportService
    {

        private readonly IReportRepository _reportRepository;

        public ReportService(INotify notify, 
                            IReportRepository reportRepository) : base(notify)
        {
            _reportRepository = reportRepository;
        }

        public async Task<IEnumerable<Report>> All() => await _reportRepository.All();

        public async Task<Report> Show(Guid id) => await _reportRepository.GetById(id);

        public async Task<bool> Add(Report report)
        {
            if (!ExecuteValidation(new ReportValidation(), report)) return false;

            if (DateTime.Compare(report.InitialDate, report.FinalDate) <= 0)
            {
                Notify("A data inicial deve ser maior que a data final");
                return false;
            }

            await _reportRepository.Add(report);
            return true;
        }

        public async Task<bool> Update(Report report)
        {
            if (!ExecuteValidation(new ReportValidation(), report)) return false;

            if (DateTime.Compare(report.InitialDate, report.FinalDate) <= 0)
            {
                Notify("A data inicial deve ser maior que a data final");
                return false;
            }

            await _reportRepository.Update(report);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            await _reportRepository.Remove(id);
            return true;
        }
        public void Dispose()
        {
            _reportRepository?.Dispose();
        }

    }
}
