using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using testshop.Data.Entity;
using testshop.Migrations;

namespace testshop.Data
{
    public class productContext : DbContext
    {
        public productContext() : base("productContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<productContext, Configuration>());
        }
        public DbSet<product> products { get; set; }
       
    }
}
