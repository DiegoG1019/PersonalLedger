using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace DiegoG.LedgerBase
{
    internal static class CachedData
    {
        private static readonly object Lock = new();
        /// <summary>
        /// Fired as soon as LoadCache finishes executing
        /// </summary>
        public static event Action? LoadedCache;
        /// <summary>
        /// Fired right before Cache is saved
        /// </summary>
        public static event Action? SavingCache;
        /// <summary>
        /// Marks whether the Cache has already been loaded for the first time
        /// </summary>
        public static bool StartupComplete { get; private set; }

        public static void LoadCache()
        {
            lock (Lock)
            {
                Directory.CreateDirectory("cache");
                ZipFile.ExtractToDirectory(Directories.InCache("ledgerbasecache"), "cache");
            }
            LoadedCache?.Invoke();
            StartupComplete = true;
        }

        public static void SaveCache()
        {
            SavingCache?.Invoke();
            lock (Lock) 
                ZipFile.CreateFromDirectory("cache", Directories.InCache("ledgerbasecache"));
        }

        public static string Get(params string[] path) => Path.Combine(Environment.CurrentDirectory, "cache", Path.Combine(path));
    }
}
