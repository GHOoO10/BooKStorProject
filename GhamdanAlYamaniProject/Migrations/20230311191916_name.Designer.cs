﻿// <auto-generated />
using System;
using GhamdanAlYamaniProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GhamdanAlYamaniProject.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    [Migration("20230311191916_name")]
    partial class name
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GhamdanAlYamaniProject.Models.Admin", b =>
                {
                    b.Property<int>("A_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("A_Id"), 1L, 1);

                    b.Property<string>("A_Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("A_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("A_Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("A_Id");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("GhamdanAlYamaniProject.Models.Books", b =>
                {
                    b.Property<int>("B_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("B_Id"), 1L, 1);

                    b.Property<int>("A_Id")
                        .HasColumnType("int");

                    b.Property<string>("B_Author")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("B_Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("B_Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("B_Price")
                        .HasColumnType("int");

                    b.Property<int>("Cat_Id")
                        .HasColumnType("int");

                    b.HasKey("B_Id");

                    b.HasIndex("A_Id");

                    b.HasIndex("Cat_Id");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("GhamdanAlYamaniProject.Models.BookStor", b =>
                {
                    b.Property<int>("BS_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BS_Id"), 1L, 1);

                    b.Property<DateTime>("BS_Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("BS_Num")
                        .HasColumnType("int");

                    b.Property<int>("BS_Type")
                        .HasColumnType("int");

                    b.Property<int>("B_Id")
                        .HasColumnType("int");

                    b.HasKey("BS_Id");

                    b.HasIndex("B_Id");

                    b.ToTable("BookStors");
                });

            modelBuilder.Entity("GhamdanAlYamaniProject.Models.Catagory", b =>
                {
                    b.Property<int>("Cat_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Cat_Id"), 1L, 1);

                    b.Property<string>("Cat_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cat_Id");

                    b.ToTable("Catagorys");
                });

            modelBuilder.Entity("GhamdanAlYamaniProject.Models.Customer", b =>
                {
                    b.Property<int>("C_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("C_Id"), 1L, 1);

                    b.Property<string>("C_Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("C_Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("C_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("C_Phone")
                        .HasColumnType("int");

                    b.HasKey("C_Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("GhamdanAlYamaniProject.Models.Orders", b =>
                {
                    b.Property<int>("O_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("O_Id"), 1L, 1);

                    b.Property<int>("B_Id")
                        .HasColumnType("int");

                    b.Property<int>("C_Id")
                        .HasColumnType("int");

                    b.Property<int>("O_Amount")
                        .HasColumnType("int");

                    b.Property<string>("O_Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("O_Id");

                    b.HasIndex("B_Id");

                    b.HasIndex("C_Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("GhamdanAlYamaniProject.Models.Books", b =>
                {
                    b.HasOne("GhamdanAlYamaniProject.Models.Admin", "Admins")
                        .WithMany()
                        .HasForeignKey("A_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GhamdanAlYamaniProject.Models.Catagory", "Catagorys")
                        .WithMany("Book")
                        .HasForeignKey("Cat_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admins");

                    b.Navigation("Catagorys");
                });

            modelBuilder.Entity("GhamdanAlYamaniProject.Models.BookStor", b =>
                {
                    b.HasOne("GhamdanAlYamaniProject.Models.Books", "Book")
                        .WithMany("BookStors")
                        .HasForeignKey("B_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("GhamdanAlYamaniProject.Models.Orders", b =>
                {
                    b.HasOne("GhamdanAlYamaniProject.Models.Books", "Book")
                        .WithMany("Order")
                        .HasForeignKey("B_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GhamdanAlYamaniProject.Models.Customer", "Customers")
                        .WithMany("Order")
                        .HasForeignKey("C_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("GhamdanAlYamaniProject.Models.Books", b =>
                {
                    b.Navigation("BookStors");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("GhamdanAlYamaniProject.Models.Catagory", b =>
                {
                    b.Navigation("Book");
                });

            modelBuilder.Entity("GhamdanAlYamaniProject.Models.Customer", b =>
                {
                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
