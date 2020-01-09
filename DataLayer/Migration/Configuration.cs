using DataLayer.Context;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Migration
{
    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {

            context.Roles.AddOrUpdate(x => x.Id,
              new IdentityRole() { Id = "a871c4ce-0260-41e5-b65e-13d3a9ea6804", Name = "Admin" },
              new IdentityRole() { Id = "9c6f3342-c84d-4a21-b1d9-e33e5ed92199", Name = "User" }
              );
           
            
        }


       
    }
}
