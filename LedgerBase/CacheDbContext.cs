using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.LedgerBase
{
    public partial class CacheDbContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Worksheet> Worksheets { get; set; }

        public CacheDbContext() : base(Directories.InCache("cache"))
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CacheDbContext>());
        }
    }
}
