using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Professor>()
                .HasMany(p => p.assignments)
                .WithOne(a => a.Professor)
                .HasForeignKey(a => a.ProfessorId);

            modelBuilder.Entity<Assignment>()
            .HasOne(a => a.Professor)
            .WithMany(s => s.assignments);
            base.OnModelCreating(modelBuilder);
        }
        
    }

}
