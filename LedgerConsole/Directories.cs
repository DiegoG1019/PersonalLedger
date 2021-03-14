using DiegoG.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiegoG.LedgerBase.Directories;

namespace DiegoG.LedgerConsole
{
    public static class Directories
    {
        private static bool isinit;
        public static string Temp { get; private set; } = Path.GetTempPath();

        public static string Working { get; private set; } = Path.GetFullPath(Directory.GetCurrentDirectory());
        public static string InWorking(string n) => Path.Combine(Working, n);

        public static string Settings { get; private set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "settings");
        public static string InSettings(params string[] n) => Path.Combine(Settings, Path.Combine(n));

        public static string Logging { get; private set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "logs");
        public static string InLogging(params string[] n) => Path.Combine(Logging, Path.Combine(n));

        public static string Lang { get; private set; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "lang");
        public static string InLang(params string[] n) => Path.Combine(Lang, Path.Combine(n));

        public static IEnumerable<(string Directory, string Path)> AllDirectories
            => isinit ? 
            ReflectionCollectionMethods.GetAllMatchingTypeStaticPropertyNameValueTuple<string>(typeof(Directories)) : 
            throw new InvalidOperationException("Directories has not been initialized");

        static Directories()
        {
            Directory.CreateDirectory(Settings);
            Directory.CreateDirectory(Logging);
            Directory.CreateDirectory(Lang);
            isinit = true;
        }

        public static void InitDirectories(DirectoriesDefinition def) => Init(def);
    }
}
