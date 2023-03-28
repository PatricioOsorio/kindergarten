﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;

namespace kindergarten.Data
{
  public enum Roles
  {
    SUPERADMIN,
    ADMIN,
    TEACHER
  }

  public static class ContextSeed
  {
    public static async Task SeedRolesAsync(
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager
      )
    {
      //Seed Roles
      await roleManager.CreateAsync(new IdentityRole(Roles.SUPERADMIN.ToString()));
      await roleManager.CreateAsync(new IdentityRole(Roles.ADMIN.ToString()));
      await roleManager.CreateAsync(new IdentityRole(Roles.TEACHER.ToString()));

    }

    public static async Task SeedSuperAdminAsync(
      UserManager<IdentityUser> userManager,
      RoleManager<IdentityRole> roleManager
    )
    {
      //Seed Default User
      var defaultUser = new IdentityUser()
      {
        UserName = "patriciomiguel_12@hotmail.com",
        Email = "patriciomiguel_12@hotmail.com",
        EmailConfirmed = true,
      };
      if (userManager.Users.All(u => u.Id != defaultUser.Id))
      {
        var user = await userManager.FindByEmailAsync(defaultUser.Email);
        if (user == null)
        {
          await userManager.CreateAsync(defaultUser, "Pato123.");
          await userManager.AddToRoleAsync(defaultUser, Roles.SUPERADMIN.ToString());
        }

      }
    }

    public static async Task SeedTeacherAsync(
  UserManager<IdentityUser> userManager,
  RoleManager<IdentityRole> roleManager
)
    {
      //Seed Default User
      var teacherUser = new IdentityUser()
      {
        UserName = "teacher@hotmail.com",
        Email = "teacher@hotmail.com",
        EmailConfirmed = true,
      };
      if (userManager.Users.All(u => u.Id != teacherUser.Id))
      {
        var user = await userManager.FindByEmailAsync(teacherUser.Email);
        if (user == null)
        {
          await userManager.CreateAsync(teacherUser, "Pato123.");
          await userManager.AddToRoleAsync(teacherUser, Roles.TEACHER.ToString());
        }

      }
    }
  }
}