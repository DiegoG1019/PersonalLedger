using DiegoG.LedgerBase;
using DiegoG.Utilities;
using DiegoG.Utilities.Collections;
using DiegoG.Utilities.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiegoG.CLI.DConsole;

namespace DiegoG.LedgerConsole.Display
{
    public record Cell
    {
        private static Lang Lang => Settings<Lang>.Current;

        public static Size CellSize { get; } = new(40, 3);

        public Rectangle BoundBox { get; private init; }
        public Entry Entry { get; private init; }

        public Cell(int x, int y, Entry entry) 
        {
            BoundBox = new(x, y, CellSize.Width, CellSize.Height);
            Entry = entry;
        }

        public void Draw(Theme theme)
        {
            var (x, y, w, h) = BoundBox;

            int maxDigits = w - 2;
            string value = Entry.Amount.Display(Exchange.CurrencyFormat.Simple, Entry.Amount.Value > (decimal)Math.Pow(10, maxDigits) ? new string('0', maxDigits - 4) + "e00" : null);

            FWrite(value,
                DrawColor(d
                    Entry.IsDebt ?
                    Entry.Amount.Value > 0 ? theme.DebtOwedToAnother : theme.DebtOwedToSelf : //It is debt
                    Entry.Amount.Value > 0 ? theme.Deposit : theme.Withdraw //It is NOT debt
                ),
                null, ConsoleEffect.None, x++, y);

            //remember that x is increased previously
            for (int i = 0; i < h && i < 3;)
                FWrite(i switch
                {
                    0 => Entry.Adquisition.ToString(Lang.DateTimeFormat.Length <= maxDigits ? Lang.DateTimeFormat : "M d y"),
                    1 => (Entry.Source?.FirstAndLastNames ?? Lang.UnknownPerson).TruncateString(maxDigits),
                    2 => Entry.Comment ?? "",
                    _ => throw new InvalidOperationException($"Invalid Data Index in Cell: {i}; Must be less than or equal to 2")
                }, DrawColor(), null, i++ < h && i < 3 ? ConsoleEffect.None : ConsoleEffect.Underline, x, y++);
        }
        private ConsoleColor drawC;
        private ConsoleColor DrawColor(ConsoleColor? c = null) { drawC = c ?? drawC; return drawC; }
    }
}
