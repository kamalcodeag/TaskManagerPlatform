﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManagerPlatform.Persistence.Contexts;

namespace TaskManagerPlatform.Persistence.Migrations
{
    [DbContext(typeof(TaskManagerPlatformDbContext))]
    [Migration("20210616091710_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TaskManagerPlatform.Domain.Entities.Permission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("29bedb33-cfd4-4938-8b54-2c877abbe0a7"),
                            CreatedDate = new DateTime(2021, 6, 16, 13, 17, 10, 384, DateTimeKind.Local).AddTicks(7454),
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "sign up"
                        },
                        new
                        {
                            Id = new Guid("a82320af-2178-4efd-8a38-5ce5ab99a2b6"),
                            CreatedDate = new DateTime(2021, 6, 16, 13, 17, 10, 385, DateTimeKind.Local).AddTicks(5850),
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "sign in"
                        },
                        new
                        {
                            Id = new Guid("91c8d823-5b49-4f33-8039-707d61027a7f"),
                            CreatedDate = new DateTime(2021, 6, 16, 13, 17, 10, 385, DateTimeKind.Local).AddTicks(5866),
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "manage users"
                        },
                        new
                        {
                            Id = new Guid("698fff34-6219-45a5-9bb3-98d7ae3fa2c7"),
                            CreatedDate = new DateTime(2021, 6, 16, 13, 17, 10, 385, DateTimeKind.Local).AddTicks(5869),
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "manage tasks"
                        });
                });

            modelBuilder.Entity("TaskManagerPlatform.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f114dd09-9bdb-4dd6-a191-3890fff210c6"),
                            CreatedDate = new DateTime(2021, 6, 16, 13, 17, 10, 386, DateTimeKind.Local).AddTicks(6621),
                            Description = "administrator",
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "admin"
                        },
                        new
                        {
                            Id = new Guid("92ef06d6-4878-42ba-9d59-ce9c0667c228"),
                            CreatedDate = new DateTime(2021, 6, 16, 13, 17, 10, 386, DateTimeKind.Local).AddTicks(7224),
                            Description = "user who is registered by admin",
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "user"
                        });
                });

            modelBuilder.Entity("TaskManagerPlatform.Domain.Entities.RoleToPermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PermissionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleToPermissions");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a4e72ddf-1e4c-49d7-8ad0-a7782e2381da"),
                            CreatedDate = new DateTime(2021, 6, 16, 13, 17, 10, 386, DateTimeKind.Local).AddTicks(7737),
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PermissionId = new Guid("29bedb33-cfd4-4938-8b54-2c877abbe0a7"),
                            RoleId = new Guid("f114dd09-9bdb-4dd6-a191-3890fff210c6")
                        },
                        new
                        {
                            Id = new Guid("6dffbe7f-bbb2-42cf-891e-91240dfd3a02"),
                            CreatedDate = new DateTime(2021, 6, 16, 13, 17, 10, 386, DateTimeKind.Local).AddTicks(8653),
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PermissionId = new Guid("a82320af-2178-4efd-8a38-5ce5ab99a2b6"),
                            RoleId = new Guid("f114dd09-9bdb-4dd6-a191-3890fff210c6")
                        },
                        new
                        {
                            Id = new Guid("aef921fa-0ce5-44a1-bb86-cb88d2c7aad3"),
                            CreatedDate = new DateTime(2021, 6, 16, 13, 17, 10, 386, DateTimeKind.Local).AddTicks(8672),
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PermissionId = new Guid("91c8d823-5b49-4f33-8039-707d61027a7f"),
                            RoleId = new Guid("f114dd09-9bdb-4dd6-a191-3890fff210c6")
                        },
                        new
                        {
                            Id = new Guid("88ab4ee7-6f2a-4ffd-8515-137580f71ef0"),
                            CreatedDate = new DateTime(2021, 6, 16, 13, 17, 10, 386, DateTimeKind.Local).AddTicks(8674),
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PermissionId = new Guid("a82320af-2178-4efd-8a38-5ce5ab99a2b6"),
                            RoleId = new Guid("92ef06d6-4878-42ba-9d59-ce9c0667c228")
                        },
                        new
                        {
                            Id = new Guid("66f6f435-06a1-42a1-a1cb-7fe1ec7503d6"),
                            CreatedDate = new DateTime(2021, 6, 16, 13, 17, 10, 386, DateTimeKind.Local).AddTicks(8676),
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PermissionId = new Guid("698fff34-6219-45a5-9bb3-98d7ae3fa2c7"),
                            RoleId = new Guid("92ef06d6-4878-42ba-9d59-ce9c0667c228")
                        });
                });

            modelBuilder.Entity("TaskManagerPlatform.Domain.Entities.Status", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f0adb644-cf0b-45b1-8952-b19179076493"),
                            CreatedDate = new DateTime(2021, 6, 16, 13, 17, 10, 386, DateTimeKind.Local).AddTicks(9104),
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "to do"
                        },
                        new
                        {
                            Id = new Guid("587c7233-7edf-4535-baf8-c50e64321d74"),
                            CreatedDate = new DateTime(2021, 6, 16, 13, 17, 10, 386, DateTimeKind.Local).AddTicks(9366),
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "doing"
                        },
                        new
                        {
                            Id = new Guid("1bfb2782-da59-4d54-b6cb-f967752a6562"),
                            CreatedDate = new DateTime(2021, 6, 16, 13, 17, 10, 386, DateTimeKind.Local).AddTicks(9370),
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "test"
                        },
                        new
                        {
                            Id = new Guid("066ac025-36d4-42b4-bb62-ea674b736203"),
                            CreatedDate = new DateTime(2021, 6, 16, 13, 17, 10, 386, DateTimeKind.Local).AddTicks(9372),
                            LastModifiedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "done"
                        });
                });

            modelBuilder.Entity("TaskManagerPlatform.Domain.Entities.Task", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("StatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskManagerPlatform.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<Guid?>("OrganizationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<string>("Surname")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TaskManagerPlatform.Domain.Entities.UserToRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserToRoles");
                });

            modelBuilder.Entity("TaskManagerPlatform.Domain.Entities.UserToTask", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TaskId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.HasIndex("UserId");

                    b.ToTable("UserToTasks");
                });

            modelBuilder.Entity("TaskManagerPlatform.Domain.Entities.RoleToPermission", b =>
                {
                    b.HasOne("TaskManagerPlatform.Domain.Entities.Permission", "Permission")
                        .WithMany("RoleToPermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManagerPlatform.Domain.Entities.Role", "Role")
                        .WithMany("RoleToPermissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TaskManagerPlatform.Domain.Entities.Task", b =>
                {
                    b.HasOne("TaskManagerPlatform.Domain.Entities.Status", "Status")
                        .WithMany("Tasks")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Status");
                });

            modelBuilder.Entity("TaskManagerPlatform.Domain.Entities.User", b =>
                {
                    b.HasOne("TaskManagerPlatform.Domain.Entities.User", "Organization")
                        .WithMany("Employees")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("TaskManagerPlatform.Domain.Entities.UserToRole", b =>
                {
                    b.HasOne("TaskManagerPlatform.Domain.Entities.Role", "Role")
                        .WithMany("UserToRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManagerPlatform.Domain.Entities.User", "User")
                        .WithMany("UserToRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskManagerPlatform.Domain.Entities.UserToTask", b =>
                {
                    b.HasOne("TaskManagerPlatform.Domain.Entities.Task", "Task")
                        .WithMany("UserToTasks")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TaskManagerPlatform.Domain.Entities.User", "User")
                        .WithMany("UserToTasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskManagerPlatform.Domain.Entities.Permission", b =>
                {
                    b.Navigation("RoleToPermissions");
                });

            modelBuilder.Entity("TaskManagerPlatform.Domain.Entities.Role", b =>
                {
                    b.Navigation("RoleToPermissions");

                    b.Navigation("UserToRoles");
                });

            modelBuilder.Entity("TaskManagerPlatform.Domain.Entities.Status", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("TaskManagerPlatform.Domain.Entities.Task", b =>
                {
                    b.Navigation("UserToTasks");
                });

            modelBuilder.Entity("TaskManagerPlatform.Domain.Entities.User", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("UserToRoles");

                    b.Navigation("UserToTasks");
                });
#pragma warning restore 612, 618
        }
    }
}