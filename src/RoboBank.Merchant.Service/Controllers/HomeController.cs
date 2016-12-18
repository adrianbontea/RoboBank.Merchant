using System.Web.Mvc;

namespace RoboBank.Merchant.Service.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return new RedirectResult("~/swagger/ui/index");
        }
    }
}
