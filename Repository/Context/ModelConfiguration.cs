using ParikshaModel.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EFRepository.Context
{
    /// <summary>
    /// Specifies the Configuration for the Entity UserDetail
    /// </summary>
    internal class UserDetailConfiguration : EntityTypeConfiguration<UserDetail>
    {
        public UserDetailConfiguration(DbModelBuilder modelBuilder)
        {
            HasMany(_ => _.Questions)
                .WithRequired(_ => _.Creator)
                .Map(_ => _.MapKey("UserDetailId"))
                .WillCascadeOnDelete(true);
            ToTable("Users");
            Property(_ => _.Name).HasColumnName("UserName").HasMaxLength(10);
        }
    }

    /// <summary>
    /// Specifies the configuration for the Entity Question
    /// </summary>
    internal class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brief>().ToTable("Brief");
            modelBuilder.Entity<Custom>().ToTable("Custom");
            modelBuilder.Entity<Match>().ToTable("Match");
            modelBuilder.Entity<Choice>().ToTable("Choice");
<<<<<<< HEAD
=======

            modelBuilder.Entity<Question>()
                .HasMany(qd => qd.Tests)
                .WithMany(t => t.Questions)
                .Map(mc =>
                {
                    mc.MapLeftKey("QuestionId");
                    mc.MapRightKey("TestId");
                    mc.ToTable("Test_Questions");
                });
>>>>>>>  This is a combination of 5 commits.
        }
    }

    /// <summary>
    /// Specifies the configuration for the Entity Test
    /// </summary>
    internal class TestConfiguration : EntityTypeConfiguration<Test>
    {
        public TestConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>()
                        .HasRequired(t => t.Creator)
                        .WithMany()
                        .WillCascadeOnDelete(false);
<<<<<<< HEAD
=======
            Property(_ => _.DateOfCreation).IsRequired();           
>>>>>>>  This is a combination of 5 commits.
        }
    }

    /// <summary>
    /// Specifies the configuration for the Entity Standard
    /// </summary>
    internal class StandardConfiguration : EntityTypeConfiguration<Standard>
    {
        public StandardConfiguration(DbModelBuilder modelBuilder)
        {
            HasMany(_ => _.Subjects)
                .WithRequired(_ => _.Standard)
                .Map(_ => _.MapKey("StandardId"))
                .WillCascadeOnDelete(false);
            ToTable("Standard");
        }
    }

    /// <summary>
    /// Specifies the configuration for the Entity Subject
    /// </summary>
    internal class SubjectConfiguration : EntityTypeConfiguration<Subject>
    {
        public SubjectConfiguration(DbModelBuilder modelBuilder)
        {
            HasMany(_ => _.Questions)
                .WithRequired(_ => _.Subject)
                .Map(_ => _.MapKey("SubjectId"))
<<<<<<< HEAD
                .WillCascadeOnDelete(true);
=======
                .WillCascadeOnDelete(true);            
>>>>>>>  This is a combination of 5 commits.
            ToTable("Subject");
            Property(_ => _.SubjectName).HasMaxLength(15);
        }
    }
<<<<<<< HEAD

    /// <summary>
    /// Specifies the Configuration for the Entity TestQuestion
    /// </summary>
    internal class TestQuestionConfiguration : EntityTypeConfiguration<TestQuestion>
    {
        public TestQuestionConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestQuestion>()
                .HasKey(_ => _.TestQuestionId);
        }
    }
=======
       
>>>>>>>  This is a combination of 5 commits.
}
