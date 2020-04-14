using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class BDContext : DbContext
    {
        public BDContext()
            : base("DbConnection")
        { }

        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<AgeCategory> AgeCategories { get; set; }
        public DbSet<TimeCategory> TimeCategories { get; set; }
        public DbSet<KvestRoom> KvestRooms { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Sertificate> Sertificates { get; set; }
        public DbSet<UsersValue> UsersValues { get; set; }

    }    
}
