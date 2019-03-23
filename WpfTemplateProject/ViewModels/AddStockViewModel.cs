using System;
using Caliburn.Micro;
using StockJournal.Events;
using StockJournal.Model;

namespace StockJournal.ViewModels
{
    class AddStockViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        private string _symbol;
        private DateTime? _buyDate = DateTime.Now;
        private double _buyPricePerShare;
        private int _numberOfShares;
        private Guid _id;

        public string Symbol
        {
            get => _symbol;
            set => Set(ref _symbol, value);
        }

        //public string[] Symbols { get; set; } = new[] {"FGEN", "LTG", "JFC"};

        public double BuyPricePerShare
        {
            get => _buyPricePerShare;
            set => Set(ref _buyPricePerShare, value);
        }

        public int NumberOfShares
        {
            get => _numberOfShares;
            set => Set(ref _numberOfShares, value);
        }

        public DateTime? BuyDate
        {
            get => _buyDate;
            set => Set(ref _buyDate, value);
        }


        public AddStockViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }


        public void Save()
        {
            var newPurchaseStock = new PurchasedStock
            {
                //BuyDate = BuyDate.Value,
                BuyPricePerShare = BuyPricePerShare,
                NumberOfShares = NumberOfShares,

                BrokersChargePercentage = Properties.Settings.Default.BrokersChargePercentage,
                SalesTaxPercentage = Properties.Settings.Default.SalesTaxPercentage,
                VatPercentage = Properties.Settings.Default.VatPercentage,
                SccpChargePercentage = Properties.Settings.Default.SccpChargePercentage,
                Id = Id
            };

            using (var db = new StockContext())
            {

                db.PurchasedStocksStocks.Add(newPurchaseStock);
                db.SaveChanges();
                _eventAggregator.PublishOnCurrentThread(new Events.StockCrudEvent(CrudType.Created, Id));
                TryClose();
            }
        }

        public Guid Id
        {
            get => _id;
            set => Set(ref _id, value);
        }
    }
}
