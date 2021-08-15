﻿// <auto-generated />
using System;
using MarsRover.Infrastructure.Persistancy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MarsRover.Api.Migrations
{
    [DbContext(typeof(MarsRoverDbContext))]
    partial class MarsRoverDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MarsRover.Domain.AggregatesModel.PlateauAggregate.Plateau", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Plateau");
                });

            modelBuilder.Entity("MarsRover.Domain.AggregatesModel.RoverAggregate.Rover", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PlateauId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Rover");
                });

            modelBuilder.Entity("MarsRover.Domain.AggregatesModel.PlateauAggregate.Plateau", b =>
                {
                    b.OwnsOne("MarsRover.Domain.AggregatesModel.PlateauAggregate.Size", "Size", b1 =>
                        {
                            b1.Property<Guid>("PlateauId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Height")
                                .HasColumnType("int");

                            b1.Property<int>("Width")
                                .HasColumnType("int");

                            b1.HasKey("PlateauId");

                            b1.ToTable("Plateau");

                            b1.WithOwner()
                                .HasForeignKey("PlateauId");
                        });

                    b.Navigation("Size");
                });

            modelBuilder.Entity("MarsRover.Domain.AggregatesModel.RoverAggregate.Rover", b =>
                {
                    b.OwnsOne("MarsRover.Domain.AggregatesModel.RoverAggregate.Position", "Position", b1 =>
                        {
                            b1.Property<Guid>("RoverId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Direction")
                                .HasColumnType("int");

                            b1.HasKey("RoverId");

                            b1.ToTable("Rover");

                            b1.WithOwner()
                                .HasForeignKey("RoverId");

                            b1.OwnsOne("MarsRover.Domain.AggregatesModel.PlateauAggregate.Coordinate", "Coordinate", b2 =>
                                {
                                    b2.Property<Guid>("PositionRoverId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<int>("X")
                                        .HasColumnType("int");

                                    b2.Property<int>("Y")
                                        .HasColumnType("int");

                                    b2.HasKey("PositionRoverId");

                                    b2.ToTable("Rover");

                                    b2.WithOwner()
                                        .HasForeignKey("PositionRoverId");
                                });

                            b1.Navigation("Coordinate");
                        });

                    b.Navigation("Position");
                });
#pragma warning restore 612, 618
        }
    }
}
