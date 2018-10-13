using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Roomly.Data.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<Guid>(nullable: false),
                    A = table.Column<string>(nullable: true),
                    Answer = table.Column<string>(nullable: true),
                    B = table.Column<string>(nullable: true),
                    Body = table.Column<string>(nullable: true),
                    C = table.Column<string>(nullable: true),
                    Category = table.Column<short>(nullable: false),
                    D = table.Column<string>(nullable: true),
                    E = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    MultipleChoice = table.Column<bool>(nullable: false),
                    ShortAnswer = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    TrueFalse = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
