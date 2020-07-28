using Microsoft.EntityFrameworkCore.Migrations;

namespace WhiteBear.Services.Catalog.Api.Data.Migrations
{
    public partial class Update_Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_ProductItems_ProductItemId1",
                table: "Reactions");

            migrationBuilder.RenameColumn(
                name: "ProductItemId1",
                table: "Reactions",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Reactions_ProductItemId1",
                table: "Reactions",
                newName: "IX_Reactions_ProductId");

            migrationBuilder.AlterColumn<string>(
                name: "ProductItemId",
                table: "Reactions",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductItems",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "ProductItems",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BrandId",
                table: "ProductItems",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Brands",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_ProductItems_ProductId",
                table: "Reactions",
                column: "ProductId",
                principalTable: "ProductItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reactions_ProductItems_ProductId",
                table: "Reactions");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Reactions",
                newName: "ProductItemId1");

            migrationBuilder.RenameIndex(
                name: "IX_Reactions_ProductId",
                table: "Reactions",
                newName: "IX_Reactions_ProductItemId1");

            migrationBuilder.AlterColumn<string>(
                name: "ProductItemId",
                table: "Reactions",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ProductItems",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "ProductItems",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "BrandId",
                table: "ProductItems",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CategoryId",
                table: "Brands",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Reactions_ProductItems_ProductItemId1",
                table: "Reactions",
                column: "ProductItemId1",
                principalTable: "ProductItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
