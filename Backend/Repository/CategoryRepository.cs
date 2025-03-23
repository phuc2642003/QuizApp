using QuizAppForDriverLicense.Models;
using QuizAppForDriverLicense.Repository.IRepository;

namespace QuizAppForDriverLicense.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly QuizAppContext _context;
        public CategoryRepository(QuizAppContext context)
        {
            _context = context;
        }
        public bool Add(Category category)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Category Get()
        {
            throw new NotImplementedException();
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public bool Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
