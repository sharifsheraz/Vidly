using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Repositories
{
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {

            public virtual DbSet<Customer> Customers { get; set; }
            public virtual DbSet<Movie> Movies { get; set; }
            public virtual DbSet<MembershipType> MembershipTypes { get; set; }
            public virtual DbSet<Genre> Genres { get; set; }
            public virtual DbSet<Rental> Rentals { get; set; }

            public ApplicationDbContext()
                : base("DefaultConnection2")
            {
                this.Configuration.LazyLoadingEnabled = false;
            }
            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
        }
}