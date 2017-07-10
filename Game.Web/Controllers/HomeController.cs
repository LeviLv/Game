using System.Web.Mvc;

namespace Game.Web.Controllers
{
    public class HomeController : GameControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}