using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotificationType = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupportRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_BaseUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "BaseUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodType = table.Column<int>(type: "int", nullable: true),
                    InsuranceType = table.Column<int>(type: "int", nullable: true),
                    SocialSecurityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HealthHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Allergies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentMedications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContactPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmergencyContactRelationship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_BaseUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "BaseUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialistLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearsOfExperience = table.Column<int>(type: "int", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_BaseUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "BaseUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Doctors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseUserId = table.Column<int>(type: "int", nullable: true),
                    OperationClaimId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_BaseUsers_BaseUserId",
                        column: x => x.BaseUserId,
                        principalTable: "BaseUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DoctorAvailabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorAvailabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorAvailabilities_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    DoctorAvailabilityId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_DoctorAvailabilities_DoctorAvailabilityId",
                        column: x => x.DoctorAvailabilityId,
                        principalTable: "DoctorAvailabilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "PatientReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientReports_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "BaseUsers",
                columns: new[] { "Id", "Address", "BirthDate", "City", "CreatedDate", "DeletedDate", "Discriminator", "Email", "FirstName", "Gender", "IsDeleted", "LastName", "PasswordHash", "PasswordSalt", "PhoneNumber", "PhotoUrl", "UpdatedDate", "UserType" },
                values: new object[,]
                {
                    { 1, "address", new DateTime(1900, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", "admin", "admin", 1, false, "admin", new byte[] { 17, 220, 85, 167, 115, 224, 158, 234, 118, 133, 129, 173, 213, 178, 100, 199, 210, 135, 239, 200, 218, 107, 179, 128, 81, 184, 86, 95, 32, 118, 62, 224, 18, 165, 227, 65, 174, 189, 133, 16, 15, 245, 42, 161, 201, 203, 104, 216, 19, 252, 215, 88, 104, 16, 47, 47, 16, 85, 42, 37, 35, 227, 221, 135 }, new byte[] { 88, 222, 124, 230, 188, 107, 198, 108, 110, 198, 8, 209, 167, 26, 74, 36, 222, 227, 70, 52, 12, 95, 114, 41, 241, 94, 38, 102, 12, 26, 35, 4, 209, 6, 109, 216, 221, 151, 59, 192, 229, 249, 200, 246, 5, 10, 69, 235, 5, 3, 209, 196, 137, 16, 136, 209, 162, 5, 25, 158, 64, 202, 8, 165, 100, 82, 146, 82, 121, 51, 63, 250, 217, 116, 201, 3, 191, 226, 137, 250, 57, 188, 252, 196, 85, 122, 236, 13, 80, 188, 1, 165, 62, 202, 169, 65, 191, 132, 41, 39, 24, 235, 142, 24, 206, 8, 186, 220, 203, 76, 229, 157, 9, 146, 69, 28, 191, 109, 109, 87, 106, 84, 41, 181, 222, 44, 8, 16 }, "1111111", "photoUrl", null, "admin" },
                    { 2, "address", new DateTime(1900, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", "string", "string", 1, false, "string", new byte[] { 248, 89, 93, 20, 51, 35, 248, 115, 150, 254, 128, 23, 210, 138, 185, 153, 245, 182, 163, 221, 178, 36, 139, 56, 90, 137, 192, 122, 86, 181, 223, 168, 149, 207, 130, 73, 11, 231, 220, 34, 253, 138, 189, 53, 150, 117, 239, 58, 123, 119, 146, 237, 61, 110, 36, 227, 193, 152, 248, 159, 228, 175, 233, 75 }, new byte[] { 109, 139, 199, 4, 15, 123, 6, 18, 173, 154, 243, 180, 57, 219, 27, 40, 76, 71, 90, 63, 180, 32, 81, 193, 45, 161, 21, 174, 3, 216, 126, 52, 91, 27, 163, 189, 40, 199, 249, 185, 252, 248, 174, 251, 68, 158, 120, 130, 83, 151, 185, 218, 13, 31, 25, 100, 217, 126, 180, 127, 97, 66, 134, 126, 166, 92, 190, 22, 252, 79, 82, 206, 65, 41, 188, 45, 92, 233, 87, 161, 102, 42, 48, 199, 45, 205, 164, 172, 194, 200, 132, 99, 73, 155, 207, 40, 96, 35, 255, 8, 23, 145, 231, 131, 243, 64, 172, 67, 182, 254, 78, 86, 14, 67, 238, 250, 205, 155, 207, 36, 104, 103, 155, 222, 68, 31, 219, 204 }, "1111111", "photoUrl", null, "doctor" },
                    { 3, "address", new DateTime(1900, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", "string3", "string3", 1, false, "string3", new byte[] { 248, 89, 93, 20, 51, 35, 248, 115, 150, 254, 128, 23, 210, 138, 185, 153, 245, 182, 163, 221, 178, 36, 139, 56, 90, 137, 192, 122, 86, 181, 223, 168, 149, 207, 130, 73, 11, 231, 220, 34, 253, 138, 189, 53, 150, 117, 239, 58, 123, 119, 146, 237, 61, 110, 36, 227, 193, 152, 248, 159, 228, 175, 233, 75 }, new byte[] { 109, 139, 199, 4, 15, 123, 6, 18, 173, 154, 243, 180, 57, 219, 27, 40, 76, 71, 90, 63, 180, 32, 81, 193, 45, 161, 21, 174, 3, 216, 126, 52, 91, 27, 163, 189, 40, 199, 249, 185, 252, 248, 174, 251, 68, 158, 120, 130, 83, 151, 185, 218, 13, 31, 25, 100, 217, 126, 180, 127, 97, 66, 134, 126, 166, 92, 190, 22, 252, 79, 82, 206, 65, 41, 188, 45, 92, 233, 87, 161, 102, 42, 48, 199, 45, 205, 164, 172, 194, 200, 132, 99, 73, 155, 207, 40, 96, 35, 255, 8, 23, 145, 231, 131, 243, 64, 172, 67, 182, 254, 78, 86, 14, 67, 238, 250, 205, 155, 207, 36, 104, 103, 155, 222, 68, 31, 219, 204 }, "1111111", "photoUrl", null, "doctor" },
                    { 4, "address", new DateTime(1900, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", "string4", "string4", 1, false, "string4", new byte[] { 248, 89, 93, 20, 51, 35, 248, 115, 150, 254, 128, 23, 210, 138, 185, 153, 245, 182, 163, 221, 178, 36, 139, 56, 90, 137, 192, 122, 86, 181, 223, 168, 149, 207, 130, 73, 11, 231, 220, 34, 253, 138, 189, 53, 150, 117, 239, 58, 123, 119, 146, 237, 61, 110, 36, 227, 193, 152, 248, 159, 228, 175, 233, 75 }, new byte[] { 109, 139, 199, 4, 15, 123, 6, 18, 173, 154, 243, 180, 57, 219, 27, 40, 76, 71, 90, 63, 180, 32, 81, 193, 45, 161, 21, 174, 3, 216, 126, 52, 91, 27, 163, 189, 40, 199, 249, 185, 252, 248, 174, 251, 68, 158, 120, 130, 83, 151, 185, 218, 13, 31, 25, 100, 217, 126, 180, 127, 97, 66, 134, 126, 166, 92, 190, 22, 252, 79, 82, 206, 65, 41, 188, 45, 92, 233, 87, 161, 102, 42, 48, 199, 45, 205, 164, 172, 194, 200, 132, 99, 73, 155, 207, 40, 96, 35, 255, 8, 23, 145, 231, 131, 243, 64, 172, 67, 182, 254, 78, 86, 14, 67, 238, 250, 205, 155, 207, 36, 104, 103, 155, 222, 68, 31, 219, 204 }, "1111111", "photoUrl", null, "doctor" },
                    { 5, "address", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", "johndoe", "John", 1, false, "Doe", new byte[] { 23, 66, 241, 13, 237, 224, 33, 41, 120, 102, 108, 131, 57, 69, 21, 73, 245, 245, 91, 96, 253, 97, 132, 251, 49, 12, 139, 17, 87, 228, 32, 157, 7, 227, 93, 239, 189, 25, 166, 62, 234, 205, 73, 24, 48, 82, 3, 210, 70, 103, 94, 66, 23, 143, 181, 143, 97, 197, 229, 33, 116, 37, 17, 126 }, new byte[] { 9, 25, 79, 164, 90, 55, 13, 186, 32, 138, 87, 230, 28, 18, 220, 252, 219, 107, 124, 209, 219, 218, 213, 214, 109, 72, 212, 237, 36, 137, 94, 234, 99, 101, 67, 156, 220, 33, 196, 33, 70, 168, 168, 228, 37, 105, 109, 111, 151, 137, 0, 209, 143, 182, 73, 6, 112, 219, 205, 238, 140, 81, 84, 37, 250, 183, 195, 86, 15, 174, 253, 113, 245, 171, 190, 174, 254, 96, 119, 147, 105, 62, 146, 233, 37, 242, 171, 23, 16, 160, 160, 102, 228, 19, 6, 107, 198, 219, 204, 115, 115, 91, 154, 234, 216, 142, 67, 143, 202, 12, 110, 158, 104, 204, 149, 83, 1, 93, 220, 248, 49, 177, 157, 252, 111, 207, 56, 22 }, "1111111", "photoUrl", null, "patient" },
                    { 6, "address", new DateTime(1975, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", "janesmith", "Jane", 1, false, "Smith", new byte[] { 130, 14, 207, 207, 44, 13, 197, 123, 91, 23, 169, 211, 163, 79, 229, 135, 19, 174, 250, 14, 220, 129, 146, 164, 166, 228, 156, 176, 101, 139, 29, 254, 148, 214, 112, 145, 193, 60, 156, 70, 180, 78, 210, 244, 59, 35, 150, 128, 185, 46, 75, 52, 136, 252, 119, 119, 191, 58, 226, 109, 65, 196, 60, 173 }, new byte[] { 121, 4, 43, 2, 14, 18, 196, 252, 176, 138, 126, 196, 158, 81, 168, 72, 194, 121, 160, 97, 161, 161, 2, 213, 168, 255, 164, 14, 185, 215, 126, 167, 141, 143, 124, 196, 39, 188, 215, 211, 181, 148, 135, 47, 158, 9, 170, 70, 195, 189, 243, 216, 200, 29, 57, 192, 218, 152, 173, 20, 30, 197, 219, 96, 149, 55, 254, 126, 218, 115, 79, 194, 115, 59, 196, 204, 137, 147, 156, 51, 154, 208, 88, 114, 243, 142, 111, 229, 23, 68, 163, 225, 26, 8, 165, 155, 65, 150, 218, 194, 119, 130, 84, 1, 137, 172, 240, 79, 92, 201, 35, 221, 28, 253, 122, 237, 207, 218, 20, 97, 118, 91, 171, 8, 179, 38, 22, 31 }, "1111111", "photoUrl", null, "patient" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Deals with diseases of the heart and circulatory system. Treats conditions like heart attacks, hypertension, cardiac rhythm disorders.", false, "Cardiology", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Deals with diseases of the nervous system. Treats disorders related to the brain, spinal cord, nerves, and muscles.", false, "Neurology", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Focuses on bones, joints, muscles, and connective tissues. Treats conditions such as fractures, dislocations, sports injuries.", false, "Orthopedics and Traumatology", null }
                });

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsDeleted", "Message", "NotificationType", "SentAt", "Title", "UpdatedDate" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Test", 1, new DateTime(2024, 6, 30, 13, 0, 0, 0, DateTimeKind.Unspecified), "Test", null });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "admin", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "users.read", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "users.write", null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "users.add", null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "users.update", null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "users.delete", null },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "doctors.read", null },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "doctors.write", null },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "doctors.add", null },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "doctors.update", null },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "doctors.delete", null },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "patients.read", null },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "patients.write", null },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "patients.add", null },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "patients.update", null },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "patients.delete", null },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "doctorAvailabilities.read", null },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "doctorAvailabilities.write", null },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "doctorAvailabilities.add", null },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "doctorAvailabilities.update", null },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "doctorAvailabilities.delete", null },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "patientReports.read", null },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "patientReports.write", null },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "patientReports.add", null },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "patientReports.update", null },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "patientReports.delete", null },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "appointments.read", null },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "appointments.write", null },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "appointments.add", null },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "appointments.update", null },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "appointments.delete", null },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "departments.read", null },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "departments.write", null },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "departments.add", null },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "departments.update", null },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "departments.delete", null },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "operationClaims.read", null },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "operationClaims.write", null },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "operationClaims.add", null },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "operationClaims.update", null },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "operationClaims.delete", null },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "userOperationClaims.read", null },
                    { 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "userOperationClaims.write", null },
                    { 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "userOperationClaims.add", null },
                    { 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "userOperationClaims.update", null },
                    { 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "userOperationClaims.delete", null },
                    { 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "feedbacks.read", null },
                    { 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "feedbacks.write", null },
                    { 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "feedbacks.add", null },
                    { 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "feedbacks.update", null },
                    { 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "feedbacks.delete", null },
                    { 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "notifications.read", null },
                    { 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "notifications.write", null },
                    { 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "notifications.add", null },
                    { 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "notifications.update", null },
                    { 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "notifications.delete", null },
                    { 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "supportRequests.read", null },
                    { 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "supportRequests.write", null },
                    { 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "supportRequests.add", null },
                    { 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "supportRequests.update", null },
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "supportRequests.delete", null }
                });

            migrationBuilder.InsertData(
                table: "SupportRequests",
                columns: new[] { "Id", "Content", "CreatedDate", "DeletedDate", "Email", "FirstName", "IsDeleted", "LastName", "PhoneNumber", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Content", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "loremipsum@loremipsum.com", "Lorem", false, "Ipsum", "1234567890", "Title", null },
                    { 2, "Content2", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "loremipsum2@loremipsum2.com", "Lorem2", false, "Ipsum2", "1234567890", "Title2", null }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Biography", "CreatedDate", "DeletedDate", "DepartmentId", "IsDeleted", "SpecialistLevel", "UpdatedDate", "UserId", "YearsOfExperience" },
                values: new object[,]
                {
                    { 1, "With over 25 years of experience, this distinguished Professor of Orthopedics specializes in orthopedic surgery. They completed their medical degree, residency, and fellowship at prestigious institutions, focusing on innovative surgical techniques and groundbreaking research. A prolific author and keynote speaker, they have contributed extensively to the academic community and are actively involved in mentoring future orthopedic surgeons. They are a respected member of the American Academy of Orthopaedic Surgeons (AAOS). Their clinical interests include joint replacement, sports medicine, and minimally invasive procedures. Known for their compassionate approach, they are dedicated to achieving excellent outcomes for their patients and are committed to community service.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, false, "Prof", null, 2, 25 },
                    { 2, "Biography", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, false, "Doç", null, 3, 15 },
                    { 3, "Biography", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, false, "Uzm", null, 4, 10 }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Description", "IsDeleted", "Rating", "Title", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test", false, 10, "Test", null, 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test2", false, 9, "Test2", null, 1 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test3", false, 7, "Test3", null, 2 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test4", false, 5, "Test4", null, 3 }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Allergies", "BloodType", "CreatedDate", "CurrentMedications", "DeletedDate", "EmergencyContactName", "EmergencyContactPhoneNumber", "EmergencyContactRelationship", "HealthHistory", "InsuranceType", "IsDeleted", "SocialSecurityNumber", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, "Penicillin", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lisinopril 10mg daily, Metformin 500mg twice daily", null, "Lorem Ipsum", "000000", "Father", "John Doe, born on January 1, 1980, has a medical history that includes hypertension, Type 2 diabetes, and asthma. He takes 10mg of Lisinopril daily, 500mg of Metformin twice daily, and uses an Albuterol inhaler as needed. In the past, he underwent an appendectomy in 2010 and knee arthroscopy in 2015. He has an allergy to penicillin. His family history shows that his father has hypertension and his mother has Type 2 diabetes. John is a non-smoker and consumes alcohol occasionally.", 1, false, "1554447878", null, 5 },
                    { 2, "None known", 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Levothyroxine 50mcg daily (for hypothyroidism), Sumatriptan (as needed for migraines)", null, "Lorem Ipsum", "000000", "Sister", "Jane Smith, born on February 15, 1975, has a medical history that includes hypothyroidism, chronic migraines, and osteoarthritis. She takes 50mcg of Levothyroxine daily and Sumatriptan as needed for migraines. In the past, she underwent gallbladder removal surgery in 2012 and a hysterectomy in 2018. She has no known allergies. Her family history includes her father having coronary artery disease and her mother suffering from rheumatoid arthritis. Jane does not smoke and drinks alcohol socially.", 2, false, "9223246896", null, 6 }
                });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "BaseUserId", "CreatedDate", "DeletedDate", "IsDeleted", "OperationClaimId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, null },
                    { 13, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 8, null },
                    { 14, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 9, null },
                    { 15, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 11, null },
                    { 16, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 20, null },
                    { 17, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 21, null },
                    { 18, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 22, null },
                    { 19, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 23, null },
                    { 20, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 26, null },
                    { 21, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 27, null },
                    { 22, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 28, null },
                    { 23, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 29, null },
                    { 24, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 32, null }
                });

            migrationBuilder.InsertData(
                table: "DoctorAvailabilities",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DoctorId", "EndTime", "IsDeleted", "StartTime", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2024, 6, 30, 17, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 6, 30, 9, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, new DateTime(2024, 6, 30, 15, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 6, 30, 8, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2024, 7, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 7, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, new DateTime(2024, 7, 4, 16, 45, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2024, 7, 4, 8, 30, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DoctorAvailabilityId", "EndTime", "IsDeleted", "PatientId", "StartTime", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2024, 6, 30, 11, 0, 0, 0, DateTimeKind.Unspecified), false, 1, new DateTime(2024, 6, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, new DateTime(2024, 6, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 2, new DateTime(2024, 6, 30, 11, 0, 0, 0, DateTimeKind.Unspecified), 2, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, new DateTime(2024, 7, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), false, 2, new DateTime(2024, 7, 4, 9, 30, 0, 0, DateTimeKind.Unspecified), 2, null }
                });

            migrationBuilder.InsertData(
                table: "PatientReports",
                columns: new[] { "Id", "AppointmentId", "CreatedDate", "DeletedDate", "Details", "IsDeleted", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test", false, "Test", null },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test2", false, "Test2", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorAvailabilityId",
                table: "Appointments",
                column: "DoctorAvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorAvailabilities_DoctorId",
                table: "DoctorAvailabilities",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DepartmentId",
                table: "Doctors",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_UserId",
                table: "Doctors",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserId",
                table: "Feedbacks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientReports_AppointmentId",
                table: "PatientReports",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserId",
                table: "Patients",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_BaseUserId",
                table: "UserOperationClaims",
                column: "BaseUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_OperationClaimId",
                table: "UserOperationClaims",
                column: "OperationClaimId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PatientReports");

            migrationBuilder.DropTable(
                name: "SupportRequests");

            migrationBuilder.DropTable(
                name: "UserOperationClaims");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "OperationClaims");

            migrationBuilder.DropTable(
                name: "DoctorAvailabilities");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "BaseUsers");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
