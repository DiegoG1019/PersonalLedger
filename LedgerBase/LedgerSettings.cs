using DiegoG.Utilities.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using System.Runtime.Loader;

namespace DiegoG.LedgerBase
{
    [AddINotifyPropertyChangedInterface]
    public class LedgerSettings : ISettings
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public string SettingsType => "LedgerSettings";
        public ulong Version => 0;
        public string? ExchangeRateAPIKey { get; set; }
    }
}
