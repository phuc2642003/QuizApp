namespace QuizAppForDriverLicense.Dtos
{
    public class RandomTempDto
    {
        public string UserId { get; set; } = null!;
        public string Content { get; set; } = null!;
        public double PassResult { get; set; }
        public double Result { get; set; }
    }
}
