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
    public class Theme : ISettings
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string SettingsType { get; } = "LedgerConsole.Theme";
        public ulong Version => 0;

        public ConsoleColor ErrorColor { get; set; } = ConsoleColor.Red;
        public ConsoleColor InfoColor { get; set; } = ConsoleColor.White;
        public ConsoleColor BorderColor { get; set; } = ConsoleColor.DarkGray;
        public ConsoleColor InputColor { get; set; } = ConsoleColor.DarkGreen;
        public ConsoleColor BackgroundColor { get; set; } = ConsoleColor.Black;
        public ConsoleColor Withdraw { get; set; } = ConsoleColor.Magenta;
        public ConsoleColor Deposit { get; set; } = ConsoleColor.Cyan;
        public ConsoleColor DebtOwedToSelf { get; set; } = ConsoleColor.DarkYellow;
        public ConsoleColor DebtOwedToAnother { get; set; } = ConsoleColor.DarkRed;

    }
}
