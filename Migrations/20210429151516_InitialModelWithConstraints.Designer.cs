﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using real_estate_market.Persistence;

namespace real_estate_market.Migrations
{
    [DbContext(typeof(RealEstateDbContext))]
    [Migration("20210429151516_InitialModelWithConstraints")]
    partial class InitialModelWithConstraints
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("real_estate_market.Models.Cladding", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Cladding");
                });

            modelBuilder.Entity("real_estate_market.Models.RealEstate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<float>("Area")
                        .HasColumnType("real");

                    b.Property<int>("CladdingId")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CladdingId");

                    b.ToTable("RealEstates");
                });

            modelBuilder.Entity("real_estate_market.Models.RealEstate", b =>
                {
                    b.HasOne("real_estate_market.Models.Cladding", "Cladding")
                        .WithMany("RealEstates")
                        .HasForeignKey("CladdingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cladding");
                });

            modelBuilder.Entity("real_estate_market.Models.Cladding", b =>
                {
                    b.Navigation("RealEstates");
                });
#pragma warning restore 612, 618
        }
    }
}
