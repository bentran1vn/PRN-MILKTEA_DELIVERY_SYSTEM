using BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessObject
{
    public class MilkTeaDeliveryDBContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Rank> Ranks { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }
        private static string? GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true).Build();
            return configuration["ConnectionStrings:DefaultConnectionString"];
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Order>()
                .HasOne<User>(x => x.Users)
                .WithMany(s => s.Orders)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<OrderDetail>()
                .HasOne(x => x.Products)
                .WithMany()
                .HasForeignKey(x => x.productID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<FeedBack>()
                .HasOne(x => x.Products)
                .WithMany()
                .HasForeignKey(x => x.productID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>()
                .HasOne<Rank>(x => x.Ranks)
                .WithOne()
                .HasForeignKey<User>(x => x.rankID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<User>()
                .HasOne<Role>(x => x.Roles)
                .WithOne()
                .HasForeignKey<User>(x => x.roleID)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Order>()
                .HasOne<Voucher>(x => x.Vouchers)
                .WithOne()
                .HasForeignKey<Voucher>(x => x.voucherID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
