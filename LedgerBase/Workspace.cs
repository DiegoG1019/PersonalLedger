using DiegoG.LedgerBase;
using DiegoG.Utilities;
using DiegoG.Utilities.Collections;
using DiegoG.Utilities.IO;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.LedgerBase
{
    public static class Workspace
    {
        private readonly static ObservableDictionary<string, Worksheet> WorksheetsDictionaryField = new();
        private readonly static object dictsync = new();
        private static ObservableDictionary<string, Worksheet> WorksheetsDictionary { get { lock (dictsync) return WorksheetsDictionaryField; } }
        public static IReadOnlyDictionary<string, Worksheet> Worksheets => WorksheetsDictionary;
        public static Worksheet? CurrentWorksheet => SelectedName is not null ? Worksheets.GetValueOrDefault(SelectedName) : null;

        private static string? SelectedName_Field { get; set; }
        public static string? SelectedName
        {
            get => SelectedName_Field;
            set { SelectedName_Field = value; SelectedWorksheetChanged?.Invoke(null, value); }
        }

        public static event NotifyCollectionChangedEventHandler? WorksheetsChanged;
        public static event EventHandler<string?>? SelectedWorksheetChanged;

        public static async Task SaveWorkspaceAsync()
        {
            AsyncTaskManager tasks = new();
            foreach (var (name, worksheet) in WorksheetsDictionary)
                tasks.Add(Serialization.Serialize.JsonAsync(worksheet, Directories.Worksheets, name + ".worksheet"));
            await tasks;
        }

        public static async Task LoadWorkspaceAsync()
        {
            AsyncTaskManager<Worksheet> tasks = new();
            foreach (var name in Directory.GetFiles(Directories.Worksheets, "*.worksheet.json", 0).Where(s => s.All(c => !char.IsWhiteSpace(c))))
                tasks.Add(Serialization.Deserialize<Worksheet>.JsonAsync(Directories.Worksheets, name.Replace(".json", "")), name.Replace(".worksheet.json", ""));
            foreach (var (worksheet, name) in tasks.GetNamedTasks())
                WorksheetsDictionary[name] = await worksheet;
        }

        /// <summary>
        /// Loads the selected Worksheet into the Workspace
        /// </summary>
        /// <param name="name"></param>
        /// <returns>The Worksheet's title</returns>
        public static async Task<string> LoadWorksheetAsync(string name)
        {
            var ws = await Serialization.Deserialize<Worksheet>.JsonAsync(Directories.Worksheets, Worksheet.ValidateAndFormatName(name));
            WorksheetsDictionary[name] = ws;
            return ws.Title;
        }

        public static async Task LoadUnloadedWorksheetsAsync()
        {
            AsyncTaskManager<Worksheet> tasks = new();
            foreach (var name in Directory.GetFiles(Directories.Worksheets, "*.worksheet.json", 0).Where(s => s.All(c => !char.IsWhiteSpace(c) && !WorksheetsDictionary.ContainsKey(s))))
                tasks.Add(Serialization.Deserialize<Worksheet>.JsonAsync(Directories.Worksheets, name), name);
            foreach (var (worksheet, name) in tasks.GetNamedTasks())
                WorksheetsDictionary[name] = await worksheet;
        }

        static Workspace() => WorksheetsDictionary.CollectionChanged += (_, e) => WorksheetsChanged?.Invoke(null, e);

    }
}
