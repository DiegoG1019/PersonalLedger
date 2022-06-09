using DiegoG.LedgerConsole;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.LedgerBase;
public interface ILedgerLanguage
{
    public Task<Language> GetLanguage(string lang);
}
