using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebCultureInGdansk.Dtos;

namespace Common.Services
{
    public class ReportModuleService : IReportModuleService
    {
        private const string ReportModuleUrl = "http://localhost:5006";

        public async Task PostReport(ReportDto reportDto)
        {
            using (var client = new HttpClient())
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(reportDto));
                var response = await client.PostAsync($"{ReportModuleUrl}" + "/api/reports/" , stringContent);
                var message = await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<IEnumerable<ReportDto>> GetReports()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{ReportModuleUrl}" + "/api/reports");
                var responseJson = await response.Content.ReadAsStringAsync(); //Json
                if (!string.IsNullOrEmpty(responseJson))
                {
                    var reports = JsonConvert.DeserializeObject<IEnumerable<ReportDto>>(responseJson);
                    return reports;
                }
            }

            return null;
        }
    }
}
