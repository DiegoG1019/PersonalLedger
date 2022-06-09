using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.LedgerBase.Models;

/// <summary>
/// Represents information necessary to make someone a Payment
/// </summary>
public class PaymentInfo
{
    public Guid Id { get; set; }

    /// <summary>
    /// The Person or Location to which this info belongs to
    /// </summary>
    public BusinessEntity? Entity { get; set; }

    /// <summary>
    /// The title of this info
    /// </summary>
    /// <remarks>
    /// For example, PayPal
    /// </remarks>
    public string? Title { get; set; }

    /// <summary>
    /// Represents extra comments for a Payment
    /// </summary>
    public string? Comment { get; set; }

    /// <summary>
    /// The data that holds information to actually make the Payment
    /// </summary>
    /// <remarks>
    /// For example, if PayPal: example@gmail.com
    /// </remarks>
    public string? Data { get; set; }
}
