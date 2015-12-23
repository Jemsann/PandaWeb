using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PandaWeb.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace PandaWeb.Models
{
    public class MySqlInitializer : IDatabaseInitializer<MyDBContext>
    {
        public void InitializeDatabase(MyDBContext context)
        {
            if (!context.Database.Exists())
            {
                // if database did not exist before - create it
                context.Database.Create();
            }
            else
            {
                // query to check if MigrationHistory table is present in the database 
                var migrationHistoryTableExists = ((IObjectContextAdapter)context).ObjectContext.ExecuteStoreQuery<int>(
                string.Format(
                  "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '{0}' AND table_name = '__MigrationHistory'",
                  "[PandaWeb]"));

                // if MigrationHistory table is not there (which is the case first time we run) - create it
                if (migrationHistoryTableExists.FirstOrDefault() == 0)
                {
                    context.Database.Delete();
                    context.Database.Create();
                }
            }
        }
    }

}