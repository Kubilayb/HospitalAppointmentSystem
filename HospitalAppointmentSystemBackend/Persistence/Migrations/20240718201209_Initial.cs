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
                    DoctorId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
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
                    DoctorId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_PatientReports_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "BaseUsers",
                columns: new[] { "Id", "Address", "BirthDate", "City", "CreatedDate", "DeletedDate", "Discriminator", "Email", "FirstName", "Gender", "IsDeleted", "LastName", "PasswordHash", "PasswordSalt", "PhoneNumber", "PhotoUrl", "UpdatedDate", "UserType" },
                values: new object[,]
                {
                    { 1, "address", new DateTime(1900, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", "admin", "admin", 1, false, "admin", new byte[] { 170, 102, 159, 137, 214, 43, 58, 9, 37, 140, 81, 152, 174, 225, 187, 237, 230, 36, 231, 46, 140, 97, 45, 216, 138, 251, 238, 93, 114, 178, 203, 131, 92, 230, 116, 172, 192, 70, 197, 199, 38, 179, 93, 82, 226, 172, 78, 34, 46, 82, 177, 223, 163, 85, 86, 186, 241, 240, 225, 192, 243, 214, 242, 11 }, new byte[] { 28, 178, 197, 84, 11, 201, 174, 60, 45, 104, 26, 243, 187, 105, 162, 132, 81, 120, 3, 31, 21, 72, 224, 114, 155, 17, 97, 68, 168, 145, 254, 244, 145, 166, 98, 141, 31, 190, 200, 199, 133, 87, 85, 189, 48, 9, 84, 218, 34, 92, 174, 140, 149, 18, 181, 74, 49, 226, 102, 251, 162, 122, 234, 246, 86, 122, 57, 157, 130, 235, 33, 147, 48, 87, 195, 19, 220, 162, 30, 108, 92, 221, 215, 57, 227, 102, 3, 27, 41, 186, 247, 182, 82, 180, 252, 91, 223, 149, 138, 12, 176, 226, 85, 228, 37, 145, 85, 123, 14, 219, 189, 251, 196, 147, 205, 79, 21, 98, 88, 83, 153, 178, 94, 102, 52, 116, 250, 136 }, "1111111", "photoUrl", null, "admin" },
                    { 2, "address", new DateTime(1900, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", "string", "string", 1, false, "string", new byte[] { 255, 36, 114, 186, 41, 169, 74, 79, 213, 3, 46, 217, 181, 228, 24, 69, 241, 241, 5, 214, 66, 163, 118, 45, 126, 166, 80, 45, 126, 97, 38, 4, 137, 216, 173, 134, 65, 141, 92, 214, 225, 11, 170, 177, 243, 76, 169, 148, 31, 126, 211, 173, 63, 201, 121, 110, 145, 242, 141, 37, 120, 129, 129, 108 }, new byte[] { 23, 106, 45, 27, 37, 35, 238, 208, 161, 34, 163, 203, 254, 182, 116, 119, 224, 163, 47, 37, 191, 118, 219, 42, 143, 224, 151, 13, 88, 73, 76, 24, 175, 104, 214, 138, 235, 225, 116, 121, 187, 85, 40, 81, 174, 11, 98, 119, 196, 58, 208, 254, 1, 30, 192, 89, 7, 159, 53, 89, 46, 206, 58, 244, 53, 171, 10, 246, 14, 109, 215, 56, 90, 7, 101, 214, 165, 158, 62, 168, 135, 244, 153, 102, 77, 132, 15, 191, 241, 10, 34, 223, 7, 112, 148, 10, 99, 191, 0, 127, 231, 227, 214, 220, 121, 221, 92, 81, 113, 30, 61, 146, 144, 168, 61, 253, 147, 213, 72, 120, 207, 112, 226, 41, 34, 103, 62, 10 }, "1111111", "photoUrl", null, "doctor" },
                    { 3, "address", new DateTime(1900, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", "string3", "string3", 1, false, "string3", new byte[] { 255, 36, 114, 186, 41, 169, 74, 79, 213, 3, 46, 217, 181, 228, 24, 69, 241, 241, 5, 214, 66, 163, 118, 45, 126, 166, 80, 45, 126, 97, 38, 4, 137, 216, 173, 134, 65, 141, 92, 214, 225, 11, 170, 177, 243, 76, 169, 148, 31, 126, 211, 173, 63, 201, 121, 110, 145, 242, 141, 37, 120, 129, 129, 108 }, new byte[] { 23, 106, 45, 27, 37, 35, 238, 208, 161, 34, 163, 203, 254, 182, 116, 119, 224, 163, 47, 37, 191, 118, 219, 42, 143, 224, 151, 13, 88, 73, 76, 24, 175, 104, 214, 138, 235, 225, 116, 121, 187, 85, 40, 81, 174, 11, 98, 119, 196, 58, 208, 254, 1, 30, 192, 89, 7, 159, 53, 89, 46, 206, 58, 244, 53, 171, 10, 246, 14, 109, 215, 56, 90, 7, 101, 214, 165, 158, 62, 168, 135, 244, 153, 102, 77, 132, 15, 191, 241, 10, 34, 223, 7, 112, 148, 10, 99, 191, 0, 127, 231, 227, 214, 220, 121, 221, 92, 81, 113, 30, 61, 146, 144, 168, 61, 253, 147, 213, 72, 120, 207, 112, 226, 41, 34, 103, 62, 10 }, "1111111", "photoUrl", null, "doctor" },
                    { 4, "address", new DateTime(1900, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", "string4", "string4", 1, false, "string4", new byte[] { 255, 36, 114, 186, 41, 169, 74, 79, 213, 3, 46, 217, 181, 228, 24, 69, 241, 241, 5, 214, 66, 163, 118, 45, 126, 166, 80, 45, 126, 97, 38, 4, 137, 216, 173, 134, 65, 141, 92, 214, 225, 11, 170, 177, 243, 76, 169, 148, 31, 126, 211, 173, 63, 201, 121, 110, 145, 242, 141, 37, 120, 129, 129, 108 }, new byte[] { 23, 106, 45, 27, 37, 35, 238, 208, 161, 34, 163, 203, 254, 182, 116, 119, 224, 163, 47, 37, 191, 118, 219, 42, 143, 224, 151, 13, 88, 73, 76, 24, 175, 104, 214, 138, 235, 225, 116, 121, 187, 85, 40, 81, 174, 11, 98, 119, 196, 58, 208, 254, 1, 30, 192, 89, 7, 159, 53, 89, 46, 206, 58, 244, 53, 171, 10, 246, 14, 109, 215, 56, 90, 7, 101, 214, 165, 158, 62, 168, 135, 244, 153, 102, 77, 132, 15, 191, 241, 10, 34, 223, 7, 112, 148, 10, 99, 191, 0, 127, 231, 227, 214, 220, 121, 221, 92, 81, 113, 30, 61, 146, 144, 168, 61, 253, 147, 213, 72, 120, 207, 112, 226, 41, 34, 103, 62, 10 }, "1111111", "photoUrl", null, "doctor" },
                    { 5, "address", new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", "johndoe", "John", 1, false, "Doe", new byte[] { 11, 164, 6, 74, 144, 156, 222, 69, 118, 136, 20, 6, 124, 25, 181, 144, 74, 46, 141, 248, 88, 218, 65, 47, 253, 207, 245, 222, 197, 246, 171, 213, 169, 43, 102, 104, 54, 160, 174, 116, 4, 148, 202, 194, 19, 119, 49, 162, 227, 64, 197, 164, 45, 112, 14, 91, 118, 120, 219, 239, 130, 55, 124, 64 }, new byte[] { 143, 28, 1, 107, 183, 119, 142, 114, 47, 183, 229, 176, 160, 169, 165, 124, 108, 239, 186, 63, 255, 196, 172, 154, 134, 96, 65, 187, 16, 72, 198, 53, 203, 115, 213, 193, 235, 159, 198, 121, 161, 122, 87, 4, 9, 229, 102, 225, 64, 216, 243, 24, 219, 112, 103, 163, 89, 64, 190, 145, 228, 195, 174, 21, 96, 68, 96, 111, 153, 141, 65, 56, 209, 15, 195, 129, 72, 137, 207, 214, 251, 231, 142, 137, 223, 2, 70, 51, 134, 30, 119, 134, 214, 144, 196, 211, 204, 176, 110, 197, 243, 158, 10, 207, 178, 235, 170, 250, 61, 64, 114, 118, 201, 142, 27, 247, 11, 100, 26, 107, 13, 206, 222, 198, 129, 81, 9, 42 }, "1111111", "photoUrl", null, "patient" },
                    { 6, "address", new DateTime(1975, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", "janesmith", "Jane", 1, false, "Smith", new byte[] { 212, 190, 13, 146, 140, 149, 151, 212, 207, 31, 220, 35, 166, 150, 115, 226, 253, 62, 28, 76, 141, 109, 146, 112, 138, 66, 99, 56, 145, 170, 198, 26, 91, 153, 32, 149, 208, 121, 236, 4, 165, 44, 163, 233, 151, 184, 216, 114, 132, 13, 235, 41, 245, 232, 247, 158, 145, 227, 129, 221, 128, 227, 2, 225 }, new byte[] { 209, 137, 9, 80, 112, 173, 245, 201, 60, 247, 186, 100, 100, 212, 168, 112, 47, 182, 229, 192, 107, 180, 12, 132, 19, 169, 171, 210, 152, 15, 12, 218, 204, 251, 117, 9, 150, 8, 168, 60, 8, 7, 61, 42, 201, 29, 40, 124, 66, 94, 220, 136, 62, 29, 217, 181, 76, 73, 20, 208, 49, 12, 61, 95, 67, 89, 30, 73, 156, 101, 15, 147, 201, 142, 110, 128, 51, 92, 88, 206, 66, 107, 198, 95, 44, 128, 37, 4, 42, 202, 115, 97, 48, 238, 201, 8, 111, 188, 183, 36, 245, 22, 121, 237, 165, 7, 3, 45, 186, 98, 6, 10, 182, 79, 8, 225, 96, 104, 230, 38, 66, 209, 225, 53, 137, 251, 255, 186 }, "1111111", "photoUrl", null, "patient" }
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
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "DoctorAvailabilityId", "DoctorId", "EndTime", "IsDeleted", "PatientId", "StartTime", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new DateTime(2024, 6, 30, 11, 0, 0, 0, DateTimeKind.Unspecified), false, 1, new DateTime(2024, 6, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 3, null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new DateTime(2024, 6, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), false, 2, new DateTime(2024, 6, 30, 11, 0, 0, 0, DateTimeKind.Unspecified), 3, null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, new DateTime(2024, 7, 4, 10, 0, 0, 0, DateTimeKind.Unspecified), false, 2, new DateTime(2024, 7, 4, 9, 30, 0, 0, DateTimeKind.Unspecified), 3, null }
                });

            migrationBuilder.InsertData(
                table: "PatientReports",
                columns: new[] { "Id", "AppointmentId", "CreatedDate", "DeletedDate", "Details", "DoctorId", "IsDeleted", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test", null, false, "Test", null },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Test2", null, false, "Test2", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorAvailabilityId",
                table: "Appointments",
                column: "DoctorAvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

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
                name: "IX_PatientReports_DoctorId",
                table: "PatientReports",
                column: "DoctorId");

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
