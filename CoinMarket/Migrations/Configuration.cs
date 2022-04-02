namespace CoinMarket.Migrations
{
    using CoinMarket.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<CoinMarket.Data.CoinMarketContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CoinMarket.Data.CoinMarketContext";
        }

        protected override void Seed(CoinMarket.Data.CoinMarketContext context)
        {
            context.Markets.AddOrUpdate(x => x.Id,
                new Market()
                {
                    Id = 1,
                    Name = "Bilance",
                    Description = "coin",
                    Status = 1
                }
            );
            context.Coins.AddOrUpdate(x => x.Id,
                new Coin() { Id = 1, Name = "BTCUSD", BaseAsset = "BTC", QuoteAsset = "BTC", LastPrice = 46436, Volumn24h = "2000000", MarketId = 1, Status = 1 }
            );
            
            //IList<Coin> coins = new List<Coin>();
            //IList<Market> markets = new List<Market>();


            //coins.Add(new Coin()
            //{
            //    Name = "BTCUSD",
            //    BaseAsset = "BTC",
            //    QuoteAsset = "BTC",
            //    LastPrice = 46436,
            //    Volumn24h = "2000000",
            //    Status = 1
            //});

            //coins.Add(new Coin()
            //{
            //    Name = "ETHUSD",
            //    BaseAsset = "ETH",
            //    QuoteAsset = "BTC",
            //    LastPrice = 3461.4,
            //    Volumn24h = "1000000",
            //    Status = 1
            //});

            //coins.Add(new Coin()
            //{
            //    Name = "SOLUSD",
            //    BaseAsset = "SOL",
            //    QuoteAsset = "BTC",
            //    LastPrice = 134.85,
            //    Volumn24h = "2000000",
            //    Status = 1
            //});


            //foreach (Coin coin in coins)
            //    context.Coins.Add(coin);
            //base.Seed(context);
        }

        private void SeedCoin()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("DefaultConnection",
                    "UserProfile", "UserId", "UserName", autoCreateTables: true);
            }
            var roles = (SimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            if (!roles.RoleExists("Administrator"))
            {
                roles.CreateRole("Administrator");
            }
            if (membership.GetUser("admin", false) == null)
            {
                membership.CreateUserAndAccount("admin", "password");
            }
            if (!roles.GetRolesForUser("admin").Contains("Administrator"))
            {
                roles.AddUsersToRoles(new[] { "admin" }, new[] { "Administrator" });
            }
        }
    }
}
