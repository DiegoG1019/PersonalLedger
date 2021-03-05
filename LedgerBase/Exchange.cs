using DiegoG.LedgerBase.Attributes;
using DiegoG.Utilities.Collections;
using DiegoG.Utilities.IO;
using DiegoG.Utilities.Settings;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO.Compression;

namespace DiegoG.LedgerBase
{
    public static class Exchange
    {
        public enum CurrencyFormat { Simple, Explicit, Full }

        private static Dictionary<Currencies, ExchangeRateSheet> ExchangeRates = new();
        public static decimal GetRate(Currencies from, Currencies to, Func<Currencies, ExchangeRateSheet>? NewExchangeSheetFactory = null)
        {
            if (!ExchangeRates.ContainsKey(from))
                ExchangeRates.Add(from, NewExchangeSheetFactory?.Invoke(from) ?? new ExchangeRateSheet(from));
            return ExchangeRates[from].GetExchange(to);
        }

        public static string FormatCurrency(decimal value, Currencies type, CurrencyFormat format = CurrencyFormat.Simple)
        {
            var att = GetCurrencyAttribute(type);
            return format switch
            {
                CurrencyFormat.Simple => att.Symbol.Replace("*", PaddedValue()),
                CurrencyFormat.Explicit => att.Currency + PaddedValue(),
                CurrencyFormat.Full => PaddedValue() + (value == decimal.One ? att.Name : att.PluralName),
                _ => throw new ArgumentException($"Unrecognized CurrencyFormat: {format}", nameof(format)),
            };

            string PaddedValue()
            => value.ToString("0." + new string('0', att.DecimalPlaces));
        }

        public static CurrencyDataAttribute GetCurrencyAttribute(Currencies type) 
            => (CurrencyDataAttribute)typeof(Currencies).GetMember(type.ToString()).First(m => m.DeclaringType! == typeof(Currencies)).GetCustomAttributes(typeof(CurrencyDataAttribute), false).First();

        public static IEnumerable<CurrencyDataAttribute> GetAllCurrencyAttributes()
        {
            foreach (var c in Enum.GetValues<Currencies>())
                yield return GetCurrencyAttribute(c);
        }

        static Exchange()
        {
            CachedData.LoadedCache += ()
                  => ExchangeRates = Serialization.Deserialize<Dictionary<Currencies, ExchangeRateSheet>>.Json(Directories.Cache, "ExchangeRates");
            CachedData.SavingCache += ()
                  => Serialization.Serialize.Json(ExchangeRates, CachedData.Get(), "ExchangeRates");
            if(CachedData.StartupComplete)
                ExchangeRates = Serialization.Deserialize<Dictionary<Currencies, ExchangeRateSheet>>.Json(Directories.Cache, "ExchangeRates");
        }
    }
}
