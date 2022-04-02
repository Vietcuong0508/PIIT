using System.Data.Entity;

namespace CoinMarket.Data
{
    public class CoinMarketContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CoinMarketContext() : base("name=CoinMarketContext")
        {
        }

        public DbSet<Models.Coin> Coins { get; set; }

        public DbSet<Models.Market> Markets { get; set; }
    }
}
