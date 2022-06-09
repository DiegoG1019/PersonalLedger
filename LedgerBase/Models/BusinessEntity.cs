using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.LedgerBase.Models;

/// <summary>
/// Represents a <see cref="BusinessEntity"/>: A Person, Location, or otherwise an Entity capable of receiving Payment
/// </summary>
public class BusinessEntity
{
    /// <summary>
    /// An arbitrary name that is used to uniquely identify a <see cref="BusinessEntity"/>
    /// </summary>
    public string Alias { get; set; }

    /// <summary>
    /// The real first name of a <see cref="BusinessEntity"/>
    /// </summary>
    public string? FirstName { get; set; }

    /// <summary>
    /// The real last name of a <see cref="BusinessEntity"/>
    /// </summary>
    public string? LastName { get; set; }

    /// <summary>
    /// A comment by the ledger keeper regarding this <see cref="BusinessEntity"/>
    /// </summary>
    public string? Comment { get; set; }

    /// <summary>
    /// A <see cref="BusinessEntity"/>'s phone number
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// A <see cref="BusinessEntity"/>'s address
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// A <see cref="BusinessEntity"/>'s email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// A <see cref="BusinessEntity"/>'s various payment info
    /// </summary>
    public List<PaymentInfo>? PaymentInfo { get; set; }
}
