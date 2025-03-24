using System;
using System.Collections.Generic;

namespace QuizAppForDriverLicense.Models
{
    public partial class Answer
    {
        public Answer()
        {
            Temps = new HashSet<RandomTemp>();
            UserAnswers = new HashSet<UserAnswer>();
        }

        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public bool IsTrue { get; set; }
        public int QuestionId { get; set; }

        public virtual Question Question { get; set; } = null!;

        public virtual ICollection<RandomTemp> Temps { get; set; }

        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
