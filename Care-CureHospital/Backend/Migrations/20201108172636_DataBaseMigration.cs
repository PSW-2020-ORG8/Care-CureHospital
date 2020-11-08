using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class DataBaseMigration : Migration
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
                name: "Patients",
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
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosies",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Anamnesisid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosies", x => x.id);
                    table.ForeignKey(
                        name: "FK_Diagnosies_Anamnesies_Anamnesisid",
                        column: x => x.Anamnesisid,
                        principalTable: "Anamnesies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Symptomes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Anamnesisid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symptomes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Symptomes_Anamnesies_Anamnesisid",
                        column: x => x.Anamnesisid,
                        principalTable: "Anamnesies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_MedicalRecords_Patients_id",
                        column: x => x.id,
                        principalTable: "Patients",
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
                        name: "FK_PatientFeedbacks_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allergiess",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    MedicalRecordid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergiess", x => x.id);
                    table.ForeignKey(
                        name: "FK_Allergiess_MedicalRecords_MedicalRecordid",
                        column: x => x.MedicalRecordid,
                        principalTable: "MedicalRecords",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
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
                    MedicalRecordid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicaments", x => x.id);
                    table.ForeignKey(
                        name: "FK_Medicaments_MedicalRecords_MedicalRecordid",
                        column: x => x.MedicalRecordid,
                        principalTable: "MedicalRecords",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Allergiess",
                columns: new[] { "id", "MedicalRecordid", "Name" },
                values: new object[] { 1, null, "penicilin" });

            migrationBuilder.InsertData(
                table: "Anamnesies",
                columns: new[] { "id", "Description" },
                values: new object[] { 1, "pacijent je dobro" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "id", "Code", "Name" },
                values: new object[] { 1, "SRB", "Srbija" });

            migrationBuilder.InsertData(
                table: "Diagnosies",
                columns: new[] { "id", "Anamnesisid", "Name" },
                values: new object[] { 1, null, "prehlada" });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "id", "Code", "Ingredients", "MedicalRecordid", "Name", "Producer", "Quantity", "StateOfValidation" },
                values: new object[] { 1, "c35", "sastojak1, sastojak2, sastojak3", null, "Brufen", "Hemofarm", 10, 0 });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "ContactNumber", "DateOfBirth", "EMail", "GuestAccount", "Jmbg", "MedicalRecordID", "Name", "Password", "Surname", "Username", "cityID" },
                values: new object[,]
                {
                    { 1, "063555333", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera@gmail.com", false, "123", 1, "Petar", "123", "Petrovic", "pera", 1 },
                    { 2, "063555333", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera@gmail.com", false, "123", 1, "Milos", "123", "Mitrovic", "pera", 1 },
                    { 3, "063555333", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera@gmail.com", false, "123", 1, "Jovan", "123", "Jovanovic", "pera", 1 },
                    { 4, "063555333", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "pera@gmail.com", false, "123", 1, "Milica", "123", "Micic", "pera", 1 }
                });

            migrationBuilder.InsertData(
                table: "Symptomes",
                columns: new[] { "id", "Anamnesisid", "Name" },
                values: new object[,]
                {
                    { 1, null, "temperatura" },
                    { 3, null, "kijanje" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "id", "Adress", "CountryID", "Name", "PostCode" },
                values: new object[] { 1, null, 1, "Beograd", 11000 });

            migrationBuilder.InsertData(
                table: "MedicalRecords",
                columns: new[] { "id", "anamnesisID", "patientID" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "PatientFeedbacks",
                columns: new[] { "Id", "IsAnonymous", "IsForPublishing", "IsPublished", "PatientID", "PublishingDate", "Text" },
                values: new object[,]
                {
                    { 1, false, true, true, 1, new DateTime(2020, 10, 30, 10, 30, 0, 0, DateTimeKind.Unspecified), "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika." },
                    { 2, true, true, true, 2, new DateTime(2020, 8, 15, 9, 17, 0, 0, DateTimeKind.Unspecified), "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika." },
                    { 5, false, false, false, 2, new DateTime(2020, 10, 18, 7, 30, 0, 0, DateTimeKind.Unspecified), "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika." },
                    { 3, true, true, false, 3, new DateTime(2020, 9, 3, 11, 30, 0, 0, DateTimeKind.Unspecified), "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika." },
                    { 4, false, false, false, 4, new DateTime(2020, 11, 6, 8, 30, 0, 0, DateTimeKind.Unspecified), "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika." },
                    { 6, true, true, false, 4, new DateTime(2020, 10, 15, 6, 30, 0, 0, DateTimeKind.Unspecified), "Iako rečenica nema značenje, ona ima dugu istoriju. Nju su nekoliko vekova koristili tipografi da bi prikazali najistaknutije osobine svojih fontova. Koristi se zbog toga što slova koja su uključena u nju, kao i razmak između slova u tim kombinacijama na najbolji mogući način otkrivaju težinu, dizajn i druge važne funkcije slovnog oblika." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergiess_MedicalRecordid",
                table: "Allergiess",
                column: "MedicalRecordid");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryID",
                table: "Cities",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosies_Anamnesisid",
                table: "Diagnosies",
                column: "Anamnesisid");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_anamnesisID",
                table: "MedicalRecords",
                column: "anamnesisID");

            migrationBuilder.CreateIndex(
                name: "IX_Medicaments_MedicalRecordid",
                table: "Medicaments",
                column: "MedicalRecordid");

            migrationBuilder.CreateIndex(
                name: "IX_PatientFeedbacks_PatientID",
                table: "PatientFeedbacks",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Symptomes_Anamnesisid",
                table: "Symptomes",
                column: "Anamnesisid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allergiess");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Diagnosies");

            migrationBuilder.DropTable(
                name: "Medicaments");

            migrationBuilder.DropTable(
                name: "PatientFeedbacks");

            migrationBuilder.DropTable(
                name: "Symptomes");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Anamnesies");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
