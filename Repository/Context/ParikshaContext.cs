using ParikshaModel.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EFRepository.Context
{
    /// <summary>
    /// ParikshaContext derives from DbContext and is the context associated with the Pariksha Model.
    /// Contains the configuration for the model
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
        /// Overrides the OnModelCreating implementation to have custom configuration and conventions
        /// </summary>
        /// <param name="modelBuilder">DbModelBuilder</param>
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