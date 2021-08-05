using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Super.GlobalPlatform.Regression.Api.Util.Resource
{
    public class Resource
    {
        public static List<RechargeTransportArg> GetRechargeTransportData()
        {
            var json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"account.json");
            var js = new DataContractJsonSerializer(typeof(List<RechargeTransportArg>));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var dadosTransporte = (List<RechargeTransportArg>)js.ReadObject(ms);

            return dadosTransporte;
        }

        public static List<RechargeMobileArg> GetRechargePhoneData()
        {
            var json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"account.json");
            var js = new DataContractJsonSerializer(typeof(List<RechargeMobileArg>));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var dadosMobile = (List<RechargeMobileArg>)js.ReadObject(ms);

            return dadosMobile;
        }

        public class RechargeTransportArg
        {
            public string Country { get; set; }
            public string ServiceName { get; set; }
            public string Person { get; set; }
            public string AccountId { get; set; }
        }

        public class RechargeMobileArg
        {

        }
    }
}
