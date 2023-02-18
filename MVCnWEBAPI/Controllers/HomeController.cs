using Microsoft.AspNetCore.Mvc;
using MVCnWEBAPI.Helper;
using MVCnWEBAPI.Models;
using Newtonsoft.Json;
using System.Text;

namespace MVCnWEBAPI.Controllers
{
    public class HomeController : Controller
    {
        EmployeeAPI _api = new EmployeeAPI();
        public async Task<IActionResult> Index()
        {

            var accessToken = HttpContext.Session.GetString("JWToken");
            HttpClient client = _api.Initial();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage getData = await client.GetAsync("api/employee");
            List<Employee> modelList = new List<Employee>();
            if (getData.IsSuccessStatusCode)
            {
                string results = getData.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<Employee>>(results);
            }
            return View(modelList);
        }

        public async Task<IActionResult> Details(int Id)
        {

            var accessToken = HttpContext.Session.GetString("JWToken");
            HttpClient client = _api.Initial();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage getData = await client.GetAsync($"api/employee/{Id}");
            var employee = new Employee();
            if (getData.IsSuccessStatusCode)
            {
                string results = getData.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<Employee>(results);
            }
            return View(employee);

        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            HttpClient client = _api.Initial();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var postEmployee = await client.PostAsJsonAsync<Employee>("api/employee", employee);
            //postEmployee.Wait();

            var result = postEmployee;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }
        //    [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            //var employee = new mvcEmployee();
            var accessToken = HttpContext.Session.GetString("JWToken");
            HttpClient client = _api.Initial();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            HttpResponseMessage putData = await client.GetAsync($"api/employee/{id}");
            var employee = new Employee();
            if (putData.IsSuccessStatusCode)
            {
                string results = putData.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<Employee>(results);
            }
            return View("Edit", employee);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee employee)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            HttpClient client = _api.Initial();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            var editData = await client.PutAsJsonAsync<Employee>("api/employee", employee);
            //postEmployee.Wait();

            var result = editData;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            return View();
        }

        //[HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            HttpClient client = _api.Initial();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            // HttpResponseMessage delData = await client.DeleteAsync($"DeleteEmployee?empId={Id}");
            HttpResponseMessage delData = await client.DeleteAsync($"api/employee/{Id}");
            var employee = new Employee();
            if (delData.IsSuccessStatusCode)
            {
                string results = delData.Content.ReadAsStringAsync().Result;

            }
            return RedirectToAction("Index");

        }
    }
}











