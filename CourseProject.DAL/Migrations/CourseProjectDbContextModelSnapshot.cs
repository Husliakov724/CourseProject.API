﻿using CourseProject.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CourseProject.DAL.Migrations;

[DbContext(typeof(CourseProjectDbContext))]
partial class CourseProjectDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "6.0.35")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

        modelBuilder.Entity("CourseProject.Core.Entities.BackgroundImage", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            b.Property<byte[]>("Bytes")
                .IsRequired()
                .HasColumnType("varbinary(max)");

            b.HasKey("Id");

            b.ToTable("BackgroundImages");
        });

        modelBuilder.Entity("CourseProject.Core.Entities.Indicator", b =>
        {
            b.Property<Guid>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("uniqueidentifier");

            b.Property<string>("Description")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            b.Property<string>("Name")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            b.Property<string>("Unit")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            b.Property<string>("Value")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            b.Property<int>("X")
                .HasColumnType("int");

            b.Property<int>("Y")
                .HasColumnType("int");

            b.HasKey("Id");

            b.ToTable("Indicators");
        });

        modelBuilder.Entity("CourseProject.Core.Entities.IndicatorValue", b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

            b.Property<DateTime>("DateTime")
                .HasColumnType("datetime2");

            b.Property<Guid>("IndicatorId")
                .HasColumnType("uniqueidentifier");

            b.Property<string>("Value")
                .IsRequired()
                .HasColumnType("nvarchar(max)");

            b.HasKey("Id");

            b.HasIndex("IndicatorId");

            b.ToTable("IndicatorValues");
        });

        modelBuilder.Entity("CourseProject.Core.Entities.IndicatorValue", b =>
        {
            b.HasOne("CourseProject.Core.Entities.Indicator", "Indicator")
                .WithMany("IndicatorValues")
                .HasForeignKey("IndicatorId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            b.Navigation("Indicator");
        });

        modelBuilder.Entity("CourseProject.Core.Entities.Indicator", b => { b.Navigation("IndicatorValues"); });
#pragma warning restore 612, 618
    }
}