using SecondModuleExam_AxmadovBekzod.Services.DTOs;
using System.Collections.Generic;

namespace SecondModuleExam_AxmadovBekzod.Services
{
    public interface IMovieServie
    {
        List<BaseMovieDto> GetAllMoviesByDirector(string director);
        BaseMovieDto GetTopRatedMovie();
        List<BaseMovieDto> GetMoviesReleasedafterYear(int year);
        BaseMovieDto GetHighestGrossingMovie();
        List<BaseMovieDto> SearchingMoviesByTitle(string keyWord);
        List<BaseMovieDto> GetMoviesWithDurationRange(int minMinutes, int maxMinutes);
        long GetTotalBoxOfficeEarningsByDirector(string director);
        List<BaseMovieDto> GetMoviesSortedByRating();
        List<BaseMovieDto> GetRecentMovies(int years);

    }
}