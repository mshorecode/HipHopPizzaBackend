using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HipHopPizza.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    CustomerEmail = table.Column<string>(type: "text", nullable: false),
                    CustomerPhone = table.Column<int>(type: "integer", nullable: false),
                    OrderTypeId = table.Column<int>(type: "integer", nullable: false),
                    Subtotal = table.Column<decimal>(type: "numeric", nullable: false),
                    Tip = table.Column<decimal>(type: "numeric", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    IsComplete = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DisplayName = table.Column<string>(type: "text", nullable: false),
                    Uid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "https://s3-media0.fl.yelpcdn.com/bphoto/OQpAaFjU-KVpCpljCoHfVQ/o.jpg", "Cheeseburger Pizza", 14m },
                    { 2, "https://cdn.cdkitchen.com/recipes/images/2010/07/11102-1568-mx.jpg", "Cold Veggie Pizza", 10m },
                    { 3, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTSN37d5qV3N4tAsDsCuihjbnWjV1xNccQy0h2TjR9C_Q&s", "Pepperoni Lovers Pizza", 12m },
                    { 4, "https://fatapplesrestaurant.com/cdn/shop/products/five-cheese_800x.jpg?v=1612571720", "Cheese Pizza", 10m },
                    { 5, "https://www.recipetineats.com/wp-content/uploads/2019/01/Baked-Buffalo-Wings_0.jpg", "The Meat Sweats Wings", 22m },
                    { 6, "https://www.smoking-meat.com/image-files/honey-barbecue-smoked-wings-575x384-1-500x375.jpg", "Honey BBQ Wings", 17m },
                    { 7, "https://alldayidreamaboutfood.com/wp-content/uploads/2022/10/Crispy-Cajun-Wings.jpg", "Crispy Cajun Wings", 15m },
                    { 8, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSabgmlhTm0aFVa9CKI41cLw-EGA_A87x7jY-4gqkeTlA&s", "Sweet and Spicy Wings", 20m }
                });

            migrationBuilder.InsertData(
                table: "OrderTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Walk-In" },
                    { 2, "Call-In" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerEmail", "CustomerName", "CustomerPhone", "IsComplete", "OrderDate", "OrderTypeId", "Subtotal", "Tip", "Total" },
                values: new object[,]
                {
                    { 1, "johnnyyourmomcalled@johnnybusiness.net", "Johnny Saniat", -5452, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10m, 10m, 20m },
                    { 2, "keanabusiness@gmail.com", "Keana Cobarde", -1195, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 22m, 5m, 27m },
                    { 3, "uevadrankbaileys4rmashu@yahoo.com", "Greg Markus", -2722, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 26m, 8m, 34m },
                    { 4, "number1grump@outlook.com", "Ryan Shore", -7833, false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 15m, 2m, 17m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "OrderTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
