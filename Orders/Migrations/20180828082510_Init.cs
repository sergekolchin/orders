using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Orders.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Date", "Number", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2018, 8, 25, 19, 25, 10, 187, DateTimeKind.Utc), "1", 0 },
                    { 2, new DateTime(2018, 8, 24, 11, 25, 10, 187, DateTimeKind.Utc), "2", 1 },
                    { 3, new DateTime(2018, 8, 17, 14, 25, 10, 187, DateTimeKind.Utc), "3", 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Apple", 4.73m },
                    { 2, "Banana", 4.66m },
                    { 3, "Mango", 3.17m },
                    { 4, "Pineapple", 3.24m },
                    { 5, "Orange", 2.15m }
                });

            migrationBuilder.InsertData(
                table: "OrderLines",
                columns: new[] { "Id", "OrderId", "Price", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 4.73m, 1, 9 },
                    { 7, 3, 4.73m, 1, 8 },
                    { 5, 2, 4.66m, 2, 2 },
                    { 8, 3, 4.66m, 2, 9 },
                    { 2, 1, 3.17m, 3, 6 },
                    { 9, 3, 3.17m, 3, 2 },
                    { 4, 1, 3.24m, 4, 2 },
                    { 3, 1, 2.15m, 5, 2 },
                    { 6, 2, 2.15m, 5, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ProductId",
                table: "OrderLines",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
