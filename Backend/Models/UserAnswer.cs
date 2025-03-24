namespace QuizAppForDriverLicense.Models
{
    public class UserAnswer
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; } = null!;

        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; } = null!;
    }
}
