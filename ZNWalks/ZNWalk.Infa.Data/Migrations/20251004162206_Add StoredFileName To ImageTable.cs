﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZNWalk.Infa.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStoredFileNameToImageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StoredFileName",
                table: "Image",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoredFileName",
                table: "Image");
        }
    }
}
