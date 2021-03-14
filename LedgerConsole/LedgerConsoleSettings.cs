using DiegoG.Utilities.Settings;
using System;
using System.ComponentModel;
using PropertyChanged;
using System.IO;

namespace DiegoG.LedgerConsole
{
    [AddINotifyPropertyChangedInterface]
    public class LedgerConsoleSettings : ISettings
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string SettingsType { get; } = "LedgerConsoleSettings";
        public ulong Version { get; } = 0;

        public string Language { get; set; } = "eng";
        public string WorksheetsDirectory { get; set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), "Worksheets");
        public int MaximumEntriesPerPage { get; set; } = 10;
        public int EntryPadding { get; set; } = 5;
    }
}
