﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductType = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Imgs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    rankID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    delete_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    delete_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.rankID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    roleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    delete_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    delete_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.roleID);
                });

            migrationBuilder.CreateTable(
                name: "Vouchers",
                columns: table => new
                {
                    voucherID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    voucherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    amount = table.Column<double>(type: "float", nullable: false),
                    min = table.Column<double>(type: "float", nullable: false),
                    max = table.Column<double>(type: "float", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    create_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    delete_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    delete_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.voucherID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roleID = table.Column<int>(type: "int", nullable: false),
                    point = table.Column<int>(type: "int", nullable: false),
                    rankID = table.Column<int>(type: "int", nullable: false),
                    yob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    create_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    delete_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    delete_At = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                    table.ForeignKey(
                        name: "FK_Users_Ranks_rankID",
                        column: x => x.rankID,
                        principalTable: "Ranks",
                        principalColumn: "rankID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles_roleID",
                        column: x => x.roleID,
                        principalTable: "Roles",
                        principalColumn: "roleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    orderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    shipperID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    voucherID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    total = table.Column<double>(type: "float", nullable: false),
                    create_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    delete_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    delete_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.orderID);
                    table.ForeignKey(
                        name: "FK_Orders_Users_shipperID",
                        column: x => x.shipperID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Vouchers_voucherID",
                        column: x => x.voucherID,
                        principalTable: "Vouchers",
                        principalColumn: "voucherID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    orderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    productID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_orderID",
                        column: x => x.orderID,
                        principalTable: "Orders",
                        principalColumn: "orderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_productID",
                        column: x => x.productID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeedBacks",
                columns: table => new
                {
                    feedBackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    point = table.Column<int>(type: "int", nullable: false),
                    OrderDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    create_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    update_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    delete_By = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    update_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    delete_At = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBacks", x => x.feedBackID);
                    table.ForeignKey(
                        name: "FK_FeedBacks_OrderDetails_OrderDetailId",
                        column: x => x.OrderDetailId,
                        principalTable: "OrderDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FeedBacks_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CreateAt", "CreateBy", "DeleteAt", "DeleteBy", "Imgs", "Price", "ProductDescription", "ProductName", "ProductType", "Quantity", "Status", "UpdateAt", "UpdateBy" },
                values: new object[,]
                {
                    { "product1", null, null, null, null, "image1.jpg", 100000.0, "Trà Sữa Đài Loan rất là ngon", "Trà sữa đài loan", 0, 100, true, null, null },
                    { "product10", null, null, null, null, "image10.jpg", 90000.0, "Hương vị bạc hà mát lạnh", "Trà sữa bạc hà", 1, 140, true, null, null },
                    { "product11", null, null, null, null, "image11.jpg", 85000.0, "Hương vị nhãn thanh ngọt", "Trà sữa vị nhãn", 1, 150, true, null, null },
                    { "product12", null, null, null, null, "image12.jpg", 88000.0, "Hương vị vải thanh mát", "Trà sữa vị vải", 0, 120, true, null, null },
                    { "product13", null, null, null, null, "image13.jpg", 93000.0, "Hương vị dưa lưới thanh mát", "Trà sữa vị dưa lưới", 0, 130, true, null, null },
                    { "product14", null, null, null, null, "image14.jpg", 90000.0, "Hương vị táo ngọt ngào", "Trà sữa vị táo", 0, 110, true, null, null },
                    { "product15", null, null, null, null, "image15.jpg", 89000.0, "Hương vị dứa nhiệt đới", "Trà sữa vị dứa", 1, 140, true, null, null },
                    { "product16", null, null, null, null, "image16.jpg", 92000.0, "Hương vị xoài nhiệt đới", "Trà sữa vị xoài", 1, 125, true, null, null },
                    { "product17", null, null, null, null, "image17.jpg", 98000.0, "Hương vị nho ngọt ngào", "Trà sữa vị nho", 2, 115, true, null, null },
                    { "product18", null, null, null, null, "image18.jpg", 97000.0, "Hương vị dừa béo ngậy", "Trà sữa vị dừa", 2, 135, true, null, null },
                    { "product19", null, null, null, null, "image19.jpg", 94000.0, "Hương vị chanh dây thanh mát", "Trà sữa vị chanh dây", 1, 120, true, null, null },
                    { "product2", null, null, null, null, "image2.jpg", 90000.0, "Trà Sữa Thái hương vị độc đáo", "Trà sữa Thái", 1, 120, true, null, null },
                    { "product20", null, null, null, null, "image20.jpg", 130000.0, "Hương vị sầu riêng độc đáo", "Trà sữa vị sầu riêng", 2, 100, true, null, null },
                    { "product21", null, null, null, null, "image21.jpg", 85000.0, "Hương vị đào thanh mát", "Trà sữa vị đào", 0, 140, true, null, null },
                    { "product22", null, null, null, null, "image22.jpg", 89000.0, "Hương vị kiwi thanh mát", "Trà sữa vị kiwi", 0, 130, true, null, null },
                    { "product23", null, null, null, null, "image23.jpg", 92000.0, "Hương vị cam tươi mát", "Trà sữa vị cam", 1, 125, true, null, null },
                    { "product24", null, null, null, null, "image24.jpg", 95000.0, "Hương vị bưởi thanh mát", "Trà sữa vị bưởi", 1, 110, true, null, null },
                    { "product25", null, null, null, null, "image25.jpg", 98000.0, "Hương vị mâm xôi ngọt ngào", "Trà sữa vị mâm xôi", 2, 135, true, null, null },
                    { "product26", null, null, null, null, "image26.jpg", 99000.0, "Hương vị cherry ngọt ngào", "Trà sữa vị cherry", 2, 115, true, null, null },
                    { "product27", null, null, null, null, "image27.jpg", 90000.0, "Hương vị dâu rừng thanh mát", "Trà sữa vị dâu rừng", 0, 140, true, null, null },
                    { "product28", null, null, null, null, "image28.jpg", 91000.0, "Hương vị lê thanh mát", "Trà sữa vị lê", 0, 120, true, null, null },
                    { "product29", null, null, null, null, "image29.jpg", 92000.0, "Hương vị chuối béo ngậy", "Trà sữa vị chuối", 1, 115, true, null, null },
                    { "product3", null, null, null, null, "image3.jpg", 80000.0, "Hương vị tươi mới và sảng khoái", "Trà đào cam sả", 1, 150, true, null, null },
                    { "product30", null, null, null, null, "image30.jpg", 93000.0, "Hương vị dâu tây ngọt ngào", "Trà sữa vị dâu tây", 1, 130, true, null, null },
                    { "product4", null, null, null, null, "image4.jpg", 110000.0, "Vị trà xanh thanh mát", "Trà sữa Matcha", 2, 90, true, null, null },
                    { "product5", null, null, null, null, "image5.jpg", 120000.0, "Hương vị Nhật Bản độc đáo", "Trà sữa Hokkaido", 2, 80, true, null, null },
                    { "product6", null, null, null, null, "image6.jpg", 115000.0, "Hương vị trà sữa đậm đà", "Trà sữa Okinawa", 2, 70, true, null, null },
                    { "product7", null, null, null, null, "image7.jpg", 95000.0, "Vị dâu tây thơm ngon", "Trà sữa dâu tây", 1, 110, true, null, null },
                    { "product8", null, null, null, null, "image8.jpg", 105000.0, "Hương vị socola béo ngậy", "Trà sữa socola", 0, 100, true, null, null },
                    { "product9", null, null, null, null, "image9.jpg", 95000.0, "Hương vị caramel ngọt ngào", "Trà sữa caramel", 0, 130, true, null, null }
                });

            migrationBuilder.InsertData(
                table: "Ranks",
                columns: new[] { "rankID", "create_At", "create_By", "delete_At", "delete_By", "description", "rankName", "update_At", "update_By" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "kakak", "RanhCOn", null, null },
                    { 2, null, null, null, null, "kakak", "RanhCha", null, null },
                    { 3, null, null, null, null, "kakak", "RanhMom", null, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "roleID", "create_At", "create_By", "delete_At", "delete_By", "description", "roleName", "update_At", "update_By" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "User", "User", null, null },
                    { 2, null, null, null, null, "Admin", "Admin", null, null },
                    { 3, null, null, null, null, "Shipper", "Shipper", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "userID", "address", "create_At", "create_By", "delete_At", "delete_By", "email", "password", "phoneNumber", "point", "rankID", "roleID", "update_At", "update_By", "userName", "yob" },
                values: new object[,]
                {
                    { "123123", "BienHoa", null, null, null, null, "email@gmail.com", "123123123", "1231231231", 100, 1, 1, null, null, "user1", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "123124", "BienHoa", null, null, null, null, "email@gmail.com", "123123123", "1231231231", 100, 1, 2, null, null, "user4", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "123125", "BienHoa", null, null, null, null, "email@gmail.com", "123123123", "1231231231", 100, 1, 3, null, null, "user5", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "123126", "BienHoa", null, null, null, null, "email@gmail.com", "123123123", "1231231231", 100, 1, 1, null, null, "user6", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "orderID", "create_At", "create_By", "delete_At", "delete_By", "note", "shipperID", "status", "total", "update_At", "update_By", "userID", "voucherID" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, null, null, null, "notenote", "123125", 1, 1000000.0, null, null, "123123", null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), null, null, null, null, "notenote", "123125", 1, 1500000.0, null, null, "123123", null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), null, null, null, null, "notenote", "123125", 1, 1500000.0, null, null, "123126", null }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "note", "orderID", "productID", "quantity" },
                values: new object[,]
                {
                    { new Guid("0399ea72-a887-4607-aea5-57411e9d38da"), "Note", new Guid("22222222-2222-2222-2222-222222222222"), "product6", 1 },
                    { new Guid("040026e5-b535-47ac-9b66-a918f6845996"), "Note", new Guid("33333333-3333-3333-3333-333333333333"), "product6", 1 },
                    { new Guid("2b4a9459-aef5-4af7-bb69-f0466e6ed23a"), "Note", new Guid("33333333-3333-3333-3333-333333333333"), "product4", 1 },
                    { new Guid("34b5c429-6fdf-4b1e-874e-f5574d839beb"), "Note", new Guid("11111111-1111-1111-1111-111111111111"), "product1", 1 },
                    { new Guid("8813041e-0464-4c99-9d52-74c000f27d40"), "Note", new Guid("22222222-2222-2222-2222-222222222222"), "product7", 1 },
                    { new Guid("905918e1-df09-44aa-9231-2011c35eec47"), "Note", new Guid("11111111-1111-1111-1111-111111111111"), "product2", 1 },
                    { new Guid("ad533ef6-a021-4f99-8c56-c3813012bc00"), "Note", new Guid("22222222-2222-2222-2222-222222222222"), "product5", 1 },
                    { new Guid("c73a5cb1-e62a-4eed-b90a-633982f61ebb"), "Note", new Guid("11111111-1111-1111-1111-111111111111"), "product3", 1 },
                    { new Guid("e0013bb4-a635-4d6b-b1bf-ab8605947b62"), "Note", new Guid("33333333-3333-3333-3333-333333333333"), "product3", 1 },
                    { new Guid("e8c0e31b-9d9e-428e-82b0-044d5a8d0e9d"), "Note", new Guid("22222222-2222-2222-2222-222222222222"), "product8", 1 },
                    { new Guid("f4db7eff-4add-490a-8f41-1ed04c2799cd"), "Note", new Guid("11111111-1111-1111-1111-111111111111"), "product4", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_OrderDetailId",
                table: "FeedBacks",
                column: "OrderDetailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_userID",
                table: "FeedBacks",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_orderID",
                table: "OrderDetails",
                column: "orderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_productID",
                table: "OrderDetails",
                column: "productID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_shipperID",
                table: "Orders",
                column: "shipperID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_userID",
                table: "Orders",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_voucherID",
                table: "Orders",
                column: "voucherID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_rankID",
                table: "Users",
                column: "rankID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_roleID",
                table: "Users",
                column: "roleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedBacks");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "Ranks");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
