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

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.orderID);
                
                entity.HasOne<User>(x => x.Users)
                    .WithMany(s => s.Orders)
                    .OnDelete(DeleteBehavior.Restrict);
                
                entity.HasOne<Voucher>(x => x.Vouchers)
                    .WithMany(v => v.Orders)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                // Setting the primary key
                entity.HasKey(e => e.Id);

                // Configure relationships
                entity.HasOne(od => od.Products)
                    .WithMany()
                    .HasForeignKey(od => od.productID)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(od => od.Orders)
                    .WithMany()
                    .HasForeignKey(od => od.orderID)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            
            modelBuilder.Entity<FeedBack>(entity =>
            {
                // Setting the primary key
                entity.HasKey(e => e.feedBackID);
                
                entity.HasOne(o => o.OrderDetail)
                    .WithOne()
                    .HasForeignKey<FeedBack>(o => o.OrderDetailId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<User>()
                .HasOne(u => u.Ranks) // A User has one Rank
                .WithMany(r => r.Users) // A Rank has many Users
                .HasForeignKey(u => u.rankID) // Foreign key in User table
                .OnDelete(DeleteBehavior.Restrict); // Set delete behavior to Restrict

            modelBuilder.Entity<User>()
                .HasMany<Order>(u => u.Orders)
                .WithOne(o => o.Users)
                .HasForeignKey(o => o.userID)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many Relationship between Role and User
            modelBuilder.Entity<User>()
                .HasOne(u => u.Roles) // A User has one Role
                .WithMany(r => r.Users) // A Role has many Users
                .HasForeignKey(u => u.roleID) // Foreign key in User table
                .OnDelete(DeleteBehavior.Restrict); // Set delete behavior to Restrict
            

            
            modelBuilder.Entity<Rank>().HasData(
                new Rank()
                {
                    rankID = 1,
                    rankName = "RanhCOn",
                    description = "kakak"
                },
                new Rank()
                {
                    rankID = 2,
                    rankName = "RanhCha",
                    description = "kakak"
                },
                new Rank()
                {
                    rankID = 3,
                    rankName = "RanhMom",
                    description = "kakak"
                }
            );
            
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    roleID = 1,
                    roleName = "User",
                    description = "User"
                },
                new Role()
                {
                    roleID = 2,
                    roleName = "Admin",
                    description = "Admin"
                },
                new Role()
                {
                    roleID = 3,
                    roleName = "Shipper",
                    description = "Shipper"
                },
                new Role()
                {
                    roleID = 4,
                    roleName = "Manager",
                    description = "Manager"
                }
            );
            
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    rankID = 1,
                    roleID = 1,
                    address = "BienHoa",
                    email = "email@gmail.com",
                    password = "123123123",
                    yob = new DateTime(1990, 1, 1),
                    point = 100,
                    phoneNumber = "1231231231",
                    userID = "123123",
                    userName = "user1",
                },
                new User()
                {
                    rankID = 1,
                    roleID = 1,
                    address = "BienHoa",
                    email = "email@gmail.com",
                    password = "123123123",
                    yob = new DateTime(1990, 1, 1),
                    point = 100,
                    phoneNumber = "1231231231",
                    userID = "123126",
                    userName = "user6",
                },
                new User()
                {
                    rankID = 1,
                    roleID = 2,
                    address = "BienHoa",
                    email = "email@gmail.com",
                    password = "123123123",
                    yob = new DateTime(1990, 1, 1),
                    point = 100,
                    phoneNumber = "1231231231",
                    userID = "123124",
                    userName = "user4",
                },
                new User()
                {
                    rankID = 1,
                    roleID = 3,
                    address = "BienHoa",
                    email = "email@gmail.com",
                    password = "123123123",
                    yob = new DateTime(1990, 1, 1),
                    point = 100,
                    phoneNumber = "1231231231",
                    userID = "123125",
                    userName = "user5",
                }
            );
            
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductID = "product1",
                    ProductName = "Trà sữa đài loan",
                    ProductDescription = "Trà Sữa Đài Loan rất là ngon",
                    ProductType = 0,
                    Price = 100000,
                    Quantity = 100,
                    Status = true,
                    Imgs = "image1.jpg"
                },
                new Product
                {
                    ProductID = "product2",
                    ProductName = "Trà sữa Thái",
                    ProductDescription = "Trà Sữa Thái hương vị độc đáo",
                    ProductType = 1,
                    Price = 90000,
                    Quantity = 120,
                    Status = true,
                    Imgs = "image2.jpg"
                },
                new Product
                {
                    ProductID = "product3",
                    ProductName = "Trà đào cam sả",
                    ProductDescription = "Hương vị tươi mới và sảng khoái",
                    ProductType = 1,
                    Price = 80000,
                    Quantity = 150,
                    Status = true,
                    Imgs = "image3.jpg"
                },
                new Product
                {
                    ProductID = "product4",
                    ProductName = "Trà sữa Matcha",
                    ProductDescription = "Vị trà xanh thanh mát",
                    ProductType = 2,
                    Price = 110000,
                    Quantity = 90,
                    Status = true,
                    Imgs = "image4.jpg"
                },
                new Product
                {
                    ProductID = "product5",
                    ProductName = "Trà sữa Hokkaido",
                    ProductDescription = "Hương vị Nhật Bản độc đáo",
                    ProductType = 2,
                    Price = 120000,
                    Quantity = 80,
                    Status = true,
                    Imgs = "image5.jpg"
                },
                new Product
                {
                    ProductID = "product6",
                    ProductName = "Trà sữa Okinawa",
                    ProductDescription = "Hương vị trà sữa đậm đà",
                    ProductType = 2,
                    Price = 115000,
                    Quantity = 70,
                    Status = true,
                    Imgs = "image6.jpg"
                },
                new Product
                {
                    ProductID = "product7",
                    ProductName = "Trà sữa dâu tây",
                    ProductDescription = "Vị dâu tây thơm ngon",
                    ProductType = 1,
                    Price = 95000,
                    Quantity = 110,
                    Status = true,
                    Imgs = "image7.jpg"
                },
                new Product
                {
                    ProductID = "product8",
                    ProductName = "Trà sữa socola",
                    ProductDescription = "Hương vị socola béo ngậy",
                    ProductType = 0,
                    Price = 105000,
                    Quantity = 100,
                    Status = true,
                    Imgs = "image8.jpg"
                },
                new Product
                {
                    ProductID = "product9",
                    ProductName = "Trà sữa caramel",
                    ProductDescription = "Hương vị caramel ngọt ngào",
                    ProductType = 0,
                    Price = 95000,
                    Quantity = 130,
                    Status = true,
                    Imgs = "image9.jpg"
                },
                new Product
                {
                    ProductID = "product10",
                    ProductName = "Trà sữa bạc hà",
                    ProductDescription = "Hương vị bạc hà mát lạnh",
                    ProductType = 1,
                    Price = 90000,
                    Quantity = 140,
                    Status = true,
                    Imgs = "image10.jpg"
                },
                new Product
                {
                    ProductID = "product11",
                    ProductName = "Trà sữa vị nhãn",
                    ProductDescription = "Hương vị nhãn thanh ngọt",
                    ProductType = 1,
                    Price = 85000,
                    Quantity = 150,
                    Status = true,
                    Imgs = "image11.jpg"
                },
                new Product
                {
                    ProductID = "product12",
                    ProductName = "Trà sữa vị vải",
                    ProductDescription = "Hương vị vải thanh mát",
                    ProductType = 0,
                    Price = 88000,
                    Quantity = 120,
                    Status = true,
                    Imgs = "image12.jpg"
                },
                new Product
                {
                    ProductID = "product13",
                    ProductName = "Trà sữa vị dưa lưới",
                    ProductDescription = "Hương vị dưa lưới thanh mát",
                    ProductType = 0,
                    Price = 93000,
                    Quantity = 130,
                    Status = true,
                    Imgs = "image13.jpg"
                },
                new Product
                {
                    ProductID = "product14",
                    ProductName = "Trà sữa vị táo",
                    ProductDescription = "Hương vị táo ngọt ngào",
                    ProductType = 0,
                    Price = 90000,
                    Quantity = 110,
                    Status = true,
                    Imgs = "image14.jpg"
                },
                new Product
                {
                    ProductID = "product15",
                    ProductName = "Trà sữa vị dứa",
                    ProductDescription = "Hương vị dứa nhiệt đới",
                    ProductType = 1,
                    Price = 89000,
                    Quantity = 140,
                    Status = true,
                    Imgs = "image15.jpg"
                },
                new Product
                {
                    ProductID = "product16",
                    ProductName = "Trà sữa vị xoài",
                    ProductDescription = "Hương vị xoài nhiệt đới",
                    ProductType = 1,
                    Price = 92000,
                    Quantity = 125,
                    Status = true,
                    Imgs = "image16.jpg"
                },
                new Product
                {
                    ProductID = "product17",
                    ProductName = "Trà sữa vị nho",
                    ProductDescription = "Hương vị nho ngọt ngào",
                    ProductType = 2,
                    Price = 98000,
                    Quantity = 115,
                    Status = true,
                    Imgs = "image17.jpg"
                },
                new Product
                {
                    ProductID = "product18",
                    ProductName = "Trà sữa vị dừa",
                    ProductDescription = "Hương vị dừa béo ngậy",
                    ProductType = 2,
                    Price = 97000,
                    Quantity = 135,
                    Status = true,
                    Imgs = "image18.jpg"
                },
                new Product
                {
                    ProductID = "product19",
                    ProductName = "Trà sữa vị chanh dây",
                    ProductDescription = "Hương vị chanh dây thanh mát",
                    ProductType = 1,
                    Price = 94000,
                    Quantity = 120,
                    Status = true,
                    Imgs = "image19.jpg"
                },
                new Product
                {
                    ProductID = "product20",
                    ProductName = "Trà sữa vị sầu riêng",
                    ProductDescription = "Hương vị sầu riêng độc đáo",
                    ProductType = 2,
                    Price = 130000,
                    Quantity = 100,
                    Status = true,
                    Imgs = "image20.jpg"
                },
                new Product
                {
                    ProductID = "product21",
                    ProductName = "Trà sữa vị đào",
                    ProductDescription = "Hương vị đào thanh mát",
                    ProductType = 0,
                    Price = 85000,
                    Quantity = 140,
                    Status = true,
                    Imgs = "image21.jpg"
                },
                new Product
                {
                    ProductID = "product22",
                    ProductName = "Trà sữa vị kiwi",
                    ProductDescription = "Hương vị kiwi thanh mát",
                    ProductType = 0,
                    Price = 89000,
                    Quantity = 130,
                    Status = true,
                    Imgs = "image22.jpg"
                },
                new Product
                {
                    ProductID = "product23",
                    ProductName = "Trà sữa vị cam",
                    ProductDescription = "Hương vị cam tươi mát",
                    ProductType = 1,
                    Price = 92000,
                    Quantity = 125,
                    Status = true,
                    Imgs = "image23.jpg"
                },
                new Product
                {
                    ProductID = "product24",
                    ProductName = "Trà sữa vị bưởi",
                    ProductDescription = "Hương vị bưởi thanh mát",
                    ProductType = 1,
                    Price = 95000,
                    Quantity = 110,
                    Status = true,
                    Imgs = "image24.jpg"
                },
                new Product
                {
                    ProductID = "product25",
                    ProductName = "Trà sữa vị mâm xôi",
                    ProductDescription = "Hương vị mâm xôi ngọt ngào",
                    ProductType = 2,
                    Price = 98000,
                    Quantity = 135,
                    Status = true,
                    Imgs = "image25.jpg"
                },
                new Product
                {
                    ProductID = "product26",
                    ProductName = "Trà sữa vị cherry",
                    ProductDescription = "Hương vị cherry ngọt ngào",
                    ProductType = 2,
                    Price = 99000,
                    Quantity = 115,
                    Status = true,
                    Imgs = "image26.jpg"
                },
                new Product
                {
                    ProductID = "product27",
                    ProductName = "Trà sữa vị dâu rừng",
                    ProductDescription = "Hương vị dâu rừng thanh mát",
                    ProductType = 0,
                    Price = 90000,
                    Quantity = 140,
                    Status = true,
                    Imgs = "image27.jpg"
                },
                new Product
                {
                    ProductID = "product28",
                    ProductName = "Trà sữa vị lê",
                    ProductDescription = "Hương vị lê thanh mát",
                    ProductType = 0,
                    Price = 91000,
                    Quantity = 120,
                    Status = true,
                    Imgs = "image28.jpg"
                },
                new Product
                {
                    ProductID = "product29",
                    ProductName = "Trà sữa vị chuối",
                    ProductDescription = "Hương vị chuối béo ngậy",
                    ProductType = 1,
                    Price = 92000,
                    Quantity = 115,
                    Status = true,
                    Imgs = "image29.jpg"
                },
                new Product
                {
                    ProductID = "product30",
                    ProductName = "Trà sữa vị dâu tây",
                    ProductDescription = "Hương vị dâu tây ngọt ngào",
                    ProductType = 1,
                    Price = 93000,
                    Quantity = 130,
                    Status = true,
                    Imgs = "image30.jpg"
                }
            );
            
            
            modelBuilder.Entity<Order>().HasData(
    new Order()
    {
        orderID = new Guid("11111111-1111-1111-1111-111111111111"), // Correct GUID format
        userID = "123123",
        total = 1000000,
        shipperID = "123125",
        status = 1,
        note = "notenote",
    },
    new Order()
    {
        orderID = new Guid("22222222-2222-2222-2222-222222222222"), // Correct GUID format
        userID = "123123",
        total = 1500000,
        shipperID = "123125",
        status = 1,
        note = "notenote",
    },
    new Order()
    {
        orderID = new Guid("33333333-3333-3333-3333-333333333333"), // Correct GUID format
        userID = "123126",
        total = 1500000,
        shipperID = "123125",
        status = 1,
        note = "notenote",
    }
);

