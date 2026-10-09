using Microsoft.EntityFrameworkCore;
using Microsoft_Azure.Models;

namespace Microsoft_Azure.Data  
{
    public class BattleGameContext : DbContext                                                                                                                                                                                                                                          
    {


        public DbSet<Player> Players { get; set; }
        public DbSet<Asset> Assets { get; set; }

        public DbSet<PlayerAsset> PlayerAssets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerAsset>()
                .HasKey(pa => new { pa.Playerid, pa.Assetid });
        }
    }
}