﻿// <auto-generated />
using System;
using AlphabetUpdateServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlphabetUpdateServer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231126133818_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true);

            modelBuilder.Entity("AlphabetUpdateServer.Entities.BucketEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Buckets");
                });

            modelBuilder.Entity("AlphabetUpdateServer.Entities.BucketFileEntity", b =>
                {
                    b.Property<string>("BucketId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .HasColumnType("TEXT");

                    b.Property<string>("BucketEntityId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Checksum")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("TEXT");

                    b.Property<long>("Size")
                        .HasColumnType("INTEGER");

                    b.HasKey("BucketId", "Path");

                    b.HasIndex("BucketEntityId");

                    b.ToTable("BucketFiles");
                });

            modelBuilder.Entity("AlphabetUpdateServer.Entities.FileChecksumEntity", b =>
                {
                    b.Property<string>("Checksum")
                        .HasColumnType("TEXT");

                    b.Property<string>("Repository")
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Checksum", "Repository");

                    b.ToTable("Checksums");
                });

            modelBuilder.Entity("AlphabetUpdateServer.Entities.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BucketEntityUserEntity", b =>
                {
                    b.Property<string>("BucketsId")
                        .HasColumnType("TEXT");

                    b.Property<string>("OwnersId")
                        .HasColumnType("TEXT");

                    b.HasKey("BucketsId", "OwnersId");

                    b.HasIndex("OwnersId");

                    b.ToTable("BucketEntityUserEntity");
                });

            modelBuilder.Entity("AlphabetUpdateServer.Entities.BucketFileEntity", b =>
                {
                    b.HasOne("AlphabetUpdateServer.Entities.BucketEntity", null)
                        .WithMany("Files")
                        .HasForeignKey("BucketEntityId");
                });

            modelBuilder.Entity("BucketEntityUserEntity", b =>
                {
                    b.HasOne("AlphabetUpdateServer.Entities.BucketEntity", null)
                        .WithMany()
                        .HasForeignKey("BucketsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlphabetUpdateServer.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("OwnersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AlphabetUpdateServer.Entities.BucketEntity", b =>
                {
                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}
