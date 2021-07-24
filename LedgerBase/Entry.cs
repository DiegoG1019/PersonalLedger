using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.LedgerBase
{
    [MessagePackObject]
    public record Entry
    {
        [Key(0)]
        public Currency Amount { get; init; }
        [Key(1)]
        public DateTime Adquisition { get; init; }
        [Key(2)]
        public string? Comment { get; init; }
        [Key(3)]
        public IEnumerable<string>? OtherComments { get; init; }
        [Key(4)]
        public Person? Source { get; init; }

        /// <summary>
        /// If this is not set to null, <see cref="Amount"/> will be interpreted as a Payment or a Loan to the <see cref="IndebtedParty"/> here specified
        /// </summary>
        [Key(5)]
        public Person? IndebtedParty { get; init; }

        public Entry(Currency amnt, DateTime adquisition)
        {
            Amount = amnt;
            Adquisition = adquisition;
        }
    }
}
