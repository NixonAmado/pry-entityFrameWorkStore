using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("Region");
            builder.Property(p => p.NombreRegion)
            .IsRequired()
            .HasMaxLength(15);

            builder.Property(p => p.NombreRegion)
            .IsRequired()
            .HasMaxLength(15);

            builder.HasOne(p => p.Estado)
            .WithMany(p=> p.Regiones)
            .HasForeignKey(p=> p.IdEstadoFk);
        
        
        
        }
    }
}