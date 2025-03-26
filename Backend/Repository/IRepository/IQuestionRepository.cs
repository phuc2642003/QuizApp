using QuizAppForDriverLicense.Models;

namespace QuizAppForDriverLicense.Repository.IRepository
{
    public interface IQuestionRepository
    {
        public List<Question> GetQuestionsByCategoryId(int? categoryId);

        public List<Question> GetRandomQuestionForRandomTemp();

        public List<Question> GetRandomQuestionByCategory(int numberOfQuestion, int categoryId);

        public List<Question> GetByRandomTempId(int tempId);

        public List<Question> GetCriticalQuestion();
    }
}
