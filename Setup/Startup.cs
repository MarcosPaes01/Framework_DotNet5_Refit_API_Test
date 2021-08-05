using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Refit;

using Super.GlobalPlatform.Regression.Api.ApiClients;
using Super.GlobalPlatform.Regression.Api.Services;

using System;

namespace Super.GlobalPlatform.Regression.Api.Setup
{
    public class Startup
    {
        public class IntegratedTests : TestStartup
        {
            public override void ConfigureServices(IServiceCollection services, IConfiguration configuration)
            {
                services.AddSingleton<TransactionService>();
                services.AddSingleton<RechargeService>();


                var settings = configuration.GetSection(nameof(TestSettings)).Get<TestSettings>();

                var internalTransferUrl = settings.SelectedEnvironment switch
                {
                    EEnvironment.Dev => settings.Environments.Dev.InternalTransferUrl,
                    EEnvironment.PreProd => settings.Environments.PreProd.InternalTransferUrl,
                    _ => throw new NotImplementedException()
                };

                var rechargeTransportationUrl = settings.SelectedEnvironment switch
                {
                    EEnvironment.Dev => settings.Environments.Dev.RechargeTransportUrl,
                    EEnvironment.PreProd => settings.Environments.PreProd.RechargeTransportUrl,
                    _ => throw new NotImplementedException()
                };


                var rechargeMobileUrl = settings.SelectedEnvironment switch
                {
                    EEnvironment.Dev => settings.Environments.Dev.RechargeMobileUrl,
                    EEnvironment.PreProd => settings.Environments.PreProd.RechargeMobileUrl,
                    _ => throw new NotImplementedException()
                };

                services.Configure<TestSettings>(configuration.GetSection(nameof(TestSettings)));

                var refitSettings = new RefitSettings
                {
                    ContentSerializer = new XmlContentSerializer()
                };

                services.AddRefitClient<ITransactionsApiClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(internalTransferUrl));

                services.AddRefitClient<IRechargeTransportApiClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(rechargeTransportationUrl));

                services.AddRefitClient<IRechargeTransportApiClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(rechargeMobileUrl));
            }
        }

    }
}

