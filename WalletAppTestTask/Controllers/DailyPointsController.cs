using Microsoft.AspNetCore.Mvc;
using WalletAppTestTask.Services;

namespace WalletAppTestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DailyPointsController : ControllerBase
    {
        public DailyPointsController()
        {
        }

        [HttpGet(Name = "GetUserDailyPoints")]
        public double Get()
        {
            return DailyPointsService.GetDailyPoints();
        }
    }
}