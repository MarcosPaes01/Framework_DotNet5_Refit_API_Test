namespace Super.GlobalPlatform.Regression.Api.ApiClients.Requests
{
    public class RechargeTransportRequest
    {
        public HeaderRQ HeaderRQ { get; set; }
        public SecurityRQ SecurityRQ { get; set; }
        public MessageRQ MessageRQ { get; set; }
    }
    public class HeaderRQ
    {
        public string MsgId { get; set; }
        public string Timestamp { get; set; }
    }

    public class SecurityRQ
    {
        public string UserId { get; set; }
        public string HostId { get; set; }
        public string ChannelId { get; set; }
        public string Profile { get; set; }
    }

    public class LegacyId
    {
        public string BranchId { get; set; }
        public string AccountType { get; set; }
        public string AccountNumber { get; set; }
        public string TokenizedAccount { get; set; }
    }

    public class OthersId
    {
        public string IdentificationType { get; set; }
        public string IdentificationId { get; set; }
        public string TokenizedAccount { get; set; }
    }

    public class Account
    {
        public LegacyId LegacyId { get; set; }
        public OthersId OthersId { get; set; }
    }

    public class MethodInformation
    {
        public Account Account { get; set; }
    }

    public class ServicePaymentFields
    {
        public string IDC { get; set; }
    }

    public class PaymentMethod
    {
        public string Type { get; set; }
        public MethodInformation MethodInformation { get; set; }
        public ServicePaymentFields ServicePaymentFields { get; set; }
    }

    public class MessageRQ
    {
        public string DigitalService { get; set; }
        public string ServicePaymentId { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
