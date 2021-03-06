﻿// <auto-generated />
using System;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Blog.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Blog.Models.BlogPost", b =>
                {
                    b.Property<int>("BlogPostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TagListID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("BlogPostId");

                    b.HasIndex("TagListID");

                    b.ToTable("BlogPost");

                    b.HasData(
                        new
                        {
                            BlogPostId = 3,
                            Body = "The app is simple to use, and will help you decide on your best furniture fit.",
                            CreatedAt = new DateTime(2020, 6, 11, 22, 5, 20, 81, DateTimeKind.Local).AddTicks(1372),
                            Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.",
                            Slug = "augmented-reality-ios-application",
                            TagListID = 1,
                            Title = "Augmented Reality iOS Application"
                        },
                        new
                        {
                            BlogPostId = 2,
                            Body = "The app is simple to use, and will help you decide on your best furniture fit.",
                            CreatedAt = new DateTime(2020, 6, 11, 22, 5, 20, 83, DateTimeKind.Local).AddTicks(4394),
                            Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.",
                            Slug = "augmented-reality-ios-application-2",
                            TagListID = 2,
                            Title = "Augmented Reality iOS Application-2"
                        });
                });

            modelBuilder.Entity("Blog.Models.TagList", b =>
                {
                    b.Property<int>("TagListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("TagListId");

                    b.ToTable("TagList");

                    b.HasData(
                        new
                        {
                            TagListId = 1,
                            Name = "iOS"
                        },
                        new
                        {
                            TagListId = 2,
                            Name = "Android"
                        });
                });

            modelBuilder.Entity("Blog.Models.BlogPost", b =>
                {
                    b.HasOne("Blog.Models.TagList", "TagList")
                        .WithMany("BlogPosts")
                        .HasForeignKey("TagListID");
                });
#pragma warning restore 612, 618
        }
    }
}
