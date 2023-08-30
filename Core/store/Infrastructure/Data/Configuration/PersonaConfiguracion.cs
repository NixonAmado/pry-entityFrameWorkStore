using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("Persona");

            builder.Property(p => p.FechaNacimiento)
            .IsRequired()
            .HasColumnType("date");

            builder.HasOne(p => p.Region)
            .WithMany(p => p.Personas)
            .HasForeignKey(p=> p.IdRegionFk);

            builder.HasOne(p => p.TipoPersona)
            .WithMany(p => p.Personas)
            .HasForeignKey(p=> p.IdTipoPersonaFk);

            builder
            .HasMany(p => p.Productos)
            .WithMany(p => p.Personas)
            .UsingEntity <ProductoPersona>
            (
                j => j 
                    .HasOne(pt => pt.Producto)
                    .WithMany(t => t.ProductosPersonas)
                    .HasForeignKey(pt => pt.IdProductoFk),
                j => j 
                    .HasOne(pt => pt.Persona)
                    .WithMany(t => t.ProductosPersonas)
                    .HasForeignKey(pt => pt.IdPersonaFk),
                j => 
                {
                    j.HasKey(t => new {t.IdProductoFk, t.IdPersonaFk});
                }
            );


            /**builder.Property(p => p.IdPersona)
            .IsRequired()
            .HasMaxLength(15);**/
    }
}