using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel;
using System.Configuration;
namespace EFRepository.Context
{
    public class ParikshaDataBaseInitializer<TContext> : IDatabaseInitializer<TContext> where TContext : DbContext
    {
        public void InitializeDatabase(TContext context)
        {
            var exists = context.Database.Exists();

            if (exists && context.Database.CompatibleWithModel(true))
            {
                return;
            }
            if (exists)
            {
                context.Database.ExecuteSqlCommand("USE Master;ALTER DATABASE Pariksha SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE Pariksha");
                context.SaveChanges();                
            }
            context.Database.Create();
        } 
    }
}