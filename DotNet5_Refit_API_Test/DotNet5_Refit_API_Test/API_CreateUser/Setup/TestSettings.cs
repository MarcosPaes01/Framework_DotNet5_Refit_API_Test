namespace Super.EWalletCore.PersonDataManagement.Application.IntegratedTests.Setup
{
    public enum EEnvironment { Qa, Dev, PreProd, Prod };

    public class TestSettings
    {
        public EEnvironment SelectedEnvironment { get; set; }
        public Environments Environments { get; set; }
    }

    public class Environments
    {
        public SettingsChild Qa { get; set; }
        public SettingsChild Dev { get; set; }
    }

    public class SettingsChild
    {
        public string QaLakeUrl { get; set; }
        public string EmbossingUrl { get; set; }
    }
}

