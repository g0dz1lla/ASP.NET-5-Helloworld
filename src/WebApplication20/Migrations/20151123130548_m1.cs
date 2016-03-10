using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace WebApplication20.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LookUp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUp", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "MasterEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterEntity", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "LookUpValue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LookUpId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookUpValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LookUpValue_LookUp_LookUpId",
                        column: x => x.LookUpId,
                        principalTable: "LookUp",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "MasterToRole",
                columns: table => new
                {
                    IdentityRoleId = table.Column<string>(nullable: false),
                    MasterID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterToRole", x => new { x.IdentityRoleId, x.MasterID });
                    table.ForeignKey(
                        name: "FK_MasterToRole_IdentityRole_IdentityRoleId",
                        column: x => x.IdentityRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MasterToRole_MasterEntity_MasterID",
                        column: x => x.MasterID,
                        principalTable: "MasterEntity",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "SlaveEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MasterId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlaveEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SlaveEntity_MasterEntity_MasterId",
                        column: x => x.MasterId,
                        principalTable: "MasterEntity",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "PageToRole",
                columns: table => new
                {
                    IdentityRoleId = table.Column<int>(nullable: false),
                    PageId = table.Column<int>(nullable: false),
                    RoleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageToRole", x => new { x.IdentityRoleId, x.PageId });
                    table.ForeignKey(
                        name: "FK_PageToRole_Page_PageId",
                        column: x => x.PageId,
                        principalTable: "Page",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PageToRole_IdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    HoursToDelete = table.Column<int>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    StateId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Message_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("LookUpValue");
            migrationBuilder.DropTable("MasterToRole");
            migrationBuilder.DropTable("Message");
            migrationBuilder.DropTable("PageToRole");
            migrationBuilder.DropTable("SlaveEntity");
            migrationBuilder.DropTable("LookUp");
            migrationBuilder.DropTable("State");
            migrationBuilder.DropTable("Page");
            migrationBuilder.DropTable("MasterEntity");
        }
    }
}
