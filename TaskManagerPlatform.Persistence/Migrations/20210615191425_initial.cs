using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManagerPlatform.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleToPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleToPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleToPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleToPermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserToRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserToTasks_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserToTasks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("63e78133-b0e2-4ea0-ab46-55f77e2ff74f"), new DateTime(2021, 6, 15, 23, 14, 24, 699, DateTimeKind.Local).AddTicks(7933), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sign up" },
                    { new Guid("5b011b03-d4b1-4867-a125-3a9b6dca426f"), new DateTime(2021, 6, 15, 23, 14, 24, 700, DateTimeKind.Local).AddTicks(6079), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sign in" },
                    { new Guid("dba63703-cd68-4d18-ba7c-0f0b93518fbb"), new DateTime(2021, 6, 15, 23, 14, 24, 700, DateTimeKind.Local).AddTicks(6092), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "manage users" },
                    { new Guid("622a1d57-ed3d-456f-9be4-02e5a8879e60"), new DateTime(2021, 6, 15, 23, 14, 24, 700, DateTimeKind.Local).AddTicks(6095), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "manage tasks" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "Description", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("7a0a1d8a-028a-4514-b63b-266b491f8cfe"), new DateTime(2021, 6, 15, 23, 14, 24, 701, DateTimeKind.Local).AddTicks(5896), "administrator", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" },
                    { new Guid("a7077177-af67-451e-ab34-d9f89d253650"), new DateTime(2021, 6, 15, 23, 14, 24, 701, DateTimeKind.Local).AddTicks(6501), "user who is registered by admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("e376b31f-7f33-4437-86ce-e2d35e67af07"), new DateTime(2021, 6, 15, 23, 14, 24, 701, DateTimeKind.Local).AddTicks(8341), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "to do" },
                    { new Guid("f34d3064-463c-4112-97f6-3d2390e380d2"), new DateTime(2021, 6, 15, 23, 14, 24, 701, DateTimeKind.Local).AddTicks(8595), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "doing" },
                    { new Guid("f4bc786d-776b-4735-88cb-7658c1dd73ce"), new DateTime(2021, 6, 15, 23, 14, 24, 701, DateTimeKind.Local).AddTicks(8600), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "test" },
                    { new Guid("0b1883f8-54c5-4c61-9d21-3ff37c827d9f"), new DateTime(2021, 6, 15, 23, 14, 24, 701, DateTimeKind.Local).AddTicks(8602), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "done" }
                });

            migrationBuilder.InsertData(
                table: "RoleToPermissions",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("3234a323-dddd-4e23-b98b-d1f6c93cc699"), new DateTime(2021, 6, 15, 23, 14, 24, 701, DateTimeKind.Local).AddTicks(6938), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("63e78133-b0e2-4ea0-ab46-55f77e2ff74f"), new Guid("7a0a1d8a-028a-4514-b63b-266b491f8cfe") },
                    { new Guid("6007b291-7964-454f-9f4a-f20e68c4fe11"), new DateTime(2021, 6, 15, 23, 14, 24, 701, DateTimeKind.Local).AddTicks(7922), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5b011b03-d4b1-4867-a125-3a9b6dca426f"), new Guid("7a0a1d8a-028a-4514-b63b-266b491f8cfe") },
                    { new Guid("c349b699-a03c-499c-9af1-973aa102faac"), new DateTime(2021, 6, 15, 23, 14, 24, 701, DateTimeKind.Local).AddTicks(7934), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("dba63703-cd68-4d18-ba7c-0f0b93518fbb"), new Guid("7a0a1d8a-028a-4514-b63b-266b491f8cfe") },
                    { new Guid("01b9c90c-ee29-4945-84b6-347d7f3069f8"), new DateTime(2021, 6, 15, 23, 14, 24, 701, DateTimeKind.Local).AddTicks(7936), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5b011b03-d4b1-4867-a125-3a9b6dca426f"), new Guid("a7077177-af67-451e-ab34-d9f89d253650") },
                    { new Guid("60b5a387-b28b-4e5a-b01f-bce5407a6bfa"), new DateTime(2021, 6, 15, 23, 14, 24, 701, DateTimeKind.Local).AddTicks(7939), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("622a1d57-ed3d-456f-9be4-02e5a8879e60"), new Guid("a7077177-af67-451e-ab34-d9f89d253650") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleToPermissions_PermissionId",
                table: "RoleToPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleToPermissions_RoleId",
                table: "RoleToPermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StatusId",
                table: "Tasks",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_OrganizationId",
                table: "Users",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToRoles_RoleId",
                table: "UserToRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToRoles_UserId",
                table: "UserToRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToTasks_TaskId",
                table: "UserToTasks",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_UserToTasks_UserId",
                table: "UserToTasks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleToPermissions");

            migrationBuilder.DropTable(
                name: "UserToRoles");

            migrationBuilder.DropTable(
                name: "UserToTasks");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
