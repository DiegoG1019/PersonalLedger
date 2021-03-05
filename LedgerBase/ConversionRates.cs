using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DiegoG.LedgerBase
{
    public sealed class ConversionRates
    {
        public decimal AED { get; init; }
        public decimal AFN { get; init; }
        public decimal ALL { get; init; }
        public decimal AMD { get; init; }
        public decimal AOA { get; init; }
        public decimal ARS { get; init; }
        public decimal AUD { get; init; }
        public decimal AWG { get; init; }
        public decimal AZN { get; init; }
        public decimal BAM { get; init; }
        public decimal BBD { get; init; }
        public decimal BDT { get; init; }
        public decimal BGN { get; init; }
        public decimal BHD { get; init; }
        public decimal BIF { get; init; }
        public decimal BMD { get; init; }
        public decimal BND { get; init; }
        public decimal BOB { get; init; }
        public decimal BRL { get; init; }
        public decimal BSD { get; init; }
        public decimal BTN { get; init; }
        public decimal BWP { get; init; }
        public decimal BYN { get; init; }
        public decimal BZD { get; init; }
        public decimal CAD { get; init; }
        public decimal CDF { get; init; }
        public decimal CHF { get; init; }
        public decimal CLP { get; init; }
        public decimal CNY { get; init; }
        public decimal COP { get; init; }
        public decimal CRC { get; init; }
        public decimal CUP { get; init; }
        public decimal CVE { get; init; }
        public decimal CZK { get; init; }
        public decimal DJF { get; init; }
        public decimal DKK { get; init; }
        public decimal DOP { get; init; }
        public decimal DZD { get; init; }
        public decimal EGP { get; init; }
        public decimal ERN { get; init; }
        public decimal ETB { get; init; }
        public decimal EUR { get; init; }
        public decimal FJD { get; init; }
        public decimal FKP { get; init; }
        public decimal GBP { get; init; }
        public decimal GEL { get; init; }
        public decimal GHS { get; init; }
        public decimal GIP { get; init; }
        public decimal GMD { get; init; }
        public decimal GNF { get; init; }
        public decimal GTQ { get; init; }
        public decimal GYD { get; init; }
        public decimal HKD { get; init; }
        public decimal HNL { get; init; }
        public decimal HRK { get; init; }
        public decimal HTG { get; init; }
        public decimal HUF { get; init; }
        public decimal IDR { get; init; }
        public decimal ILS { get; init; }
        public decimal INR { get; init; }
        public decimal IQD { get; init; }
        public decimal IRR { get; init; }
        public decimal ISK { get; init; }
        public decimal JMD { get; init; }
        public decimal JOD { get; init; }
        public decimal JPY { get; init; }
        public decimal KES { get; init; }
        public decimal KGS { get; init; }
        public decimal KHR { get; init; }
        public decimal KPW { get; init; }
        public decimal KRW { get; init; }
        public decimal KWD { get; init; }
        public decimal KYD { get; init; }
        public decimal KZT { get; init; }
        public decimal LAK { get; init; }
        public decimal LBP { get; init; }
        public decimal LKR { get; init; }
        public decimal LRD { get; init; }
        public decimal LSL { get; init; }
        public decimal LYD { get; init; }
        public decimal MAD { get; init; }
        public decimal MDL { get; init; }
        public decimal MGA { get; init; }
        public decimal MKD { get; init; }
        public decimal MMK { get; init; }
        public decimal MNT { get; init; }
        public decimal MOP { get; init; }
        public decimal MRU { get; init; }
        public decimal MUR { get; init; }
        public decimal MVR { get; init; }
        public decimal MWK { get; init; }
        public decimal MXN { get; init; }
        public decimal MYR { get; init; }
        public decimal MZN { get; init; }
        public decimal NAD { get; init; }
        public decimal NGN { get; init; }
        public decimal NIO { get; init; }
        public decimal NOK { get; init; }
        public decimal NPR { get; init; }
        public decimal NZD { get; init; }
        public decimal OMR { get; init; }
        public decimal PAB { get; init; }
        public decimal PEN { get; init; }
        public decimal PGK { get; init; }
        public decimal PHP { get; init; }
        public decimal PKR { get; init; }
        public decimal PLN { get; init; }
        public decimal PYG { get; init; }
        public decimal QAR { get; init; }
        public decimal RON { get; init; }
        public decimal RSD { get; init; }
        public decimal RUB { get; init; }
        public decimal RWF { get; init; }
        public decimal SAR { get; init; }
        public decimal SBD { get; init; }
        public decimal SCR { get; init; }
        public decimal SDG { get; init; }
        public decimal SEK { get; init; }
        public decimal SGD { get; init; }
        public decimal SHP { get; init; }
        public decimal SLL { get; init; }
        public decimal SOS { get; init; }
        public decimal SRD { get; init; }
        public decimal STN { get; init; }
        public decimal SYP { get; init; }
        public decimal SZL { get; init; }
        public decimal THB { get; init; }
        public decimal TJS { get; init; }
        public decimal TMT { get; init; }
        public decimal TND { get; init; }
        public decimal TOP { get; init; }
        public decimal TRY { get; init; }
        public decimal TTD { get; init; }
        public decimal TWD { get; init; }
        public decimal TZS { get; init; }
        public decimal UAH { get; init; }
        public decimal UGX { get; init; }
        public decimal USD { get; init; }
        public decimal UYU { get; init; }
        public decimal UZS { get; init; }
        public decimal VES { get; init; }
        public decimal VND { get; init; }
        public decimal VUV { get; init; }
        public decimal WST { get; init; }
        public decimal XAF { get; init; }
        public decimal XCD { get; init; }
        public decimal XPF { get; init; }
        public decimal YER { get; init; }
        public decimal ZAR { get; init; }
        public decimal ZMW { get; init; }
        public decimal ZWL { get; init; }


        private static readonly Dictionary<Currencies, PropertyInfo> Props = new();

        static readonly Type type = typeof(ConversionRates);
        public decimal this[Currencies currency]
        {
            get
            {
                if(!Props.ContainsKey(currency))
                    Props[currency] = type.GetProperty(currency.ToString())!;
                return (decimal)Props[currency].GetValue(this)!;
            }
        }
    }
}