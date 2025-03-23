using Microsoft.AspNetCore.Mvc;
using QuizAppForDriverLicense.Repository.IRepository;

namespace QuizAppForDriverLicense.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var categories = _categoryRepository.GetAll();

            return Ok(categories);
        }
    }
}
