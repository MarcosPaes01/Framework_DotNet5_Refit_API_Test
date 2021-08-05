namespace Super.GlobalPlatform.Regression.Api.Setup
{
    public enum EEnvironment { Dev, PreProd, Prod };

    public class TestSettings
    {
        public EEnvironment SelectedEnvironment { get; set; }
        public Environments Environments { get; set; }
    }

    public class Environments
    {
        public SettingsChild PreProd { get; set; }
        public SettingsChild Dev { get; set; }
    }

    public class SettingsChild
    {
        public string InternalTransferUrl { get; set; }
        public string RechargeTransportUrl { get; set; }
        public string RechargeMobileUrl { get; set; }
    }
}
