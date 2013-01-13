using ParikshaModel.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel;
using System.Configuration;
namespace EFRepository.Context
{
    internal class UserDetailConfiguration : EntityTypeConfiguration<UserDetail>
    {
        public UserDetailConfiguration(DbModelBuilder modelBuilder)
        {
            this.ToTable("Users");
        }
    }

    internal class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brief>().ToTable("Brief");
            modelBuilder.Entity<Custom>().ToTable("Custom");
            modelBuilder.Entity<Match>().ToTable("Match");
            modelBuilder.Entity<Choice>().ToTable("Choice");
        }
    }

    internal class TestConfiguration : EntityTypeConfiguration<Test>
    {
        public TestConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>()
                        .HasRequired(t => t.Creator)
                        .WithMany()                        
                        .WillCascadeOnDelete(false);
        }
    }

    internal class StandardConfiguration : EntityTypeConfiguration<Standard>
    {
        public StandardConfiguration(DbModelBuilder modelBuilder)
        {
            this.HasMany(_ => _.Subjects)
                .WithRequired(_ => _.Standard)
                .Map(_ => _.MapKey("StandardId"))
                .WillCascadeOnDelete(false);
            this.ToTable("Standard");
        }
    }

    internal class SubjectConfiguration : EntityTypeConfiguration<Subject>
    {
        public SubjectConfiguration(DbModelBuilder modelBuilder)
        {
            this.ToTable("Subject");
        }
    }

    internal class TestQuestionConfiguration : EntityTypeConfiguration<TestQuestion>
    {
        public TestQuestionConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestQuestion>()
                .HasKey(_ => _.TestQuestionId);
        }
    }
    
    public class ParikshaContext :DbContext
    {
        public ParikshaContext()
        {           
           Database.Connection.ConnectionString = @"Data Source=ARTHINKPAD\SQLEXPRESS;Initial Catalog=Pariksha;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;";
           Database.SetInitializer(new ParikshaDataBaseInitializer<ParikshaContext>());
        }

        #region DbSet declaration
            public DbSet<UserDetail> UserDetails { get; set; }
            public DbSet<Standard> Standards { get; set; }
            public DbSet<Subject> Subjects { get; set; }
            public DbSet<Question> Questions { get; set; }
            public DbSet<Brief> Brief { get; set; }
            public DbSet<Custom> Custom { get; set; }
            public DbSet<Choice> Choice { get; set; }
            public DbSet<Match> Match { get; set; }
            public DbSet<Test> Tests { get; set; }
            public DbSet<TestQuestion> TestQuestions { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Configurations.Add(new UserDetailConfiguration(modelBuilder)); 
            modelBuilder.Configurations.Add(new SubjectConfiguration(modelBuilder)); 
            modelBuilder.Configurations.Add(new QuestionConfiguration(modelBuilder));
            modelBuilder.Configurations.Add(new TestConfiguration(modelBuilder));
            modelBuilder.Configurations.Add(new TestQuestionConfiguration(modelBuilder));  
            modelBuilder.HasDefaultSchema("ParikshaDev");
        }
    }    
}