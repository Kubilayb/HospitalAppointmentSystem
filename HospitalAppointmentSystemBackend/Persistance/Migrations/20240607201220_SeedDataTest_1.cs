using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataTest_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "CreatedDate", "DeletedDate", "Email", "FirstName", "IsActive", "LastName", "Password", "PhoneNumber", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Admin Address", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@example.com", "Admin", false, "User", "adminpassword", "1234567890", null },
                    { 2, "Doctor Address", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "doctor@example.com", "Doctor", false, "User", "doctorpassword", "1234567891", null },
                    { 3, "Patient Address", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "patient@example.com", "Patient", false, "User", "patientpassword", "1234567892", null }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                column: "Id",
                value: 1);

            migrationBuilder.InsertData(
                table: "Doctors",
                column: "Id",
                value: 2);

            migrationBuilder.InsertData(
                table: "Patients",
                column: "Id",
                value: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
