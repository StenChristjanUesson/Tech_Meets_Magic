﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechMeetsMagic.Data;

#nullable disable

namespace TechMeetsMagic.Data.Migrations
{
    [DbContext(typeof(TechMeetsMagicContext))]
    [Migration("20241113114805_DataMigration7")]
    partial class DataMigration7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TechMeetsMagic.Core.Domain.FileToDatabase", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("ImageData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("NpcId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("FilesToDatabase");
                });

            modelBuilder.Entity("TechMeetsMagic.Core.Domain.NPC", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("NPCAttackDamage")
                        .HasColumnType("int");

                    b.Property<int>("NPCCurrentHP")
                        .HasColumnType("int");

                    b.Property<string>("NPCDescribtion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NPCLevel")
                        .HasColumnType("int");

                    b.Property<int>("NPCMaxHP")
                        .HasColumnType("int");

                    b.Property<string>("NPCName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NPCStatus")
                        .HasColumnType("int");

                    b.Property<int>("NpcType")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("NPCs");
                });
#pragma warning restore 612, 618
        }
    }
}