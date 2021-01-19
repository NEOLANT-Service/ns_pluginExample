using System;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NsPluginExample.Application.Services;
using NsPluginExample.DAL.Contexts;
using NsPluginExample.DAL.UnitOfWorks;
using NsPluginExample.Domain.Contracts.Services;
using NsPluginExample.Domain.Contracts.UnitOfWorks;
using NsPluginExample.Domain.Models.NsModels.OAuth;
using NsPluginExample.Models.Configuration;
using NsPluginExample.Services;

namespace NsPluginExample
{
    public partial class Startup
    {
        private void ConstructCompositionRoot(IServiceCollection services, IConfiguration configuration)
        {
            //DbContexts
            services.AddDbContext<NsPluginExampleContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("ExampleContext"), sqlOptions =>
                {
                    sqlOptions.CommandTimeout(300000);
                    sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                }));

            //Unit of works
            services.AddScoped<INsPluginExampleUnitOfWork, NsPluginExampleUnitOfWork>();

            //Services
            services.AddSingleton<IAppConfigurationService>(x =>
            {
                AppConfiguration config = new AppConfiguration();
                Configuration.Bind(config);
                return new AppConfigurationService(config);
            });
            services.AddScoped<INsModelsService>(x =>
            {
                var config = x.GetRequiredService<IAppConfigurationService>().Configuration;
                return new NsModelsService(x.GetRequiredService<INeosyntezClient>(), x.GetRequiredService<INsFileContentsService>(), config.NeosyntezClient.Instance);
            });
            services.AddScoped<INsObjectsService>(x =>
            {
                var config = x.GetRequiredService<IAppConfigurationService>().Configuration;
                return new NsObjectsService(x.GetRequiredService<INeosyntezClient>(), config.NeosyntezClient.Instance);
            });
            services.AddScoped<INsPanoramsService>(x =>
            {
                var config = x.GetRequiredService<IAppConfigurationService>().Configuration;
                return new NsPanoramsService(x.GetRequiredService<INeosyntezClient>(), config.NeosyntezClient.Instance);
            });
            services.AddScoped<INsFileContentsService>(x =>
            {
                var config = x.GetRequiredService<IAppConfigurationService>().Configuration;
                return new NsFileContentsService(x.GetRequiredService<INeosyntezClient>(), config.NeosyntezClient.Instance);
            });


            services.AddSingleton(x =>
            {
                var neosintezInstance = Configuration.GetSection("NeosintezClient").GetValue("Instance", string.Empty);
                return new NsApiClient.Client(neosintezInstance, new HttpClient());
            });

            services.AddScoped<INeosyntezClient, NeosyntezClient>();
            services.AddScoped<ITokenStorage>(x =>
            {
                var configService = x.GetRequiredService<IAppConfigurationService>();
                switch (configService.Configuration.NeosyntezClient.Auth.TokenStorage)
                {
                    case TokenStorageType.Database:
                        return new TokenStorage(x.GetService<INsPluginExampleUnitOfWork>());
                    case TokenStorageType.Memory:
                        return new InMemoryTokenStorage(x.GetService<IMemoryCache>());
                    default:
                        throw new ArgumentException(nameof(configService.Configuration.NeosyntezClient.Auth.TokenStorage));
                }
            });
            services.AddScoped<Func<HttpClient, IAuthenticatorService>>(x => (httpClient) =>
            {
                httpClient.BaseAddress = new Uri(x.GetService<IAppConfigurationService>().Configuration.NeosyntezClient.Instance);
                return new AuthenticatorService(httpClient, x.GetService<OAuth2Config>());

            });

            services.AddScoped(x =>
             {
                 var configService = x.GetService<IAppConfigurationService>();
                 return new OAuth2Config()
                 {
                     ClientId = configService.Configuration.NeosyntezClient.Auth.ClientId,
                     ClientSecret = configService.Configuration.NeosyntezClient.Auth.Secret,
                     UserName = configService.Configuration.NeosyntezClient.Auth.UserName,
                     UserPassword = configService.Configuration.NeosyntezClient.Auth.Password,
                     TokenEndpoint = "/connect/token"
                 };
             });

            //Если в качестве хранилища токена безопасности используется БД то делаем миграции
            AppConfiguration result = new AppConfiguration();
            Configuration.Bind(result);
            if (result.NeosyntezClient.Auth.TokenStorage == TokenStorageType.Database)
                services.UseMigrations();
        }
    }
}
