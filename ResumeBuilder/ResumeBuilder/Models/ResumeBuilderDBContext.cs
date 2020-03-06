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
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Stream> Streams { get; set; }
        public DbSet<University> Universitys { get; set; }

    }
}