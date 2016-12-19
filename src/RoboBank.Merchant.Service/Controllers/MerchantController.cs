using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using RoboBank.Merchant.Application;
using RoboBank.Merchant.Service.Custom;
using RoboBank.Merchant.Service.Models;

namespace RoboBank.Merchant.Service.Controllers
{
    [AIGenericExceptionHandling]
    public class MerchantController : ApiController
    {
        private readonly MerchantApplicationService _merchantApplicationService;

        public MerchantController(MerchantApplicationService merchantApplicationService)
        {
            _merchantApplicationService = merchantApplicationService;
        }

        [Route("merchants/websites/{websiteKey}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetMerchantWebsiteAsync(string websiteKey)
        {
            var merchantWebsiteInfo = await _merchantApplicationService.GetMerchantWebsiteAsync(websiteKey);

            if (merchantWebsiteInfo != null)
            {
                return Ok(Mapper.Map<MerchantWebsiteInfo, MerchantWebsiteModel>(merchantWebsiteInfo));
            }

            return NotFound();
        }

        [Route("merchants/websites")]
        [HttpPost]
        public async Task<IHttpActionResult> AddMerchantWebsiteAsync(MerchantWebsiteModel websiteModel)
        {
            var websiteInfo = Mapper.Map<MerchantWebsiteModel, MerchantWebsiteInfo>(websiteModel);
            await _merchantApplicationService.AddMerchantWebsiteAsync(websiteInfo);

            return Ok();
        }
    }
}
