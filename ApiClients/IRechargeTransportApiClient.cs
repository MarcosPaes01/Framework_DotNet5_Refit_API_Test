using Refit;

using Super.GlobalPlatform.Regression.Api.ApiClients.Requests;

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Super.GlobalPlatform.Regression.Api.ApiClients
{
    public interface IRechargeTransportApiClient
    {
        [Headers("Content-Type: application/json", "Content-Type: application/x-www-form-urlencoded", "pCHANNEL: CLIENT CHANNEL", "")]
        [Post("/own-channels/service-payment/agreement/7FADDDED-63F0-443E-828F-137AA0CA431A/regular-payment")]
        public Task<HttpResponseMessage> RunRechargeTransport([Body] RechargeTransportRequest request);


        [Headers("Content-Type: application/json", "Content-Type: application/x-www-form-urlencoded", "pCHANNEL: CLIENT CHANNEL", "")]
        [Post("/own-channels/service-payment/agreement/7FADDDED-63F0-443E-828F-137AA0CA431A/regular-payment")]
        public Task<HttpResponseMessage> RunRechargesMobile([Body] RechargeMobileRequest request);
    }

    public class RechargeTransport_ResponseSuccess
    {

    }

    public class RechargeMobile_ResponseSuccess
    {

    }

    public class RechargeMobile_ResponseFailure
    {
    }


    public class RechargeTransport_ResponseFailure
    {
        public string MessageRS { get; set; }
        public List<Response> Responses { get; set; }
        public Header HeaderrRs { get; set; }
        public Status StatusRS { get; set; }

        public class Response
        {
        }

        public class Header
        {
            public string MsgId { get; set; }
            public string MsgIdOrg { get; set; }
            public string Timestamp { get; set; }
        }

        public class Status
        {
            public string Code { get; set; }
            public string Description { get; set; }
        }
    }
}

