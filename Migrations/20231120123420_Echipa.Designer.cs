﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vicol_Lorena_Proiect.Data;

#nullable disable

namespace Vicol_Lorena_Proiect.Migrations
{
    [DbContext(typeof(Vicol_Lorena_ProiectContext))]
    [Migration("20231120123420_Echipa")]
    partial class Echipa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Vicol_Lorena_Proiect.Models.Echipa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("EchipaNume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Echipa");
                });

            modelBuilder.Entity("Vicol_Lorena_Proiect.Models.Produs", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Alergeni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cantitate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EchipaID")
                        .HasColumnType("int");

                    b.Property<string>("Ingrediente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("ID");

                    b.HasIndex("EchipaID");

                    b.ToTable("Produs");
                });

            modelBuilder.Entity("Vicol_Lorena_Proiect.Models.Produs", b =>
                {
                    b.HasOne("Vicol_Lorena_Proiect.Models.Echipa", "Echipa")
                        .WithMany("Produse")
                        .HasForeignKey("EchipaID");

                    b.Navigation("Echipa");
                });

            modelBuilder.Entity("Vicol_Lorena_Proiect.Models.Echipa", b =>
                {
                    b.Navigation("Produse");
                });
#pragma warning restore 612, 618
        }
    }
}
