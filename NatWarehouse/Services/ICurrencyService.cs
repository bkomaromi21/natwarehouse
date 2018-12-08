using System;
namespace NatWarehouse.Services
{
    /// <summary>
    /// Currency service interface. Defines a contract for getting currency exchange rates.
    /// </summary>
    public interface ICurrencyService
    {
        double? GetExchangeRate(string toCurrency, bool forceImmediateUpdate);
    }
}
