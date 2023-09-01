using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace Infrastructure.Data;
public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions <StoreContext> options) : base(options)
    {
    }
    public DbSet<Pais>? Paises { get; set; }
    public DbSet<Estado>? Estados { get; set; }
    public DbSet<Region>? Regiones { get; set; }
    public DbSet<Persona>? Personas { get; set; }
    public DbSet<Producto>? Productos { get; set; }
    public DbSet<TipoPersona>? TiposPersona { get; set; }
    public DbSet<ProductoPersona>? PersonaProductos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}





