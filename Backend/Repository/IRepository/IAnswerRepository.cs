using QuizAppForDriverLicense.Models;

namespace QuizAppForDriverLicense.Repository.IRepository
{
    public interface IAnswerRepository
    {
        public List<Answer> GetByUserId(string userId);

        public bool ClearAllAnswerByUserId(string userId);
    }
}
