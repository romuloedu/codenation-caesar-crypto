using System;
using Codenation.CaesarCrypto.ConsoleApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Codenation.CaesarCrypto.ConsoleApp
{
    public static class ServiceProviderBuilder
    {
        public static IServiceProvider GetServiceProvider()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables()
                .AddUserSecrets(typeof(Program).Assembly)
                .Build();

            var services = new ServiceCollection();

            services.Configure<CodenationSecrets>(configuration
                .GetSection("CodenationSecrets"));

            var provider = services.BuildServiceProvider();

            return provider;
        }
    }
}