using System;
using System.Collections.Generic;

namespace QuizAppForDriverLicense.Models
{
    public partial class RandomTemp
    {
        public RandomTemp()
        {
            Answers = new HashSet<Answer>();
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string Content { get; set; } = null!;
        public double PassResult { get; set; }
        public double Result { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
