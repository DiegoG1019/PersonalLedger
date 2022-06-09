using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.LedgerBase;

/// <summary>
/// Provides extension methods to configure things for PersonalLedger
/// </summary>
public static class LedgerExtensions
{
    public static IServiceCollection AddLedger(this IServiceCollection services)
    {
        services.AddSqlite<LedgerContext>(@"dat/ledger");
        services.AddSingleton<ILedgerLanguage, StaticLedgerLanguage>();
        return services;
    }
}
