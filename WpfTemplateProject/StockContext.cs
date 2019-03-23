using System.Data.Entity;
using StockJournal.Model;

namespace StockJournal
{
    class StockContext : DbContext
    {
        public DbSet<PurchasedStock> PurchasedStocksStocks { get; set; }
    }
}
