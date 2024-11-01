using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Definición de la tabla Books en el modelo de datos
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración adicional, si es necesario, por ejemplo, restricciones o relaciones
            modelBuilder.Entity<Book>().HasKey(b => b.Id);
            modelBuilder.Entity<Book>().Property(b => b.Title).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Book>().Property(b => b.Author).IsRequired().HasMaxLength(255);
            modelBuilder.Entity<Book>().Property(b => b.ISBN).IsRequired().HasMaxLength(20);
        }
    }
}
