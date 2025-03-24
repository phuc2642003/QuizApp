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
                            IsTrue = a.IsTrue
                        }).ToList()
                    })
                    .ToList();
                return questions;
            }
            questions = _context.Questions
                .Include(x=>x.Answers)
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
                        IsTrue = a.IsTrue
                    }).ToList()
                })
                .ToList();
            return questions;
        }
    }
}
