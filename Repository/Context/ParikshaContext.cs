using ParikshaModel.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
namespace EFRepository.Context
{
    /// <summary>
    /// 
    /// </summary>
    internal class UserDetailConfiguration : EntityTypeConfiguration<UserDetail>
    {
        public UserDetailConfiguration(DbModelBuilder modelBuilder)
        {
            HasMany(_ => _.Questions)                
                .WithRequired(_ => _.Creator)
                .Map(_ => _.MapKey("UserDetailId"))
                .WillCascadeOnDelete(false);
            ToTable("Users");
        }
    }

    /// <summary>
    /// 
    /// </summary>
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

    /// <summary>
    /// 
    /// </summary>
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
    
    /// <summary>
    /// 
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
    /// 
    /// </summary>
    internal class SubjectConfiguration : EntityTypeConfiguration<Subject>
    {
        public SubjectConfiguration(DbModelBuilder modelBuilder)
        {
            HasMany(_ => _.Questions)
                .WithRequired(_ => _.Subject)
                .Map(_ => _.MapKey("SubjectId"))
                .WillCascadeOnDelete(true);
            ToTable("Subject");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal class TestQuestionConfiguration : EntityTypeConfiguration<TestQuestion>
    {
        public TestQuestionConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestQuestion>()
                .HasKey(_ => _.TestQuestionId);
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    public class ParikshaContext : DbContext
    {
        public ParikshaContext()
        {           
           Database.Connection.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Pariksha;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False;";
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();            
            modelBuilder.Configurations.Add(new UserDetailConfiguration(modelBuilder));
            modelBuilder.Configurations.Add(new StandardConfiguration(modelBuilder)); 
            modelBuilder.Configurations.Add(new SubjectConfiguration(modelBuilder)); 
            modelBuilder.Configurations.Add(new QuestionConfiguration(modelBuilder));
            modelBuilder.Configurations.Add(new TestConfiguration(modelBuilder));
            modelBuilder.Configurations.Add(new TestQuestionConfiguration(modelBuilder));  
            modelBuilder.HasDefaultSchema("ParikshaDev");
        }      
    }
}