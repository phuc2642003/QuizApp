using Microsoft.AspNetCore.Identity;

namespace QuizAppForDriverLicense.Models
{
    public class User : IdentityUser
    {
        public virtual ICollection<UserAnswer> UserAnswers { get; set; } = new HashSet<UserAnswer>();
    }
}
