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


    }
}