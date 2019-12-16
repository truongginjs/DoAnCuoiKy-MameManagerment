using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Design.Model;

namespace Design.Context
{
    public class ShopGameContext: DbContext 
    {
        public ShopGameContext(): base("DBGames")
        {
        }

        public DbSet<Game> games {  get; set; }
        public DbSet<Transaction> transactions { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Human> humen { get; set; }
    }
}
