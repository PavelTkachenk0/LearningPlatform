﻿using LearningPlatform.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearningPlatform.DAL;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
    {

    }
    public DbSet<Category> Category { get; set; }
    public DbSet<CategoryItem> CategoryItem { get; set; }
    public DbSet<Content> Content { get; set; }
    public DbSet<MediaType> MediaType { get; set; }
    public DbSet<UserCategory> UserCategory { get; set; }
}
