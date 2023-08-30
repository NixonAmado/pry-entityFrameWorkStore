using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Data.Configuration;
    public class TipoPersonaConfiguration : IEntityTypeConfiguration<TipoPersona> 
    {
        public void Configure(EntityTypeBuilder<TipoPersona> builder)
        {
            builder.ToTable("TipoPersona");
            builder.Property(p => p.Descripcion)
            .IsRequired()
            .HasMaxLength(50);
            builder.HasKey(p => p.IdTPersona);


        }	
    }
