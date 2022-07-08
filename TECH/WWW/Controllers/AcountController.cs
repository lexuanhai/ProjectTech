using Domain;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WWW.Models;

namespace WWW.Controllers
{
    public class AcountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(AppUser user)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:7240/api/User/Register", stringContent))
                {
                    string jsonResult = await response.Content.ReadAsStringAsync();
                    var jsonConvertData = JsonConvert.DeserializeObject<ApiResponse>(jsonResult);
                    if (jsonConvertData != null)
                    {
                        
                    }
                }
            }

            return Redirect("~/Home/Index");
        }
    }
}
