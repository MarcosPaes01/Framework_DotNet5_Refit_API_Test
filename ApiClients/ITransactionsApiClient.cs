using Refit;

using Super.GlobalPlatform.Regression.Api.ApiClients.Requests;

using System.Net.Http;
using System.Threading.Tasks;

namespace Super.GlobalPlatform.Regression.Api.ApiClients
{

    public interface ITransactionsApiClient
    {
        [Headers("Cookie: 01a26ebae7eeb2bb16bb971adc7006e1=cf8eb6df13584c1017314eb1aaacabb8", "Content-Type: application/json")]
        [Post("/run-internal-transfer")]
        public Task<HttpResponseMessage> RunInternalTransfer([Body] TransacionsRequest request);

        [Headers("Cookie: 01a26ebae7eeb2bb16bb971adc7006e1=cf8eb6df13584c1017314eb1aaacabb8", "Content-Type: application/json")]
        [Post("/run-outgoing-domestic-payment")]
        public Task<HttpResponseMessage> RunOutgoingDomesticPayment([Body] TransacionsRequest request);
    }

    public class InternalTransferResponse_Success
    {
        public string Country { get; set; }

    }
    public class OutgoingDomesticPaymentResponse_Success
    {
        public string Country { get; set; }

    }
}


