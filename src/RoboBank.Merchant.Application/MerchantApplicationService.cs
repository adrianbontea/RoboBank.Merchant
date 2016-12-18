using System.Threading.Tasks;
using RoboBank.Merchant.Application.Ports;

namespace RoboBank.Merchant.Application
{
    public class MerchantApplicationService
    {
        private readonly IMerchantWebsiteRepository _merchantWebsiteRepository;
        private readonly IMapper _mapper;

        public MerchantApplicationService(IMerchantWebsiteRepository merchantWebsiteRepository, IMapper mapper)
        {
            _merchantWebsiteRepository = merchantWebsiteRepository;
            _mapper = mapper;
        }

        public async Task<MerchantWebsiteInfo> GetMerchantWebsiteAsync(string websiteKey)
        {
            var merchantWebsite = await _merchantWebsiteRepository.GetByWebsiteKeyAsync(websiteKey);
            return _mapper.Map<Domain.MerchantWebsite, MerchantWebsiteInfo>(merchantWebsite);
        }

        public async Task AddMerchantWebsiteAsync(MerchantWebsiteInfo websiteInfo)
        {
            var merchantWebsite = _mapper.Map<MerchantWebsiteInfo, Domain.MerchantWebsite>(websiteInfo);
            await _merchantWebsiteRepository.AddAsync(merchantWebsite);
        }
    }
}
