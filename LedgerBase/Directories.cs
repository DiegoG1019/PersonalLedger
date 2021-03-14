using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DiegoG.LedgerBase
{
    public static class Directories
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public static string Cache { get; private set; }
        public static string InCache(params string[] path) => Path.Combine(Cache, Path.Combine(path));
        public static string Worksheets { get; set; }
        public static string InWorksheets(params string[] n) => Path.Combine(Worksheets, Path.Combine(n));


        private static bool IsInit = false;
        public static void Init(DirectoriesDefinition def)
        {
            if (IsInit)
                throw new InvalidOperationException("Cannot initialize Directories twice");
            IsInit = true;

            Cache = def.Cache ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "cache");
            Worksheets = def.Worksheets ?? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments), "Ledger", "Worksheets");
            Directory.CreateDirectory(Cache);
        }
        public sealed record DirectoriesDefinition(string? Cache, string? Worksheets) { }
    }
}
