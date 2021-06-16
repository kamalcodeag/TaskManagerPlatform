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
                    OrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                        onDelete: ReferentialAction.SetNull);
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
                    { new Guid("29bedb33-cfd4-4938-8b54-2c877abbe0a7"), new DateTime(2021, 6, 16, 13, 17, 10, 384, DateTimeKind.Local).AddTicks(7454), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sign up" },
                    { new Guid("a82320af-2178-4efd-8a38-5ce5ab99a2b6"), new DateTime(2021, 6, 16, 13, 17, 10, 385, DateTimeKind.Local).AddTicks(5850), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "sign in" },
                    { new Guid("91c8d823-5b49-4f33-8039-707d61027a7f"), new DateTime(2021, 6, 16, 13, 17, 10, 385, DateTimeKind.Local).AddTicks(5866), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "manage users" },
                    { new Guid("698fff34-6219-45a5-9bb3-98d7ae3fa2c7"), new DateTime(2021, 6, 16, 13, 17, 10, 385, DateTimeKind.Local).AddTicks(5869), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "manage tasks" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedDate", "Description", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("f114dd09-9bdb-4dd6-a191-3890fff210c6"), new DateTime(2021, 6, 16, 13, 17, 10, 386, DateTimeKind.Local).AddTicks(6621), "administrator", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" },
                    { new Guid("92ef06d6-4878-42ba-9d59-ce9c0667c228"), new DateTime(2021, 6, 16, 13, 17, 10, 386, DateTimeKind.Local).AddTicks(7224), "user who is registered by admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("f0adb644-cf0b-45b1-8952-b19179076493"), new DateTime(2021, 6, 16, 13, 17, 10, 386, DateTimeKind.Local).AddTicks(9104), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "to do" },
                    { new Guid("587c7233-7edf-4535-baf8-c50e64321d74"), new DateTime(2021, 6, 16, 13, 17, 10, 386, DateTimeKind.Local).AddTicks(9366), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "doing" },
                    { new Guid("1bfb2782-da59-4d54-b6cb-f967752a6562"), new DateTime(2021, 6, 16, 13, 17, 10, 386, DateTimeKind.Local).AddTicks(9370), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "test" },
                    { new Guid("066ac025-36d4-42b4-bb62-ea674b736203"), new DateTime(2021, 6, 16, 13, 17, 10, 386, DateTimeKind.Local).AddTicks(9372), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "done" }
                });

            migrationBuilder.InsertData(
                table: "RoleToPermissions",
                columns: new[] { "Id", "CreatedDate", "LastModifiedDate", "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("a4e72ddf-1e4c-49d7-8ad0-a7782e2381da"), new DateTime(2021, 6, 16, 13, 17, 10, 386, DateTimeKind.Local).AddTicks(7737), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("29bedb33-cfd4-4938-8b54-2c877abbe0a7"), new Guid("f114dd09-9bdb-4dd6-a191-3890fff210c6") },
                    { new Guid("6dffbe7f-bbb2-42cf-891e-91240dfd3a02"), new DateTime(2021, 6, 16, 13, 17, 10, 386, DateTimeKind.Local).AddTicks(8653), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a82320af-2178-4efd-8a38-5ce5ab99a2b6"), new Guid("f114dd09-9bdb-4dd6-a191-3890fff210c6") },
                    { new Guid("aef921fa-0ce5-44a1-bb86-cb88d2c7aad3"), new DateTime(2021, 6, 16, 13, 17, 10, 386, DateTimeKind.Local).AddTicks(8672), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("91c8d823-5b49-4f33-8039-707d61027a7f"), new Guid("f114dd09-9bdb-4dd6-a191-3890fff210c6") },
                    { new Guid("88ab4ee7-6f2a-4ffd-8515-137580f71ef0"), new DateTime(2021, 6, 16, 13, 17, 10, 386, DateTimeKind.Local).AddTicks(8674), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("a82320af-2178-4efd-8a38-5ce5ab99a2b6"), new Guid("92ef06d6-4878-42ba-9d59-ce9c0667c228") },
                    { new Guid("66f6f435-06a1-42a1-a1cb-7fe1ec7503d6"), new DateTime(2021, 6, 16, 13, 17, 10, 386, DateTimeKind.Local).AddTicks(8676), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("698fff34-6219-45a5-9bb3-98d7ae3fa2c7"), new Guid("92ef06d6-4878-42ba-9d59-ce9c0667c228") }
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
