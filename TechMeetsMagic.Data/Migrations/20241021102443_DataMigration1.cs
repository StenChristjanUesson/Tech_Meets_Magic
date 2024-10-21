using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechMeetsMagic.Data.Migrations
{
    /// <inheritdoc />
    public partial class DataMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NPCs",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NPCName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NPCDescribtion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NPCLevel = table.Column<int>(type: "int", nullable: false),
                    NPCStatus = table.Column<int>(type: "int", nullable: false),
                    NPCMaxHP = table.Column<int>(type: "int", nullable: false),
                    NPCCurrentHP = table.Column<int>(type: "int", nullable: false),
                    NPCAttackDamage = table.Column<int>(type: "int", nullable: false),
                    NpcType = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NPCs", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NPCs");
        }
    }
}
