﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TreasureFinder.Models;

namespace Treasure.Solution.Migrations
{
    [DbContext(typeof(TreasureFinderContext))]
    [Migration("20210614181838_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TreasureFinder.Models.Image", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ImageString")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("ImageId");

                    b.HasIndex("ItemId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("TreasureFinder.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Adress")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Condition")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Dimensions")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Url")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Weight")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ItemId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("TreasureFinder.Models.Image", b =>
                {
                    b.HasOne("TreasureFinder.Models.Item", null)
                        .WithMany("Images")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TreasureFinder.Models.Item", b =>
                {
                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
