using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.LedgerBase.DataProcessors
{
    public static class Operations
    {
        public static IndexDebts IndexDebts(Worksheet? worksheet = null)
        {
            worksheet ??= Workspace.CurrentWorksheet ?? throw new ArgumentNullException(nameof(worksheet), $"Parameter {nameof(worksheet)} cannot be null if {nameof(Workspace)}.{nameof(Workspace.CurrentWorksheet)} is also null");
            throw new NotImplementedException();
#warning Not Implemented
        }
    }
}
