using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class CsoportForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beosztasok_Csoportok_CsoportId",
                table: "Beosztasok");

            migrationBuilder.DropIndex(
                name: "IX_Beosztasok_CsoportId",
                table: "Beosztasok");

            migrationBuilder.DropColumn(
                name: "CsoportId",
                table: "Beosztasok");

            migrationBuilder.AddColumn<Guid>(
                name: "Csoport_Id",
                table: "Beosztasok",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Beosztasok_Csoport_Id",
                table: "Beosztasok",
                column: "Csoport_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Beosztasok_Csoportok_Csoport_Id",
                table: "Beosztasok",
                column: "Csoport_Id",
                principalTable: "Csoportok",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beosztasok_Csoportok_Csoport_Id",
                table: "Beosztasok");

            migrationBuilder.DropIndex(
                name: "IX_Beosztasok_Csoport_Id",
                table: "Beosztasok");

            migrationBuilder.DropColumn(
                name: "Csoport_Id",
                table: "Beosztasok");

            migrationBuilder.AddColumn<Guid>(
                name: "CsoportId",
                table: "Beosztasok",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beosztasok_CsoportId",
                table: "Beosztasok",
                column: "CsoportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beosztasok_Csoportok_CsoportId",
                table: "Beosztasok",
                column: "CsoportId",
                principalTable: "Csoportok",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
