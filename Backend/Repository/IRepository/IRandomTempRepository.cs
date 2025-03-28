using QuizAppForDriverLicense.Dtos;
using QuizAppForDriverLicense.Models;

namespace QuizAppForDriverLicense.Repository.IRepository
{
    public interface IRandomTempRepository
    {
        public bool Add(RandomTempDto rt);
        public RandomTemp Get(int id);
        public bool AddQuestions(List<Question> questions, string userId);

        public RandomTemp GetLastTemp(string userId);
        public bool AddTempAnswers(List<int> answers, int tempId);
        public void UpdateResult(List<int> answers, int tempId);
        public List<TempResultInfoDto> GetResults(string userId);
        public TempResultInfoDto GetTempResult(int tempId);
    }
}
