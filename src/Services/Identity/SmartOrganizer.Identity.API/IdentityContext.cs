using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SmartOrganizer.Identity.API
{
    public class IdentityContext : IdentityDbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
            // TODO: some logic
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: move connection string into configuration file
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=IdentityDB;Trusted_Connection=True;");
        }
    }
}
