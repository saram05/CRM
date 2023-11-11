using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDateOportunity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FinishDate",
                table: "Oportunities",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedDate",
                table: "Oportunities",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 15);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FinishDate",
                table: "Oportunities",
                type: "datetime2",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Oportunities",
                type: "datetime2",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);
        }
    }
}
