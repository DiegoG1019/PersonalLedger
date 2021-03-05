using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DiegoG.LedgerBase
{
#nullable disable
    public static class Directories
    {
        public static string Cache { get; private set; }
        public static string InCache(params string[] path) => Path.Combine(Cache, Path.Combine(path));

        private static bool IsInit = false;
        public static void Init(DirectoriesDefinition def)
        {
            if (IsInit)
                throw new InvalidOperationException("Cannot initialize Directories twice");
            IsInit = true;

            Cache = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "cache");
            Directory.CreateDirectory(Cache);
        }
        public sealed record DirectoriesDefinition() { }
    }
}
