using QuizAppForDriverLicense.Dtos;

namespace QuizAppForDriverLicense.Repository.IRepository
{
    public interface IUserAnswerRepository
    {
        public bool Add(UserAnswerDto ua);
    }
}
