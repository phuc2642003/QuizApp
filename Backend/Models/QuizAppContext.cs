using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QuizAppForDriverLicense.Models
{
    public partial class QuizAppContext : IdentityDbContext<User>
    {
        public QuizAppContext()
        {
        }

        public QuizAppContext(DbContextOptions<QuizAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Exam> Exams { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<UserExam> UserExams { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =(local); database = QuizAppVersion4;uid=sa;pwd=phuc2642003;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey });
            
            modelBuilder.Entity<UserExam>()
            .HasOne(e => e.User)  // 1 ExamResult thuộc về 1 User
            .WithMany()  // 1 User có thể có nhiều ExamResult
            .HasForeignKey(e => e.UserId)  // Khóa ngoại
            .OnDelete(DeleteBehavior.Cascade);  // Xóa user sẽ xóa luôn ExamResult
            
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("Answer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.IsTrue).HasColumnName("isTrue");

                entity.Property(e => e.QuestionId).HasColumnName("questionId");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answer_Question");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.ToTable("Exam");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.PassResult).HasColumnName("passResult");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.ExamId).HasColumnName("examId");

                entity.Property(e => e.ImgUrl)
                    .HasColumnType("text")
                    .HasColumnName("imgUrl");

                entity.Property(e => e.IsCriticalFail).HasColumnName("isCriticalFail");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Question_Category");

                entity.HasMany(d => d.Exams)
                    .WithMany(p => p.Questions)
                    .UsingEntity<Dictionary<string, object>>(
                        "ExamQuestion",
                        l => l.HasOne<Exam>().WithMany().HasForeignKey("ExamId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ExamQuestion_Exam"),
                        r => r.HasOne<Question>().WithMany().HasForeignKey("QuestionId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ExamQuestion_Question"),
                        j =>
                        {
                            j.HasKey("QuestionId", "ExamId");

                            j.ToTable("ExamQuestion");

                            j.IndexerProperty<int>("QuestionId").HasColumnName("questionId");

                            j.IndexerProperty<int>("ExamId").HasColumnName("examId");
                        });
            });

            modelBuilder.Entity<UserExam>(entity =>
            {
                entity.ToTable("UserExam");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ExamId).HasColumnName("examId");

                entity.Property(e => e.Result).HasColumnName("result");

                entity.Property(e => e.UserId)
                    .HasMaxLength(450)
                    .HasColumnName("userId");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.UserExams)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserExam_Exam");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
