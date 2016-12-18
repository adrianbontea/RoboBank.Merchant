using System.Threading.Tasks;
using RoboBank.Merchant.Domain;

namespace RoboBank.Merchant.Application.Ports
{
    public interface IMerchantWebsiteRepository
    {
        Task<MerchantWebsite> GetByWebsiteKeyAsync(string websiteKey);

        Task AddAsync(MerchantWebsite website);
    }
}
