using System.Collections.Generic;

namespace SecondModuleExam_AxmadovBekzod.Services.DTOs.Extensions
{
    public static class TotalBoxOfficeEarnings
    {
        public static long BoxOfficeEarnings(this List<long> total)
        {
            var Earnings = new BaseMovieDto();
            long res = 0;
            foreach (var item in total)
            {
                res += Earnings.BoxOfficeEarnings;
            }
            return res;
        }
    }
}
