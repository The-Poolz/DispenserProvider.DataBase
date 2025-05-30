﻿// <auto-generated />
using System;
using DispenserProvider.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DispenserProvider.DataBase.Migrations
{
    [DbContext(typeof(DispenserContext))]
    [Migration("20241119100723_Add-ProviderAddress-To-BuilderDTO")]
    partial class AddProviderAddressToBuilderDTO
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DispenserProvider.DataBase.Models.BuilderDTO", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(36,18)");

                    b.Property<DateTime?>("FinishTime")
                        .HasColumnType("datetime2(0)");

                    b.Property<string>("ProviderAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(42)");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2(0)");

                    b.Property<long>("TransactionDetailId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("TransactionDetailId");

                    b.ToTable("Builders");
                });

            modelBuilder.Entity("DispenserProvider.DataBase.Models.DispenserDTO", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(64)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LogSignature")
                        .IsRequired()
                        .HasColumnType("nvarchar(132)");

                    b.Property<long?>("RefundDetailId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RefundFinishTime")
                        .HasColumnType("datetime2(0)");

                    b.Property<string>("Signature")
                        .HasColumnType("nvarchar(132)");

                    b.Property<string>("UserAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(42)");

                    b.Property<long>("WithdrawalDetailId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("LogSignature");

                    b.HasIndex("RefundDetailId")
                        .IsUnique()
                        .HasFilter("[RefundDetailId] IS NOT NULL");

                    b.HasIndex("Signature")
                        .IsUnique()
                        .HasFilter("[Signature] IS NOT NULL");

                    b.HasIndex("WithdrawalDetailId")
                        .IsUnique();

                    b.ToTable("Dispenser");
                });

            modelBuilder.Entity("DispenserProvider.DataBase.Models.LogDTO", b =>
                {
                    b.Property<string>("Signature")
                        .HasColumnType("nvarchar(132)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2(0)");

                    b.HasKey("Signature");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("DispenserProvider.DataBase.Models.SignatureDTO", b =>
                {
                    b.Property<string>("Signature")
                        .HasColumnType("nvarchar(132)");

                    b.Property<bool>("IsRefund")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ValidFrom")
                        .HasColumnType("datetime2(0)");

                    b.Property<DateTime>("ValidUntil")
                        .HasColumnType("datetime2(0)");

                    b.HasKey("Signature");

                    b.ToTable("Signatures");
                });

            modelBuilder.Entity("DispenserProvider.DataBase.Models.TransactionDetailDTO", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ChainId")
                        .HasColumnType("bigint");

                    b.Property<long>("PoolId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("TransactionDetails");
                });

            modelBuilder.Entity("DispenserProvider.DataBase.Models.BuilderDTO", b =>
                {
                    b.HasOne("DispenserProvider.DataBase.Models.TransactionDetailDTO", "TransactionDetail")
                        .WithMany("Builders")
                        .HasForeignKey("TransactionDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TransactionDetail");
                });

            modelBuilder.Entity("DispenserProvider.DataBase.Models.DispenserDTO", b =>
                {
                    b.HasOne("DispenserProvider.DataBase.Models.LogDTO", "Log")
                        .WithMany("Dispenser")
                        .HasForeignKey("LogSignature")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DispenserProvider.DataBase.Models.TransactionDetailDTO", "RefundDetail")
                        .WithOne()
                        .HasForeignKey("DispenserProvider.DataBase.Models.DispenserDTO", "RefundDetailId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DispenserProvider.DataBase.Models.SignatureDTO", "UserSignature")
                        .WithOne("Dispenser")
                        .HasForeignKey("DispenserProvider.DataBase.Models.DispenserDTO", "Signature")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DispenserProvider.DataBase.Models.TransactionDetailDTO", "WithdrawalDetail")
                        .WithOne("Dispenser")
                        .HasForeignKey("DispenserProvider.DataBase.Models.DispenserDTO", "WithdrawalDetailId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Log");

                    b.Navigation("RefundDetail");

                    b.Navigation("UserSignature");

                    b.Navigation("WithdrawalDetail");
                });

            modelBuilder.Entity("DispenserProvider.DataBase.Models.LogDTO", b =>
                {
                    b.Navigation("Dispenser");
                });

            modelBuilder.Entity("DispenserProvider.DataBase.Models.SignatureDTO", b =>
                {
                    b.Navigation("Dispenser")
                        .IsRequired();
                });

            modelBuilder.Entity("DispenserProvider.DataBase.Models.TransactionDetailDTO", b =>
                {
                    b.Navigation("Builders");

                    b.Navigation("Dispenser")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
