using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Data.Configuration;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.ToTable("Producto");

            builder.Property(p=> p.CodInterno)
            .IsRequired()
            .HasMaxLength(15);

            builder.Property(p=> p.Nombre)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p=> p.StockMin)
            .IsRequired()
            .HasMaxLength(5)
            .HasColumnType("int");


            builder.Property(p=> p.StockMax)
            .HasMaxLength(5)
            .HasColumnType("int");

            builder.Property(p => p.Stock)
            .IsRequired()
            .HasMaxLength(5)  
            .HasColumnType("int");

            builder.Property( p=>  p.ValVenta)
            .IsRequired()
            .HasColumnType("decimal");
        
            builder.Property( p=>  p.FechaCreacion)
            .IsRequired()
            .HasColumnType("date");
        
        
        }

    }
        