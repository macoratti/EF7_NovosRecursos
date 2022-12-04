using EF7ExecuteDelete.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF7ExecuteDelete.Data;

public class AppDbContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Animal> Animais { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=Desktop-dk57unp\\SQLEXPRESS;Initial Catalog=PetsDB;Integrated Security=True;TrustServerCertificate=True;")
         .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //shadow property
        modelBuilder.Entity<Endereco>()
           .Property<int>("ClienteId");

        //shadow property
        modelBuilder.Entity<Animal>()
            .Property<int>("ClienteId");
    }
}
