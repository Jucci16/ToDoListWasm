﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoListWasm.Data;

#nullable disable

namespace ToDoListWasm.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220311151702_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ToDoListWasm.Model.ToDoCollectionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ToDoCollection", (string)null);
                });

            modelBuilder.Entity("ToDoListWasm.Model.ToDoItemModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ToDoCollectionModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ToDoCollectionModelId");

                    b.ToTable("ToDoItem", (string)null);
                });

            modelBuilder.Entity("ToDoListWasm.Model.ToDoItemModel", b =>
                {
                    b.HasOne("ToDoListWasm.Model.ToDoCollectionModel", null)
                        .WithMany("Items")
                        .HasForeignKey("ToDoCollectionModelId");
                });

            modelBuilder.Entity("ToDoListWasm.Model.ToDoCollectionModel", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
