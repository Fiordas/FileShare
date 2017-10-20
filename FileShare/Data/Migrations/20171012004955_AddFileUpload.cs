using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FileShare.Data.Migrations
{
    public partial class AddFileUpload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Size",
                table: "SharedFile",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AddColumn<string>(
                name: "PublicFile",
                table: "SharedFile",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicFile",
                table: "SharedFile");

            migrationBuilder.AlterColumn<float>(
                name: "Size",
                table: "SharedFile",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
