using CC.Yi.DAL;
using CC.Yi.IDAL;
using CC.Yi.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace CC.Yi.DALFactory
{
    public partial class DbSession : IDbSession
    {
        public int SaveChanges()
        {
            var context = DbContentFactory.GetCurrentDbContent();

            var saved = false;
            while (!saved)
            {
                try
                {
                    // Attempt to save changes to the database
                    context.SaveChanges();
                    saved = true;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    foreach (var entry in ex.Entries)
                    {
                        var databaseValues = entry.GetDatabaseValues();

                        // Refresh original values to bypass next concurrency check
                        entry.OriginalValues.SetValues(databaseValues);

                    }
                }
            }

            return 1;
        }
        public DataContext GetDbContent()
        {
            return DbContentFactory.GetCurrentDbContent();
        }

    }
}
