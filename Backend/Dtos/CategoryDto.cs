namespace QuizAppForDriverLicense.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Content { get; set; } = null!;
    }
}
