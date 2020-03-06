namespace ResumeBuilder.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ResumeBuilder.Models.ResumeBuilderDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ResumeBuilder.Models.ResumeBuilderDBContext context)
        {
            if(!context.Users.Any())
            {
                context.Users.Add(new Models.User { 
                    Username = "admin",
                    Password = "12345678"
                });
                context.Users.Add(new Models.User
                {
                    Username = "ag",
                    Password = "12345678"
                });

            }
        }
    }
}
