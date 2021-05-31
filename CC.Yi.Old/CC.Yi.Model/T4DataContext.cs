using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace CC.Yi.Model
{
    public partial class DataContext :DbContext
    {
        public DbSet<student> student { get; set; }
    }
}