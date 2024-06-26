using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessObject.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    productID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    productName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productType = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    imgs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    delete_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    delete_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.productID);
                });

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    rankID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    delete_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    delete_At = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    create_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    delete_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    delete_At = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.roleID);
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
                    create_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    delete_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    delete_At = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    orderID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    shipperID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    voucherID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    total = table.Column<double>(type: "float", nullable: false),
                    create_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    delete_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    delete_At = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    orderID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    productID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.orderID);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_orderID",
                        column: x => x.orderID,
                        principalTable: "Orders",
                        principalColumn: "orderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_productID",
                        column: x => x.productID,
                        principalTable: "Products",
                        principalColumn: "productID",
                        onDelete: ReferentialAction.Restrict);
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
                    create_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    delete_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    delete_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vouchers", x => x.voucherID);
                    table.ForeignKey(
                        name: "FK_Vouchers_Orders_voucherID",
                        column: x => x.voucherID,
                        principalTable: "Orders",
                        principalColumn: "orderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FeedBacks",
                columns: table => new
                {
                    feedBackID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    point = table.Column<int>(type: "int", nullable: false),
                    productID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    create_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    update_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    delete_By = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    create_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    delete_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBacks", x => x.feedBackID);
                    table.ForeignKey(
                        name: "FK_FeedBacks_OrderDetails_productID",
                        column: x => x.productID,
                        principalTable: "OrderDetails",
                        principalColumn: "orderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_productID",
                table: "FeedBacks",
                column: "productID");

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
                name: "IX_Users_rankID",
                table: "Users",
                column: "rankID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_roleID",
                table: "Users",
                column: "roleID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedBacks");

            migrationBuilder.DropTable(
                name: "Vouchers");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Ranks");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
