using Microsoft.AspNetCore.Mvc;

namespace WebRong.Controllers
{
    public class UserController : Controller
    {
        public UserController() {

        }
        public ActionResult Index() { return View(); }
    }
}
