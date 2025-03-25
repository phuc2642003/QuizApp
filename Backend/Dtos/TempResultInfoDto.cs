using QuizAppForDriverLicense.Models;

namespace QuizAppForDriverLicense.Dtos
{
    public class TempResultInfoDto
    {
        public int TempId { get; set; }
        public int Point { get; set; }
        public bool Pass { get; set; }
    }
}
