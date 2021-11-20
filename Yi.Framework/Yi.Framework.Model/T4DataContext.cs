using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Yi.Framework.Model.Models;

namespace Yi.Framework.Model
{
    public partial class DataContext :DbContext
    {
        public DbSet<menu> menu { get; set; }
        public DbSet<mould> mould { get; set; }
        public DbSet<order> order { get; set; }
        public DbSet<role> role { get; set; }
        public DbSet<sku> sku { get; set; }
        public DbSet<spu> spu { get; set; }
        public DbSet<stock> stock { get; set; }
        public DbSet<user> user { get; set; }
        public DbSet<visit> visit { get; set; }
    }
}

