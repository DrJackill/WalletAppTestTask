using Microsoft.EntityFrameworkCore;

namespace WalletAppTestTask.Services
{
    public static class ServiceExtansion
    {
        public static void ConfigureModelServices(this IServiceCollection services)
        {
            services.AddScoped<IUserTransactionService, UserTransactionService>();
        }

        public static Season GetSeason(this DateTimeOffset dateTimeOffset){
            var month = dateTimeOffset.Month;
            if (month == 12 || month <= 2){
                return Season.Winter;
            }
            if (month >= 3 && month <= 5){
                return Season.Spring;
            }
            if (month >= 6 && month <= 8){
                return Season.Summer;
            }
            return Season.Autumn;
        }
    
        public enum Season{
            Winter,
            Spring,
            Summer,
            Autumn
        }
    }
}