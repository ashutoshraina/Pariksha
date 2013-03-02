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
                    return;
                }
            }
            catch (Exception)
            {
                // Do nothing if no metadata 
            }
            finally
            {
                if (exists)
                {
                    context.Database.ExecuteSqlCommand("USE Master;ALTER DATABASE Pariksha SET SINGLE_USER WITH ROLLBACK IMMEDIATE; DROP DATABASE Pariksha");
                    context.SaveChanges();
                }

                context.Database.Create();
            }
        } 
    }
}