using Super.GlobalPlatform.Regression.Api.ApiClients;
using Super.GlobalPlatform.Regression.Api.ApiClients.Requests;
using Super.GlobalPlatform.Regression.Api.Util;

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using static Super.GlobalPlatform.Regression.Api.ApiClients.ResponseApiClient;

namespace Super.GlobalPlatform.Regression.Api.Services
{
    public class TransactionService
    {
        private readonly ITransactionsApiClient apiClient;
        private readonly ReportService reportService;
        private readonly Serialize serialize;

        public TransactionService(ITransactionsApiClient client)
        {
            apiClient = client;
            reportService = new ReportService();
        }

        public async Task<(HttpStatusCode Status, object Response)> RunIncomingDomesticTransfer(TransacionsRequest request)
        {
            var httpResponse = await apiClient.RunInternalTransfer(request);


            if (httpResponse.IsSuccessStatusCode)
            {
                var response = await httpResponse.Content.ReadAsAsync<InternalTransferResponse_Success>();
                await reportService.GenerateReportAsync(serialize.SerializeIndented(request), serialize.SerializeIndented(response), httpResponse.StatusCode, httpResponse.RequestMessage.RequestUri.AbsoluteUri, httpResponse.RequestMessage.Method.Method);
                return (httpResponse.StatusCode, response);
            }
            else
            {
                var response = await httpResponse.Content.ReadAsAsync<Response_Failure>();
                await reportService.GenerateReportAsync(serialize.SerializeIndented(request), serialize.SerializeIndented(response), httpResponse.StatusCode, httpResponse.RequestMessage.RequestUri.AbsoluteUri, httpResponse.RequestMessage.Method.Method);
                return (httpResponse.StatusCode, response);
            }
        }

        public async Task<(HttpStatusCode Status, object Response)> RunOutgoingDomesticPayment(TransacionsRequest request)
        {
            var httpResponse = await apiClient.RunOutgoingDomesticPayment(request);


            if (httpResponse.IsSuccessStatusCode)
            {
                var response = await httpResponse.Content.ReadAsAsync<InternalTransferResponse_Success>();
                await reportService.GenerateReportAsync(serialize.SerializeIndented(request), serialize.SerializeIndented(response), httpResponse.StatusCode, httpResponse.RequestMessage.RequestUri.AbsoluteUri, httpResponse.RequestMessage.Method.Method);
                return (httpResponse.StatusCode, response);
            }
            else
            {
                var response = await httpResponse.Content.ReadAsAsync<Response_Failure>();
                await reportService.GenerateReportAsync(serialize.SerializeIndented(request), serialize.SerializeIndented(response), httpResponse.StatusCode, httpResponse.RequestMessage.RequestUri.AbsoluteUri, httpResponse.RequestMessage.Method.Method);
                return (httpResponse.StatusCode, response);
            }
        }
    }
}