modelBuilder.Entity<OrderDetail>().HasData(
    new OrderDetail()
    {
        orderID = new Guid("11111111-1111-1111-1111-111111111111"), // Matching GUID with Order
        productID = "product1",
        quantity = 1,
        note = "Note",
    },
    new OrderDetail()
    {
        orderID = new Guid("11111111-1111-1111-1111-111111111111"), // Matching GUID with Order
        productID = "product2",
        quantity = 1,
        note = "Note",
    },
    new OrderDetail()
    {
        orderID = new Guid("11111111-1111-1111-1111-111111111111"), // Matching GUID with Order
        productID = "product3",
        quantity = 1,
        note = "Note",
    },
    new OrderDetail()
    {
        orderID = new Guid("11111111-1111-1111-1111-111111111111"), // Matching GUID with Order
        productID = "product4",
        quantity = 1,
        note = "Note",
    },
    new OrderDetail()
    {
        orderID = new Guid("33333333-3333-3333-3333-333333333333"), // Matching GUID with Order
        productID = "product3",
        quantity = 1,
        note = "Note",
    },
    new OrderDetail()
    {
        orderID = new Guid("33333333-3333-3333-3333-333333333333"), // Matching GUID with Order
        productID = "product4",
        quantity = 1,
        note = "Note",
    },
    new OrderDetail()
    {
        orderID = new Guid("33333333-3333-3333-3333-333333333333"), // Matching GUID with Order
        productID = "product6",
        quantity = 1,
        note = "Note",
    },
    new OrderDetail()
    {
        orderID = new Guid("22222222-2222-2222-2222-222222222222"), // Matching GUID with Order
        productID = "product5",
        quantity = 1,
        note = "Note",
    },
    new OrderDetail()
    {
        orderID = new Guid("22222222-2222-2222-2222-222222222222"), // Matching GUID with Order
        productID = "product6",
        quantity = 1,
        note = "Note",
    },
    new OrderDetail()
    {
        orderID = new Guid("22222222-2222-2222-2222-222222222222"), // Matching GUID with Order
        productID = "product7",
        quantity = 1,
        note = "Note",
    },
    new OrderDetail()
    {
        orderID = new Guid("22222222-2222-2222-2222-222222222222"), // Matching GUID with Order
        productID = "product8",
        quantity = 1,
        note = "Note",
    }
);

        }
    }
}
