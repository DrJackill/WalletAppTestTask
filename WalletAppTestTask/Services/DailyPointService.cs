using static WalletAppTestTask.Services.ServiceExtansion;

namespace WalletAppTestTask.Services
{
    public static class DailyPointsService
    {
			private static readonly DateTime springStarts = new (DateTimeOffset.UtcNow.Year, 3, 1);
			private static readonly DateTime summerStarts = new (DateTimeOffset.UtcNow.Year, 6, 1);
			private static readonly DateTime autumnStarts = new (DateTimeOffset.UtcNow.Year, 9, 1);
			private static readonly DateTime winterStarts = new (DateTimeOffset.UtcNow.Year, 12, 1);
			private static readonly DateTime afterNewYearWinterStarts = new (DateTimeOffset.UtcNow.Year - 1, 12, 1);

        public static double GetDailyPoints(){
            var date = DateTimeOffset.UtcNow;
            return date.GetSeason() switch
            {
                Season.Winter => CalculatePoints((date.Month == 12 ? date - winterStarts : date - afterNewYearWinterStarts).Days - 1),
                Season.Spring => CalculatePoints((date - springStarts).Days - 1),
                Season.Summer => CalculatePoints((date - summerStarts).Days - 1),
                _ => CalculatePoints((date - autumnStarts).Days - 1),
            };
        }

        private static double CalculatePoints(int days, double beyondThePreviousDay = 1, double previousDay = 2){
            switch (days){
                case -1:
                    return 1;
                case 0:
                    return Math.Round(previousDay);
            }
            var currentDay = beyondThePreviousDay + (previousDay * 0.6);
            return CalculatePoints(days - 1, previousDay, currentDay);
        }
    }
}