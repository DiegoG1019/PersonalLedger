using DiegoG.Utilities.IO;
using DiegoG.Utilities.Settings;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net;

namespace DiegoG.LedgerBase
{
    public class ExchangeRateSheet
    {
        public Currencies BaseCurrency { get; init; }
        public DateTime LastRefresh { get; private set; }
        public ConversionRates? Rates { get; init; }

        public virtual decimal GetExchange(Currencies to)
        {
            if (Rates is null || LastRefresh - DateTime.Now < TimeSpan.FromHours(5))
            {
                Log.Information($"Refreshing Exchange Rate Sheet for {BaseCurrency}");
                if (RefreshRate())
                    Log.Information($"Succesfully refreshed Exchange Rates for {BaseCurrency}");
                else
                {
                    Log.Warning($"Unable to refresh Exchange Rates for {BaseCurrency}");
                    if (Rates is null)
                        throw new InvalidOperationException("Rates is still null after a failed refresh attempt. The app requires internet connection when there is no stored cache");
                }
            }
            return Rates![to];
        }

        protected void UpdateLastRefreshed(DateTime? dt = null) => LastRefresh = dt ?? DateTime.Now;

        protected virtual bool RefreshRate()
        {
            try
            {
                string URLString = $"https://v6.exchangerate-api.com/v6/{Settings<LedgerSettings>.Current.ExchangeRateAPIKey}/latest/{Exchange.GetCurrencyAttribute(BaseCurrency).Currency}";
                using var webClient = new WebClient();
                var jdocstr = webClient.DownloadString(URLString);
                var jdoc = Serialization.Parse.Json(jdocstr);
                if (jdoc.RootElement.GetProperty("result").GetString() != "success")
                {
                    Log.Debug("Unsuccesful request refreshing exchange rates:" + jdoc.RootElement.GetProperty("error-type").GetString());
                    return false;
                }
                //JDoc = jdoc;
                //JDS = jdocstr;
                UpdateLastRefreshed();
                return true;
            }
            catch (WebException e)
            {
                Log.Debug("WebException caught requesting Exchange Rates:\n" + e.ToString());
                return false;
            }
        }

        public ExchangeRateSheet(Currencies baseCurrency)
            => BaseCurrency = baseCurrency;

    }
}
