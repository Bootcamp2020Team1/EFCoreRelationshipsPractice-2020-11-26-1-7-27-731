﻿using Microsoft.EntityFrameworkCore;
using EFCoreRelationshipsPractice.Entities;
namespace EFCoreRelationshipsPractice.Repository
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
            : base(options)
        {
        }

        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<ProfileEntity> Profiles { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
    }
}