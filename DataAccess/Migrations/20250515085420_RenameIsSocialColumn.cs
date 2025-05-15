using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MapMyJourneyAPI.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameIsSocialColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Identity_Profiles_ProfileId",
                table: "Identity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Identity",
                table: "Identity");

            migrationBuilder.RenameTable(
                name: "Identity",
                newName: "Identities");

            migrationBuilder.RenameColumn(
                name: "isSocial",
                table: "Identities",
                newName: "IsSocial");

            migrationBuilder.RenameIndex(
                name: "IX_Identity_ProfileId",
                table: "Identities",
                newName: "IX_Identities_ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Identities",
                table: "Identities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Identities_Profiles_ProfileId",
                table: "Identities",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Identities_Profiles_ProfileId",
                table: "Identities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Identities",
                table: "Identities");

            migrationBuilder.RenameTable(
                name: "Identities",
                newName: "Identity");

            migrationBuilder.RenameColumn(
                name: "IsSocial",
                table: "Identity",
                newName: "isSocial");

            migrationBuilder.RenameIndex(
                name: "IX_Identities_ProfileId",
                table: "Identity",
                newName: "IX_Identity_ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Identity",
                table: "Identity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Identity_Profiles_ProfileId",
                table: "Identity",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
