using Super.EWalletCore.PersonDataManagement.Application.IntegratedTests.ApiClient;
using Super.EWalletCore.PersonDataManagement.Application.IntegratedTests.Util;

using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Super.EWalletCore.PersonDataManagement.Application.IntegratedTests.Services
{
    public class PersonService
    {
        private readonly IPersonClient apiClient;
        private readonly ReportService reportService;

        public PersonService(IPersonClient client)
        {
            apiClient = client;
            reportService = new ReportService();
        }

        public async Task<(HttpStatusCode Status, object Response)> RunCreatePerson(CreatePersonRequest request, int country)
        {
            var httpResponse = await apiClient.RunCreatePerson(request, country);

            if (httpResponse.IsSuccessStatusCode)
            {
                var response = await httpResponse.Content.ReadAsAsync<CreatePersonResponse_Success>();
                await reportService.GenerateReportAsync(SerializeIndented(request), SerializeIndented(response), httpResponse.StatusCode, httpResponse.RequestMessage.RequestUri.AbsoluteUri, httpResponse.RequestMessage.Method.Method);
                return (httpResponse.StatusCode, response);
            }
            else
            {
                var response = await httpResponse.Content.ReadAsAsync<CreatePersonResponse_Failure>();
                await reportService.GenerateReportAsync(SerializeIndented(request), SerializeIndented(response), httpResponse.StatusCode, httpResponse.RequestMessage.RequestUri.AbsoluteUri, httpResponse.RequestMessage.Method.Method);
                return (httpResponse.StatusCode, response);
            }
        }
        private string SerializeIndented(object obj)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            return JsonSerializer.Serialize(obj, options);
        }
    }
}
