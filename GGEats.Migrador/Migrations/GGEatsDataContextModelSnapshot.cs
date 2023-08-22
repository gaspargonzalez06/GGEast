﻿// <auto-generated />
using GGEats.Migrador;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GGEats.Migrador.Migrations
{
    [DbContext(typeof(GGEatsDataContext))]
    partial class GGEatsDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GGEats.Data.Models.Detalles", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<decimal>("Impuesto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrdenId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Order_Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Product_Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sku")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total_Linea")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrdenId");

                    b.ToTable("Detalles");
                });

            modelBuilder.Entity("GGEats.Data.Models.Ordenes", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Fecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Importado")
                        .HasColumnType("bit");

                    b.Property<decimal>("Impuesto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Procesada")
                        .HasColumnType("bit");

                    b.Property<string>("Product_Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Ordenes");
                });

            modelBuilder.Entity("GGEats.Data.Models.Detalles", b =>
                {
                    b.HasOne("GGEats.Data.Models.Ordenes", "Orden")
                        .WithMany("Detalles")
                        .HasForeignKey("OrdenId");
                });
#pragma warning restore 612, 618
        }
    }
}