using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebCultureInGdansk.Dtos;

namespace Common.Interfaces
{
    public interface IReportModuleService
    {
        Task PostReport(ReportDto reportDto);
        Task<IEnumerable<ReportDto>> GetReports();
    }
}
