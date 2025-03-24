using Microsoft.EntityFrameworkCore;
using QuizAppForDriverLicense.Models;
using QuizAppForDriverLicense.Repository.IRepository;

namespace QuizAppForDriverLicense.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly QuizAppContext _context;
        public QuestionRepository(QuizAppContext context)
        {
            _context = context;
        }
        public List<Question> GetQuestionsByCategoryId(int? categoryId)
        {
            var questions = new List<Question>();
            if(categoryId.HasValue)
            {
                questions = _context.Questions
                    .Include(x=>x.Answers)
                    .ThenInclude(a=>a.UserAnswers)
                    .Where(x => x.CategoryId == categoryId)
                    .Select(q => new Question
                    {
                        Id = q.Id,
                        Name = q.Name,
                        Content = q.Content,
                        ImgUrl = q.ImgUrl,
                        IsCriticalFail = q.IsCriticalFail,
                        CategoryId = q.CategoryId,
                        Answers = q.Answers.Select(a => new Answer
                        {
                            Id = a.Id,
                            Content = a.Content,
                            IsTrue = a.IsTrue,
                            UserAnswers = a.UserAnswers.Select(u=> new UserAnswer
                            {
                                Id=u.Id,
                                UserId = u.UserId,
                                AnswerId = u.AnswerId
                            }).ToList()
                        }).ToList()
                    })
                    .ToList();
                return questions;
            }
            questions = _context.Questions
                .Include(x=>x.Answers)
                .ThenInclude(a => a.UserAnswers)
                .Select(q => new Question
                {
                    Id = q.Id,
                    Name = q.Name,
                    Content = q.Content,
                    ImgUrl = q.ImgUrl,
                    IsCriticalFail = q.IsCriticalFail,
                    CategoryId = q.CategoryId,
                    Answers = q.Answers.Select(a => new Answer
                    {
                        Id = a.Id,
                        Content = a.Content,
                        IsTrue = a.IsTrue,
                        UserAnswers = a.UserAnswers.Select(u => new UserAnswer
                        {
                            Id = u.Id,
                            UserId = u.UserId,
                            AnswerId = u.AnswerId
                        }).ToList()
                    }).ToList()
                })
                .ToList();
            return questions;
        }

        public List<Question> GetRandomQuestionForRandomTemp()
        {
            throw new NotImplementedException();
        }
    }
}
