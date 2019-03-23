using System;
using StockJournal.Model;

namespace StockJournal.Events
{
    class StockCrudEvent : CrudEvent
    {
        public PurchasedStock PurchasedStock { get; set; }

        public StockCrudEvent(CrudType crudType, Guid entityId) : base(crudType, entityId)
        {

        }

        public StockCrudEvent(CrudType crudType, Guid entityId, PurchasedStock purchasedStock) : base(crudType, entityId)
        {
            PurchasedStock = purchasedStock;
        }
    }
}
