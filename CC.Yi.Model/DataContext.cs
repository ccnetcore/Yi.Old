using Microsoft.EntityFrameworkCore;
using System;

namespace CC.Yi.Model
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
