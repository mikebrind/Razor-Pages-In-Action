using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CityBreaks.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CountryName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    ISO3166code = table.Column<string>(name: "ISO 3166 code", type: "TEXT", maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    CityId = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxNumberOfGuests = table.Column<int>(type: "INTEGER", nullable: false),
                    DayRate = table.Column<decimal>(type: "TEXT", nullable: false),
                    SmokingPermitted = table.Column<bool>(type: "INTEGER", nullable: false),
                    AvailableFrom = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ISO 3166 code", "CountryName" },
                values: new object[] { 1, "hr", "Croatia" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ISO 3166 code", "CountryName" },
                values: new object[] { 2, "dk", "Denmark" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ISO 3166 code", "CountryName" },
                values: new object[] { 3, "fr", "France" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ISO 3166 code", "CountryName" },
                values: new object[] { 4, "de", "Germany" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ISO 3166 code", "CountryName" },
                values: new object[] { 5, "nl", "Holland" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ISO 3166 code", "CountryName" },
                values: new object[] { 6, "it", "Italy" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ISO 3166 code", "CountryName" },
                values: new object[] { 7, "es", "Spain" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ISO 3166 code", "CountryName" },
                values: new object[] { 8, "gb", "United Kingdom" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "ISO 3166 code", "CountryName" },
                values: new object[] { 9, "us", "United States" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name", "Image" },
                values: new object[] { 5, 1, "Dubrovnik", "dubrovnik.jpg" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name", "Image" },
                values: new object[] { 4, 2, "Copenhagen", "copenhagen.jpg" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name", "Image" },
                values: new object[] { 10, 3, "Paris", "paris.jpg" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name", "Image" },
                values: new object[] { 3, 4, "Berlin", "berlin.jpg" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name", "Image" },
                values: new object[] { 1, 5, "Amsterdam", "amsterdam.jpg" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name", "Image" },
                values: new object[] { 11, 6, "Rome", "rome.jpg" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name", "Image" },
                values: new object[] { 12, 6, "Venice", "venice.jpg" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name", "Image" },
                values: new object[] { 2, 7, "Barcelona", "barcelona.jpg" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name", "Image" },
                values: new object[] { 8, 7, "Madrid", "madrid.jpg" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name", "Image" },
                values: new object[] { 6, 8, "Edinburgh", "edinburgh.jpg" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name", "Image" },
                values: new object[] { 7, 8, "London", "london.jpg" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name", "Image" },
                values: new object[] { 9, 9, "New York", "new-york.jpg" });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 13, "Hlidina ul.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 66.00m, 2, "Hotel Kalisi", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 43, "Via Canale", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 60.00m, 3, "Hotel Antonio", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 4, "Carrer Dels Talles", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 42.00m, 2, "Gothic Hotel", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 15, "Carrer de Ferren", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 68.00m, 1, "The Schafer", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 38, "Via Laietana", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 88.00m, 3, "Hotel Colonial", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 7, "Calle del Amparo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 87.00m, 2, "Tapas Hotel", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 18, "Calle de la Fe", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 86.00m, 3, "Ceveceria Hotel", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 34, "Calle del Bosce", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 71.00m, 4, "Hotel Mardi Gras", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 8, "Cowgate", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 81.00m, 1, "Halfpenny Hotel", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 23, "Grassmarket", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 86.00m, 2, "The Drop Inn Well", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 26, "Castle Hill", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 82.00m, 2, "Bide A Wee", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 29, "Fraser Street", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 89.00m, 2, "15", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 33, "Princes Street", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 43.00m, 1, "The Majestic", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 35, "George Street", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 56.00m, 1, "Atlantic Hotel", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 40, "Queen Street", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 81.00m, 3, "The Royal", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 42, "St Andrew Square", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 44.00m, 1, "The Cudogan", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 49, "South Bridge", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 73.00m, 1, "124", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 3, "The Strand", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 72.00m, 2, "Ratz Hotel", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 19, "Charing Cross Road", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 89.00m, 2, "The Sleepover", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 12, "7th Avenue", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 52.00m, 4, "New Yorker", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 25, "Broadway", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 52.00m, 2, "The Theatre Hotel", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 30, "W 30th St", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 63.00m, 1, "1742", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 41, "Calle de Mezzo", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 58.00m, 3, "Hotel Soprano", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 32, "Calle Ponti di Venici", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 69.00m, 4, "17", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 11, "Calle Oche", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 70.00m, 3, "Gondalo Hotel", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 6, "Calle dei Mercanti", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 50.00m, 3, "Merchant's Hotel", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 17, "Đorđićeva ul.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 50.00m, 4, "7", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 2, "Vester Volgade", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 75.00m, 1, "Andersen Hotel", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 9, "Magstraede", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 60.00m, 3, "Mermaid Inn", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 14, "Svætegarde", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 66.00m, 1, "Schlaafhaus", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 21, "Sankt Annæ Pl", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 41.00m, 3, "Nummer Ni", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 24, "Christianshavn Voldgade", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 50.00m, 3, "32", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 27, "Nørre Allé", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 59.00m, 1, "16", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 31, "Hans Kirks Wej", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 53.00m, 2, "6", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 47, "Favergade", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 60.00m, 2, "City Hotel", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 50, "Lavendelstræde", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 75.00m, 4, "Det Lille", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 37, "Madison Avenue", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 89.00m, 1, "The Presidents Hotel", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 1, "Rue de Reynard", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 81.00m, 1, "Hotel Paris", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 5, "Kurfürstenstraße", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 68.00m, 3, "Beetle Hotel", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 16, "Pohlstraße", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 58.00m, 1, "Beliner Hotel", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 39, "Bülowstraße", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 87.00m, 2, "Saigon Night", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 10, "Beursstraat", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 72.00m, 2, "Dam Hotel", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 20, "Nieuwendijk", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 69.00m, 1, "14", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 22, "Wolvenstraate", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 86.00m, 1, "33", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 28, "Oudezijds Voorburgwal", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 69.00m, 3, "The Lion Hotel", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 36, "Damstraat", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 46.00m, 4, "Van Dijk Hotel", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 44, "Via Barberini", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 53.00m, 4, "Hotel Ponti", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 48, "Via della Corozza", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 89.00m, 1, "Bottino Hotel", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 45, "Rue Visconti", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 53.00m, 3, "Hotel Seine", false });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailableFrom", "CityId", "DayRate", "MaxNumberOfGuests", "Name", "SmokingPermitted" },
                values: new object[] { 46, "6th Ave", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 65.00m, 3, "452", false });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CityId",
                table: "Properties",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
