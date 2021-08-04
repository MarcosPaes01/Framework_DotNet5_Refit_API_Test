using System.Collections.Generic;

namespace Super.GlobalPlatform.Regression.Api.ApiClients.Requests
{
    public class TransacionsRequest
    {
        public bool SimulationMode { get; set; }
        public string Channel { get; set; }
        public string BusinessOperation { get; set; }
        public string CommentOnTurnover { get; set; }
        public string BusinessUnit { get; set; }
        public string ExternalOperationReferenceNumber { get; set; }
        public bool? ExternalPrenoteReferenceNumber { get; set; }
        public TurnoverPart Initiator { get; set; }
        public List<TurnoverPart> Receivers { get; set; }
    }

    public class Amount_Type
    {
        public string Currency { get; set; }
        public string Amount { get; set; }
    }

    public class TurnoverPart
    {
        public string OperationNumber { get; set; }
        public string AccountNrType { get; set; }
        public string BankKey { get; set; }
        public string AccountNumber { get; set; }
        public Amount_Type OperationAmount { get; set; }
        public Amount_Type AccountAmount { get; set; }
        public Amount_Type CompensationAmount { get; set; }
        public string ExchangeRate { get; set; }
        public string ExchangeRateCompensation { get; set; }
        public string CurrencyPairOriginalAccountCurrency { get; set; }
        public string CurrencyPairCompensationAccountCurrency { get; set; }
        public bool IndicatorCreditOperation { get; set; }
        public bool? OperationNote { get; set; }
    }
}
