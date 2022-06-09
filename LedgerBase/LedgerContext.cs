using DiegoG.LedgerBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.LedgerBase;

public partial class LedgerContext : DbContext
{
    public DbSet<BusinessEntity> Businesses { get; set; }
    public DbSet<Entry> Entries { get; set; }
    public DbSet<PaymentInfo> PaymentInfo { get; set; }

    public LedgerContext(DbContextOptions<LedgerContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);

        var business = mb.Entity<BusinessEntity>();
        business.HasKey(x => x.Alias);
        business.HasMany(x => x.PaymentInfo).WithOne(x => x.Entity);

        var entry = mb.Entity<Entry>();
        entry.HasKey(x => x.Id);

        var payments = mb.Entity<PaymentInfo>();
        payments.HasKey(x => x.Id);
    }
}
