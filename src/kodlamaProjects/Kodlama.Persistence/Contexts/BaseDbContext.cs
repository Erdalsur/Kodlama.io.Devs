using Kodlama.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<ProgrammingTechnology> ProgrammingTechnologies { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lesson>(a =>
            {
                a.ToTable("Lessons").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.ProgrammingTechnologies);
            });
            modelBuilder.Entity<ProgrammingTechnology>(a=>
            {
                a.ToTable("ProgrammingTechnologies").HasKey(k => k.Id);
                a.Property(k => k.Id).HasColumnName("Id");
                a.Property(k => k.LessonId).HasColumnName("LessonId");
                a.Property(k => k.Name).HasColumnName("Name");
                a.HasOne(k => k.Lesson);
            });


            Lesson[] brandEntitySeeds = { new(1, "C#"), new(2, "Java") };
            modelBuilder.Entity<Lesson>().HasData(brandEntitySeeds);
            
            ProgrammingTechnology[] programmingTechnologies = 
                { 
                    new(1, 1, "WPF"),
                    new(2,1,"ASP"),
                    new(3,2, "Spring") 
                };
            modelBuilder.Entity<ProgrammingTechnology>().HasData(programmingTechnologies);

        }
    }
}
