using System;

namespace Super.GlobalPlatform.Regression.Api.Util.DataGenerator
{
    public static class DocumentGenerator
    {
        public static string BrazilianDocument()
        {
            int sum = 0;
            int[] multiplierA = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplierB = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rnd = new Random();
            string seed = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                sum += int.Parse(seed[i].ToString()) * multiplierA[i];

            int mod = sum % 11;
            if (mod < 2)
                mod = 0;
            else
                mod = 11 - mod;

            seed += mod;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(seed[i].ToString()) * multiplierB[i];

            mod = sum % 11;

            if (mod < 2)
                mod = 0;
            else
                mod = 11 - mod;

            seed += mod;
            return seed.Replace(".", "").Replace("-", "");
        }
    }
}
