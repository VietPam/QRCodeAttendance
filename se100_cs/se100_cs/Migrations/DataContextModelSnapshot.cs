﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using se100_cs.Model;

#nullable disable

namespace se100_cs.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("se100_cs.Model.SqlAttendance", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<long>("employeeID")
                        .HasColumnType("bigint");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.Property<DateTime>("time")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ID");

                    b.HasIndex("employeeID");

                    b.ToTable("tb_attendance");
                });

            modelBuilder.Entity("se100_cs.Model.SqlDepartment", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("tb_department");
                });

            modelBuilder.Entity("se100_cs.Model.SqlEmployee", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("avatar")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("birth_day")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("cmnd")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("departmentID")
                        .HasColumnType("bigint");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("gender")
                        .HasColumnType("boolean");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("positionID")
                        .HasColumnType("bigint");

                    b.Property<int?>("role")
                        .HasColumnType("integer");

                    b.Property<string>("token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("departmentID");

                    b.HasIndex("positionID");

                    b.ToTable("tb_employee");
                });

            modelBuilder.Entity("se100_cs.Model.SqlPayroll", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<long?>("employeeID")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("receive_date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("salary")
                        .HasColumnType("bigint");

                    b.HasKey("ID");

                    b.HasIndex("employeeID");

                    b.ToTable("tb_payroll");
                });

            modelBuilder.Entity("se100_cs.Model.SqlPosition", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("departmentID")
                        .HasColumnType("bigint");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<long>("salary_coeffcient")
                        .HasColumnType("bigint");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("departmentID");

                    b.ToTable("tb_position");
                });

            modelBuilder.Entity("se100_cs.Model.SqlRole", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("ID"));

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("tb_role");
                });

            modelBuilder.Entity("se100_cs.Model.SqlAttendance", b =>
                {
                    b.HasOne("se100_cs.Model.SqlEmployee", "employee")
                        .WithMany()
                        .HasForeignKey("employeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");
                });

            modelBuilder.Entity("se100_cs.Model.SqlEmployee", b =>
                {
                    b.HasOne("se100_cs.Model.SqlDepartment", "department")
                        .WithMany()
                        .HasForeignKey("departmentID");

                    b.HasOne("se100_cs.Model.SqlPosition", "position")
                        .WithMany()
                        .HasForeignKey("positionID");

                    b.Navigation("department");

                    b.Navigation("position");
                });

            modelBuilder.Entity("se100_cs.Model.SqlPayroll", b =>
                {
                    b.HasOne("se100_cs.Model.SqlEmployee", "employee")
                        .WithMany()
                        .HasForeignKey("employeeID");

                    b.Navigation("employee");
                });

            modelBuilder.Entity("se100_cs.Model.SqlPosition", b =>
                {
                    b.HasOne("se100_cs.Model.SqlDepartment", "department")
                        .WithMany()
                        .HasForeignKey("departmentID");

                    b.Navigation("department");
                });
#pragma warning restore 612, 618
        }
    }
}
