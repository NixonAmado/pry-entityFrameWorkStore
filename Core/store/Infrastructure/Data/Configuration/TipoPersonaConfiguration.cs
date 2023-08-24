namespace Infrastructure.Data.Configuration
using Core.Entities;

    public class TipoPersonaConfiguration: IEntityTypeConfiguration<TipoPersona> 
    {
        public void Configure(EntityTypeBuilder<TipoPersona>)
        {
            builder.ToTable("TipoPersona");
            builder.Property(p => p.Descripcion)
            .IsRequired();
            .HasMaxLength(50);
            builder.HasKey(p => p.IdTipoPersona);


        }	
    }
