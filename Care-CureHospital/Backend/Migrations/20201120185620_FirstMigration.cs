using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Anamnesies",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anamnesies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Jmbg = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    ContactNumber = table.Column<string>(nullable: true),
                    EMail = table.Column<string>(nullable: true),
                    cityID = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    GuestAccount = table.Column<bool>(nullable: false),
                    MedicalRecordID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Id);
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
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameOfType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesOfRoom", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosies",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    anamnesisID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosies", x => x.id);
                    table.ForeignKey(
                        name: "FK_Diagnosies_Anamnesies_anamnesisID",
                        column: x => x.anamnesisID,
                        principalTable: "Anamnesies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Symptomes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    anamnesisID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptomes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Symptomes_Anamnesies_anamnesisID",
                        column: x => x.anamnesisID,
                        principalTable: "Anamnesies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PostCode = table.Column<int>(nullable: false),
                    Adress = table.Column<string>(nullable: true),
                    CountryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false),
                    patientID = table.Column<int>(nullable: false),
                    anamnesisID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.id);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Anamnesies_anamnesisID",
                        column: x => x.anamnesisID,
                        principalTable: "Anamnesies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Patient_id",
                        column: x => x.id,
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
                    PatientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientFeedbacks_Patient_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patient",
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
                    Surname = table.Column<string>(nullable: true),
                    Jmbg = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    ContactNumber = table.Column<string>(nullable: true),
                    EMail = table.Column<string>(nullable: true),
                    cityID = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    specialitationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctor_Specialitations_specialitationID",
                        column: x => x.specialitationID,
                        principalTable: "Specialitations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FromDateTime = table.Column<DateTime>(nullable: false),
                    ToDateTime = table.Column<DateTime>(nullable: false),
                    RoomID = table.Column<string>(nullable: true),
                    typeOfRoomID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.id);
                    table.ForeignKey(
                        name: "FK_Rooms_TypesOfRoom_typeOfRoomID",
                        column: x => x.typeOfRoomID,
                        principalTable: "TypesOfRoom",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    medicalRecordID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.id);
                    table.ForeignKey(
                        name: "FK_Allergies_MedicalRecords_medicalRecordID",
                        column: x => x.medicalRecordID,
                        principalTable: "MedicalRecords",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicaments",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Producer = table.Column<string>(nullable: true),
                    StateOfValidation = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Ingredients = table.Column<string>(nullable: true),
                    medicalRecordID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicaments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Medicaments_MedicalRecords_medicalRecordID",
                        column: x => x.medicalRecordID,
                        principalTable: "MedicalRecords",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventaryRoom",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    roomID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventaryRoom", x => x.id);
                    table.ForeignKey(
                        name: "FK_InventaryRoom_Rooms_roomID",
                        column: x => x.roomID,
                        principalTable: "Rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalExamination",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FromDateTime = table.Column<DateTime>(nullable: false),
                    ToDateTime = table.Column<DateTime>(nullable: false),
                    Urgency = table.Column<bool>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: true),
                    roomID = table.Column<int>(nullable: false),
                    doctorID = table.Column<int>(nullable: false),
                    patientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalExamination", x => x.id);
                    table.ForeignKey(
                        name: "FK_MedicalExamination_Doctor_doctorID",
                        column: x => x.doctorID,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalExamination_Patient_patientID",
                        column: x => x.patientID,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalExamination_Rooms_roomID",
                        column: x => x.roomID,
                        principalTable: "Rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FromDateTime = table.Column<DateTime>(nullable: false),
                    ToDateTime = table.Column<DateTime>(nullable: false),
                    Urgency = table.Column<bool>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: true),
                    roomID = table.Column<int>(nullable: false),
                    doctorSpecialistID = table.Column<int>(nullable: false),
                    patientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.id);
                    table.ForeignKey(
                        name: "FK_Survey_Doctor_doctorSpecialistID",
                        column: x => x.doctorSpecialistID,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Survey_Patient_patientID",
                        column: x => x.patientID,
                        principalTable: "Patient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Survey_Rooms_roomID",
                        column: x => x.roomID,
                        principalTable: "Rooms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalExaminationReport",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Comment = table.Column<string>(nullable: true),
                    PublishingDate = table.Column<DateTime>(nullable: false),
                    medicalExaminationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalExaminationReport", x => x.id);
                    table.ForeignKey(
                        name: "FK_MedicalExaminationReport_MedicalExamination_medicalExaminati~",
                        column: x => x.medicalExaminationID,
                        principalTable: "MedicalExamination",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Survey1",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    CommentSurvey = table.Column<string>(nullable: true),
                    PublishingDate = table.Column<DateTime>(nullable: false),
                    medicalExaminationID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey1", x => x.id);
                    table.ForeignKey(
                        name: "FK_Survey1_MedicalExamination_medicalExaminationID",
                        column: x => x.medicalExaminationID,
                        principalTable: "MedicalExamination",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    QuestionText = table.Column<string>(nullable: true),
                    answerID = table.Column<int>(nullable: false),
                    Answer = table.Column<int>(nullable: false),
                    surveyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.id);
                    table.ForeignKey(
                        name: "FK_Question_Survey1_surveyID",
                        column: x => x.surveyID,
                        principalTable: "Survey1",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Anamnesies",
                columns: new[] { "id", "Description" },
                values: new object[,]
                {
                    { 1, "Pacijent je dobro" },
                    { 2, "Pacijent je loše" },
                    { 3, "Pacijent je vrlo dobro" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "id", "Code", "Name" },
                values: new object[] { 1, "SRB", "Srbija" });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "Id", "ContactNumber", "DateOfBirth", "EMail", "GuestAccount", "Jmbg", "MedicalRecordID", "Name", "Password", "Surname", "Username", "cityID" },
                values: new object[,]
                {
                    { 1, "063555333", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera@gmail.com", false, "123", 1, "Petar", "123", "Petrovic", "pera", 1 },
                    { 2, "063555333", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera@gmail.com", false, "123", 2, "Milos", "123", "Mitrovic", "pera", 1 },
                    { 3, "063555333", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera@gmail.com", false, "123", 3, "Jovan", "123", "Jovanovic", "pera", 1 },
                    { 4, "063555333", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera@gmail.com", false, "123", 4, "Milica", "123", "Micic", "pera", 1 }
                });

            migrationBuilder.InsertData(
                table: "Specialitations",
                columns: new[] { "Id", "SpecialitationForDoctor" },
                values: new object[] { 1, "Hirurg" });

            migrationBuilder.InsertData(
                table: "TypesOfRoom",
                columns: new[] { "id", "NameOfType" },
                values: new object[,]
                {
                    { 1, "Soba za preglede" },
                    { 2, "Soba za operacije" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "id", "Adress", "CountryID", "Name", "PostCode" },
                values: new object[] { 1, null, 1, "Beograd", 11000 });

            migrationBuilder.InsertData(
                table: "Diagnosies",
                columns: new[] { "id", "Name", "anamnesisID" },
                values: new object[,]
                {
                    { 3, "Migrena", 2 },
                    { 2, "Virus", 2 },
                    { 1, "Prehlada", 1 }
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "Id", "ContactNumber", "DateOfBirth", "EMail", "Jmbg", "Name", "Password", "Surname", "Username", "cityID", "specialitationID" },
                values: new object[,]
                {
                    { 1, "06345111144", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera@gmail.com", "123", "Petar", "123", "Petrovic", "pera", 1, 1 },
                    { 2, "06345111144", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera@gmail.com", "123", "Petar", "123", "Petrovic", "pera", 1, 1 },
                    { 3, "06345111144", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera@gmail.com", "123", "Petar", "123", "Petrovic", "pera", 1, 1 },
                    { 4, "06345111144", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera@gmail.com", "123", "Petar", "123", "Petrovic", "pera", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "MedicalRecords",
                columns: new[] { "id", "anamnesisID", "patientID" },
                values: new object[,]
                {
                    { 2, 1, 2 },
                    { 4, 1, 4 },
                    { 1, 1, 1 },
                    { 3, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "PatientFeedbacks",
                columns: new[] { "Id", "IsAnonymous", "IsForPublishing", "IsPublished", "PatientID", "PublishingDate", "Text" },
                values: new object[,]
                {
                    { 1, false, true, true, 1, new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika." },
                    { 2, true, true, true, 2, new DateTime(2020, 8, 15, 9, 17, 0, 0, DateTimeKind.Unspecified), "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika." },
                    { 3, true, true, false, 3, new DateTime(2020, 9, 3, 11, 30, 0, 0, DateTimeKind.Unspecified), "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika." },
                    { 6, true, true, false, 4, new DateTime(2020, 10, 15, 6, 30, 0, 0, DateTimeKind.Unspecified), "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika." },
                    { 4, false, false, false, 4, new DateTime(2020, 11, 6, 8, 30, 0, 0, DateTimeKind.Unspecified), "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika." },
                    { 5, false, false, false, 2, new DateTime(2020, 10, 18, 7, 30, 0, 0, DateTimeKind.Unspecified), "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika." }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "id", "FromDateTime", "RoomID", "ToDateTime", "typeOfRoomID" },
                values: new object[,]
                {
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "201", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "101", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "301", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "Symptomes",
                columns: new[] { "id", "Name", "anamnesisID" },
                values: new object[,]
                {
                    { 2, "Kašalj", 1 },
                    { 1, "Temperatura", 2 },
                    { 3, "Glavobolja", 2 }
                });

            migrationBuilder.InsertData(
                table: "Allergies",
                columns: new[] { "id", "Name", "medicalRecordID" },
                values: new object[,]
                {
                    { 1, "Penicilin", 1 },
                    { 4, "Penicilin", 1 },
                    { 3, "Penicilin", 2 },
                    { 2, "Penicilin", 3 }
                });

            migrationBuilder.InsertData(
                table: "InventaryRoom",
                columns: new[] { "id", "Name", "Quantity", "roomID" },
                values: new object[,]
                {
                    { 3, "Kreveti", 1, 2 },
                    { 2, "Stolice", 1, 1 },
                    { 1, "Stolovi", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "MedicalExamination",
                columns: new[] { "id", "FromDateTime", "ShortDescription", "ToDateTime", "Urgency", "doctorID", "patientID", "roomID" },
                values: new object[,]
                {
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sve je bilo uredu na pregledu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 3, 3 },
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sve je bilo uredu na pregledu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, 2, 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sve je bilo uredu na pregledu", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 2, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "id", "Code", "Ingredients", "Name", "Producer", "Quantity", "StateOfValidation", "medicalRecordID" },
                values: new object[,]
                {
                    { 3, "L523", "sastojak1, sastojak2, sastojak3", "Brufen", "Hemofarm", 10, 0, 3 },
                    { 5, "L423", "sastojak1, sastojak2, sastojak3", "Brufen", "Hemofarm", 10, 0, 2 },
                    { 2, "L233", "sastojak1, sastojak2, sastojak3", "Brufen", "Hemofarm", 10, 0, 2 },
                    { 7, "L423", "sastojak1, sastojak2, sastojak3", "Brufen", "Hemofarm", 10, 0, 1 },
                    { 6, "L423", "sastojak1, sastojak2, sastojak3", "Brufen", "Hemofarm", 10, 0, 1 },
                    { 4, "L423", "sastojak1, sastojak2, sastojak3", "Brufen", "Hemofarm", 10, 0, 4 },
                    { 1, "L123", "sastojak1, sastojak2, sastojak3", "Brufen", "Hemofarm", 10, 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "MedicalExaminationReport",
                columns: new[] { "id", "Comment", "PublishingDate", "medicalExaminationID" },
                values: new object[,]
                {
                    { 1, "Pacijent je dobro i nema većih problema", new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Pacijent je veoma dobro i nema većih problema", new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, "Pacijent ima virus", new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "Survey1",
                columns: new[] { "id", "CommentSurvey", "PublishingDate", "Title", "medicalExaminationID" },
                values: new object[,]
                {
                    { 1, "Sve je super u bolnici", new DateTime(2020, 11, 6, 8, 30, 0, 0, DateTimeKind.Unspecified), "Naslov", 1 },
                    { 2, "Sve je super u bolnici", new DateTime(2020, 11, 6, 8, 30, 0, 0, DateTimeKind.Unspecified), "Naslov", 2 }
                });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "id", "Answer", "QuestionText", "answerID", "surveyID" },
                values: new object[,]
                {
                    { 1, 0, "Pitanje1", 1, 1 },
                    { 2, 0, "Pitanje2", 1, 1 },
                    { 5, 0, "Pitanje5", 1, 1 },
                    { 3, 0, "Pitanje3", 1, 2 },
                    { 4, 0, "Pitanje4", 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_medicalRecordID",
                table: "Allergies",
                column: "medicalRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryID",
                table: "Cities",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosies_anamnesisID",
                table: "Diagnosies",
                column: "anamnesisID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_specialitationID",
                table: "Doctor",
                column: "specialitationID");

            migrationBuilder.CreateIndex(
                name: "IX_InventaryRoom_roomID",
                table: "InventaryRoom",
                column: "roomID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExamination_doctorID",
                table: "MedicalExamination",
                column: "doctorID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExamination_patientID",
                table: "MedicalExamination",
                column: "patientID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExamination_roomID",
                table: "MedicalExamination",
                column: "roomID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalExaminationReport_medicalExaminationID",
                table: "MedicalExaminationReport",
                column: "medicalExaminationID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_anamnesisID",
                table: "MedicalRecords",
                column: "anamnesisID");

            migrationBuilder.CreateIndex(
                name: "IX_Medicaments_medicalRecordID",
                table: "Medicaments",
                column: "medicalRecordID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientFeedbacks_PatientID",
                table: "PatientFeedbacks",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Question_surveyID",
                table: "Question",
                column: "surveyID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_typeOfRoomID",
                table: "Rooms",
                column: "typeOfRoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_doctorSpecialistID",
                table: "Survey",
                column: "doctorSpecialistID");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_patientID",
                table: "Survey",
                column: "patientID");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_roomID",
                table: "Survey",
                column: "roomID");

            migrationBuilder.CreateIndex(
                name: "IX_Survey1_medicalExaminationID",
                table: "Survey1",
                column: "medicalExaminationID");

            migrationBuilder.CreateIndex(
                name: "IX_Symptomes_anamnesisID",
                table: "Symptomes",
                column: "anamnesisID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "Cities");

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
                name: "Countries");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Survey1");

            migrationBuilder.DropTable(
                name: "Anamnesies");

            migrationBuilder.DropTable(
                name: "MedicalExamination");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Specialitations");

            migrationBuilder.DropTable(
                name: "TypesOfRoom");
        }
    }
}
