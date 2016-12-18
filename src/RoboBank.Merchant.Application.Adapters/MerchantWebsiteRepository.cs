using System.Threading.Tasks;
using Newtonsoft.Json;
using RoboBank.Merchant.Application.Ports;
using RoboBank.Merchant.Domain;
using StackExchange.Redis;

namespace RoboBank.Merchant.Application.Adapters
{
    public class MerchantWebsiteRepository : IMerchantWebsiteRepository
    {
        private readonly ConnectionMultiplexer _connectionMultiplexer;

        public MerchantWebsiteRepository(ConnectionMultiplexer connectionMultiplexer)
        {
            _connectionMultiplexer = connectionMultiplexer;
        }

        public async Task<MerchantWebsite> GetByWebsiteKeyAsync(string websiteKey)
        {
            var database = _connectionMultiplexer.GetDatabase();
            var merchantWebsiteData = await database.StringGetAsync(websiteKey);
            return JsonConvert.DeserializeObject<MerchantWebsite>(merchantWebsiteData);
        }

        public async Task AddAsync(MerchantWebsite website)
        {
            var database = _connectionMultiplexer.GetDatabase();
            var merchantWebsiteData = JsonConvert.SerializeObject(website);
            await database.StringSetAsync(website.WebsiteKey, merchantWebsiteData);
        }
    }
}
