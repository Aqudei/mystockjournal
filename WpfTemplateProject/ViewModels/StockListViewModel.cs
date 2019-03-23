using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using Caliburn.Micro;
using StockJournal.Events;
using StockJournal.Model;

namespace StockJournal.ViewModels
{
    sealed class StockListViewModel : Screen, IHandleWithTask<Events.StockCrudEvent>
    {
        private readonly IWindowManager _windowManager;
        private readonly IEventAggregator _eventAggregator;

        public ICollectionView Items
        {
            get => _items;
            set => Set(ref _items, value);
        }

        private readonly BindableCollection<PurchasedStock> _stocks
            = new BindableCollection<PurchasedStock>();

        private PurchasedStock _selectedItem;
        private ICollectionView _items;

        public PurchasedStock SelectedItem
        {
            get => _selectedItem;
            set => Set(ref _selectedItem, value);
        }

        public StockListViewModel(IWindowManager windowManager, IEventAggregator eventAggregator)
        {
            DisplayName = "My Stocks";

            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
            using (var db = new StockContext())
            {
                _stocks.AddRange(db.PurchasedStocksStocks.ToList());
            }

            Items = CollectionViewSource.GetDefaultView(_stocks);

            _eventAggregator.Subscribe(this);
        }

        public void AddStock()
        {
            var addStockViewModel = IoC.Get<AddStockViewModel>();
            addStockViewModel.Id = Guid.NewGuid();
            _windowManager.ShowDialog(addStockViewModel);
        }

        public Task Handle(StockCrudEvent message)
        {
            return Task.Run(() =>
            {
                var item = _stocks.FirstOrDefault(stock => stock.Id.Equals(message.EntityId));
                if (item != null)
                {
                    _stocks.Remove(item);
                }

                if (message.CrudType == CrudType.Deleted)
                    return;

                _stocks.Add(message.PurchasedStock);
                SelectedItem = message.PurchasedStock;
            });
        }
    }
}
