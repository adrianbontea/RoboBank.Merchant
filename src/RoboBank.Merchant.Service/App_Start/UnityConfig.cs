using System;
using System.Configuration;
using Microsoft.Practices.Unity;
using RoboBank.Merchant.Application.Adapters;
using RoboBank.Merchant.Application.Ports;
using StackExchange.Redis;

namespace RoboBank.Merchant.Service
{
    public static class UnityConfig
    {
        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return Container.Value;
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IMerchantWebsiteRepository, MerchantWebsiteRepository>();
            container.RegisterType<IMapper, Mapper>();

            var redisConnectionString = ConfigurationManager.AppSettings["RedisConnectionString"];
            var connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionString);
            container.RegisterInstance(connectionMultiplexer);
        }
    }
}