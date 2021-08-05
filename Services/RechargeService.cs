using Super.GlobalPlatform.Regression.Api.ApiClients;
using Super.GlobalPlatform.Regression.Api.ApiClients.Requests;
using Super.GlobalPlatform.Regression.Api.Util;

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Super.GlobalPlatform.Regression.Api.Services
{
    public class RechargeService
    {
        private readonly IRechargeTransportApiClient apiClient;
        private readonly ReportService reportService;
        private readonly Serialize serialize;

        public RechargeService(IRechargeTransportApiClient client)
        {
            apiClient = client;
            reportService = new ReportService();
        }

        public async Task<(HttpStatusCode Status, object Response)> RunRechargeTransport(RechargeTransportRequest request)
        {
            var httpResponse = await apiClient.RunRechargeTransport(request);


            if (httpResponse.IsSuccessStatusCode)
            {
                var response = await httpResponse.Content.ReadAsAsync<RechargeMobile_ResponseSuccess>();
                await reportService.GenerateReportAsync(serialize.SerializeIndented(request), serialize.SerializeIndented(response), httpResponse.StatusCode, httpResponse.RequestMessage.RequestUri.AbsoluteUri, httpResponse.RequestMessage.Method.Method);
                return (httpResponse.StatusCode, response);
            }
            else
            {
                var response = await httpResponse.Content.ReadAsAsync<RechargeTransport_ResponseFailure>();
                await reportService.GenerateReportAsync(serialize.SerializeIndented(request), serialize.SerializeIndented(response), httpResponse.StatusCode, httpResponse.RequestMessage.RequestUri.AbsoluteUri, httpResponse.RequestMessage.Method.Method);
                return (httpResponse.StatusCode, response);
            }
        }

        public async Task<(HttpStatusCode Status, object Response)> RunRechargeMobile(RechargeMobileRequest request)
        {
            var httpResponse = await apiClient.RunRechargesMobile(request);


            if (httpResponse.IsSuccessStatusCode)
            {
                var response = await httpResponse.Content.ReadAsAsync<RechargeTransport_ResponseSuccess>();
                await reportService.GenerateReportAsync(serialize.SerializeIndented(request), serialize.SerializeIndented(response), httpResponse.StatusCode, httpResponse.RequestMessage.RequestUri.AbsoluteUri, httpResponse.RequestMessage.Method.Method);
                return (httpResponse.StatusCode, response);
            }
            else
            {
                var response = await httpResponse.Content.ReadAsAsync<RechargeTransport_ResponseFailure>();
                await reportService.GenerateReportAsync(serialize.SerializeIndented(request), serialize.SerializeIndented(response), httpResponse.StatusCode, httpResponse.RequestMessage.RequestUri.AbsoluteUri, httpResponse.RequestMessage.Method.Method);
                return (httpResponse.StatusCode, response);
            }
        }
    }
}
