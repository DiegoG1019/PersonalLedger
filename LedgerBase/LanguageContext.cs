using DiegoG.LedgerConsole;
using Microsoft.EntityFrameworkCore;

namespace DiegoG.LedgerBase;

public partial class LanguageContext : DbContext
{
    public DbSet<Language> Languages { get; set; }

    public LanguageContext(DbContextOptions<LanguageContext> options) : base(options) { }
}