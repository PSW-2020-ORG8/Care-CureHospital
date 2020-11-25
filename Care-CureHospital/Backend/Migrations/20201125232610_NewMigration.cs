using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anamnesies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anamnesies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialitations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SpecialitationForDoctor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialitations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesOfRoom",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameOfType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfRoom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    AnamnesisId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnosies_Anamnesies_AnamnesisId",
                        column: x => x.AnamnesisId,
                        principalTable: "Anamnesies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Symptomes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    AnamnesisId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Symptomes_Anamnesies_AnamnesisId",
                        column: x => x.AnamnesisId,
                        principalTable: "Anamnesies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PostCode = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FromDateTime = table.Column<DateTime>(nullable: false),
                    ToDateTime = table.Column<DateTime>(nullable: false),
                    RoomId = table.Column<string>(nullable: true),
                    TypeOfRoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_TypesOfRoom_TypeOfRoomId",
                        column: x => x.TypeOfRoomId,
                        principalTable: "TypesOfRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ParentName = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Jmbg = table.Column<string>(nullable: true),
                    IdentityCard = table.Column<string>(nullable: true),
                    HealthInsuranceCard = table.Column<string>(nullable: true),
                    BloodGroup = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    ContactNumber = table.Column<string>(nullable: true),
                    EMail = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    SpecialitationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctor_Specialitations_SpecialitationId",
                        column: x => x.SpecialitationId,
                        principalTable: "Specialitations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ParentName = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Jmbg = table.Column<string>(nullable: true),
                    IdentityCard = table.Column<string>(nullable: true),
                    HealthInsuranceCard = table.Column<string>(nullable: true),
                    BloodGroup = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    ContactNumber = table.Column<string>(nullable: true),
                    EMail = table.Column<string>(nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    GuestAccount = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patient_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventaryRoom",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventaryRoom", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventaryRoom_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalExaminations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FromDateTime = table.Column<DateTime>(nullable: false),
                    ToDateTime = table.Column<DateTime>(nullable: false),
                    Urgency = table.Column<bool>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: true),
                    RoomId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalExaminations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalExaminations_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalExaminations_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalExaminations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientId = table.Column<int>(nullable: false),
                    AnamnesisId = table.Column<int>(nullable: false),
                    ActiveMedicalRecord = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Anamnesies_AnamnesisId",
                        column: x => x.AnamnesisId,
                        principalTable: "Anamnesies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientFeedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(nullable: true),
                    PublishingDate = table.Column<DateTime>(nullable: false),
                    IsForPublishing = table.Column<bool>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    IsAnonymous = table.Column<bool>(nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientFeedbacks_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FromDateTime = table.Column<DateTime>(nullable: false),
                    ToDateTime = table.Column<DateTime>(nullable: false),
                    Urgency = table.Column<bool>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: true),
                    RoomId = table.Column<int>(nullable: false),
                    DoctorSpecialistId = table.Column<int>(nullable: false),
                    PatientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Survey_Doctor_DoctorSpecialistId",
                        column: x => x.DoctorSpecialistId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Survey_Patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Survey_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalExaminationReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    PublishingDate = table.Column<DateTime>(nullable: false),
                    MedicalExaminationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalExaminationReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalExaminationReport_MedicalExaminations_MedicalExaminat~",
                        column: x => x.MedicalExaminationId,
                        principalTable: "MedicalExaminations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    PublishingDate = table.Column<DateTime>(nullable: false),
                    MedicalExaminationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescription_MedicalExaminations_MedicalExaminationId",
                        column: x => x.MedicalExaminationId,
                        principalTable: "MedicalExaminations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Survey1",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    CommentSurvey = table.Column<string>(nullable: true),
                    PublishingDate = table.Column<DateTime>(nullable: false),
                    MedicalExaminationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Survey1_MedicalExaminations_MedicalExaminationId",
                        column: x => x.MedicalExaminationId,
                        principalTable: "MedicalExaminations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    MedicalRecordId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Allergies_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicaments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Producer = table.Column<string>(nullable: true),
                    StateOfValidation = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Ingredients = table.Column<string>(nullable: true),
                    MedicalRecordId = table.Column<int>(nullable: false),
                    PrescriptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicaments_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Medicaments_Prescription_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuestionText = table.Column<string>(nullable: true),
                    Answer = table.Column<int>(nullable: false),
                    SurveyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Survey1_SurveyId",
                        column: x => x.SurveyId,
                        principalTable: "Survey1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Anamnesies",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Pacijent je dobro" },
                    { 2, "Pacijent je loše" },
                    { 3, "Pacijent je vrlo dobro" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Srbija" });

            migrationBuilder.InsertData(
                table: "Specialitations",
                columns: new[] { "Id", "SpecialitationForDoctor" },
                values: new object[,]
                {
                    { 1, "Lekar opste prakse" },
                    { 2, "Hirurg" }
                });

            migrationBuilder.InsertData(
                table: "TypesOfRoom",
                columns: new[] { "Id", "NameOfType" },
                values: new object[,]
                {
                    { 1, "Soba za preglede" },
                    { 2, "Soba za operacije" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Address", "CountryId", "Name", "PostCode" },
                values: new object[,]
                {
                    { 1, "Brace Jerkovic 1", 1, "Beograd", 11000 },
                    { 2, "Bulevar Cara Lazara 1", 1, "Novi Sad", 22100 }
                });

            migrationBuilder.InsertData(
                table: "Diagnosies",
                columns: new[] { "Id", "AnamnesisId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Prehlada" },
                    { 2, 2, "Virus" },
                    { 3, 2, "Migrena" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "FromDateTime", "RoomId", "ToDateTime", "TypeOfRoomId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "101", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "201", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "301", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Symptomes",
                columns: new[] { "Id", "AnamnesisId", "Name" },
                values: new object[,]
                {
                    { 2, 1, "Kašalj" },
                    { 1, 2, "Temperatura" },
                    { 3, 2, "Glavobolja" }
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "BloodGroup", "CityId", "ContactNumber", "DateOfBirth", "EMail", "Gender", "HealthInsuranceCard", "IdentityCard", "Jmbg", "Name", "ParentName", "Password", "SpecialitationId", "Surname", "Username" },
                values: new object[,]
                {
                    { 2, 0, 1, "06345111144", new DateTime(2004, 1, 1, 3, 3, 3, 0, DateTimeKind.Unspecified), "aca@gmail.com", 0, null, null, "13212312312312", "Aleksandar", null, "123", 1, "Aleksic", "aca" },
                    { 4, 0, 1, "06345111144", new DateTime(2004, 1, 1, 3, 3, 3, 0, DateTimeKind.Unspecified), "nikola@gmail.com", 0, null, null, "13316712312312", "Nikola", null, "123", 1, "Nikic", "nikola" },
                    { 1, 0, 2, "06345111144", new DateTime(2000, 1, 1, 3, 3, 3, 0, DateTimeKind.Unspecified), "milan@gmail.com", 0, null, null, "13312312312312", "Milan", null, "123", 1, "Petrovic", "milan" },
                    { 3, 0, 2, "06345111144", new DateTime(2005, 1, 1, 3, 3, 3, 0, DateTimeKind.Unspecified), "jovan@gmail.com", 0, null, null, "13312367312312", "Jovan", null, "123", 2, "Jovic", "jovan" }
                });

            migrationBuilder.InsertData(
                table: "InventaryRoom",
                columns: new[] { "Id", "Name", "Quantity", "RoomId" },
                values: new object[,]
                {
                    { 1, "Stolovi", 1, 1 },
                    { 2, "Stolice", 1, 1 },
                    { 3, "Kreveti", 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "BloodGroup", "CityId", "ContactNumber", "DateOfBirth", "EMail", "Gender", "GuestAccount", "HealthInsuranceCard", "IdentityCard", "Jmbg", "Name", "ParentName", "Password", "Surname", "Username" },
                values: new object[,]
                {
                    { 1, 2, 1, "063554533", new DateTime(2000, 1, 1, 3, 3, 3, 0, DateTimeKind.Unspecified), "pera@gmail.com", 0, false, "32312312312", "123123123", "13312312312312", "Petar", "Zika", "123", "Petrovic", "pera" },
                    { 3, 0, 1, "0635557673", new DateTime(2002, 1, 1, 3, 3, 3, 0, DateTimeKind.Unspecified), "mica@gmail.com", 0, false, "62312312312", "163123123", "12312512312312", "Mica", "Jelena", "123", "Micic", "mica" },
                    { 2, 2, 2, "0635235333", new DateTime(2001, 1, 1, 3, 3, 3, 0, DateTimeKind.Unspecified), "zika@gmail.com", 0, false, "712312312312", "124123123", "12342312312312", "Zika", "Pera", "123", "Zikic", "zika" },
                    { 4, 2, 2, "063555356", new DateTime(2004, 1, 1, 3, 3, 3, 0, DateTimeKind.Unspecified), "luna@gmail.com", 1, false, "52312312312", "127123123", "12312316712312", "Luna", "Jovan", "123", "Lunic", "luna" }
                });

            migrationBuilder.InsertData(
                table: "MedicalExaminations",
                columns: new[] { "Id", "DoctorId", "FromDateTime", "PatientId", "RoomId", "ShortDescription", "ToDateTime", "Urgency" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "Pacijent je imao glavobolju", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 3, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, "Sve je bilo u redu na pregledu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 5, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, "Pacijenta je boleo stomak", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 6, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, "Sve je bilo u redu na pregledu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 4, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, "Pacijenta je boleo stomak", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false },
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, "Sve je bilo u redu na pregledu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false }
                });

            migrationBuilder.InsertData(
                table: "MedicalRecords",
                columns: new[] { "Id", "ActiveMedicalRecord", "AnamnesisId", "PatientId" },
                values: new object[,]
                {
                    { 1, false, 1, 1 },
                    { 3, true, 1, 3 },
                    { 2, true, 1, 2 },
                    { 4, true, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "PatientFeedbacks",
                columns: new[] { "Id", "IsAnonymous", "IsForPublishing", "IsPublished", "PatientId", "PublishingDate", "Text" },
                values: new object[,]
                {
                    { 1, false, true, true, 1, new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika." },
                    { 3, true, true, false, 3, new DateTime(2020, 9, 3, 11, 30, 0, 0, DateTimeKind.Unspecified), "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika." },
                    { 2, true, true, true, 2, new DateTime(2020, 8, 15, 9, 17, 0, 0, DateTimeKind.Unspecified), "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika." },
                    { 5, false, false, false, 2, new DateTime(2020, 10, 18, 7, 30, 0, 0, DateTimeKind.Unspecified), "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika." },
                    { 4, false, false, false, 4, new DateTime(2020, 11, 6, 8, 30, 0, 0, DateTimeKind.Unspecified), "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika." },
                    { 6, true, true, false, 4, new DateTime(2020, 10, 15, 6, 30, 0, 0, DateTimeKind.Unspecified), "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika." }
                });

            migrationBuilder.InsertData(
                table: "Allergies",
                columns: new[] { "Id", "MedicalRecordId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Penicilin" },
                    { 4, 1, "Ambrozija" },
                    { 2, 3, "Brufen" },
                    { 3, 2, "Panadol" }
                });

            migrationBuilder.InsertData(
                table: "MedicalExaminationReport",
                columns: new[] { "Id", "Comment", "MedicalExaminationId", "PublishingDate" },
                values: new object[,]
                {
                    { 3, "Pacijent ima virus", 2, new DateTime(2020, 9, 12, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Pacijent je lose", 2, new DateTime(2020, 10, 14, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Pacijent ima virus", 2, new DateTime(2020, 11, 18, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 1, "Pacijent je dobro i nema vecih problema", 3, new DateTime(2020, 9, 20, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Pacijent je veoma dobro i nema vecih problema", 4, new DateTime(2020, 11, 23, 10, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "Id", "Comment", "MedicalExaminationId", "PublishingDate" },
                values: new object[,]
                {
                    { 3, "Redovno koristite prepisane lekove", 2, new DateTime(2020, 12, 25, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Ne preskacite konzumiranje leka", 2, new DateTime(2020, 10, 12, 3, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Svakodnevno koristite prepisani lek", 3, new DateTime(2020, 9, 12, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 1, "Redovno koristite prepisane lekove", 4, new DateTime(2020, 11, 30, 10, 30, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Redovno koristite prepisane lekove", 4, new DateTime(2020, 11, 26, 10, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Survey1",
                columns: new[] { "Id", "CommentSurvey", "MedicalExaminationId", "PublishingDate", "Title" },
                values: new object[,]
                {
                    { 2, "Sve je super u bolnici", 2, new DateTime(2020, 11, 6, 8, 30, 0, 0, DateTimeKind.Unspecified), "Naslov" },
                    { 1, "Sve je super u bolnici", 1, new DateTime(2020, 11, 6, 8, 30, 0, 0, DateTimeKind.Unspecified), "Naslov" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "Id", "Code", "Ingredients", "MedicalRecordId", "Name", "PrescriptionId", "Producer", "Quantity", "StateOfValidation" },
                values: new object[,]
                {
                    { 3, "L523", "sastojak1, sastojak2, sastojak3", 3, "Paracetamol", 3, "Hemofarm", 10, 0 },
                    { 2, "L233", "sastojak1, sastojak2, sastojak3", 2, "Panadol", 1, "Hemofarm", 10, 0 },
                    { 1, "L123", "sastojak1, sastojak2, sastojak3", 1, "Brufen", 1, "Hemofarm", 10, 0 },
                    { 4, "L423", "sastojak1, sastojak2, sastojak3", 4, "Vitamin B", 2, "Hemofarm", 10, 0 },
                    { 5, "L233", "sastojak1, sastojak2, sastojak3", 1, "Panadol", 2, "Hemofarm", 14, 0 }
                });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Answer", "QuestionText", "SurveyId" },
                values: new object[,]
                {
                    { 14, 4, "Posvećenost medicinskog osoblja pacijentu", 2 },
                    { 7, 3, "Ispunjenost vremena zakazanog termina i vreme provedeno u cekonici", 1 },
                    { 6, 0, "Profesionalizam u obavljanju svoji duznosti medicinskog osoblja", 1 },
                    { 5, 1, "Posvećenost medicinskog osoblja pacijentu", 1 },
                    { 4, 0, "Ljubaznost medicinskog osoblja prema pacijentu", 1 },
                    { 3, 1, "Pružanje informacija od strane doktora o mom zdravstvenom stanju i mogućnostima lečenja", 1 },
                    { 2, 0, "Posvećenost doktora pacijentu", 1 },
                    { 1, 1, "Ljubaznost doktora prema pacijentu", 1 },
                    { 10, 1, "Ljubaznost doktora prema pacijentu", 2 },
                    { 11, 1, "Posvećenost doktora pacijentu", 2 },
                    { 8, 4, "Higijena unutar bolnice", 1 },
                    { 12, 0, "Pružanje informacija od strane doktora o mom zdravstvenom stanju i mogućnostima lečenja", 2 },
                    { 18, 2, "Opremljenost bolnice", 2 },
                    { 17, 1, "Higijena unutar bolnice", 2 },
                    { 16, 2, "Ispunjenost vremena zakazanog termina i vreme provedeno u cekonici", 2 },
                    { 15, 4, "Profesionalizam u obavljanju svoji duznosti medicinskog osoblja", 2 },
                    { 13, 3, "Ljubaznost medicinskog osoblja prema pacijentu", 2 },
                    { 9, 1, "Opremljenost bolnice", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_MedicalRecordId",
                table: "Allergies",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosies_AnamnesisId",
                table: "Diagnosies",
                column: "AnamnesisId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_CityId",
                table: "Doctor",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_SpecialitationId",
                table: "Doctor",
                column: "SpecialitationId");

            migrationBuilder.CreateIndex(
                name: "IX_InventaryRoom_RoomId",
                table: "InventaryRoom",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExaminationReport_MedicalExaminationId",
                table: "MedicalExaminationReport",
                column: "MedicalExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExaminations_DoctorId",
                table: "MedicalExaminations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExaminations_PatientId",
                table: "MedicalExaminations",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExaminations_RoomId",
                table: "MedicalExaminations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_AnamnesisId",
                table: "MedicalRecords",
                column: "AnamnesisId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PatientId",
                table: "MedicalRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicaments_MedicalRecordId",
                table: "Medicaments",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicaments_PrescriptionId",
                table: "Medicaments",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_CityId",
                table: "Patient",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientFeedbacks_PatientId",
                table: "PatientFeedbacks",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_MedicalExaminationId",
                table: "Prescription",
                column: "MedicalExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_SurveyId",
                table: "Question",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_TypeOfRoomId",
                table: "Rooms",
                column: "TypeOfRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_DoctorSpecialistId",
                table: "Survey",
                column: "DoctorSpecialistId");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_PatientId",
                table: "Survey",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_RoomId",
                table: "Survey",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Survey1_MedicalExaminationId",
                table: "Survey1",
                column: "MedicalExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_Symptomes_AnamnesisId",
                table: "Symptomes",
                column: "AnamnesisId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "Diagnosies");

            migrationBuilder.DropTable(
                name: "InventaryRoom");

            migrationBuilder.DropTable(
                name: "MedicalExaminationReport");

            migrationBuilder.DropTable(
                name: "Medicaments");

            migrationBuilder.DropTable(
                name: "PatientFeedbacks");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "Symptomes");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Survey1");

            migrationBuilder.DropTable(
                name: "Anamnesies");

            migrationBuilder.DropTable(
                name: "MedicalExaminations");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Specialitations");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "TypesOfRoom");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
