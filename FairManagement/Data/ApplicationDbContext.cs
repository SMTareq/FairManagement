using System;
using System.Collections.Generic;
using System.Text;
using FairManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FairManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Visitor> Visitors { get; set; }

        public DbSet<Fair> Fairs { get; set; }

        public DbSet<ProjectCategory> projectCategories { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<MarkingScmehe> MarkingScmehes { get; set; }

        public DbSet<Mark> Marks { get; set; }
    }
}
