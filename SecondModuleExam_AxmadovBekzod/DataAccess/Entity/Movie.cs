using System;

namespace SecondModuleExam_AxmadovBekzod.Entity
{
    public class Movie
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Director { get; set; }
        public int DurationMinutes { get; set; }

        public double Rating { get; set; }

        public long BoxOfficeEarnings { get; set; }

        public int ReleaseDate { get; set; }


    }
}
