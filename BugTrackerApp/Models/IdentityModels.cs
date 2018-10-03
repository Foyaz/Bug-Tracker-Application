using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BugTrackerApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Project> Created { get; set; }

        [InverseProperty("Users")]
        public virtual ICollection<Project> Managed { get; set; }
        public ApplicationUser()
        {
            Created = new HashSet<Project>();
            Managed = new HashSet<Project>();
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<BugTrackerApp.Models.Projects> Projects { get; set; }

        public System.Data.Entity.DbSet<BugTrackerApp.Models.ApplicationUser> ApplicationUsers { get; set; }
    }

    public class Projects
    {
        public object User { get; internal set; }
        public object UserId { get; internal set; }
    }
}