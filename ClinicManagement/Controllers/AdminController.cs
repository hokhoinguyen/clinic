using Microsoft.AspNetCore.Mvc;

namespace ClinicManagement.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminView()
        {
            return View();
        }
    }
}
