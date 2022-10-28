﻿// <auto-generated />
using BrewingContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace brewing.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20221028003210_Complete_Model_Migrations")]
    partial class CompleteModelMigrations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc.2.22472.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("brewing.Models.FlavorType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Flavor")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("flavor_type");
                });

            modelBuilder.Entity("brewing.Models.GrainType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("grain_type");
                });

            modelBuilder.Entity("brewing.Models.Hop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("IngredientTypeId")
                        .HasColumnType("integer");

                    b.Property<decimal>("alphaAcid")
                        .HasColumnType("numeric");

                    b.Property<decimal>("betaAcid")
                        .HasColumnType("numeric");

                    b.Property<int>("internationalBitteringUnits")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IngredientTypeId");

                    b.ToTable("hops");
                });

            modelBuilder.Entity("brewing.Models.IngredientType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ingredient_type");
                });

            modelBuilder.Entity("brewing.Models.Hop", b =>
                {
                    b.HasOne("brewing.Models.IngredientType", "IngredientType")
                        .WithMany()
                        .HasForeignKey("IngredientTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IngredientType");
                });
#pragma warning restore 612, 618
        }
    }
}