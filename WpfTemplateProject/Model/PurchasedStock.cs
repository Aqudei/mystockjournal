using System;

namespace StockJournal.Model
{
    public class PurchasedStock
    {
        public Guid Id { get; set; }

        public double BuyPricePerShare { get; set; }
        public double SellPricePerShare { get; set; }
        public int NumberOfShares { get; set; }
        public DateTime BuyDate { get; set; } = DateTime.Now;
        public DateTime SellDate { get; set; } = DateTime.Now;

        public double SccpChargePercentage { get; set; }
        public double BrokersChargePercentage { get; set; }
        public double VatPercentage { get; set; }
        public double SalesTaxPercentage { get; set; }

       

        public double ActualBuyPrice
        {
            get
            {
                var commission = NumberOfShares * BuyPricePerShare * 0.0025;
                commission = commission > 20 ? commission : 20;
                return commission + NumberOfShares * BuyPricePerShare * 0.00010 + commission * 0.12;
            }
        }

        public double SellPrice { get; set; }
        public double ActualSellPrice { get; set; }
    }
}
