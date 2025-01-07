using SecondModuleExam_AxmadovBekzod.Entity;
using SecondModuleExam_AxmadovBekzod.Repositories;

namespace SecondModuleExam_AxmadovBekzod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var demo = new MovieRepository();
            Movie movie = new Movie();
            movie.Title = "Titanik";
            movie.Director = "Bekzod";
            demo.WriteMovie(movie);

        }
    }
}
