using System;
using System.Data.Entity;

namespace EFRepository.Context
{
    /// <summary>
    /// Implements the IDatabaseInitializer to provide a custom database initialisation for the context.
    /// </summary>
    /// <typeparam name="TContext">TContext is the DbContext</typeparam>
    public class ParikshaDataBaseInitializer<TContext> : IDatabaseInitializer<TContext> where TContext : DbContext
    {
        /// <summary>
        /// The method to Initialise the database.
        /// Takes care of the database cannot be dropped since it is in use problem while dropping and recreating the database.
        /// </summary>
        /// <param name="context">The DbContext on which to run the initialiser</param>
        public void InitializeDatabase(TContext context)
        {
            var exists = context.Database.Exists();

            try
            {
                if (exists && context.Database.CompatibleWithModel(true))
                {
                    // everything is good , we are done
                    return;
                }

                if (!exists)
                {
                    context.Database.Create();
                }
            }
            catch (Exception)
            {
                //Something is wrong , either we could not locate the metadata or the model is not compatible.
                //if the database exists and model is not compatible then go ahead drop it and recreate it.
                if (exists)
                {
                    context.Database.ExecuteSqlCommand("ALTER DATABASE Pariksha SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                    context.Database.ExecuteSqlCommand("USE Master DROP DATABASE Pariksha");
                    context.SaveChanges();
                }

                context.Database.Create();
            }
        } 
    }
}