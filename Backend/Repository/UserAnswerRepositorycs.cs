using QuizAppForDriverLicense.Dtos;
using QuizAppForDriverLicense.Models;
using QuizAppForDriverLicense.Repository.IRepository;

namespace QuizAppForDriverLicense.Repository
{
    public class UserAnswerRepository : IUserAnswerRepository
    {
        private readonly QuizAppContext _context;
        public UserAnswerRepository(QuizAppContext context)
        {
            _context = context;
        }
        public bool Add(UserAnswerDto ua)
        {
            UserAnswer userAnswer = new UserAnswer()
            {
                AnswerId = ua.AnswerId,
                UserId = ua.UserId
            };
            _context.UserAnswers.Add(userAnswer);
            return _context.SaveChanges() > 0;
        }
    }
}
