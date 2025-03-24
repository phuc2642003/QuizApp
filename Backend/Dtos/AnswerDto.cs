using QuizAppForDriverLicense.Models;

namespace QuizAppForDriverLicense.Dtos
{
    public class AnswerDto
    {

        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public bool IsTrue { get; set; }
        public int QuestionId { get; set; }

    }
}
