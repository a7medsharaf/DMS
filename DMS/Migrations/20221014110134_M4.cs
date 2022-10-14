using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMS.Migrations
{
    public partial class M4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folders_KnowledgePools_Parent",
                table: "Folders");

            migrationBuilder.DropIndex(
                name: "IX_Folders_Parent",
                table: "Folders");

            migrationBuilder.AddColumn<string>(
                name: "ParentType",
                table: "Folders",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentType",
                table: "Folders");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_Parent",
                table: "Folders",
                column: "Parent");

            migrationBuilder.AddForeignKey(
                name: "FK_Folders_KnowledgePools_Parent",
                table: "Folders",
                column: "Parent",
                principalTable: "KnowledgePools",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
