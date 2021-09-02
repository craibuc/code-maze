using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "owner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    RegionCode = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owner", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AccountType = table.Column<int>(type: "INTEGER", nullable: false),
                    OwnerId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_account_owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "owner",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "owner",
                columns: new[] { "Id", "City", "FirstName", "LastName", "PostalCode", "RegionCode", "Street" },
                values: new object[] { 1, "city", "John", "Doe", "00000", "AA", "street" });

            migrationBuilder.InsertData(
                table: "owner",
                columns: new[] { "Id", "City", "FirstName", "LastName", "PostalCode", "RegionCode", "Street" },
                values: new object[] { 2, "city", "Jane", "Foe", "00000", "AA", "street" });

            migrationBuilder.InsertData(
                table: "account",
                columns: new[] { "Id", "AccountType", "DateCreated", "OwnerId" },
                values: new object[] { 100, 0, new DateTime(2021, 9, 2, 9, 28, 46, 932, DateTimeKind.Local).AddTicks(4086), 1 });

            migrationBuilder.InsertData(
                table: "account",
                columns: new[] { "Id", "AccountType", "DateCreated", "OwnerId" },
                values: new object[] { 200, 1, new DateTime(2021, 9, 2, 9, 28, 46, 935, DateTimeKind.Local).AddTicks(6923), 1 });

            migrationBuilder.InsertData(
                table: "account",
                columns: new[] { "Id", "AccountType", "DateCreated", "OwnerId" },
                values: new object[] { 300, 0, new DateTime(2021, 9, 2, 9, 28, 46, 935, DateTimeKind.Local).AddTicks(6954), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_account_OwnerId",
                table: "account",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropTable(
                name: "owner");
        }
    }
}
