﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentManagement.Services;

#nullable disable

namespace StudentManagement.Migrations
{
    [DbContext(typeof(StudentDbContextService))]
    partial class StudentDbContextServiceModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentManagement.Models.BillHistoryDb", b =>
                {
                    b.Property<int>("SeqNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeqNo"));

                    b.Property<double>("AmountPaid")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("InvoiceDate")
                        .HasColumnType("date");

                    b.Property<string>("InvoiceNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RollNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SeqNo");

                    b.ToTable("BillHistoryTable");
                });

            modelBuilder.Entity("StudentManagement.Models.PendingFeesDb", b =>
                {
                    b.Property<int>("SeqNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeqNo"));

                    b.Property<double>("ActualFee")
                        .HasColumnType("float");

                    b.Property<double>("BalanceFee")
                        .HasColumnType("float");

                    b.Property<double>("PaidFee")
                        .HasColumnType("float");

                    b.Property<string>("RegNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("standard")
                        .HasColumnType("int");

                    b.Property<string>("studentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SeqNo");

                    b.ToTable("PendingFeesTable");
                });
#pragma warning restore 612, 618
        }
    }
}
