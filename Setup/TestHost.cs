
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using System;
using System.IO;

namespace Super.GlobalPlatform.Regression.Api.Setup
{
    public abstract class TestStartup
    {
        public abstract void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }

    public abstract class TestHost<T> : IDisposable
        where T : TestStartup
    {
        public TestHost()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            var services = new ServiceCollection();

            services.AddSingleton(Configuration);
            services.AddLogging(opt => opt.AddConsole());

            var startup = Activator.CreateInstance<T>();

            startup.ConfigureServices(services, Configuration);

            ServiceProvider = services.BuildServiceProvider();
        }

        public IServiceProvider ServiceProvider { get; }
        public IConfiguration Configuration { get; }
        public IServiceScope Scope => ServiceProvider.CreateScope();
        public TService GetService<TService>() => Scope.ServiceProvider.GetRequiredService<TService>();

        public void Dispose()
        {
            Scope.Dispose();
        }
    }
}
