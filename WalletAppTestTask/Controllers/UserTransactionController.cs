using System.Collections.Immutable;
using Microsoft.AspNetCore.Mvc;
using WalletAppTestTask.Models.Transactions;
using WalletAppTestTask.Services;

namespace WalletAppTestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserTransactionController : ControllerBase
    {
        public UserTransactionController(IUserTransactionService userTransactionService)
        {
            UserTransactionService = userTransactionService;
        }

        public IUserTransactionService UserTransactionService { get; }

        [HttpGet(Name = "GetUserTransactionsList")]
        public async Task<IImmutableList<UserTransaction>> Get(string userId)
        {
            return await UserTransactionService.GetListAsync(new Guid(userId));
        }

        [HttpPost(Name = "PostUserTransaction")]
        public async Task<UserTransaction> Post(string userId){
            return await UserTransactionService.CreateDraftAsync(new Guid(userId));
        }
    }
}