﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vicol_Lorena_Proiect.Data;

#nullable disable

namespace Vicol_Lorena_Proiect.Migrations
{
    [DbContext(typeof(Vicol_Lorena_ProiectContext))]
    partial class Vicol_Lorena_ProiectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Vicol_Lorena_Proiect.Models.Angajat", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAngajarii")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeAngajat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Angajat");
                });

            modelBuilder.Entity("Vicol_Lorena_Proiect.Models.Categorie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NumeCategorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("Vicol_Lorena_Proiect.Models.CategorieProdus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CategorieID")
                        .HasColumnType("int");

                    b.Property<int>("ProdusID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CategorieID");

                    b.HasIndex("ProdusID");

                    b.ToTable("CategorieProdus");
                });

            modelBuilder.Entity("Vicol_Lorena_Proiect.Models.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Vicol_Lorena_Proiect.Models.Comanda", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataLivrarii")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ProdusID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("ProdusID")
                        .IsUnique()
                        .HasFilter("[ProdusID] IS NOT NULL");

                    b.ToTable("Comanda");
                });

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

            modelBuilder.Entity("Vicol_Lorena_Proiect.Models.ListaAngajati", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AngajatID")
                        .HasColumnType("int");

                    b.Property<int>("EchipaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AngajatID");

                    b.HasIndex("EchipaID");

                    b.ToTable("ListaAngajati");
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

            modelBuilder.Entity("Vicol_Lorena_Proiect.Models.CategorieProdus", b =>
                {
                    b.HasOne("Vicol_Lorena_Proiect.Models.Categorie", "Categorie")
                        .WithMany("CategorieProduse")
                        .HasForeignKey("CategorieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vicol_Lorena_Proiect.Models.Produs", "Produs")
                        .WithMany("CategorieProduse")
                        .HasForeignKey("ProdusID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("Produs");
                });

            modelBuilder.Entity("Vicol_Lorena_Proiect.Models.Comanda", b =>
                {
                    b.HasOne("Vicol_Lorena_Proiect.Models.Client", "Client")
                        .WithMany("Comenzi")
                        .HasForeignKey("ClientID");

                    b.HasOne("Vicol_Lorena_Proiect.Models.Produs", "Produs")
                        .WithOne("Comanda")
                        .HasForeignKey("Vicol_Lorena_Proiect.Models.Comanda", "ProdusID");

                    b.Navigation("Client");

                    b.Navigation("Produs");
                });

            modelBuilder.Entity("Vicol_Lorena_Proiect.Models.ListaAngajati", b =>
                {
                    b.HasOne("Vicol_Lorena_Proiect.Models.Angajat", "Angajat")
                        .WithMany("ListeAngajati")
                        .HasForeignKey("AngajatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vicol_Lorena_Proiect.Models.Echipa", "Echipa")
                        .WithMany("ListeAngajati")
                        .HasForeignKey("EchipaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Angajat");

                    b.Navigation("Echipa");
                });

            modelBuilder.Entity("Vicol_Lorena_Proiect.Models.Produs", b =>
                {
                    b.HasOne("Vicol_Lorena_Proiect.Models.Echipa", "Echipa")
                        .WithMany("Produse")
                        .HasForeignKey("EchipaID");

                    b.Navigation("Echipa");
                });

            modelBuilder.Entity("Vicol_Lorena_Proiect.Models.Angajat", b =>
                {
                    b.Navigation("ListeAngajati");
                });

            modelBuilder.Entity("Vicol_Lorena_Proiect.Models.Categorie", b =>
                {
                    b.Navigation("CategorieProduse");
                });

            modelBuilder.Entity("Vicol_Lorena_Proiect.Models.Client", b =>
                {
                    b.Navigation("Comenzi");
                });

            modelBuilder.Entity("Vicol_Lorena_Proiect.Models.Echipa", b =>
                {
                    b.Navigation("ListeAngajati");

                    b.Navigation("Produse");
                });

            modelBuilder.Entity("Vicol_Lorena_Proiect.Models.Produs", b =>
                {
                    b.Navigation("CategorieProduse");

                    b.Navigation("Comanda");
                });
#pragma warning restore 612, 618
        }
    }
}
