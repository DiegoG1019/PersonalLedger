using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.LedgerBase.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class CurrencyDataAttribute : Attribute
    {
        /// <summary>
        /// Consult https://justforex.com/education/currencies
        /// </summary>
        /// <param name="currency">The global currency name. For example: 'USD'</param>
        /// <param name="symbol">The Symbol to use when formatting the value. Use a single * to denote where the number should go.</param>
        /// <param name="code">The Digital Code of the currency</param>
        /// <param name="name">The Name of the currency</param>
        /// <param name="places">The decimal places to use. defaults to 2</param>
        /// <param name="pluralname">Sets the plural name of the currency. Use a single * to replace with 'name'. Set to null to use Name. Defaults to null</param>
        public CurrencyDataAttribute(Currencies value, string currency, string symbol, int code, string name, string? pluralname = null, int places = 2)
        {
            if (currency.Contains('*'))
                throw new ArgumentException("Currency names may not contain a replacement char '*'");
            if (symbol.Count(s => s == '*') > 1)
                throw new ArgumentException("Symbol string may not contain more than one replacement char '*'");
            if (name.Contains('*'))
                throw new ArgumentException("Name may not contain a replacement char '*'");
            if (pluralname is not null)
                if (pluralname.Count(s => s == '*') > 1)
                    throw new ArgumentException("Pluralname string may not contain more than one replacement char '*'");
            if (places < 0)
                throw new ArgumentException("Decimal places must be a positive integer");
            if (Enum.GetName(value) is null)
                throw new ArgumentException("Currency value is not recognized");

            Value = value;
            Currency = currency;
            Symbol = symbol;
            Code = code;
            Name = name;
            PluralName = (pluralname ?? name).Replace("*", name);
            DecimalPlaces = places;
        }

        /// <summary>
        /// The Enum Value of the Currency
        /// </summary>
        public Currencies Value { get; init; }
        /// <summary>
        /// The global currency name. For example: 'USD'
        /// </summary>
        public string Currency { get; init; }
        /// <summary>
        /// The Symbol to use when formatting the value. Use a single * to denote where the number should go.
        /// </summary>
        public string Symbol { get; init; }
        /// <summary>
        /// The Digital Code of the currency
        /// </summary>
        public int Code { get; init; }
        /// <summary>
        /// The decimal places to use. defaults to 2
        /// </summary>
        public int DecimalPlaces { get; init; }
        /// <summary>
        /// The Name of the currency
        /// </summary>
        public string Name { get; init; }
        /// <summary>
        /// The plural name of the currency
        /// </summary>
        public string PluralName { get; init; }
    }
}
