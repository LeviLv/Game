using System.Web.Mvc;

namespace Game.Web.Controllers
{
    public class AboutController : GameControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}