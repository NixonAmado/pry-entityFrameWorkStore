﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Core.Entities.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdPaisFk")
                        .HasColumnType("int");

                    b.Property<string>("NombreEstado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdPaisFk");

                    b.ToTable("Estado", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombrePais")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Pais", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<int?>("IdRegionFk")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoPersonaFk")
                        .HasColumnType("int");

                    b.Property<string>("NombrePersona")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdRegionFk");

                    b.HasIndex("IdTipoPersonaFk");

                    b.ToTable("Persona", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CodInterno")
                        .HasMaxLength(15)
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Stock")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.Property<int>("StockMax")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.Property<int>("StockMin")
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    b.Property<decimal>("ValVenta")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.ToTable("Producto", (string)null);
                });

            modelBuilder.Entity("Core.Entities.ProductoPersona", b =>
                {
                    b.Property<int>("IdProductoFk")
                        .HasColumnType("int");

                    b.Property<int>("IdPersonaFk")
                        .HasColumnType("int");

                    b.HasKey("IdProductoFk", "IdPersonaFk");

                    b.HasIndex("IdPersonaFk");

                    b.ToTable("PersonaProductos");
                });

            modelBuilder.Entity("Core.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("IdEstadoFk")
                        .HasColumnType("int");

                    b.Property<string>("NombreRegion")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("IdEstadoFk");

                    b.ToTable("Region", (string)null);
                });

            modelBuilder.Entity("Core.Entities.TipoPersona", b =>
                {
                    b.Property<int>("IdTPersona")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("IdTPersona");

                    b.ToTable("TipoPersona", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Estado", b =>
                {
                    b.HasOne("Core.Entities.Pais", "Pais")
                        .WithMany("Estados")
                        .HasForeignKey("IdPaisFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pais");
                });

            modelBuilder.Entity("Core.Entities.Persona", b =>
                {
                    b.HasOne("Core.Entities.Region", "Region")
                        .WithMany("Personas")
                        .HasForeignKey("IdRegionFk");

                    b.HasOne("Core.Entities.TipoPersona", "TipoPersona")
                        .WithMany("Personas")
                        .HasForeignKey("IdTipoPersonaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");

                    b.Navigation("TipoPersona");
                });

            modelBuilder.Entity("Core.Entities.ProductoPersona", b =>
                {
                    b.HasOne("Core.Entities.Persona", "Persona")
                        .WithMany("ProductosPersonas")
                        .HasForeignKey("IdPersonaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Producto", "Producto")
                        .WithMany("ProductosPersonas")
                        .HasForeignKey("IdProductoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("Core.Entities.Region", b =>
                {
                    b.HasOne("Core.Entities.Estado", "Estado")
                        .WithMany("Regiones")
                        .HasForeignKey("IdEstadoFk");

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("Core.Entities.Estado", b =>
                {
                    b.Navigation("Regiones");
                });

            modelBuilder.Entity("Core.Entities.Pais", b =>
                {
                    b.Navigation("Estados");
                });

            modelBuilder.Entity("Core.Entities.Persona", b =>
                {
                    b.Navigation("ProductosPersonas");
                });

            modelBuilder.Entity("Core.Entities.Producto", b =>
                {
                    b.Navigation("ProductosPersonas");
                });

            modelBuilder.Entity("Core.Entities.Region", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Core.Entities.TipoPersona", b =>
                {
                    b.Navigation("Personas");
                });
#pragma warning restore 612, 618
        }
    }
}
