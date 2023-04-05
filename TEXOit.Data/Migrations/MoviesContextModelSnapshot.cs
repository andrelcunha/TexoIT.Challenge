﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TEXOit.Data;

#nullable disable

namespace TEXOit.Data.Migrations
{
    [DbContext(typeof(MovieContext))]
    partial class MoviesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.15");

            modelBuilder.Entity("MovieProducer", b =>
                {
                    b.Property<int>("MoviesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProducersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MoviesId", "ProducersId");

                    b.HasIndex("ProducersId");

                    b.ToTable("MovieProducer");
                });

            modelBuilder.Entity("MovieStudio", b =>
                {
                    b.Property<int>("MoviesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudiosId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MoviesId", "StudiosId");

                    b.HasIndex("StudiosId");

                    b.ToTable("MovieStudio");
                });

            modelBuilder.Entity("TEXOit.Core.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<bool>("Winner")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Movies", (string)null);
                });

            modelBuilder.Entity("TEXOit.Core.Models.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Producers", (string)null);
                });

            modelBuilder.Entity("TEXOit.Core.Models.Studio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Studios", (string)null);
                });

            modelBuilder.Entity("MovieProducer", b =>
                {
                    b.HasOne("TEXOit.Core.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .IsRequired();

                    b.HasOne("TEXOit.Core.Models.Producer", null)
                        .WithMany()
                        .HasForeignKey("ProducersId")
                        .IsRequired();
                });

            modelBuilder.Entity("MovieStudio", b =>
                {
                    b.HasOne("TEXOit.Core.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .IsRequired();

                    b.HasOne("TEXOit.Core.Models.Studio", null)
                        .WithMany()
                        .HasForeignKey("StudiosId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
