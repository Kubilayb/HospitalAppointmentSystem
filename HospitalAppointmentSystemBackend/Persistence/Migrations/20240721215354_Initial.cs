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
                    { 1, "address", new DateTime(1900, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", "admin", "admin", 1, false, "admin", new byte[] { 182, 26, 122, 26, 113, 228, 51, 245, 212, 101, 167, 78, 135, 250, 191, 71, 244, 226, 100, 100, 84, 13, 49, 7, 77, 180, 55, 224, 191, 212, 252, 202, 232, 126, 148, 25, 80, 177, 33, 79, 93, 31, 82, 99, 119, 156, 219, 173, 131, 57, 137, 88, 149, 53, 23, 176, 129, 238, 112, 162, 147, 143, 82, 95 }, new byte[] { 69, 28, 19, 73, 126, 242, 134, 100, 177, 211, 26, 41, 221, 154, 186, 39, 233, 223, 208, 187, 129, 126, 172, 138, 66, 182, 93, 46, 193, 37, 103, 103, 85, 70, 229, 107, 145, 46, 77, 196, 0, 197, 142, 126, 88, 220, 31, 157, 228, 179, 156, 159, 88, 57, 1, 150, 78, 154, 174, 3, 185, 250, 21, 67, 37, 3, 32, 129, 221, 11, 39, 79, 255, 167, 191, 70, 13, 185, 28, 54, 56, 33, 28, 73, 25, 227, 117, 10, 188, 13, 119, 138, 27, 75, 35, 46, 215, 100, 106, 46, 237, 19, 21, 84, 133, 236, 109, 15, 134, 21, 225, 105, 10, 154, 9, 180, 2, 78, 88, 249, 24, 134, 103, 4, 33, 49, 30, 190 }, "1111111", "photoUrl", null, "admin" },
                    { 2, "address", new DateTime(1900, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", "string", "string", 1, false, "string", new byte[] { 124, 53, 227, 228, 190, 68, 30, 10, 192, 8, 146, 115, 146, 83, 219, 62, 197, 55, 220, 68, 166, 64, 22, 124, 175, 250, 111, 147, 186, 13, 105, 135, 171, 227, 139, 188, 132, 46, 216, 88, 86, 70, 109, 163, 208, 128, 45, 117, 124, 22, 27, 14, 40, 139, 225, 27, 87, 72, 198, 162, 130, 117, 217, 240 }, new byte[] { 216, 97, 190, 132, 68, 147, 192, 93, 21, 215, 32, 89, 220, 32, 219, 182, 41, 108, 91, 13, 232, 6, 128, 41, 0, 45, 109, 6, 245, 136, 1, 61, 245, 113, 119, 228, 137, 171, 247, 119, 168, 63, 140, 56, 68, 186, 84, 8, 163, 43, 139, 72, 76, 53, 46, 50, 218, 236, 167, 139, 62, 230, 2, 65, 11, 41, 36, 170, 74, 232, 183, 150, 235, 199, 196, 149, 107, 55, 53, 224, 93, 245, 160, 150, 149, 211, 131, 206, 190, 37, 189, 148, 144, 19, 75, 216, 99, 80, 126, 21, 3, 245, 113, 128, 105, 218, 177, 143, 80, 218, 66, 207, 194, 22, 174, 138, 36, 117, 33, 58, 45, 179, 239, 79, 108, 26, 219, 178 }, "1111111", "photoUrl", null, "doctor" },
                    { 3, "address", new DateTime(1900, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", "string3", "string3", 1, false, "string3", new byte[] { 124, 53, 227, 228, 190, 68, 30, 10, 192, 8, 146, 115, 146, 83, 219, 62, 197, 55, 220, 68, 166, 64, 22, 124, 175, 250, 111, 147, 186, 13, 105, 135, 171, 227, 139, 188, 132, 46, 216, 88, 86, 70, 109, 163, 208, 128, 45, 117, 124, 22, 27, 14, 40, 139, 225, 27, 87, 72, 198, 162, 130, 117, 217, 240 }, new byte[] { 216, 97, 190, 132, 68, 147, 192, 93, 21, 215, 32, 89, 220, 32, 219, 182, 41, 108, 91, 13, 232, 6, 128, 41, 0, 45, 109, 6, 245, 136, 1, 61, 245, 113, 119, 228, 137, 171, 247, 119, 168, 63, 140, 56, 68, 186, 84, 8, 163, 43, 139, 72, 76, 53, 46, 50, 218, 236, 167, 139, 62, 230, 2, 65, 11, 41, 36, 170, 74, 232, 183, 150, 235, 199, 196, 149, 107, 55, 53, 224, 93, 245, 160, 150, 149, 211, 131, 206, 190, 37, 189, 148, 144, 19, 75, 216, 99, 80, 126, 21, 3, 245, 113, 128, 105, 218, 177, 143, 80, 218, 66, 207, 194, 22, 174, 138, 36, 117, 33, 58, 45, 179, 239, 79, 108, 26, 219, 178 }, "1111111", "photoUrl", null, "doctor" },
                    { 4, "address", new DateTime(1900, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", "string4", "string4", 1, false, "string4", new byte[] { 124, 53, 227, 228, 190, 68, 30, 10, 192, 8, 146, 115, 146, 83, 219, 62, 197, 55, 220, 68, 166, 64, 22, 124, 175, 250, 111, 147, 186, 13, 105, 135, 171, 227, 139, 188, 132, 46, 216, 88, 86, 70, 109, 163, 208, 128, 45, 117, 124, 22, 27, 14, 40, 139, 225, 27, 87, 72, 198, 162, 130, 117, 217, 240 }, new byte[] { 216, 97, 190, 132, 68, 147, 192, 93, 21, 215, 32, 89, 220, 32, 219, 182, 41, 108, 91, 13, 232, 6, 128, 41, 0, 45, 109, 6, 245, 136, 1, 61, 245, 113, 119, 228, 137, 171, 247, 119, 168, 63, 140, 56, 68, 186, 84, 8, 163, 43, 139, 72, 76, 53, 46, 50, 218, 236, 167, 139, 62, 230, 2, 65, 11, 41, 36, 170, 74, 232, 183, 150, 235, 199, 196, 149, 107, 55, 53, 224, 93, 245, 160, 150, 149, 211, 131, 206, 190, 37, 189, 148, 144, 19, 75, 216, 99, 80, 126, 21, 3, 245, 113, 128, 105, 218, 177, 143, 80, 218, 66, 207, 194, 22, 174, 138, 36, 117, 33, 58, 45, 179, 239, 79, 108, 26, 219, 178 }, "1111111", "photoUrl", null, "doctor" },
                    { 5, "address", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", "johndoe", "John", 1, false, "Doe", new byte[] { 239, 28, 39, 143, 80, 7, 248, 165, 169, 4, 48, 166, 128, 146, 188, 143, 40, 158, 122, 12, 134, 146, 222, 18, 144, 163, 167, 47, 88, 167, 133, 52, 19, 3, 24, 107, 21, 75, 140, 164, 24, 246, 42, 75, 22, 156, 125, 114, 226, 187, 0, 96, 90, 57, 48, 232, 221, 226, 151, 207, 81, 180, 245, 159 }, new byte[] { 64, 193, 30, 126, 132, 162, 166, 192, 244, 178, 74, 151, 108, 67, 203, 44, 253, 121, 66, 160, 58, 197, 6, 166, 192, 110, 245, 221, 212, 128, 232, 42, 94, 176, 26, 30, 121, 59, 6, 147, 193, 55, 222, 115, 241, 33, 144, 64, 54, 220, 31, 194, 233, 107, 165, 190, 175, 207, 197, 184, 138, 58, 20, 206, 147, 219, 128, 246, 236, 80, 152, 140, 57, 169, 142, 109, 19, 147, 39, 90, 167, 5, 204, 235, 147, 8, 59, 240, 193, 241, 136, 70, 124, 64, 184, 161, 188, 19, 68, 228, 59, 144, 184, 168, 53, 209, 63, 237, 178, 228, 84, 231, 145, 6, 46, 191, 131, 145, 184, 226, 60, 79, 200, 126, 255, 101, 170, 100 }, "1111111", "photoUrl", null, "patient" },
                    { 6, "address", new DateTime(1975, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", "janesmith", "Jane", 1, false, "Smith", new byte[] { 214, 149, 137, 196, 243, 194, 183, 249, 177, 142, 84, 83, 205, 116, 110, 16, 40, 185, 128, 121, 185, 162, 242, 13, 64, 176, 52, 61, 209, 253, 63, 134, 90, 170, 23, 173, 233, 45, 77, 140, 210, 215, 115, 232, 168, 206, 91, 24, 13, 118, 208, 87, 214, 201, 169, 37, 225, 32, 230, 62, 235, 37, 239, 23 }, new byte[] { 212, 90, 231, 221, 62, 134, 158, 58, 181, 119, 108, 144, 147, 189, 125, 69, 213, 80, 107, 18, 164, 73, 27, 101, 242, 66, 202, 27, 81, 222, 36, 222, 158, 206, 253, 121, 251, 61, 143, 158, 122, 46, 190, 194, 27, 203, 192, 242, 64, 107, 2, 162, 97, 47, 162, 14, 147, 205, 27, 208, 131, 1, 113, 218, 130, 182, 20, 165, 234, 48, 150, 215, 9, 234, 135, 116, 214, 182, 137, 3, 75, 203, 165, 244, 131, 104, 192, 122, 235, 139, 166, 181, 16, 17, 66, 238, 74, 228, 233, 151, 155, 64, 93, 23, 83, 116, 151, 242, 72, 246, 202, 60, 46, 222, 196, 154, 127, 251, 207, 219, 222, 13, 141, 117, 206, 113, 26, 216 }, "1111111", "photoUrl", null, "patient" }
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
