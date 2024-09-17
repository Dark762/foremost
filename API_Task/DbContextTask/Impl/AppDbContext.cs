using CrossCutting.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace API_Task.DbContextTask.Impl
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Prioridad> Prioridades { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tarea>()
                .ToTable("Tarea"); // Use the actual table name if different

            modelBuilder.Entity<Usuario>()
                .ToTable("Usuario");

            modelBuilder.Entity<Prioridad>()
                .ToTable("Prioridad");

            // Configure relationships
            modelBuilder.Entity<Tarea>()
                .HasOne(t => t.Usuario)
                .WithMany(u => u.Tareas)
                .HasForeignKey(t => t.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tarea>()
                .HasOne(t => t.Prioridad)
                .WithMany(p => p.Tareas)
                .HasForeignKey(t => t.IdPrioridad)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed data for Prioridad table
            modelBuilder.Entity<Prioridad>().HasData(
                new Prioridad { Id = 1, Nombre = "Alto" },
                new Prioridad { Id = 2, Nombre = "Medio" },
                new Prioridad { Id = 3, Nombre = "Bajo" }
            );
        }
    }
}
