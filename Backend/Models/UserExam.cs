using System;
using System.Collections.Generic;

namespace QuizAppForDriverLicense.Models
{
    public partial class UserExam
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public int ExamId { get; set; }
        public double? Result { get; set; }
        public virtual User User { get; set; } = null!;
        public virtual Exam Exam { get; set; } = null!;
    }
}
