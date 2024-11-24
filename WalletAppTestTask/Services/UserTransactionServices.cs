using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using WalletAppTestTask.Context;
using WalletAppTestTask.Models.Transactions;

namespace WalletAppTestTask.Services
{
    public interface IUserTransactionService
    {
        Task<UserTransaction> CreateDraftAsync(Guid userId);

        Task<IImmutableList<UserTransaction>> GetListAsync(Guid guid);
    }

    public class UserTransactionService : IUserTransactionService
    {
        public UserTransactionService(IDbContextFactory<WalletAppContext> dbContextFactory)
        {
            DbContextFactory = dbContextFactory;
        }

        public IDbContextFactory<WalletAppContext> DbContextFactory { get; }

        public async Task<UserTransaction> CreateDraftAsync(Guid userId)
        {
            var dbcontext = await DbContextFactory.CreateDbContextAsync();
            var userTrans = new UserTransaction(
                userId,
                 UserTransactionType.Credit,
                 (int)new Random().NextInt64(1, 500),
                  "TestTrans",
                   "TestTransDescript",
                   "TestAuthUser",
                   true,
                   DateTimeOffset.UtcNow,
                   "TestUrl" );
            dbcontext.Add(userTrans);
            await dbcontext.SaveChangesAsync();
            return userTrans;
        }

        public async Task<IImmutableList<UserTransaction>> GetListAsync(Guid userId)
        {
            var dbcontext = await DbContextFactory.CreateDbContextAsync();
            var dbSet = dbcontext.Set<UserTransaction>();
            return dbSet.Where(t => t.UserDataId == userId).ToImmutableList();
        }
    }
}