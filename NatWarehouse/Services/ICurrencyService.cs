using System;
namespace NatWarehouse.Services
{
    public interface ICurrencyService
    {
        double? GetExchangeRate(string toCurrency, bool forceImmediateUpdate);
    }
}
