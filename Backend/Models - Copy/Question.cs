//using System;
//using System.Collections.Generic;

//namespace QuizAppForDriverLicense.Models
//{
//    public partial class Question
//    {
//        public Question()
//        {
//            Answers = new HashSet<Answer>();
//            Exams = new HashSet<Exam>();
//        }

//        public int Id { get; set; }
//        public string Name { get; set; } = null!;
//        public string? ImgUrl { get; set; }
//        public bool IsCriticalFail { get; set; }
//        public int CategoryId { get; set; }
//        public int ExamId { get; set; }

//        public virtual Category Category { get; set; } = null!;
//        public virtual ICollection<Answer> Answers { get; set; }

//        public virtual ICollection<Exam> Exams { get; set; }
//    }
//}
