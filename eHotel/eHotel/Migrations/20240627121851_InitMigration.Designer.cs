﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eHotel.eHotel.Services.Database;

#nullable disable

namespace eHotel.Migrations
{
    [DbContext(typeof(eHotelContext))]
    [Migration("20240627121851_InitMigration")]
    partial class InitMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("eHotel.eHotel.Model.JediniceMjere", b =>
                {
                    b.Property<int>("JedinicaMjereId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JedinicaMjereId"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JedinicaMjereId");

                    b.ToTable("JediniceMjere");
                });

            modelBuilder.Entity("eHotel.eHotel.Model.Korisnici", b =>
                {
                    b.Property<int>("KorisnikId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KorisnikId"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KorisnickoIme")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KorisnikId");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("eHotel.eHotel.Model.KorisniciUloge", b =>
                {
                    b.Property<int>("KorisnikUlogaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KorisnikUlogaId"));

                    b.Property<DateTime>("DatumIzmjene")
                        .HasColumnType("datetime2");

                    b.Property<int?>("KorisniciKorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("int");

                    b.Property<int>("UlogaId")
                        .HasColumnType("int");

                    b.HasKey("KorisnikUlogaId");

                    b.HasIndex("KorisniciKorisnikId");

                    b.HasIndex("UlogaId");

                    b.ToTable("KorisniciUloge");
                });

            modelBuilder.Entity("eHotel.eHotel.Model.Sobe", b =>
                {
                    b.Property<int>("SobeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SobeId"));

                    b.Property<decimal>("Cijena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("JedinicaMjereId")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Slika")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("SlikaThumb")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("StateMachine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("VrstaId")
                        .HasColumnType("int");

                    b.HasKey("SobeId");

                    b.ToTable("Sobe");
                });

            modelBuilder.Entity("eHotel.eHotel.Model.Uloge", b =>
                {
                    b.Property<int>("UlogaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UlogaId"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UlogaId");

                    b.ToTable("Uloge");
                });

            modelBuilder.Entity("eHotel.eHotel.Model.VrsteSoba", b =>
                {
                    b.Property<int>("VrstaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VrstaId"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VrstaId");

                    b.ToTable("VrsteSoba");
                });

            modelBuilder.Entity("eHotel.eHotel.Model.KorisniciUloge", b =>
                {
                    b.HasOne("eHotel.eHotel.Model.Korisnici", null)
                        .WithMany("KorisniciUloges")
                        .HasForeignKey("KorisniciKorisnikId");

                    b.HasOne("eHotel.eHotel.Model.Uloge", "Uloga")
                        .WithMany()
                        .HasForeignKey("UlogaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Uloga");
                });

            modelBuilder.Entity("eHotel.eHotel.Model.Korisnici", b =>
                {
                    b.Navigation("KorisniciUloges");
                });
#pragma warning restore 612, 618
        }
    }
}
