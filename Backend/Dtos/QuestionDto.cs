namespace QuizAppForDriverLicense.Dtos
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImgUrl { get; set; }
        public bool IsCriticalFail { get; set; }
        public int CategoryId { get; set; }
        public string Content { get; set; } = null!;
    }
}
