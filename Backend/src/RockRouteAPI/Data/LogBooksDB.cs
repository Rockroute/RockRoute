using System;
using System.Collections.Generic; //to use List
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RockRoute.Models;

    public class LogBooksDB : DbContext
    {
        public LogBooksDB (DbContextOptions<LogBooksDB> options)
            : base(options)
        {
        }

        public DbSet<RockRoute.Models.LogBook> LogBook { get; set; } = default!;
    }