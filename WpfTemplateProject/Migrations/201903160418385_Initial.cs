using System.Data.Entity.Migrations;

namespace StockJournal.Migrations
{
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchasedStocks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        BuyPricePerShare = c.Double(nullable: false),
                        SellPricePerShare = c.Double(nullable: false),
                        NumberOfShares = c.Int(nullable: false),
                        BuyDate = c.DateTime(nullable: false),
                        SellDate = c.DateTime(nullable: false),
                        SccpChargePercentage = c.Double(nullable: false),
                        BrokersChargePercentage = c.Double(nullable: false),
                        VatPercentage = c.Double(nullable: false),
                        SalesTaxPercentage = c.Double(nullable: false),
                        SellPrice = c.Double(nullable: false),
                        ActualSellPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PurchasedStocks");
        }
    }
}
