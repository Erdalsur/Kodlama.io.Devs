﻿// <auto-generated />
using Kodlama.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kodlama.Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20220908124500_ProgrammingTechnology")]
    partial class ProgrammingTechnology
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Kodlama.Domain.Entities.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Lessons", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "C#"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Java"
                        });
                });

            modelBuilder.Entity("Kodlama.Domain.Entities.ProgrammingTechnology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("LessonId")
                        .HasColumnType("int")
                        .HasColumnName("LessonId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("ProgrammingTechnologies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LessonId = 1,
                            Name = "WPF"
                        },
                        new
                        {
                            Id = 2,
                            LessonId = 1,
                            Name = "ASP"
                        },
                        new
                        {
                            Id = 3,
                            LessonId = 2,
                            Name = "Spring"
                        });
                });

            modelBuilder.Entity("Kodlama.Domain.Entities.ProgrammingTechnology", b =>
                {
                    b.HasOne("Kodlama.Domain.Entities.Lesson", "Lesson")
                        .WithMany("ProgrammingTechnologies")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("Kodlama.Domain.Entities.Lesson", b =>
                {
                    b.Navigation("ProgrammingTechnologies");
                });
#pragma warning restore 612, 618
        }
    }
}
