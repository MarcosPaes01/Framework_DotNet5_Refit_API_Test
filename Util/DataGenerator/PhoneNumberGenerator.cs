using System;

namespace Super.GlobalPlatform.Regression.Api.Util.DataGenerator
{
    public static class PhoneNumberGenerator
    {
        public static string BrazilianPhoneNumber()
        {
            Random rdn = new Random();
            return "55" + "11" + rdn.Next(911111111, 999999999).ToString();
        }
    }
}
