using DiegoG.Utilities.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace DiegoG.LedgerConsole
{
    [AddINotifyPropertyChangedInterface]
    public class Lang : ICommentedSettings
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string SettingsType { get; } = "LedgerConsole.Lang";
        public ulong Version => 0;

        public string APIKeyRiokai { get; set; } = "Received";
        public string APIKeyQuery { get; set; } = "Please input your ExchangeRateAPI Key here";
        public string WorksheetNotExist { get; set; } = "The specified Worksheet \"{0}\" does not exist. Could not load";
        public string WorksheetLoaded { get; set; } = "Loaded Worksheet {0} titled {1}";
        public string AllWorksheetsLoaded { get; set; } = "Loaded Worksheets";
        public string NoWorksheet { get; set; } = "No Worksheet selected";
        public string AdquiredFrom { get; set; } = "By: {0}";
        public string WithdrawnFor { get; set; } = "For: {0}";
        public string DateTimeFormat { get; set; } = "MMM dd, hh:mmt";
        public string UnknownPerson { get; set; } = "Unknown";
        public string[] _Comments { get; } = new[]
        {
            "For strings with {x} in them, the number represents the index. There can be more than one {x} with the same index, the string belonging to it will merely repeat. They MUST start from 0, and there needs to be more or equal placeholders than variables to be used. Please make sure not to add less than the original string has, or it will result in an error. Please make sure not to add more than necessary, as it will result in bad formatting."
        };
        public Dictionary<string, string> _Usage { get; } = new()
        {
            { nameof(DateTimeFormat), "If DateTimeFormat becomes too long, it'll be ignored and the default will be used instead. Please refer to: https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings" }
        };
    }
}
