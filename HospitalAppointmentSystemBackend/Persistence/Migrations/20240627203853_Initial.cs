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
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Type = table.Column<int>(type: "int", nullable: false),
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
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Rating = table.Column<int>(type: "int", nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodType = table.Column<int>(type: "int", nullable: false),
                    InsuranceType = table.Column<int>(type: "int", nullable: false),
                    SocialSecurityNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doctors_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseUserId = table.Column<int>(type: "int", nullable: false),
                    OperationClaimId = table.Column<int>(type: "int", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserOperationClaims_OperationClaims_OperationClaimId",
                        column: x => x.OperationClaimId,
                        principalTable: "OperationClaims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientReports_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientReports_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BaseUsers",
                columns: new[] { "Id", "Address", "BirthDate", "City", "CreatedDate", "DeletedDate", "Discriminator", "Email", "FirstName", "Gender", "IsDeleted", "LastName", "PasswordHash", "PasswordSalt", "PhoneNumber", "PhotoUrl", "UpdatedDate", "UserType" },
                values: new object[,]
                {
                    { 1, "address", new DateTime(1900, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", "admin", "admin", 1, false, "admin", new byte[] { 240, 175, 156, 237, 136, 46, 233, 233, 188, 39, 245, 36, 122, 30, 64, 142, 100, 42, 50, 47, 118, 128, 85, 115, 225, 69, 86, 149, 195, 128, 139, 136, 210, 121, 218, 77, 172, 30, 144, 145, 184, 105, 219, 9, 144, 154, 16, 169, 201, 226, 141, 159, 159, 180, 42, 24, 12, 105, 147, 32, 231, 44, 109, 241 }, new byte[] { 151, 208, 155, 205, 195, 196, 159, 202, 19, 235, 151, 203, 213, 147, 201, 58, 215, 241, 128, 221, 192, 144, 197, 208, 34, 241, 221, 199, 59, 230, 119, 33, 254, 93, 67, 3, 50, 141, 178, 87, 226, 108, 206, 60, 135, 71, 220, 150, 218, 119, 201, 201, 137, 135, 213, 157, 218, 135, 126, 18, 65, 118, 182, 64, 107, 196, 241, 250, 215, 136, 119, 78, 117, 218, 213, 205, 92, 160, 122, 121, 160, 78, 26, 207, 0, 254, 52, 187, 192, 84, 9, 195, 42, 201, 246, 94, 29, 171, 119, 171, 116, 21, 103, 84, 142, 206, 24, 57, 173, 53, 155, 105, 68, 83, 98, 150, 5, 194, 203, 175, 26, 66, 206, 78, 148, 69, 59, 62 }, "1111111", "photoUrl", null, "admin" },
                    { 2, "address", new DateTime(1900, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", "string", "string", 1, false, "string", new byte[] { 240, 175, 156, 237, 136, 46, 233, 233, 188, 39, 245, 36, 122, 30, 64, 142, 100, 42, 50, 47, 118, 128, 85, 115, 225, 69, 86, 149, 195, 128, 139, 136, 210, 121, 218, 77, 172, 30, 144, 145, 184, 105, 219, 9, 144, 154, 16, 169, 201, 226, 141, 159, 159, 180, 42, 24, 12, 105, 147, 32, 231, 44, 109, 241 }, new byte[] { 151, 208, 155, 205, 195, 196, 159, 202, 19, 235, 151, 203, 213, 147, 201, 58, 215, 241, 128, 221, 192, 144, 197, 208, 34, 241, 221, 199, 59, 230, 119, 33, 254, 93, 67, 3, 50, 141, 178, 87, 226, 108, 206, 60, 135, 71, 220, 150, 218, 119, 201, 201, 137, 135, 213, 157, 218, 135, 126, 18, 65, 118, 182, 64, 107, 196, 241, 250, 215, 136, 119, 78, 117, 218, 213, 205, 92, 160, 122, 121, 160, 78, 26, 207, 0, 254, 52, 187, 192, 84, 9, 195, 42, 201, 246, 94, 29, 171, 119, 171, 116, 21, 103, 84, 142, 206, 24, 57, 173, 53, 155, 105, 68, 83, 98, 150, 5, 194, 203, 175, 26, 66, 206, 78, 148, 69, 59, 62 }, "1111111", "photoUrl", null, "doctor" },
                    { 3, "address", new DateTime(1900, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", "string3", "string3", 1, false, "string3", new byte[] { 240, 175, 156, 237, 136, 46, 233, 233, 188, 39, 245, 36, 122, 30, 64, 142, 100, 42, 50, 47, 118, 128, 85, 115, 225, 69, 86, 149, 195, 128, 139, 136, 210, 121, 218, 77, 172, 30, 144, 145, 184, 105, 219, 9, 144, 154, 16, 169, 201, 226, 141, 159, 159, 180, 42, 24, 12, 105, 147, 32, 231, 44, 109, 241 }, new byte[] { 151, 208, 155, 205, 195, 196, 159, 202, 19, 235, 151, 203, 213, 147, 201, 58, 215, 241, 128, 221, 192, 144, 197, 208, 34, 241, 221, 199, 59, 230, 119, 33, 254, 93, 67, 3, 50, 141, 178, 87, 226, 108, 206, 60, 135, 71, 220, 150, 218, 119, 201, 201, 137, 135, 213, 157, 218, 135, 126, 18, 65, 118, 182, 64, 107, 196, 241, 250, 215, 136, 119, 78, 117, 218, 213, 205, 92, 160, 122, 121, 160, 78, 26, 207, 0, 254, 52, 187, 192, 84, 9, 195, 42, 201, 246, 94, 29, 171, 119, 171, 116, 21, 103, 84, 142, 206, 24, 57, 173, 53, 155, 105, 68, 83, 98, 150, 5, 194, 203, 175, 26, 66, 206, 78, 148, 69, 59, 62 }, "1111111", "photoUrl", null, "doctor" },
                    { 4, "address", new DateTime(1900, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "User", "string4", "string4", 1, false, "string4", new byte[] { 240, 175, 156, 237, 136, 46, 233, 233, 188, 39, 245, 36, 122, 30, 64, 142, 100, 42, 50, 47, 118, 128, 85, 115, 225, 69, 86, 149, 195, 128, 139, 136, 210, 121, 218, 77, 172, 30, 144, 145, 184, 105, 219, 9, 144, 154, 16, 169, 201, 226, 141, 159, 159, 180, 42, 24, 12, 105, 147, 32, 231, 44, 109, 241 }, new byte[] { 151, 208, 155, 205, 195, 196, 159, 202, 19, 235, 151, 203, 213, 147, 201, 58, 215, 241, 128, 221, 192, 144, 197, 208, 34, 241, 221, 199, 59, 230, 119, 33, 254, 93, 67, 3, 50, 141, 178, 87, 226, 108, 206, 60, 135, 71, 220, 150, 218, 119, 201, 201, 137, 135, 213, 157, 218, 135, 126, 18, 65, 118, 182, 64, 107, 196, 241, 250, 215, 136, 119, 78, 117, 218, 213, 205, 92, 160, 122, 121, 160, 78, 26, 207, 0, 254, 52, 187, 192, 84, 9, 195, 42, 201, 246, 94, 29, 171, 119, 171, 116, 21, 103, 84, 142, 206, 24, 57, 173, 53, 155, 105, 68, 83, 98, 150, 5, 194, 203, 175, 26, 66, 206, 78, 148, 69, 59, 62 }, "1111111", "photoUrl", null, "doctor" }
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
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "IsDeleted", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "users.admin", null },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "users.read", null },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "users.write", null },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "users.add", null },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "users.update", null },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "users.delete", null },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "doctors.admin", null },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "doctors.read", null },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "doctors.write", null },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "doctors.add", null },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "doctors.update", null },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "doctors.delete", null },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "patients.admin", null },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "patients.read", null },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "patients.write", null },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "patients.add", null },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "patients.update", null },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "patients.delete", null },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "doctorAvailabilities.admin", null },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "doctorAvailabilities.read", null },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "doctorAvailabilities.write", null },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "doctorAvailabilities.add", null },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "doctorAvailabilities.update", null },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "doctorAvailabilities.delete", null },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "patientReports.admin", null },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "patientReports.read", null },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "patientReports.write", null },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "patientReports.add", null },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "patientReports.update", null },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "patientReports.delete", null },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "appointments.admin", null },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "appointments.read", null },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "appointments.write", null },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "appointments.add", null },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "appointments.update", null },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "appointments.delete", null },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "departments.admin", null },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "departments.read", null },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "departments.write", null },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "departments.add", null },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "departments.update", null },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "departments.delete", null },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "operationClaims.admin", null },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "operationClaims.read", null },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "operationClaims.write", null },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "operationClaims.add", null },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "operationClaims.update", null },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "operationClaims.delete", null },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "userOperationClaims.admin", null },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "userOperationClaims.read", null },
                    { 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "userOperationClaims.write", null },
                    { 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "userOperationClaims.add", null },
                    { 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "userOperationClaims.update", null },
                    { 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "userOperationClaims.delete", null },
                    { 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "feedbacks.admin", null },
                    { 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "feedbacks.read", null },
                    { 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "feedbacks.write", null },
                    { 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "feedbacks.add", null },
                    { 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "feedbacks.update", null },
                    { 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "feedbacks.delete", null },
                    { 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "notifications.admin", null },
                    { 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "notifications.read", null },
                    { 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "notifications.write", null },
                    { 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "notifications.add", null },
                    { 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "notifications.update", null },
                    { 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "notifications.delete", null },
                    { 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "supportRequests.admin", null },
                    { 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "supportRequests.read", null },
                    { 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "supportRequests.write", null },
                    { 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "supportRequests.add", null },
                    { 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "supportRequests.update", null },
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "supportRequests.delete", null }
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
                table: "UserOperationClaims",
                columns: new[] { "Id", "BaseUserId", "CreatedDate", "DeletedDate", "IsDeleted", "OperationClaimId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 1, null },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 7, null },
                    { 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 13, null },
                    { 4, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 19, null },
                    { 5, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 25, null },
                    { 6, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 31, null },
                    { 7, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 37, null },
                    { 8, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 43, null },
                    { 9, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 49, null },
                    { 10, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 55, null },
                    { 11, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 61, null },
                    { 12, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, 67, null },
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
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_UserId",
                table: "Feedbacks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientReports_AppointmentId",
                table: "PatientReports",
                column: "AppointmentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientReports_DoctorId",
                table: "PatientReports",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientReports_PatientId",
                table: "PatientReports",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserId",
                table: "Patients",
                column: "UserId");

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
