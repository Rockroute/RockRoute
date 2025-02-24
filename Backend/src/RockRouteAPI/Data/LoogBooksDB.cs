using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RockRoute.Models;

    public class LoogBooksDB : DbContext
    {
        public LoogBooksDB (DbContextOptions<LoogBooksDB> options)
            : base(options)
        {
        }

        public DbSet<RockRoute.Models.LogBook> LogBook { get; set; } = default!;
    }
