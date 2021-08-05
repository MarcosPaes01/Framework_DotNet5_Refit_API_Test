using NUnit.Framework;

using Super.GlobalPlatform.Regression.Api.ApiClients.Requests;
using Super.GlobalPlatform.Regression.Api.Services;
using Super.GlobalPlatform.Regression.Api.Setup;

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

using static Super.GlobalPlatform.Regression.Api.ApiClients.ResponseApiClient;
using static Super.GlobalPlatform.Regression.Api.Setup.Startup;


namespace Super.GlobalPlatform.Regression.Api.Tests
{
    [TestFixture]
    public class InternalTransferTest : TestHost<IntegratedTests>
    {
        private readonly TransactionService service;
        public string currency = "ARS";
        public InternalTransferTest()
        {
            service = GetService<TransactionService>();
        }

        [TestCase(TestName = "HappyPath_InternalTransfer_OneReceiver")]
        public async Task HappyPath_InternalTransfer_OneReceiver()
        {

            var internalTransferRequestBody = GenerateBodyInternalTranfer(currency);
            var (statusInternalTransfer, responseInternalTransfer) = await service.RunIncomingDomesticTransfer(internalTransferRequestBody);
            Assert.AreEqual(HttpStatusCode.OK, statusInternalTransfer);
            Assert.AreEqual(responseInternalTransfer, null);
        }

        [TestCase(TestName = "HappyPath_InternalTransfer_TwoReceivers")]
        public async Task HappyPath_InternalTransfer_TwoReceivers()
        {

            var internalTransferRequestBody = GenerateBodyInternalTranfer(currency);
            internalTransferRequestBody.Receivers[0] = new TurnoverPart
            {
                OperationNumber = "1",
                AccountNrType = "1",
                BankKey = "1",
                AccountNumber = "TRX_AR_S",
                OperationAmount = new Amount_Type
                {
                    Currency = currency,
                    Amount = "200.00"
                },
                AccountAmount = new Amount_Type
                {
                    Currency = currency,
                    Amount = "200.00"
                },
                CompensationAmount = new Amount_Type
                {
                    Currency = currency,
                    Amount = "200.00"
                },
                ExchangeRate = "1.00",
                ExchangeRateCompensation = "1.00",
                CurrencyPairOriginalAccountCurrency = currency + "/" + currency,
                CurrencyPairCompensationAccountCurrency = currency + "/" + currency,
                IndicatorCreditOperation = true,
                OperationNote = null
            };

            var (statusInternalTransfer, responseInternalTransfer) = await service.RunIncomingDomesticTransfer(internalTransferRequestBody);
            Assert.AreEqual(HttpStatusCode.UnprocessableEntity, statusInternalTransfer);
        }

        [TestCase(TestName = "AlternativePath_SameAccountInTransaction")]
        public async Task AlternativePath_SameAccountInTransaction()
        {
            var internalTransferRequestBody = GenerateBodyInternalTranfer(currency);
            internalTransferRequestBody.Receivers[0].AccountNumber = internalTransferRequestBody.Initiator.AccountNumber;

            var (statusInternalTransfer, responseInternalTransfer) = await service.RunIncomingDomesticTransfer(internalTransferRequestBody);
            Assert.AreEqual(HttpStatusCode.BadRequest, statusInternalTransfer);
            Assert.AreEqual(responseInternalTransfer, null);
        }

        [TestCase(TestName = "AlternativePath_DifferentValuesInInitiatorAnReceiver")]
        public async Task AlternativePath_DifferentValuesInInitiatorAndReceiver()
        {
            var internalTransferRequestBody = GenerateBodyInternalTranfer(currency);
            internalTransferRequestBody.Receivers[0].OperationAmount.Amount = "1.00";

            var (statusInternalTransfer, responseInternalTransfer) = await service.RunIncomingDomesticTransfer(internalTransferRequestBody);
            Assert.AreEqual(HttpStatusCode.UnprocessableEntity, statusInternalTransfer);
        }

        [TestCase(TestName = "AlternativePath_AccountInvalidInInitiator")]
        public async Task AlternativePath_AccountInvalid()
        {
            var internalTransferRequestBody = GenerateBodyInternalTranfer(currency);
            internalTransferRequestBody.Initiator.AccountNumber = "4546";

            var (statusInternalTransfer, responseInternalTransfer) = await service.RunIncomingDomesticTransfer(internalTransferRequestBody);

            Assert.AreEqual(HttpStatusCode.UnprocessableEntity, statusInternalTransfer);

            var sucessResponse = responseInternalTransfer as Response_Failure;

        }

