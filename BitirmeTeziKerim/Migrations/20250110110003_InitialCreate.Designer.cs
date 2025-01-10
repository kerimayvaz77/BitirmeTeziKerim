﻿// <auto-generated />
using BitirmeTeziKerim.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BitirmeTeziKerim.Migrations
{
    [DbContext(typeof(BitirmeTeziDbContext))]
    [Migration("20250110110003_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("BitirmeTeziKerim.Models.AdminTablo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("KullaniciIsmi")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sifre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("AdminTablos");
                });

            modelBuilder.Entity("BitirmeTeziKerim.Models.Duyuru", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Aciklama")
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Duyurues");
                });

            modelBuilder.Entity("BitirmeTeziKerim.Models.DuyuruLinkTablo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("KoyulacakLink")
                        .HasColumnType("TEXT");

                    b.Property<string>("KoyulacakLink2")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("DuyuruLinks");
                });

            modelBuilder.Entity("BitirmeTeziKerim.Models.PersonelTablo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AkademikPersonel")
                        .HasColumnType("TEXT");

                    b.Property<string>("IdariPersonel")
                        .HasColumnType("TEXT");

                    b.Property<int>("Sayi")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Sayi1")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sinif")
                        .HasColumnType("TEXT");

                    b.Property<string>("Unvan")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PersonelTablos");
                });

            modelBuilder.Entity("BitirmeTeziKerim.Models.Sayilar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("SayiTablo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sayilars");
                });

            modelBuilder.Entity("BitirmeTeziKerim.Models.SayilarTablo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AkademikBirim")
                        .HasColumnType("TEXT");

                    b.Property<int>("Erkek")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Kadin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OgrenimDuzeyi")
                        .HasColumnType("TEXT");

                    b.Property<int>("SayilarId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Toplam")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("SayilarId");

                    b.ToTable("SayilarTablos");
                });

            modelBuilder.Entity("BitirmeTeziKerim.Models.SayilarTablo", b =>
                {
                    b.HasOne("BitirmeTeziKerim.Models.Sayilar", "Sayilar")
                        .WithMany()
                        .HasForeignKey("SayilarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sayilar");
                });
#pragma warning restore 612, 618
        }
    }
}
