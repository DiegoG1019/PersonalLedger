using DiegoG.LedgerConsole;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiegoG.LedgerBase;

internal sealed class StaticLedgerLanguage : ILedgerLanguage
{
    public static readonly Dictionary<string, Task<Language>> langs = new()
    {
        { "eng", Task.FromResult(new Language
            (
                Lang: "eng",
                APIKeyReceived: "API Key saved",
                APIKeyQuery: "Please input your API Key",
                Unknown: "Unknown",
                Entry: new(
                    "Date",
                    "Added on",
                    "Last edited on",
                    "Description",
                    "Comments",
                    "Source"
                ),
                Business: new(
                    "Alias",
                    "First name",
                    "Second name",
                    "Comment",
                    "Phone number",
                    "Address",
                    "E-mail",
                    "Payment information"
                ),
                PaymentInfo: new(
                    "Entity",
                    "Title",
                    "Comment",
                    "Data"
                )
            )) 
        }
    };

    public Task<Language> GetLanguage(string lang) => langs[lang];
}