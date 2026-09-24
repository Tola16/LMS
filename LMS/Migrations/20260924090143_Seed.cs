using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LMS.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "BorrowDate",
                table: "BorrowRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 24, 12, 1, 43, 312, DateTimeKind.Local).AddTicks(6162),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 9, 24, 11, 51, 8, 757, DateTimeKind.Local).AddTicks(5147));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Programming" },
                    { 2, "Computer Science" },
                    { 3, "Literature" },
                    { 4, "History" },
                    { 5, "Science" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "Id", "Email", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "ahmed.hassan@example.com", "Ahmed Hassan", "01012345678" },
                    { 2, "sara.mohamed@example.com", "Sara Mohamed", "01123456789" },
                    { 3, "omar.ali@example.com", "Omar Ali", "01234567890" },
                    { 4, "mariam.ibrahim@example.com", "Mariam Ibrahim", "01098765432" },
                    { 5, "youssef.mahmoud@example.com", "Youssef Mahmoud", "01187654321" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "AvailableCopies", "CategoryId", "Price", "PublishedYear", "Title" },
                values: new object[,]
                {
                    { 1, "Robert C. Martin", 5, 1, 35.99m, 2008, "Clean Code" },
                    { 2, "Andrew Hunt", 3, 1, 42.50m, 1999, "The Pragmatic Programmer" },
                    { 3, "Thomas H. Cormen", 4, 2, 55.00m, 2009, "Introduction to Algorithms" },
                    { 4, "Erich Gamma", 2, 2, 48.75m, 1994, "Design Patterns" },
                    { 5, "F. Scott Fitzgerald", 6, 3, 15.99m, 1925, "The Great Gatsby" }
                });

            migrationBuilder.InsertData(
                table: "BorrowRecords",
                columns: new[] { "Id", "BookId", "BorrowDate", "MemberId", "ReturnDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, new DateTime(2026, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, new DateTime(2026, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2026, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2026, 9, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2026, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2026, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BorrowRecords",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BorrowRecords",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BorrowRecords",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BorrowRecords",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BorrowRecords",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BorrowDate",
                table: "BorrowRecords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 9, 24, 11, 51, 8, 757, DateTimeKind.Local).AddTicks(5147),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 9, 24, 12, 1, 43, 312, DateTimeKind.Local).AddTicks(6162));
        }
    }
}
