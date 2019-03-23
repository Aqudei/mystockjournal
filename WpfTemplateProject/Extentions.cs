using StockJournal.Model;

namespace StockJournal
{
    public static class Extentions
    {
        public static double ComputeActualSellPrice(this PurchasedStock purchasedStock, double targetSellPrice)
        {
            var brokerCommission = purchasedStock.NumberOfShares * targetSellPrice * Properties.Settings.Default.BrokersChargePercentage;
            brokerCommission = brokerCommission > 20 ? brokerCommission : 20;

            return brokerCommission
                   + purchasedStock.NumberOfShares * targetSellPrice * Properties.Settings.Default.SccpChargePercentage
                   + Properties.Settings.Default.VatPercentage * brokerCommission
                   + Properties.Settings.Default.SalesTaxPercentage * purchasedStock.NumberOfShares * targetSellPrice;

        }

        public static bool WillBreakEven(this PurchasedStock purchasedStock, double targetSellPrice)
        {
            var actualSellPrice = purchasedStock.ComputeActualSellPrice(targetSellPrice);
            return purchasedStock.ActualBuyPrice <= actualSellPrice;
        }
    }
}
