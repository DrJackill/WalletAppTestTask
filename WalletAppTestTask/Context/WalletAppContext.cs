using Microsoft.EntityFrameworkCore;
using WalletAppTestTask.Models.Transactions;

namespace WalletAppTestTask.Context
{
    public class WalletAppContext : DbContext
    {
        public WalletAppContext(DbContextOptions options)
         : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserTransactionTypeConfiguration().Configure(modelBuilder.Entity<UserTransaction>());
        }
    }
}