using System.Collections.Generic;
using System;
using SecondModuleExam_AxmadovBekzod.Entity;

namespace SecondModuleExam_AxmadovBekzod.Repositories
{
    public interface IMovieRepository
    {
        Guid WriteMovie(Movie movie);
        List<Movie> ReadAllMovies();
        void RemoveMovie(Guid movieId);
        Movie GetMovieById(Guid movieId);
        void UpdateMovie(Movie movie);
    }
}