using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using www.mnb.hu.webservices;

namespace NatWarehouse.Services
{
    public class CurrencyService : ICurrencyService
    {
        private const string RATE_TAG_NAME = "Rate";
        private const string CURRENCY_ATTRIBUTE_NAME = "curr";

        private DateTime? lastAccessTime = null;
        private double cached;
        
        public double? GetExchangeRate(string toCurrency, bool forceImmediateUpdate) {

            // Prevent too frequent web servcice calls if possible
            if (this.lastAccessTime != null && this.lastAccessTime.Value.AddMinutes(5) > DateTime.UtcNow && !forceImmediateUpdate) {
                return cached;
            }

            var client = new MNBArfolyamServiceSoapClient();
            var body = new GetCurrentExchangeRatesRequestBody();

            try
            {
                var currentExchangeRates = client.GetCurrentExchangeRatesAsync(body);

                Task.WaitAll(new Task[] { currentExchangeRates });
                var test = currentExchangeRates.Result.GetCurrentExchangeRatesResponse1;

                XDocument xDocument = XDocument.Parse(test.GetCurrentExchangeRatesResult);

                var rates = xDocument.Descendants(RATE_TAG_NAME);

                foreach (var rate in rates)
                {
                    var currency = rate.Attribute(CURRENCY_ATTRIBUTE_NAME).Value;

                    if (currency == toCurrency.ToUpper())
                    {
                        lastAccessTime = DateTime.Now;
                        this.cached = double.Parse(rate.Value.Replace(",", "."));
                        return this.cached;
                    }
                }
            } catch (Exception) {
                // TODO: Add better exception handling
                return null;
            }

            return null;
        }
    }
}
