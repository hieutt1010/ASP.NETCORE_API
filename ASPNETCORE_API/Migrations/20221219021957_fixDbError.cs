using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPNETCOREAPI.Migrations
{
    /// <inheritdoc />
    public partial class fixDbError : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "WalkDifficuties");

            migrationBuilder.DropColumn(
                name: "WalkDifficultyId",
                table: "WalkDifficuties");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RegionId",
                table: "WalkDifficuties",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "WalkDifficultyId",
                table: "WalkDifficuties",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
