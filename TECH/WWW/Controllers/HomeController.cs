using Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using WWW.Models;

namespace WWW.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoginUser()
        {
            return View();
        }

        public async Task<IActionResult> LoginUser(UserInfo user)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
                using (var response =  await httpClient.PostAsync("https://localhost:7240/api/User/Create", stringContent))
                {
                    string token = await response.Content.ReadAsStringAsync();
                    var jsonConvertData = JsonConvert.DeserializeObject<ApiResponse>(token);
                    if (jsonConvertData != null)
                    {
                        if (jsonConvertData.Data != null)
                        {
                            HttpContext.Session.SetString("JWToken", jsonConvertData.Data);                            
                        }
                    }                   
                }
            }

            return Redirect("~/Home/Index");
        }

        [HttpGet]
        public async Task<List<CategoryModel>> GetAllCategory()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (!string.IsNullOrEmpty(accessToken))
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                string jsonData = await client.GetStringAsync("https://localhost:7240/Category/GetAll");
                var jsonConvertData = new ApiResponse();
                if (!string.IsNullOrEmpty(jsonData))
                {
                    jsonConvertData = JsonConvert.DeserializeObject<ApiResponse>(jsonData);
                }
                var _jsonConvertData = JsonConvert.DeserializeObject<List<CategoryModel>>(jsonConvertData.Data).ToList();
                return _jsonConvertData;
            }
            return new List<CategoryModel>();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}