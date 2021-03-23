using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bars_Server.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace Bars_Server.Data
{
    public class Bars_ServerContext : DbContext
    {
        public Bars_ServerContext (DbContextOptions<Bars_ServerContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Bars_Server.Models.Contract> Contract { get; set; }
    }
}
