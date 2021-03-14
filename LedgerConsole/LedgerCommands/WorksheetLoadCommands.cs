using DiegoG.CLI;
using DiegoG.LedgerBase;
using DiegoG.Utilities.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.LedgerConsole.LedgerCommands
{
    [CLICommand]
    class WorksheetLoadCommands : ICommand
    {
        static Lang Lang => Settings<Lang>.Current;
        static Theme Theme => Settings<Theme>.Current;
        public string HelpExplanation { get; } = "Loads a specific worksheet onto memory";
        public string HelpUsage { get; } = "worksheet-load [name] (-n) (-a)";
        public string Trigger { get; } = "worksheet-load";
        public string Alias { get; } = "load";
        public IEnumerable<(string Option, string Explanation)> HelpOptions { get; } = new[]
        {
            ("name", "The name of the worksheet to load from and save into"),
            ("-n", "Flags that, even if the worksheet already exists, it should create a new one"),
            ("-a", "Flags that it should load up all the available worksheets in the worksheet folder")
        };

        public async Task<string> Action(CommandArguments args)
        {
            var file = LedgerBase.Directories.InWorksheets(args.Arguments[1]);
            var createnew = args.Flags.Contains("n");
            var loadall = args.Flags.Contains("a");
            if (!File.Exists(file) && !createnew)
            {
                DConsole.FWrite(Lang.WorksheetNotExist, Theme.ErrorColor, Theme.BackgroundColor, 0, Program.CommandOutputY, file);
                return string.Empty;
            }
            if (loadall)
            {
                if (createnew)
                    await Workspace.LoadWorkspaceAsync();
                else
                    await Workspace.LoadUnloadedWorksheetsAsync();
                DConsole.FWrite(Lang.AllWorksheetsLoaded, Theme.InfoColor, Theme.BackgroundColor, 0, Program.CommandOutputY);
                return string.Empty;
            }
            DConsole.FWrite(Lang.WorksheetLoaded, Theme.ErrorColor, Theme.BackgroundColor, 0, Program.CommandOutputY, file, await Workspace.LoadWorksheetAsync(file));
            return string.Empty;
        }
        void ICommand.ClearData() { return; }
    }
}
