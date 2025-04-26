using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CoreFuels.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Calories", "Carbohydrates", "Fats", "Name", "Proteins" },
                values: new object[,]
                {
                    { 1, "52", 14.0, 0.20000000000000001, "Apple", 0.29999999999999999 },
                    { 2, "96", 27.0, 0.29999999999999999, "Banana", 1.3 },
                    { 3, "165", 0.0, 3.6000000000000001, "Chicken Breast", 31.0 },
                    { 4, "130", 28.0, 0.29999999999999999, "Rice", 2.7000000000000002 },
                    { 5, "68", 0.59999999999999998, 4.7999999999999998, "Egg", 5.5 },
                    { 6, "42", 5.0, 1.0, "Milk", 3.3999999999999999 },
                    { 7, "265", 49.0, 3.2000000000000002, "Bread", 9.0 },
                    { 8, "402", 1.3, 33.0, "Cheese", 25.0 },
                    { 9, "18", 3.8999999999999999, 0.20000000000000001, "Tomato", 0.90000000000000002 },
                    { 10, "77", 17.0, 0.10000000000000001, "Potato", 2.0 },
                    { 11, "41", 10.0, 0.20000000000000001, "Carrot", 0.90000000000000002 },
                    { 12, "47", 12.0, 0.10000000000000001, "Orange", 0.90000000000000002 },
                    { 13, "250", 0.0, 15.0, "Beef", 26.0 },
                    { 14, "208", 0.0, 13.0, "Fish (Salmon)", 20.0 },
                    { 15, "59", 3.6000000000000001, 0.40000000000000002, "Yogurt", 10.0 },
                    { 16, "50", 13.0, 0.10000000000000001, "Pineapple", 0.5 },
                    { 17, "32", 7.7000000000000002, 0.29999999999999999, "Strawberry", 0.69999999999999996 },
                    { 18, "131", 25.0, 1.1000000000000001, "Pasta", 5.0 },
                    { 19, "717", 0.10000000000000001, 81.0, "Butter", 0.90000000000000002 },
                    { 20, "15", 2.8999999999999999, 0.20000000000000001, "Lettuce", 1.3999999999999999 },
                    { 21, "16", 3.6000000000000001, 0.10000000000000001, "Cucumber", 0.59999999999999998 },
                    { 22, "304", 82.400000000000006, 0.0, "Honey", 0.29999999999999999 },
                    { 23, "654", 14.0, 65.0, "Walnuts", 15.0 },
                    { 24, "579", 22.0, 50.0, "Almonds", 21.0 },
                    { 25, "546", 61.0, 31.0, "Chocolate", 7.0 },
                    { 26, "22", 3.2999999999999998, 0.29999999999999999, "Mushrooms", 3.1000000000000001 },
                    { 27, "588", 20.0, 50.0, "Peanut Butter", 25.0 },
                    { 28, "160", 9.0, 15.0, "Avocado", 2.0 },
                    { 29, "57", 14.5, 0.29999999999999999, "Blueberries", 0.69999999999999996 },
                    { 30, "389", 66.299999999999997, 6.9000000000000004, "Oats", 16.899999999999999 },
                    { 31, "23", 3.6000000000000001, 0.40000000000000002, "Spinach", 2.8999999999999999 },
                    { 32, "354", 15.199999999999999, 33.5, "Coconut", 3.2999999999999998 },
                    { 33, "69", 18.100000000000001, 0.20000000000000001, "Grapes", 0.69999999999999996 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 33);
        }
    }
}
