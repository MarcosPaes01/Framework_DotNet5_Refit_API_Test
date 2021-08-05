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
    public class RechargeTransportTest : TestHost<IntegratedTests>
    {
        private readonly RechargeService service;

        public RechargeTransportTest()
        {
            service = GetService<RechargeService>();
        }

        [TestCase]
        public async Task HappyPath_RechargeTransport()
        {
            var dataRecTransport = Resource.GetRechargeTransportData();

            var rechargeRequestBody = GenerateBodyRechargeTransport(dataRecTransport[0].Person, dataRecTransport[0].AccountId);

            var (status, response) = await service.RunRechargeTransport(rechargeRequestBody);

            Assert.AreEqual(HttpStatusCode.OK, status);
            Assert.AreNotEqual(response, null);
        }

        [TestCase]
        public async Task AlternativePath_AccountNotExists()
        {
            var dataRecTransport = Resource.GetRechargeTransportData();
            dataRecTransport[0].AccountId = "123465798";

            var rechargeRequestBody = GenerateBodyRechargeTransport(dataRecTransport[0].Person, dataRecTransport[0].AccountId);

            var (status, response) = await service.RunRechargeTransport(rechargeRequestBody);

            Assert.AreEqual(HttpStatusCode.BadRequest, status);
            Assert.AreNotEqual(response, null);
        }

        [TestCase]
        public async Task AlternativePath_TransportDataNotExists()
        {
            var dataRecTransport = Resource.GetRechargeTransportData();

            var rechargeRequestBody = GenerateBodyRechargeTransport(dataRecTransport[0].Person, dataRecTransport[0].AccountId);

            var (status, response) = await service.RunRechargeTransport(rechargeRequestBody);

            Assert.AreEqual(HttpStatusCode.BadRequest, status);
            Assert.AreNotEqual(response, null);
        }


        [TestCase]
        public async Task AlternativePath_DeleteCard()
        {
            var dataRecTransport = Resource.GetRechargeTransportData();

            var rechargeRequestBody = GenerateBodyRechargeTransport(dataRecTransport[0].Person, dataRecTransport[0].AccountId);

            var (status, response) = await service.RunRechargeTransport(rechargeRequestBody);

            Assert.AreEqual(HttpStatusCode.BadRequest, status);
            Assert.AreNotEqual(response, null);
        }

        [TestCase]
        public async Task AlternativePath_UpdateCardNameById()
        {
            var dataRecTransport = Resource.GetRechargeTransportData();

            var rechargeRequestBody = GenerateBodyRechargeTransport(dataRecTransport[0].Person, dataRecTransport[0].AccountId);

            var (status, response) = await service.RunRechargeTransport(rechargeRequestBody);

            Assert.AreEqual(HttpStatusCode.BadRequest, status);
            Assert.AreNotEqual(response, null);
        }



        private RechargeTransportRequest GenerateBodyRechargeTransport(string personId, string accountId)
        {
            return new RechargeTransportRequest
            {
                HeaderRQ = new HeaderRQ
                {
                    MsgId = "",
                    Timestamp = ""
                },

                SecurityRQ =
                {
                    UserId = personId,
                    HostId = "" ,
                    ChannelId = "",
                    Profile = ""
                },
                MessageRQ = new MessageRQ
                {
                    DigitalService = "",
                    ServicePaymentId = "",
                    Amount = "",
                    Currency = "",
                    PaymentMethod = new PaymentMethod
                    {
                        MethodInformation = new MethodInformation
                        {
                            Account = new Account
                            {
                                LegacyId = new LegacyId
                                {
                                    BranchId = "",
                                    AccountType = "",
                                    AccountNumber = "",
                                    TokenizedAccount = ""
                                },
                                OthersId = new OthersId
                                {
                                    IdentificationType = "SDGUID",
                                    IdentificationId = accountId,
                                    TokenizedAccount = ""
                                }

                            }
                        },
                        ServicePaymentFields = new ServicePaymentFields
                        {
                            IDC = "6061268880223082"
                        }
                    }
                }
            };
        }
    }
}

