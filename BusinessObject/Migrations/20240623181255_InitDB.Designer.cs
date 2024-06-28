﻿// <auto-generated />
using System;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessObject.Migrations
{
    [DbContext(typeof(MilkTeaDeliveryDBContext))]
    [Migration("20240623181255_InitDB")]
    partial class InitDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusinessObject.Entities.FeedBack", b =>
                {
                    b.Property<int>("feedBackID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("feedBackID"));

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("create_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("create_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("delete_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("delete_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("point")
                        .HasColumnType("int");

                    b.Property<string>("productID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("update_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("update_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("feedBackID");

                    b.HasIndex("productID");

                    b.ToTable("FeedBacks");
                });

            modelBuilder.Entity("BusinessObject.Entities.Order", b =>
                {
                    b.Property<string>("orderID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("create_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("create_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("delete_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("delete_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shipperID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<double>("total")
                        .HasColumnType("float");

                    b.Property<DateTime>("update_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("update_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("voucherID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("orderID");

                    b.HasIndex("shipperID");

                    b.HasIndex("userID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BusinessObject.Entities.OrderDetail", b =>
                {
                    b.Property<string>("orderID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<string>("productID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("orderID");

                    b.HasIndex("productID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("BusinessObject.Entities.Product", b =>
                {
                    b.Property<string>("productID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("create_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("create_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("delete_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("delete_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imgs")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<string>("productDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("productType")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("update_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("update_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("productID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BusinessObject.Entities.Rank", b =>
                {
                    b.Property<int>("rankID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("rankID"));

                    b.Property<DateTime>("create_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("create_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("delete_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("delete_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("update_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("update_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("rankID");

                    b.ToTable("Ranks");
                });

            modelBuilder.Entity("BusinessObject.Entities.Role", b =>
                {
                    b.Property<int>("roleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roleID"));

                    b.Property<DateTime>("create_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("create_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("delete_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("delete_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("roleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("update_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("update_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("roleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BusinessObject.Entities.User", b =>
                {
                    b.Property<string>("userID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("create_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("create_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("delete_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("delete_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("point")
                        .HasColumnType("int");

                    b.Property<int>("rankID")
                        .HasColumnType("int");

                    b.Property<int>("roleID")
                        .HasColumnType("int");

                    b.Property<DateTime>("update_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("update_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("yob")
                        .HasColumnType("datetime2");

                    b.HasKey("userID");

                    b.HasIndex("rankID")
                        .IsUnique();

                    b.HasIndex("roleID")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BusinessObject.Entities.Voucher", b =>
                {
                    b.Property<string>("voucherID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("create_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("create_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("delete_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("delete_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("max")
                        .HasColumnType("float");

                    b.Property<double>("min")
                        .HasColumnType("float");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("update_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("update_By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("voucherName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("voucherID");

                    b.ToTable("Vouchers");
                });

            modelBuilder.Entity("BusinessObject.Entities.FeedBack", b =>
                {
                    b.HasOne("BusinessObject.Entities.OrderDetail", "Products")
                        .WithMany()
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Products");
                });

            modelBuilder.Entity("BusinessObject.Entities.Order", b =>
                {
                    b.HasOne("BusinessObject.Entities.User", "Shippers")
                        .WithMany()
                        .HasForeignKey("shipperID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObject.Entities.User", "Users")
                        .WithMany("Orders")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Shippers");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BusinessObject.Entities.OrderDetail", b =>
                {
                    b.HasOne("BusinessObject.Entities.Order", "Orders")
                        .WithMany()
                        .HasForeignKey("orderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObject.Entities.Product", "Products")
                        .WithMany()
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("BusinessObject.Entities.User", b =>
                {
                    b.HasOne("BusinessObject.Entities.Rank", "Ranks")
                        .WithOne()
                        .HasForeignKey("BusinessObject.Entities.User", "rankID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("BusinessObject.Entities.Role", "Roles")
                        .WithOne()
                        .HasForeignKey("BusinessObject.Entities.User", "roleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Ranks");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("BusinessObject.Entities.Voucher", b =>
                {
                    b.HasOne("BusinessObject.Entities.Order", null)
                        .WithOne("Vouchers")
                        .HasForeignKey("BusinessObject.Entities.Voucher", "voucherID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("BusinessObject.Entities.Order", b =>
                {
                    b.Navigation("Vouchers")
                        .IsRequired();
                });

            modelBuilder.Entity("BusinessObject.Entities.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}