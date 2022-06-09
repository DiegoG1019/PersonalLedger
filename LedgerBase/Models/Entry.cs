using MessagePack;
using NodaMoney;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.LedgerBase.Models;

/// <summary>
/// Represents an absolute entry in the worksheet. Regardless of whether it was borrowed, it was indebted, etc. It's used to represent the absolute financial state
/// </summary>
public record Entry
{
    public Guid Id { get; set; }
    /// <summary>
    /// The Money that moved
    /// </summary>
    public Money Money { get; init; }

    /// <summary>
    /// The date when the event represented by the entry took place
    /// </summary>
    /// <remarks>
    /// This property represents the actual date when the money exchange was made, for example, if an entry was added today about a purchase that was made 4 days prior, this date would reflect 4 days prior.
    /// </remarks>
    public DateTime Date { get; init; }

    /// <summary>
    /// The date when the entry was added
    /// </summary>
    public DateTime Added { get; init; }

    /// <summary>
    /// The date when this Entry was last edited
    /// </summary>
    public DateTime LastEdited { get; init; }

    /// <summary>
    /// A descriptiong fitting this Entry
    /// </summary>
    public string? Description { get; init; }
    
    /// <summary>
    /// A comment regarding this Entry
    /// </summary>
    public string? Comment { get; init; }
    
    /// <summary>
    /// The BusinessEntity that sourced this Entry
    /// </summary>
    public string? Source { get; init; }
}
