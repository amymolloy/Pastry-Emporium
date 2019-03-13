using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PastryEmporium.Models;

namespace PastryEmporium.Models
{
    public class PastryEmporiumContext : IdentityDbContext<IdentityUser>
    {
        public PastryEmporiumContext (DbContextOptions<PastryEmporiumContext> options)
            : base(options)
        {
        }

        public DbSet<PastryEmporium.Models.Pastry> Pastry { get; set; }

        public DbSet<PastryEmporium.Models.Customer> Customer { get; set; }

        public DbSet<PastryEmporium.Models.Purchase> Purchase { get; set; }

        public DbSet<PastryEmporium.Models.Feedback> Feedback { get; set; }
    }
}
