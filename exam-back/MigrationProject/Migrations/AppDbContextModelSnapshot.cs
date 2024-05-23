﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MigrationProject;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MigrationProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Todo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PriorityId")
                        .HasColumnType("uuid");

                    b.Property<int>("Sort")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("PriorityId");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("Domain.TodoCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CategorySort")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("TodoCategories");
                });

            modelBuilder.Entity("Domain.TodoPriority", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("PriorityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PrioritySort")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("TodoPriorities");
                });

            modelBuilder.Entity("Domain.Todo", b =>
                {
                    b.HasOne("Domain.TodoCategory", "Category")
                        .WithMany("Todos")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.TodoPriority", "Priority")
                        .WithMany("Todos")
                        .HasForeignKey("PriorityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Priority");
                });

            modelBuilder.Entity("Domain.TodoCategory", b =>
                {
                    b.Navigation("Todos");
                });

            modelBuilder.Entity("Domain.TodoPriority", b =>
                {
                    b.Navigation("Todos");
                });
#pragma warning restore 612, 618
        }
    }
}
