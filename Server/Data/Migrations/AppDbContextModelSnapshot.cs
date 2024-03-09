﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Server.Data;

#nullable disable

namespace Server.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.2");

            modelBuilder.Entity("Server.Data.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Enabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT");

                    b.Property<string>("Ingredients")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TimeToPrepare")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Recipes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Description",
                            Enabled = false,
                            Image = "image1.png",
                            Ingredients = "[\"Ing1\",\"ing2\"]",
                            TimeToPrepare = 20,
                            Title = "Recipe 1",
                            Type = "Breakfast"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Description",
                            Enabled = false,
                            Image = "image1.png",
                            Ingredients = "[\"Ing1\",\"ing2\"]",
                            TimeToPrepare = 20,
                            Title = "Recipe 2",
                            Type = "Breakfast"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Description",
                            Enabled = false,
                            Image = "image1.png",
                            Ingredients = "[\"Ing1\",\"ing2\"]",
                            TimeToPrepare = 20,
                            Title = "Recipe 3",
                            Type = "Breakfast"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Description",
                            Enabled = false,
                            Image = "image1.png",
                            Ingredients = "[\"Ing1\",\"ing2\"]",
                            TimeToPrepare = 20,
                            Title = "Recipe 4",
                            Type = "Breakfast"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Description",
                            Enabled = false,
                            Image = "image1.png",
                            Ingredients = "[\"Ing1\",\"ing2\"]",
                            TimeToPrepare = 20,
                            Title = "Recipe 5",
                            Type = "Breakfast"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Description",
                            Enabled = false,
                            Image = "image1.png",
                            Ingredients = "[\"Ing1\",\"ing2\"]",
                            TimeToPrepare = 20,
                            Title = "Recipe 6",
                            Type = "Breakfast"
                        });
                });

            modelBuilder.Entity("Server.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "example@mail.com",
                            IsAdmin = false,
                            Password = "hash",
                            Username = "recipemaster1"
                        },
                        new
                        {
                            Id = 2,
                            Email = "example@mail.com",
                            IsAdmin = false,
                            Password = "hash",
                            Username = "recipemaster2"
                        },
                        new
                        {
                            Id = 3,
                            Email = "example@mail.com",
                            IsAdmin = false,
                            Password = "hash",
                            Username = "recipemaster3"
                        },
                        new
                        {
                            Id = 4,
                            Email = "example@mail.com",
                            IsAdmin = false,
                            Password = "hash",
                            Username = "recipemaster4"
                        },
                        new
                        {
                            Id = 5,
                            Email = "example@mail.com",
                            IsAdmin = false,
                            Password = "hash",
                            Username = "recipemaster5"
                        },
                        new
                        {
                            Id = 6,
                            Email = "example@mail.com",
                            IsAdmin = false,
                            Password = "hash",
                            Username = "recipemaster6"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
