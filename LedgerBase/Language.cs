using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace DiegoG.LedgerConsole;

public record Language(
    string Lang,
    string APIKeyReceived,
    string APIKeyQuery,
    string Unknown,
    EntryLanguage Entry,
    BusinessLanguage Business,
    PaymentInfoLanguage PaymentInfo,
    string DateTimeFormat = "MMM dd, hh:mmt"
);

public record EntryLanguage
(
    string Date,
    string Added,
    string LastEdited,
    string Description,
    string Comment,
    string Source
);

public record BusinessLanguage
(
    string Alias,
    string FirstName,
    string LastName,
    string Comment,
    string PhoneNumber,
    string Address,
    string Email,
    string PaymentInfo
);

public record PaymentInfoLanguage
(
    string Entity,
    string Title,
    string Comment,
    string Data
);