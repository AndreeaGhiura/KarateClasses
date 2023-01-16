using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KarateClasses.Models;
using KarateClasses.Data;

namespace KarateClasses.Data
{
    public class KarateClassesContext : IdentityDbContext
    {
        public KarateClassesContext(DbContextOptions<KarateClassesContext> options)
            : base(options)
        {
        }

        public DbSet<KarateClasses.Models.Karate> Karate { get; set; } = default!;

        public DbSet<KarateClasses.Models.Location> Location { get; set; }

        public DbSet<KarateClasses.Models.Trainer> Trainer { get; set; }

        public DbSet<KarateClasses.Models.Category> Category { get; set; }

        public DbSet<KarateClasses.Models.Member> Member { get; set; }

        public DbSet<KarateClasses.Models.Subscription> Subscription { get; set; }
    }
}
