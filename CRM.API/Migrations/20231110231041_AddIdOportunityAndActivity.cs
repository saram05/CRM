using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRM.API.Migrations
{
    /// <inheritdoc />
    public partial class AddIdOportunityAndActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Oportunities_OportunityId",
                table: "Activities");

            migrationBuilder.AddColumn<int>(
                name: "CleintId",
                table: "Oportunities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "OportunityId",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Oportunities_OportunityId",
                table: "Activities",
                column: "OportunityId",
                principalTable: "Oportunities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Oportunities_OportunityId",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "CleintId",
                table: "Oportunities");

            migrationBuilder.AlterColumn<int>(
                name: "OportunityId",
                table: "Activities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Oportunities_OportunityId",
                table: "Activities",
                column: "OportunityId",
                principalTable: "Oportunities",
                principalColumn: "Id");
        }
    }
}
