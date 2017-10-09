using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vidly.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength((255))]
        public string DrivingLicence { get; set; }


        [Required]
        [StringLength((50))]
        public string Phone { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>     // IdentityDbContext est la liaison pour la base de données  (gateWay to DB)
    {
        //Qaund on fait la commande de migration, entityframework entre dans cette classe et cherche tous les Dbset pour créer les tables et faires les mises à jour

        public DbSet<Customer> Customers { get; set; }   // DbSet Customer est la représentation de la table Customers 
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MemebershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
       

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