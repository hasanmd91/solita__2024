﻿// <auto-generated />
using System;
using CityBike.WebApi.src.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CityBike.WebApi.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CityBike.Core.src.Entity.Journey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CoveredDistance")
                        .HasColumnType("integer")
                        .HasColumnName("covered_distance");

                    b.Property<DateTime>("DepartureDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("departure_date_time");

                    b.Property<int>("DepartureStationId")
                        .HasColumnType("integer")
                        .HasColumnName("departure_station_id");

                    b.Property<int>("Duration")
                        .HasColumnType("integer")
                        .HasColumnName("duration");

                    b.Property<DateTime>("ReturnDateTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("return_date_time");

                    b.Property<int>("ReturnStationId")
                        .HasColumnType("integer")
                        .HasColumnName("return_station_id");

                    b.HasKey("Id")
                        .HasName("pk_journeys");

                    b.ToTable("journeys", (string)null);
                });

            modelBuilder.Entity("CityBike.Core.src.Entity.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("X")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("x");

                    b.Property<string>("Y")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("y");

                    b.HasKey("Id")
                        .HasName("pk_stations");

                    b.ToTable("stations", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
