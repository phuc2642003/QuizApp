using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuizAppForDriverLicense.Models;
using QuizAppForDriverLicense.Repository.IRepository;
using System.IO.Pipes;

namespace QuizAppForDriverLicense.Repository
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly QuizAppContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public AnswerRepository(QuizAppContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public bool ClearAllAnswerByUserId(string userId)
        {
            var answers= _context.UserAnswers.Where(x => x.UserId == userId).ToList();
            _context.UserAnswers.RemoveRange(answers);
            return _context.SaveChanges() > 0;
        }

        public List<Answer> GetByTemp(int tempId)
        {
            var randomTemp = _context.RandomTemps.Include(x=> x.Answers).SingleOrDefault(x => x.Id == tempId);

            return randomTemp.Answers
                .Select(x=>new Answer
                {
                    Id = x.Id,
                    Content = x.Content,
                    IsTrue = x.IsTrue,
                    QuestionId = x.QuestionId
                })
                .ToList();
        }

        public List<Answer> GetByUserId(string userId)
        {
            return new List<Answer>();
        }

    }
}
