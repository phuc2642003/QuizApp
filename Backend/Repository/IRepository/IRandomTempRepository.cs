using QuizAppForDriverLicense.Dtos;

namespace QuizAppForDriverLicense.Repository.IRepository
{
    public interface IRandomTempRepository
    {
        public bool Add(RandomTempDto rt);
    }
}
