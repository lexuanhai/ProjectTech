using Dto;
using Reponsitory;

namespace Service
{
    public interface ICategoryService
    {
        List<CategoryModel> GetAll1();
    }
    public class CategoryService: ICategoryService
    {

        private readonly ICategoryReponsitory _categoryRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        public CategoryService(
            ICategoryReponsitory categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Get All Category
        /// <returns>List All CategoryModel from DB</returns>
        public List<CategoryModel> GetAll1()
        {
            var categories = _categoryRepository.GetAll().Select(c => new CategoryModel()
            {
                Id = c.Id,
                Name = c.Name

            }).ToList();

            return categories;
        }
    }
}