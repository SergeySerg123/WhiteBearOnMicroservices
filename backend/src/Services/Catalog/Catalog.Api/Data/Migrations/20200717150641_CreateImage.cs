using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WhiteBear.Services.Catalog.Api.Data.Migrations
{
    public partial class CreateImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviewImgUrl",
                table: "ProductItems");

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "ProductItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_ImageId",
                table: "ProductItems",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Image_ImageId",
                table: "ProductItems",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Image_ImageId",
                table: "ProductItems");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_ProductItems_ImageId",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "ProductItems");

            migrationBuilder.AddColumn<string>(
                name: "PreviewImgUrl",
                table: "ProductItems",
                nullable: true);
        }
    }
}
