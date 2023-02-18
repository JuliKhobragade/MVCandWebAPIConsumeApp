using Microsoft.AspNetCore.Mvc;
using MVCnWEBAPI.Models;
using Newtonsoft.Json;
using System.Text;

namespace MVCnWEBAPI.Controllers
{
    public class TokenController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        // [HttpPost]
        public async Task<IActionResult> LoginUser(EmpInfo user)
        {
            using (var httpclinet = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                using (var response = await httpclinet.PostAsync("https://localhost:7191/api/token/", stringContent))
                {
                    string token = await response.Content.ReadAsStringAsync();
                    if (token == "Invalid Credentials")
                    {
                        ViewBag.Message = "Incorrect Email or Password";
                        return Redirect("~/Token/Index");

                    }
                    HttpContext.Session.SetString("JWToken", token);
                }
                return Redirect("~/Home/Index");


            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Token/Index");
        }

    }
}
