using API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        [Route("/Category/GetAll")]
        public IActionResult GetAll()
        {
            var data = _categoryService.GetAll1();
            return Ok(new ApiResponse
            {
                Success = true,
                Message = "success",
                Data = JsonConvert.SerializeObject(data)
            });
        }

    }
}
