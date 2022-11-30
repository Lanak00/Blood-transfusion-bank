using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BloodTransfusionBank.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonationCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonationCenters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DonationCenterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_DonationCenters_DonationCenterId",
                        column: x => x.DonationCenterId,
                        principalTable: "DonationCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DonationCenters",
                columns: new[] { "Id", "Address", "City", "Description", "Image", "Name", "Rating" },
                values: new object[] { 1, "201 Main St", "New York", "Donation Center is a health facility where you can schedule appointment to donate blood. In order to be able to donate blood you have to complete the survey first and also make sure your last bloodd donation was at least six months ago.", "https://upload.wikimedia.org/wikipedia/commons/3/3d/Hartford_Hospital_main_entrance.JPG", "Donation Center 1", 4.7999999999999998 });

            migrationBuilder.InsertData(
                table: "DonationCenters",
                columns: new[] { "Id", "Address", "City", "Description", "Image", "Name", "Rating" },
                values: new object[] { 2, "15 Maple St", "New York", "Donation Center is a health facility where you can schedule appointment to donate blood. In order to be able to donate blood you have to complete the survey first and also make sure your last bloodd donation was at least six months ago.", "https://i0.wp.com/ctnewsjunkie.com/wp-content/uploads/2020/12/UConn_Health_Center_wikipedia_720x540_720_540_99_sha-100.jpg?fit=720%2C540&ssl=1", "Donation Center 2", 4.2999999999999998 });

            migrationBuilder.InsertData(
                table: "DonationCenters",
                columns: new[] { "Id", "Address", "City", "Description", "Image", "Name", "Rating" },
                values: new object[] { 3, "201 Main St", "New York", "Donation Center is a health facility where you can schedule appointment to donate blood. In order to be able to donate blood you have to complete the survey first and also make sure your last bloodd donation was at least six months ago.", "https://upload.wikimedia.org/wikipedia/commons/3/3d/Hartford_Hospital_main_entrance.JPG", "Donation Center 33", 4.0999999999999996 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Date", "DonationCenterId", "Duration", "UserId" },
                values: new object[] { 1, new DateTime(2022, 5, 9, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, 30, 1 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "Date", "DonationCenterId", "Duration", "UserId" },
                values: new object[] { 2, new DateTime(2022, 5, 9, 9, 45, 0, 0, DateTimeKind.Unspecified), 1, 30, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DonationCenterId",
                table: "Appointments",
                column: "DonationCenterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "DonationCenters");
        }
    }
}
