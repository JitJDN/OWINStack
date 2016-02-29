using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Data.Entity;

namespace LocalAccountsApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    //public class ApplicationUser : IdentityUser
    //{
    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
    //    {
    //        // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }
    //}


    public class users : IdentityUser
    {
        public override string UserName
        {
            get
            {
                return Email;
            }
            set
            {
                Email = value;
            }
        }

        override public string PasswordHash
        {
            get
            {
                return Password;
            }

            set
            {
                Password = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<users> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }

        public string Password { get; set; }

        //        //public int Id { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public System.DateTime CreatedDate { get; set; }
        //public Nullable<System.DateTime> ModifiedDate { get; set; }
    }



    public partial class DaumAuctionEntities : IdentityDbContext<users>
    {
        public DaumAuctionEntities()
            : base("name=DaumAuctionEntities")
        {
        }

        //public DbSet<addresses> addresses { get; set; }
        //public DbSet<auctions> auctions { get; set; }
        //public DbSet<images> images { get; set; }
        //public DbSet<Musers> muserss { get; set; }

        public static DaumAuctionEntities Create()
        {
            return new DaumAuctionEntities();
        }

    }

    //public class ApplicationDbContext : IdentityDbContext<users>
    //{
    //    public ApplicationDbContext()
    //        : base("DefaultConnection", throwIfV1Schema: false)
    //    {
    //    }

    //    public DbSet<users> users { get; set; }

    //    public static ApplicationDbContext Create()
    //    {
    //        return new ApplicationDbContext();
    //    }
    //}
}