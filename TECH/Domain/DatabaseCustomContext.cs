﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DatabaseCustomContext:DbContext
    {
        public DatabaseCustomContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Category { set; get; } = default!;
    }
}
