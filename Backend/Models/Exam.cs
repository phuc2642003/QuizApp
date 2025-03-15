using System;
using System.Collections.Generic;

namespace QuizAppForDriverLicense.Models
{
    public partial class Exam
    {
        public Exam()
        {
            UserExams = new HashSet<UserExam>();
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Content { get; set; }
        public double? PassResult { get; set; }

        public virtual ICollection<UserExam> UserExams { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
