using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace jobapptest.Models
{
    public class AppDBContext : DbContext
    {
        public DbSet<JobDetails>JobDetail{get;set;}
        public DbSet<Applicants> Apllicant { get; set; }
    }
}