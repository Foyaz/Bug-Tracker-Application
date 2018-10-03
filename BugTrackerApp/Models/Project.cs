using System;
using System.Collections.Generic;


namespace BugTrackerApp.Models
{
    public class Project
    {
        public Project()
        {
            Users = new HashSet<ApplicationUser>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }


    }
}