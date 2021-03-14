using DiegoG.Utilities.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;
using System.ComponentModel;
using System.Text.Json.Serialization;
using MessagePack;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using DiegoG.Utilities.IO;
using System.Text.RegularExpressions;

namespace DiegoG.LedgerBase
{
    /// <summary>
    /// A worksheet full of Entries, automatically ordered by Date
    /// </summary>
    [AddINotifyPropertyChangedInterface, MessagePackObject]
    public class Worksheet : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private LinkedList<Entry> EntryList { get; } = new();
        private NoRepeatsList<Currencies> Currencies { get; } = new();
        private Dictionary<Currencies, Currency> PerCurrencyTotals_ { get; } = new();

        public const string FileExtension = ".worksheet";
        public static string StandarizeName(string name) => Regex.Replace(name, @"\s+", "").ToLower();
        public static string ValidateName(string name)
            => name.Any(c => char.IsWhiteSpace(c)) ?
            throw new ArgumentException("Name is invalid") :
            name.ToLower();

        public static string ValidateAndFormatName(string name) => ValidateName(name) + ".worksheet.json";

        public int EntryCount => EntryList.Count;

        [Key(0)]
        public Currencies AbsoluteCurrency { get; set; }

        [Key(1)]
        public IEnumerable<Entry> Entries
        {
            get => EntryList; 
            init
            {
                EntryList.Clear();
                foreach (var e in value)
                    EntryList.AddLast(e);
            }
        }

        [Key(2)]
        public string Title { get; set; }


        [JsonIgnore, IgnoreMember, XmlIgnore, IgnoreDataMember]
        public IEnumerable<Currencies> UsedCurrencies => Currencies;

        [JsonIgnore, IgnoreMember, XmlIgnore, IgnoreDataMember]
        public IReadOnlyDictionary<Currencies, Currency> PerCurrencyTotals => PerCurrencyTotals_;

        [JsonIgnore, IgnoreMember, XmlIgnore, IgnoreDataMember]
        public Currency AbsoluteTotal { get; private set; }

        public IOrderedEnumerable<Entry> CreateOrderedEnumerable<TKey>(Func<Entry, TKey> keySelector, IComparer<TKey>? comparer, bool descending = false)
            => descending ?
            EntryList.OrderByDescending(keySelector, comparer) :
            EntryList.OrderBy(keySelector, comparer);

        public virtual void AddEntry(Entry entry)
        {
            var n = EntryList.GetNodes().FirstOrDefault(s => s.Value.Adquisition > entry.Adquisition);
            if (n is not null)
                EntryList.AddAfter(n, entry);
            EntryList.AddFirst(entry);

            AbsoluteTotal += entry.Amount;
            ActOnPerCurrencyTotal(entry, (c, e) => c += entry.Amount);

            Currencies.TryAdd(entry.Amount.Type);
        }

        public virtual void RemoveEntry(Entry entry)
        {
            EntryList.Remove(EntryList.GetNodes().First(s => s.Value == entry));

            AbsoluteTotal -= entry.Amount;
            ActOnPerCurrencyTotal(entry, (c, e) => c -= entry.Amount);

            Currencies.Remove(entry.Amount.Type);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="func"></param>
        protected void ActOnPerCurrencyTotal(Entry entry, Func<Currency, Entry, Currency> func)
        {
            var c = PerCurrencyTotals_[entry.Amount.Type] ?? new Currency(0, entry.Amount.Type);
            c = func(c, entry);
            PerCurrencyTotals_[c.Type] = c;
        }

        [OnDeserialized]
        protected internal virtual void OnDeserialized()
        {
            foreach(var c in EntryList)
            {
                AbsoluteTotal += c.Amount;
                ActOnPerCurrencyTotal(c, (c, e) => c += e.Amount);
            }
        }

        public Worksheet(string title, Currencies absoluteCurrency = LedgerBase.Currencies.USDollar)
        {
            AbsoluteTotal = new(0, absoluteCurrency);
            PropertyChanged += (o, a) =>
            {
                if (a.PropertyName == nameof(AbsoluteCurrency))
                    AbsoluteTotal = Currency.Convert(AbsoluteTotal, AbsoluteCurrency);
            };
            Title = title;
        }
    }
}
