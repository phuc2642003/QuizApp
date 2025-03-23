using QuizAppForDriverLicense.Models;

namespace QuizAppForDriverLicense.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public List<Category> GetAll();
        public Category Get();
        public bool Add(Category category);
        public bool Update(Category category);
        public bool Delete(int id);

    }
}
