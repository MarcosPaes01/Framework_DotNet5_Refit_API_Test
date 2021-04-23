using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Super.EWalletCore.PersonDataManagement.Application.IntegratedTests.ApiClient;

using System;

namespace Super.EWalletCore.PersonDataManagement.Application.IntegratedTests.Setup
{
    public class IntegratedTestsStartup : TestHost
    {
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<PersonService>();

            var settings = configuration.GetSection(nameof(TestSettings)).Get<TestSettings>();

            var embossingUrl = settings.SelectedEnvironment switch
            {
                EEnvironment.Dev => settings.Environments.Dev.EmbossingUrl,
                EEnvironment.Qa => settings.Environments.Qa.EmbossingUrl,
                _ => throw new NotImplementedException()
            };

            services.AddRefitClient<IPersonClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(embossingUrl));

        }
    }
}

