using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace WebApplication20.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Password", table: "Message");
            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Message",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "PasswordHash", table: "Message");
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Message",
                nullable: true);
        }
    }
}
