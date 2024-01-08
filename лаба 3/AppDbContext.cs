﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labrab3
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Composition> Compositions { get; set; }

        public string DbPath { get; }

        public AppDbContext(string dbPath)
        {
            DbPath = dbPath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
        }
    }
}
