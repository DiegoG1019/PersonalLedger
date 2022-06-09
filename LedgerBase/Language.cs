using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace DiegoG.LedgerConsole;

public class Language
{
    public string Lang { get; set; }
    public string APIKeyReceived { get; set; } = "Received";
    public string APIKeyQuery { get; set; } = "Please input your ExchangeRateAPI Key here";
    public string AdquiredFrom { get; set; } = "By: {0}";
    public string WithdrawnFor { get; set; } = "For: {0}";
    public string DateTimeFormat { get; set; } = "MMM dd, hh:mmt";
    public string UnknownPerson { get; set; } = "Unknown";
}
