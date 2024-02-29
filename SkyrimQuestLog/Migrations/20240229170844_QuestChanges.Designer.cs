﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkyrimQuestLog.Data;

#nullable disable

namespace SkyrimQuestLog.Migrations
{
    [DbContext(typeof(SkyrimQuestLogDb))]
    [Migration("20240229170844_QuestChanges")]
    partial class QuestChanges
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SkyrimQuestLog.Models.Quest", b =>
                {
                    b.Property<int>("QuestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuestId"));

                    b.Property<int>("Cities")
                        .HasColumnType("int");

                    b.Property<int>("Faction")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<int>("Main")
                        .HasColumnType("int");

                    b.Property<int>("Mischellaneous")
                        .HasColumnType("int");

                    b.Property<int>("OrcStringholds")
                        .HasColumnType("int");

                    b.Property<int>("Other")
                        .HasColumnType("int");

                    b.Property<string>("QuestDescription")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("QuestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reward")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Settlements")
                        .HasColumnType("int");

                    b.Property<int>("Towns")
                        .HasColumnType("int");

                    b.Property<string>("Walkthrough")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuestId");

                    b.ToTable("Quests");
                });
#pragma warning restore 612, 618
        }
    }
}
