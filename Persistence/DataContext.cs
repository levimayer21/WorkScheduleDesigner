using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<BeoIdentity>
    {
        public DbSet<Beosztas> Beosztasok {get; set;}
        public DbSet<Csoport> Csoportok { get; set; }
        public DataContext(DbContextOptions options) : base(options)
        {

        }
    }
}