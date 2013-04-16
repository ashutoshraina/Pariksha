namespace EFRepository.Migrations
{
    using System.Data.Entity.Migrations;
    using Context;
    internal sealed class Configuration : DbMigrationsConfiguration<ParikshaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EFRepository.Context.ParikshaContext";
        }

        protected override void Seed(ParikshaContext context)
        {

            context.Database.ExecuteSqlCommand(@"ALTER TABLE [ParikshaDev].[Match] DROP CONSTRAINT [FK_ParikshaDev.Match_ParikshaDev.Questions_QuestionId]");
            context.Database.ExecuteSqlCommand(@"ALTER TABLE [ParikshaDev].[Match] ADD CONSTRAINT [FK_ParikshaDev.Match_ParikshaDev.Questions_QuestionId] FOREIGN KEY (QuestionId) REFERENCES [ParikshaDev].[Questions] (QuestionId) ON DELETE CASCADE");

            context.Database.ExecuteSqlCommand(@"ALTER TABLE [ParikshaDev].[Brief] DROP CONSTRAINT [FK_ParikshaDev.Brief_ParikshaDev.Questions_QuestionId]");
            context.Database.ExecuteSqlCommand(@"ALTER TABLE [ParikshaDev].[Brief] ADD CONSTRAINT [FK_ParikshaDev.Brief_ParikshaDev.Questions_QuestionId] FOREIGN KEY (QuestionId) REFERENCES [ParikshaDev].[Questions] (QuestionId) ON DELETE CASCADE");

            context.Database.ExecuteSqlCommand(@"ALTER TABLE [ParikshaDev].[Choice] DROP CONSTRAINT [FK_ParikshaDev.Choice_ParikshaDev.Questions_QuestionId]");
            context.Database.ExecuteSqlCommand(@"ALTER TABLE [ParikshaDev].[Choice] ADD CONSTRAINT [FK_ParikshaDev.Choice_ParikshaDev.Questions_QuestionId] FOREIGN KEY (QuestionId) REFERENCES [ParikshaDev].[Questions] (QuestionId) ON DELETE CASCADE");

            context.Database.ExecuteSqlCommand(@"ALTER TABLE [ParikshaDev].[Custom] DROP CONSTRAINT [FK_ParikshaDev.Custom_ParikshaDev.Questions_QuestionId]");
            context.Database.ExecuteSqlCommand(@"ALTER TABLE [ParikshaDev].[Custom] ADD CONSTRAINT [FK_ParikshaDev.Custom_ParikshaDev.Questions_QuestionId] FOREIGN KEY (QuestionId) REFERENCES [ParikshaDev].[Questions] (QuestionId) ON DELETE CASCADE");

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
