﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhoneBook.DataAccess;

namespace PhoneBook.Migrations
{
    [DbContext(typeof(PhoneBookContext))]
    [Migration("20211207154941_AddAbonentCityFK")]
    partial class AddAbonentCityFK
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhoneBook.DataAccess.Abonent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CityIndex")
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CityIndex");

                    b.ToTable("Abonents");
                });

            modelBuilder.Entity("PhoneBook.DataAccess.City", b =>
                {
                    b.Property<string>("Index")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Index");

                    b.HasIndex("RegionId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("PhoneBook.DataAccess.PhoneNumber", b =>
                {
                    b.Property<string>("Number")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("AbonentId")
                        .HasColumnType("int");

                    b.HasKey("Number");

                    b.HasIndex("AbonentId");

                    b.ToTable("PhoneNumber");
                });

            modelBuilder.Entity("PhoneBook.DataAccess.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("PhoneBook.DataAccess.Abonent", b =>
                {
                    b.HasOne("PhoneBook.DataAccess.City", "City")
                        .WithMany("Abonents")
                        .HasForeignKey("CityIndex");

                    b.Navigation("City");
                });

            modelBuilder.Entity("PhoneBook.DataAccess.City", b =>
                {
                    b.HasOne("PhoneBook.DataAccess.Region", "Region")
                        .WithMany("Cities")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("PhoneBook.DataAccess.PhoneNumber", b =>
                {
                    b.HasOne("PhoneBook.DataAccess.Abonent", "Abonent")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("AbonentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Abonent");
                });

            modelBuilder.Entity("PhoneBook.DataAccess.Abonent", b =>
                {
                    b.Navigation("PhoneNumbers");
                });

            modelBuilder.Entity("PhoneBook.DataAccess.City", b =>
                {
                    b.Navigation("Abonents");
                });

            modelBuilder.Entity("PhoneBook.DataAccess.Region", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
