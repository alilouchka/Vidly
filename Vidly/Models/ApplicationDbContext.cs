using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>     // IdentityDbContext est la liaison pour la base de données  (gateWay to DB)
    {
        //Qaund on fait la commande de migration, entityframework entre dans cette classe et cherche tous les Dbset pour créer les tables et faires les mises à jour

        public DbSet<Customer> Customers { get; set; }   // DbSet Customer est la représentation de la table Customers 
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MemebershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rental> Rentals { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}