        [TestCase(TestName = "AlternativePath_AccountInvalidInReceiver")]
        public async Task AlternativePath_AccountInvalidInReceiver()
        {
            var internalTransferRequestBody = GenerateBodyInternalTranfer(currency);
            internalTransferRequestBody.Receivers[0].AccountNumber = "4546";

            var (statusInternalTransfer, responseInternalTransfer) = await service.RunIncomingDomesticTransfer(internalTransferRequestBody);
            Assert.AreEqual(HttpStatusCode.UnprocessableEntity, statusInternalTransfer);
        }

        [TestCase(TestName = "AlternativePath_BusinessOperationNotExists")]
        public async Task AlternativePath_BusinessOperationNotExists()
        {
            var internalTransferRequestBody = GenerateBodyInternalTranfer(currency);
            internalTransferRequestBody.BusinessOperation = "123456";

            var (statusInternalTransfer, responseInternalTransfer) = await service.RunIncomingDomesticTransfer(internalTransferRequestBody);

            Assert.AreEqual(HttpStatusCode.UnprocessableEntity, statusInternalTransfer);
        }

        [TestCase(TestName = "AlternativePath_NegativeTransactedAmount")]
        public async Task AlternativePath_NegativeTransactedAmount()
        {
            var internalTransferRequestBody = GenerateBodyInternalTranfer(currency);
            internalTransferRequestBody.Initiator.OperationAmount.Amount = "-1.00";
            internalTransferRequestBody.Initiator.AccountAmount.Amount = "-1.00";
            internalTransferRequestBody.Initiator.CompensationAmount.Amount = "-1.00";

            var (statusInternalTransfer, responseInternalTransfer) = await service.RunIncomingDomesticTransfer(internalTransferRequestBody);

            Assert.AreEqual(HttpStatusCode.BadRequest, statusInternalTransfer);
        }

        [TestCase(TestName = "AlternativePath_ReceiverIsSystemicAccount")]
        public async Task AlternativePath_ReceiverIsSystemicAccount()
        {
            var internalTransferRequestBody = GenerateBodyInternalTranfer(currency);
            internalTransferRequestBody.Receivers[0].AccountNumber = "TRX_AR_S";

            var (statusInternalTransfer, responseInternalTransfer) = await service.RunIncomingDomesticTransfer(internalTransferRequestBody);

            Assert.AreEqual(HttpStatusCode.UnprocessableEntity, statusInternalTransfer);
        }

        public TransacionsRequest GenerateBodyInternalTranfer(string currency)
        {
            return new TransacionsRequest
            {
                SimulationMode = true,
                Channel = "2",
                BusinessOperation = "90036",
                CommentOnTurnover = "IntegrationTests_Transactions",
                BusinessUnit = "2",
                ExternalOperationReferenceNumber = "1",
                ExternalPrenoteReferenceNumber = null,
                Initiator = new TurnoverPart
                {
                    OperationNumber = "1",
                    AccountNrType = "1",
                    BankKey = "1",
                    AccountNumber = "TRX_AR_C",
                    OperationAmount = new Amount_Type
                    {
                        Currency = currency,
                        Amount = "200.00"
                    },
                    AccountAmount = new Amount_Type
                    {
                        Currency = currency,
                        Amount = "200.00"
                    },
                    CompensationAmount = new Amount_Type
                    {
                        Currency = currency,
                        Amount = "200.00"
                    },
                    ExchangeRate = "1.00",
                    ExchangeRateCompensation = "1.00",
                    CurrencyPairOriginalAccountCurrency = currency + "/" + currency,
                    CurrencyPairCompensationAccountCurrency = currency + "/" + currency,
                    IndicatorCreditOperation = false,
                    OperationNote = null
                },
                Receivers = new List<TurnoverPart>
                {
                    new TurnoverPart
                    {
                        OperationNumber = "1",
                        AccountNrType = "1",
                        BankKey = "1",
                        AccountNumber = "TRX_AR_S",
                        OperationAmount = new Amount_Type
                        {
                            Currency = currency,
                            Amount = "200.00"
                        },
                        AccountAmount = new Amount_Type
                        {
                            Currency = currency,
                            Amount = "200.00"
                        },
                        CompensationAmount = new Amount_Type
                        {
                            Currency = currency,
                            Amount = "200.00"
                        },
                        ExchangeRate = "1.00",
                        ExchangeRateCompensation = "1.00",
                        CurrencyPairOriginalAccountCurrency = currency + "/" + currency,
                        CurrencyPairCompensationAccountCurrency = currency + "/" + currency,
                        IndicatorCreditOperation = true,
                        OperationNote = null
                    }
                }
            };
        }
    }
}

