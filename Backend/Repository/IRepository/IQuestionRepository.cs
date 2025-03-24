using QuizAppForDriverLicense.Models;

namespace QuizAppForDriverLicense.Repository.IRepository
{
    public interface IQuestionRepository
    {
        public List<Question> GetQuestionsByCategoryId(int? categoryId);
    }
}
