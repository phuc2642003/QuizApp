using Microsoft.EntityFrameworkCore;
using QuizAppForDriverLicense.Dtos;
using QuizAppForDriverLicense.Models;
using QuizAppForDriverLicense.Repository.IRepository;

namespace QuizAppForDriverLicense.Repository
{
    public class RandomTempRepository : IRandomTempRepository
    {
        private readonly QuizAppContext _context;
        public RandomTempRepository(QuizAppContext context)
        {
            _context = context;
        }

        public bool Add(RandomTempDto rt)
        {
            RandomTemp randomTemp = new RandomTemp()
            {
                UserId = rt.UserId,
                Content = rt.Content,
                Result = rt.Result,
                PassResult = rt.PassResult
            };
            _context.RandomTemps.Add(randomTemp);
            return _context.SaveChanges() > 0;
        }

        public bool AddQuestions(List<Question> questions, string userId)
        {
            var randomTemp = GetLastTemp(userId);
            foreach (Question q in questions)
            {
                randomTemp.Questions.Add(q);
            }
            return _context.SaveChanges() > 0;
        }

        public bool AddTempAnswers(List<int> answerId, int tempId)
        {
            var temp = Get(tempId);
            foreach(int i in answerId)
            {
                Answer a = _context.Answers.Find(i);
                temp.Answers.Add(a);
            }
            return _context.SaveChanges() > 0;
        }

        public RandomTemp Get(int id)
        {
            return _context.RandomTemps.Find(id);
        }

        public RandomTemp GetLastTemp(string userId)
        {
            var temp = _context.RandomTemps.Where(rt=>rt.UserId==userId ).OrderByDescending(rt => rt.Id).FirstOrDefault();

            return temp;
        }

        public List<TempResultInfoDto> GetResults(string UserId)
        {
            var randomTemps = _context.RandomTemps
                .Include(x=>x.Answers)
                .Where(x=>x.UserId == UserId)
                .ToList();
            List<TempResultInfoDto> tempResultInfoDtos = new();
            foreach (RandomTemp rt in randomTemps)
            {
                TempResultInfoDto temp = new TempResultInfoDto()
                {
                    TempId = rt.Id,
                    Point = rt.Answers.Where(x => x.IsTrue).Count(),
                    Pass = rt.Result >= rt.PassResult ? true : false
                };
                if(temp.Point!=0)
                {
                    tempResultInfoDtos.Add(temp);
                }    
                
            }
            return tempResultInfoDtos;
        }

        public void UpdateResult(List<int> answers, int tempId)
        {
            int result = 0;
            var temp = Get(tempId);
            foreach(int i in answers)
            {
                Answer a = _context.Answers.Find(i);
                if(!a.IsTrue)
                {
                    temp.Result = -1;
                    return;
                }
                else
                {
                    result += 1;
                }    
            }
            temp.Result = result;
        }
    }
}
