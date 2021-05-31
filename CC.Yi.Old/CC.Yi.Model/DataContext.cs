using Microsoft.EntityFrameworkCore;
using System;

namespace CC.Yi.Model
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        //public DbSet<result_user> result_user { get; set; }
    }
}
