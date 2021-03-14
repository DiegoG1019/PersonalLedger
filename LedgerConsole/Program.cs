using DiegoG.CLI;
using DiegoG.LedgerBase;
using DiegoG.Utilities;
using DiegoG.Utilities.Settings;
using Serilog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Loader;
using System.Threading.Tasks;
using static DiegoG.CLI.DConsole;

#nullable enable
namespace DiegoG.LedgerConsole
{
    public static class Program
    {
        private static Serilog.Core.LoggingLevelSwitch LoggingLevelSwitch { get; } = new(Serilog.Events.LogEventLevel.Verbose);

        static async Task Init()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File($"Ledger_{DateTime.Now}",
                    fileSizeLimitBytes: 40960,
                    rollingInterval: RollingInterval.Hour,
                    levelSwitch: LoggingLevelSwitch)
                .CreateLogger();

            //
            var entry = "Starting Ledger Console";
            FWrite(entry, ConsoleColor.Yellow, x: PlaceMiddleX(entry), y: 2);
            //

            Task console = Task.Run(() => Commands.Initialize(new(true, false, false, false, false, false)));

            Log.Information("Initializing settings");

            Log.Debug("Initializing LedgerConsoleSettings");
            Settings<LedgerConsoleSettings>.Initialize(Directories.Settings, "LedgerConsoleSettings");
            Log.Debug("Initializing LedgerSettings");
            Settings<LedgerSettings>.Initialize(Directories.Settings, "LedgerSettings");
            Log.Debug("Initializing LedgerLang");
            Settings<Lang>.Initialize(Directories.Lang, Settings<LedgerConsoleSettings>.Current.Language);

            var deftask = Task.Run(Defaults);

            Log.Information("Settings LedgerSettings");
            foreach (var s in Settings<LedgerSettings>.CurrentProperties)
                Log.Information($"{s.ObjectA} = {s.ObjectB}");

            Task aktask = Task.CompletedTask;
            if (Settings<LedgerSettings>.Current.ExchangeRateAPIKey is null)
            {
                var riokai = Settings<Lang>.Current.APIKeyRiokai;
                var query = Settings<Lang>.Current.APIKeyQuery;
                FWrite(query, ConsoleColor.Yellow, x: PlaceMiddleX(query), y: 4).InputField(12, 5, textc: ConsoleColor.Cyan);
                aktask = ReadLineAsync(onComplete: s =>
                {
                    FWrite(riokai, ConsoleColor.Yellow, x: PlaceMiddleX(riokai), y: 6);
                    Settings<LedgerSettings>.Current.ExchangeRateAPIKey = s;
                });
            }

            Log.Information("Settings LedgerConsoleSettings");
            foreach (var s in Settings<LedgerConsoleSettings>.CurrentProperties)
                Log.Information($"{s.ObjectA} = {s.ObjectB}");

            Log.Information("Initializing other directories");
            Directories.InitDirectories(new(null, Settings<LedgerConsoleSettings>.Current.WorksheetsDirectory));

            AssemblyLoadContext.Default.Unloading += alc =>
            {
                AsyncTaskManager tasks = new();
                tasks.Add(Settings<LedgerConsoleSettings>.SaveSettingsAsync());
                tasks.Add(Settings<LedgerSettings>.SaveSettingsAsync());
                tasks.Add(Settings<Lang>.SaveSettingsAsync());
                tasks.Add(Settings<Theme>.SaveSettingsAsync());
                tasks.WaitAll();
            };

            await aktask;
            _ = Settings<LedgerSettings>.SaveSettingsAsync();
            await console;
            await deftask;
        }

        private static readonly object BTSync = new();
        private static readonly Queue<Func<Task>> BackgroundTasks = new();
        public static void Invoke(Func<Task> func) { lock (BTSync) BackgroundTasks.Enqueue(func); }
        public static void Invoke(Action action) { lock (BTSync) BackgroundTasks.Enqueue(() => Task.Run(() => action())); }
        static async Task Main(string[] args)
        {
            await Init();
            await Commands.Call(args);
            AsyncTaskManager tasks = new();

            SIAB();

            while (true)
            {
                tasks.Add(Task.Delay(20));

                lock (BTSync)
                    for (int i = 0; i < 5 && BackgroundTasks.Count > 0; i++)
                        tasks.Add(BackgroundTasks.Dequeue()());

                if (TryReadLine(out var inp, 500))
                {
                    tasks.Add(Commands.Call(inp));
                    SIAB();
                }

                await tasks;
                tasks.Clear();
            }
            //Set Input and Border
            static void SIAB() => ClearLine(GUIBorder, Settings<Theme>.Current.BorderColor).InputField(1, InputMarkY, textc: Settings<Theme>.Current.InputColor);
        }

        static async Task Defaults()
        {
            var spanish = new Lang()
            {
                APIKeyQuery = "Escriba su llave para el API",
                APIKeyRiokai = "Recibido",
            };
            await Settings<Lang>.CreateDefaultsAsync(new[] { (spanish, "esp") });
        }
    }
}
