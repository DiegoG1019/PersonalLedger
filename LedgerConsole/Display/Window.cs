using DiegoG.LedgerBase;
using DiegoG.Utilities;
using DiegoG.Utilities.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiegoG.CLI.DConsole;
using static DiegoG.LedgerConsole.Program;

namespace DiegoG.LedgerConsole.Display
{
    public static class Window
    {
        public static Point Pointer { get; private set; }
        /// <summary>
        /// Reserved vertical space for the GUIBox
        /// </summary>
        public static int GUIBoxVertical => 5;
        /// <summary>
        /// Reserved vertical space for the Workspace Title and data at the top
        /// </summary>
        public static int GUIReservedVerticalTop => 2;
        /// <summary>
        /// Reserved vertical space for Command Info at the bottom
        /// </summary>
        public static int GUIReservedVerticalBottom => 4;

        public static int CommandOutputY => Height - 1;
        public static int InputMarkY => CommandOutputY - 1;
        public static int GUIBorder => InputMarkY - 1;

        public static int TotalGUIReserved => GUIBoxVertical + GUIReservedVerticalBottom + GUIReservedVerticalTop;
        public static IEnumerable<IEnumerable<Cell>> Pages { get; private set; }

        private static Rectangle PrevWindow { get; set; }

        private readonly static Point Up    = new(0, -1);
        private readonly static Point Down  = new(0, 1);
        private readonly static Point Left  = new(-1, 0);
        private readonly static Point Right = new(1, 0);
        static Window()
        {
            PrevWindow = WindowSize;
            Pointer = new(0, 0);
            WindowChanged += async r => //This might throw an exception that, if thrown, can't be handled.
            {
                if (WindowSize.Width != PrevWindow.Width || WindowSize.Height != PrevWindow.Height)
                {
                    PrevWindow = WindowSize;
                    await UpdateWorksheet();
                }
            };

            KeyPressed += k => 
            { 
                if (k.Modifiers == 0)
                {
                    var a = k.Key switch
                    {
                        ConsoleKey.UpArrow => Pointer + Up;
                        ConsoleKey.DownArrow => Pointer + Down;
                        ConsoleKey.LeftArrow => Pointer + Left;
                        ConsoleKey.RightArrow => Pointer + Right;
                    }
                    if (WindowSize.Contains(a))
                        Pointer = a;
                }
            };
        }

        public static async Task UpdateSelected()
        {

        }

        public static async Task UpdateWorksheet()
        {
            var lang = Settings<Lang>.Current;
            var setts = Settings<LedgerConsoleSettings>.Current;
            var theme = Settings<Theme>.Current;

            Size entrySize = new(Cell.CellSize.Width + setts.EntryPadding, Cell.CellSize.Height + setts.EntryPadding);
            if (WindowSize.Width < entrySize.Width || WindowSize.Height < entrySize.Height)
                throw new InvalidOperationException($"Console window is too small. It needs to be at least w:{entrySize.Width} h:{entrySize.Height}. Current Size: w:{WindowSize.Width} h:{WindowSize.Height}");
            
            if (Workspace.CurrentWorksheet is null)
            {
                ClearFrom(0, GUIBorder - 1, Settings<Theme>.Current.BackgroundColor);
                FWrite(lang.NoWorksheet, theme.ErrorColor, theme.BackgroundColor, ConsoleEffect.None, 0, GUIBorder - 1);
                return;
            }

            int maxX = entrySize.Width / WindowSize.Width;
            int maxY = entrySize.Height / WindowSize.Height - (GUIReservedVerticalTop + GUIReservedVerticalBottom);
            int entryXOffset = setts.EntryPadding;
            int entryYOffset = GUIReservedVerticalTop;
            int x = 0; int y = 0;
            AsyncTaskManager<Cell> tasks = new();
            foreach (var entry in Workspace.CurrentWorksheet.Entries)
            {
                tasks.Run(() =>
                {
                    var c = new Cell(x * entrySize.Width + entryXOffset, y * entrySize.Height + entryYOffset, entry);
                    c.Draw(theme);
                    return c;
                }); 
                if (x < maxX)
                    x++;
                else
                { x = 0; y++; }
                if (y >= maxY)
                    break;
            }
            await tasks;
        }
    }
}
