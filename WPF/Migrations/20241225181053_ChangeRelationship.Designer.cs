﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WPF.DbContexts;

#nullable disable

namespace WPF.Migrations
{
    [DbContext(typeof(DataModelContext))]
    [Migration("20241225181053_ChangeRelationship")]
    partial class ChangeRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("WPF.DTOs.RequestParametresDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RequestParametresDTO");
                });

            modelBuilder.Entity("WPF.DTOs.ScenarioDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Interval")
                        .HasColumnType("TEXT");

                    b.Property<int>("MaxRate")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RequestParametresId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RequestParametresId");

                    b.ToTable("ScenarioDTO");
                });

            modelBuilder.Entity("WPF.DTOs.ScenarioDTO", b =>
                {
                    b.HasOne("WPF.DTOs.RequestParametresDTO", "RequestParametres")
                        .WithMany("Scenarios")
                        .HasForeignKey("RequestParametresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestParametres");
                });

            modelBuilder.Entity("WPF.DTOs.RequestParametresDTO", b =>
                {
                    b.Navigation("Scenarios");
                });
#pragma warning restore 612, 618
        }
    }
}
