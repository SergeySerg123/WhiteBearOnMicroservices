using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WhiteBear.Services.Catalog.Api.Data.Migrations
{
    public partial class RemoveImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Images_ImgId",
                table: "ProductItems");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropIndex(
                name: "IX_ProductItems_ImgId",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "ImgId",
                table: "ProductItems");

            migrationBuilder.AddColumn<string>(
                name: "PreviewImgUrl",
                table: "ProductItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviewImgUrl",
                table: "ProductItems");

            migrationBuilder.AddColumn<string>(
                name: "ImgId",
                table: "ProductItems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    PreviewUrl = table.Column<string>(nullable: true),
                    ProductId = table.Column<string>(nullable: true),
                    ProductItemId = table.Column<string>(nullable: true),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_ProductItems_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_ImgId",
                table: "ProductItems",
                column: "ImgId",
                unique: true,
                filter: "[ImgId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductItemId",
                table: "Images",
                column: "ProductItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Images_ImgId",
                table: "ProductItems",
                column: "ImgId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
