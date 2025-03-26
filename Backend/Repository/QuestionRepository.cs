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

        public List<Question> GetByRandomTempId(int tempId)
        {
            var temp = _context.RandomTemps
                .Include(x=>x.Questions)
                .ThenInclude(q=>q.Answers)
                .SingleOrDefault(x=>x.Id==tempId);

            var questions= temp.Questions
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
                        
                    }).ToList()
                })
                .ToList();

            return questions;
        }

        public List<Question> GetCriticalQuestion()
        {
            return _context.Questions
                .Include(q => q.Answers)
                .ThenInclude(a => a.UserAnswers)
                .Where(q=>q.IsCriticalFail)
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
        }

        public List<Question> GetQuestionsByCategoryId(int? categoryId)
        {
            return _context.Questions
                .Include(q => q.Answers)
                .ThenInclude(a => a.UserAnswers)
                .Where(q => !categoryId.HasValue || categoryId == 0 || q.CategoryId == categoryId)
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
        }
        public List<Question> GetRandomQuestionByCategory(int numberOfQuestion, int categoryId)
        {
            var randomQuestions = _context.Questions
               .Where(q => q.CategoryId == categoryId && !q.IsCriticalFail)
               .OrderBy(q => Guid.NewGuid())
               .Take(numberOfQuestion)
               .Include(q => q.Answers)
               .ToList();

            return randomQuestions;
        }    
        public List<Question> GetRandomQuestionForRandomTemp()
        {
            var questions1 = GetRandomQuestionByCategory(9, 1);
            var questions2 = GetRandomQuestionByCategory(1, 2);
            var questions3 = GetRandomQuestionByCategory(1, 3);
            var questions4 = GetRandomQuestionByCategory(7, 4);
            var questions5 = GetRandomQuestionByCategory(4, 5);

            var criticalQuestions = _context.Questions.Where(q=>q.IsCriticalFail)
               .Take(3)
               .Include(q => q.Answers)
               .ToList();
            var allQuestions = questions1
                .Concat(questions2)
                .Concat(questions3)
                .Concat(questions4)
                .Concat(questions5)
                .Concat(criticalQuestions)
                .ToList();

            return allQuestions;
        }
    }
}
