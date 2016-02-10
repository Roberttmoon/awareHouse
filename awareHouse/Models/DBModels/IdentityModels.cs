using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations;

namespace awareHouse.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public int employeeFK { get; set; }
        public virtual Employee Employee { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("awareHouse", throwIfV1Schema: false)
        {


        }



        public static ApplicationDbContext Create()
        {
            
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<awareHouse.Models.City> Cities { get; set; }
        public System.Data.Entity.DbSet<awareHouse.Models.ZipCode> ZipCode { get; set; }
        public System.Data.Entity.DbSet<awareHouse.Models.State> State { get; set; }
        public System.Data.Entity.DbSet<awareHouse.Models.StreetAddress> StreetAddress { get; set; }

        public System.Data.Entity.DbSet<awareHouse.Models.Row> Row { get; set; }
        public System.Data.Entity.DbSet<awareHouse.Models.Height> Height { get; set; }
        public System.Data.Entity.DbSet<awareHouse.Models.Bay> Bay { get; set; }
        public System.Data.Entity.DbSet<awareHouse.Models.Slot> Slot { get; set; }

        public System.Data.Entity.DbSet<awareHouse.Models.Employee> Employee { get; set; }
        public System.Data.Entity.DbSet<awareHouse.Models.EmployeeAddress> EmployeeAddress { get; set; }

        public System.Data.Entity.DbSet<awareHouse.Models.Customer> Customers { get; set; }
        public System.Data.Entity.DbSet<awareHouse.Models.CustomerAddress> CustomerAddress { get; set; }

        public System.Data.Entity.DbSet<awareHouse.Models.Pallet> Pallets { get; set; }
        public System.Data.Entity.DbSet<awareHouse.Models.Touch> Touch { get; set; }

    }
}