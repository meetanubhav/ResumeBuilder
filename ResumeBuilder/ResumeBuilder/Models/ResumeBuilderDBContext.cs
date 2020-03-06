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
    }
}