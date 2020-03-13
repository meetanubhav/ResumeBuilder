using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ResumeBuilder.Models
{
    public class ResumeBuilderDBContext : DbContext
    {
        public ResumeBuilderDBContext() : base()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Settings> Settings { get; set; }

    }
}