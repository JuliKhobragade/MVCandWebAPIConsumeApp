using Microsoft.AspNetCore.Mvc;

namespace MVCnWEBAPI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
