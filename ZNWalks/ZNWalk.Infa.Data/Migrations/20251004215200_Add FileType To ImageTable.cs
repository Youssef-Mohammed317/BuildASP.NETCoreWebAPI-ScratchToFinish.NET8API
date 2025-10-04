﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZNWalk.Infa.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFileTypeToImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileType",
                table: "Image",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileType",
                table: "Image");
        }
    }
}
