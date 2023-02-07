using Microsoft.AspNetCore.Mvc;

namespace FindoctorWeb.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult UserOrDoctor()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserRegister()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DoctorRegister()
        {
            return View();
        }


    }
}
