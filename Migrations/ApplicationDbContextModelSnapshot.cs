﻿// <auto-generated />
using System;
using AlphabetUpdateServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlphabetUpdateServer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("AlphabetUpdateServer.Entities.FileChecksumStorageEntity", b =>
                {
                    b.Property<string>("BucketId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsReadyOnly")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(34)
                        .HasColumnType("TEXT");

                    b.HasKey("BucketId", "Id");

                    b.ToTable("ChecksumStorages");

                    b.HasDiscriminator<string>("Type").HasValue("FileChecksumStorageEntity");

                    b.UseTphMappingStrategy();
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

            modelBuilder.Entity("AlphabetUpdateServer.Models.FileLocation", b =>
                {
                    b.Property<string>("Location")
                        .HasColumnType("TEXT");

                    b.Property<string>("Checksum")
                        .HasColumnType("TEXT");

                    b.Property<long>("Size")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Storage")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Location", "Checksum");

                    b.ToTable("Checksums");
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

            modelBuilder.Entity("AlphabetUpdateServer.Entities.RFilesChecksumStorageEntity", b =>
                {
                    b.HasBaseType("AlphabetUpdateServer.Entities.FileChecksumStorageEntity");

                    b.Property<string>("ClientSecret")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("RFilesChecksumStorageEntity");
                });

            modelBuilder.Entity("AlphabetUpdateServer.Entities.BucketFileEntity", b =>
                {
                    b.HasOne("AlphabetUpdateServer.Entities.BucketEntity", null)
                        .WithMany("Files")
                        .HasForeignKey("BucketEntityId");
                });

            modelBuilder.Entity("AlphabetUpdateServer.Entities.FileChecksumStorageEntity", b =>
                {
                    b.HasOne("AlphabetUpdateServer.Entities.BucketEntity", "Bucket")
                        .WithMany("Storages")
                        .HasForeignKey("BucketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bucket");
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

                    b.Navigation("Storages");
                });
#pragma warning restore 612, 618
        }
    }
}
