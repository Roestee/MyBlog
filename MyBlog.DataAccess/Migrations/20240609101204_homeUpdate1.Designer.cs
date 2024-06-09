﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyBlog.DataAccess.Concrete.EntityFrameworkCore.Context;

#nullable disable

namespace MyBlog.DataAccess.Migrations
{
    [DbContext(typeof(MyBlogDbContext))]
    [Migration("20240609101204_homeUpdate1")]
    partial class homeUpdate1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyBlog.Entities.AboutMe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HomeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HomeId")
                        .IsUnique();

                    b.ToTable("AboutMes");
                });

            modelBuilder.Entity("MyBlog.Entities.ContactMe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CVUrl")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HomeId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HomeId")
                        .IsUnique();

                    b.ToTable("ContactMes");
                });

            modelBuilder.Entity("MyBlog.Entities.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AboutMeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SchoolName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AboutMeId");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("MyBlog.Entities.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AboutMeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("JobEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("JobStartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("StillWorking")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("AboutMeId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("MyBlog.Entities.Home", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Home");

                    b.HasData(
                        new
                        {
                            Id = 1
                        });
                });

            modelBuilder.Entity("MyBlog.Entities.MyService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HomeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HomeId")
                        .IsUnique();

                    b.ToTable("MyServices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HomeId = 1
                        });
                });

            modelBuilder.Entity("MyBlog.Entities.MyWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HomeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HomeId")
                        .IsUnique();

                    b.ToTable("MyWorks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HomeId = 1
                        });
                });

            modelBuilder.Entity("MyBlog.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("MyServicesId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("MyServicesId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("MyBlog.Entities.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AboutMeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AboutMeId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("MyBlog.Entities.SocialMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ContactMeId")
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("ContactMeId");

                    b.ToTable("SocialMedias");
                });

            modelBuilder.Entity("MyBlog.Entities.Summary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HomeId")
                        .HasColumnType("int");

                    b.Property<string>("JobPosition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HomeId")
                        .IsUnique();

                    b.ToTable("Summaries");
                });

            modelBuilder.Entity("MyBlog.Entities.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BackgroundImgUrl")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MyWorksId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("WorkUrl")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("MyWorksId");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("MyBlog.Entities.AboutMe", b =>
                {
                    b.HasOne("MyBlog.Entities.Home", "Home")
                        .WithOne("AboutMe")
                        .HasForeignKey("MyBlog.Entities.AboutMe", "HomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Home");
                });

            modelBuilder.Entity("MyBlog.Entities.ContactMe", b =>
                {
                    b.HasOne("MyBlog.Entities.Home", "Home")
                        .WithOne("ContactMe")
                        .HasForeignKey("MyBlog.Entities.ContactMe", "HomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Home");
                });

            modelBuilder.Entity("MyBlog.Entities.Education", b =>
                {
                    b.HasOne("MyBlog.Entities.AboutMe", "AboutMe")
                        .WithMany("Educations")
                        .HasForeignKey("AboutMeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AboutMe");
                });

            modelBuilder.Entity("MyBlog.Entities.Experience", b =>
                {
                    b.HasOne("MyBlog.Entities.AboutMe", "AboutMe")
                        .WithMany("Experiences")
                        .HasForeignKey("AboutMeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AboutMe");
                });

            modelBuilder.Entity("MyBlog.Entities.MyService", b =>
                {
                    b.HasOne("MyBlog.Entities.Home", "Home")
                        .WithOne("MyService")
                        .HasForeignKey("MyBlog.Entities.MyService", "HomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Home");
                });

            modelBuilder.Entity("MyBlog.Entities.MyWork", b =>
                {
                    b.HasOne("MyBlog.Entities.Home", "Home")
                        .WithOne("MyWork")
                        .HasForeignKey("MyBlog.Entities.MyWork", "HomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Home");
                });

            modelBuilder.Entity("MyBlog.Entities.Service", b =>
                {
                    b.HasOne("MyBlog.Entities.MyService", "MyService")
                        .WithMany("Services")
                        .HasForeignKey("MyServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MyService");
                });

            modelBuilder.Entity("MyBlog.Entities.Skill", b =>
                {
                    b.HasOne("MyBlog.Entities.AboutMe", "AboutMe")
                        .WithMany("Skills")
                        .HasForeignKey("AboutMeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AboutMe");
                });

            modelBuilder.Entity("MyBlog.Entities.SocialMedia", b =>
                {
                    b.HasOne("MyBlog.Entities.ContactMe", "ContactMe")
                        .WithMany("SocialMedias")
                        .HasForeignKey("ContactMeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactMe");
                });

            modelBuilder.Entity("MyBlog.Entities.Summary", b =>
                {
                    b.HasOne("MyBlog.Entities.Home", "Home")
                        .WithOne("Summary")
                        .HasForeignKey("MyBlog.Entities.Summary", "HomeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Home");
                });

            modelBuilder.Entity("MyBlog.Entities.Work", b =>
                {
                    b.HasOne("MyBlog.Entities.MyWork", "MyWorks")
                        .WithMany("Works")
                        .HasForeignKey("MyWorksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MyWorks");
                });

            modelBuilder.Entity("MyBlog.Entities.AboutMe", b =>
                {
                    b.Navigation("Educations");

                    b.Navigation("Experiences");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("MyBlog.Entities.ContactMe", b =>
                {
                    b.Navigation("SocialMedias");
                });

            modelBuilder.Entity("MyBlog.Entities.Home", b =>
                {
                    b.Navigation("AboutMe");

                    b.Navigation("ContactMe");

                    b.Navigation("MyService");

                    b.Navigation("MyWork");

                    b.Navigation("Summary");
                });

            modelBuilder.Entity("MyBlog.Entities.MyService", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("MyBlog.Entities.MyWork", b =>
                {
                    b.Navigation("Works");
                });
#pragma warning restore 612, 618
        }
    }
}
