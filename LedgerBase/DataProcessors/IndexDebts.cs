using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiegoG.LedgerBase.DataProcessors
{
    public record IndexDebts(Worksheet Worksheet) : DataProcessOperation
    {
        public int CountedDebts { get; private set; }
        public int Entries { get; private set; } = Worksheet.EntryCount;
        public int ReadEntries { get; private set; }

        private readonly List<Entry> Debts = new();
        public IEnumerable<Entry> DebtEntries => Debts;

        private readonly int EntriesPerLoop = 25;
        protected override async Task Process(CancellationToken cancellationToken)
        {
            int readEntries = 0;
            int countedDebts = 0;
            int loopEntryCount = 0;

            foreach(var entry in Worksheet.Entries)
            {
                readEntries++;
                loopEntryCount++;
                if(entry.IndebtedParty is not null)
                {
                    countedDebts++;
                    Debts.Add(entry);
                }

                if(loopEntryCount >= EntriesPerLoop)
                {
                    if (cancellationToken.IsCancellationRequested)
                        throw new TaskCanceledException();

                    loopEntryCount = 0;
                    CountedDebts = countedDebts;
                    ReadEntries = readEntries;
                    Progress = readEntries / Entries;

                    await Task.Delay(100, cancellationToken);
//100ms may be a little too much?
                }
            }
        }
    }
}
