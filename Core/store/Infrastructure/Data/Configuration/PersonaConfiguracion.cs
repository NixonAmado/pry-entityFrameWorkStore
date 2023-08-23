using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("Persona");

            builder.Property(p => p.IdPersona)
            .IsRequired()
            .HasMaxLength(15);
            
            builder.Property(p => p.FechaNacimiento)
            .IsRequired()
            .HasColumnType("date");

            builder.HasOne(p => p.Region)
            .WithMany(p => p.Personas)
            .HasForeignKey(p=> p.IdRegionFk);

            builder.HasOne(p => p.IdTipoPersona)
            .WithMany(p => p.Personas)
            .HasForeignKey(p=> p.IdRegionFk);


            /**builder.Property(p => p.IdPersona)
            .IsRequired()
            .HasMaxLength(15);**/
    }
}