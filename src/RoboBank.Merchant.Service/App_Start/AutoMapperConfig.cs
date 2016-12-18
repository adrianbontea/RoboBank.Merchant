using AutoMapper;
using RoboBank.Merchant.Application;
using RoboBank.Merchant.Domain;
using RoboBank.Merchant.Service.Models;

namespace RoboBank.Merchant.Service
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<MerchantWebsiteModel, MerchantWebsiteInfo>();
                cfg.CreateMap<MerchantWebsiteInfo, MerchantWebsiteModel>();
                cfg.CreateMap<MerchantWebsite, MerchantWebsiteInfo>();
                cfg.CreateMap<MerchantWebsiteInfo, MerchantWebsite>();
            });
        }
    }
}