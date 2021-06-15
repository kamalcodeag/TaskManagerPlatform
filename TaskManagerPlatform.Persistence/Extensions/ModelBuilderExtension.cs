using Microsoft.EntityFrameworkCore;
using System;
using TaskManagerPlatform.Domain.Entities;

namespace TaskManagerPlatform.Persistence.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Permission
            Permission signUpPermission = new Permission
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Name = "sign up"
            };

            Permission signInPermission = new Permission
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Name = "sign in"
            };

            Permission manageUsersPermission = new Permission
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Name = "manage users"
            };

            Permission manageTasksPermission = new Permission
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Name = "manage tasks"
            };

            modelBuilder.Entity<Permission>().HasData(signUpPermission, signInPermission, manageUsersPermission, manageTasksPermission);
            #endregion

            #region Role
            Role adminRole = new Role
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Name = "admin",
                Description = "administrator"
            };

            Role userRole = new Role
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Name = "user",
                Description = "user who is registered by admin"
            };

            modelBuilder.Entity<Role>().HasData(adminRole, userRole);
            #endregion

            #region RoleToPermission
            RoleToPermission adminSignUpRoleToPermission = new RoleToPermission
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                RoleId = adminRole.Id,
                PermissionId = signUpPermission.Id
            };

            RoleToPermission adminSignInRoleToPermission = new RoleToPermission
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                RoleId = adminRole.Id,
                PermissionId = signInPermission.Id
            };

            RoleToPermission adminManagerUsersRoleToPermission = new RoleToPermission
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                RoleId = adminRole.Id,
                PermissionId = manageUsersPermission.Id
            };

            RoleToPermission userSignInRoleToPermission = new RoleToPermission
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                RoleId = userRole.Id,
                PermissionId = signInPermission.Id
            };

            RoleToPermission userManageTasksRoleToPermission = new RoleToPermission
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                RoleId = userRole.Id,
                PermissionId = manageTasksPermission.Id
            };

            modelBuilder.Entity<RoleToPermission>().HasData(adminSignUpRoleToPermission, adminSignInRoleToPermission, adminManagerUsersRoleToPermission,
                                                    userSignInRoleToPermission, userManageTasksRoleToPermission);
            #endregion

            #region Status
            Status toDoStatus = new Status
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Name = "to do"
            };

            Status doingStatus = new Status
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Name = "doing"
            };

            Status testStatus = new Status
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Name = "test"
            };

            Status doneStatus = new Status
            {
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                Name = "done"
            };

            modelBuilder.Entity<Status>().HasData(toDoStatus, doingStatus, testStatus, doneStatus);
            #endregion
        }
    }
}