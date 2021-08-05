using NUnit.Framework;

using Super.GlobalPlatform.Regression.Api.ApiClients.Requests;
using Super.GlobalPlatform.Regression.Api.Services;
using Super.GlobalPlatform.Regression.Api.Setup;
using Super.GlobalPlatform.Regression.Api.Util.Resource;

using System.Net;
using System.Threading.Tasks;

using static Super.GlobalPlatform.Regression.Api.Setup.Startup;

namespace Super.GlobalPlatform.Regression.Api.Tests
{

    [TestFixture]
    public class RechargePhoneTest : TestHost<IntegratedTests>
    {
        private readonly RechargeService service;

        public RechargePhoneTest()
        {
            service = GetService<RechargeService>();
        }

        [TestCase]
        public async Task HappyPath_RechargePhone()
        {
            var dataRecTransport = Resource.GetRechargePhoneData();

            var rechargeRequestBody = GenerateBodyRechargeTransport();

            var (status, response) = await service.RunRechargeMobile(rechargeRequestBody);

            Assert.AreEqual(HttpStatusCode.OK, status);
            Assert.AreNotEqual(response, null);
        }

        public RechargeMobileRequest GenerateBodyRechargeTransport()
        {
            throw new System.NotImplementedException();
        }
    }

}
