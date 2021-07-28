using MessagePack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using DiegoG.Utilities.Collections;
using System.Diagnostics.CodeAnalysis;

namespace DiegoG.LedgerBase
{
    [MessagePackObject]
    public record Currency
    {
        [Key(0)]
        public decimal Value { get; init; }
        [Key(1)]
        public Currencies Type { get; init; }

        public string Display(Exchange.CurrencyFormat format = Exchange.CurrencyFormat.Simple, string? numberformat = null) => Exchange.FormatCurrency(Value, Type, format, numberformat);

        public static Currency Convert(Currency curr, Currencies type) => type == curr.Type ? curr : new(curr.Value * Exchange.GetRate(curr.Type, type), type);

        public Currency(decimal value, Currencies type)
        {
            Value = value;
            Type = type;
        }

        public static Currency Parse(string s)
            => TryParse(s, out var result) ? result : throw new ArgumentException("Input string is not in correct format: " + s);

        public static bool TryParse(string s, [NotNullWhen(true)] out Currency? result)
        {
            result = null;

            var val = Regex.Matches(s, @"(\d+(\.\d+)?)|(\.\d+)");
            if (val.Count != 1)
                return false;

            var allattr = Exchange.GetAllCurrencyAttributes();

            if (allattr.Count(a => s.ContainsAny(new string[] { a.Currency, a.Name, a.PluralName, a.Symbol })) != 1)
                return false;

            var attr = allattr.First(a => s.ContainsAny(new string[] { a.Currency, a.Name, a.PluralName, a.Symbol }));

            result = new(decimal.Parse(val.First().Value), attr.Value);
            return true;
        }

        public static Currency Zero { get; } = new(0, Currencies.USDollar);

        public static Currency operator +(Currency A, Currency B) 
            => A.Value == 0 || B.Value == 0 ? A : (A with { Value = A.Value + Convert(B, A.Type).Value });
        public static Currency operator -(Currency A, Currency B)
            => A.Value == 0 || B.Value == 0 ? A : (A with { Value = A.Value - Convert(B, A.Type).Value });

        public static Currency operator +(Currency A, decimal value) => A with { Value = A.Value + value };
        public static Currency operator -(Currency A, decimal value) => A with { Value = A.Value + value };
        public static Currency operator /(Currency A, decimal value) => A with { Value = A.Value + value };
        public static Currency operator *(Currency A, decimal value) => A with { Value = A.Value + value };
        public static Currency operator %(Currency A, decimal value) => A with { Value = A.Value + value };
    }
}
