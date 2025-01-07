namespace SecondModuleExam_AxmadovBekzod.Services.DTOs.Extensions
{
    public static class MinutesToHours
    {

        public static int MinutesTohours(this int minutes)
        {
            var durationMinutes = new BaseMovieDto();

            return durationMinutes.DurationMinutes / 60;
        }
    }
}
