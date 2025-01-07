using SecondModuleExam_AxmadovBekzod.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace SecondModuleExam_AxmadovBekzod.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly string _path;
        private readonly List<Movie> _movies;

        public MovieRepository()
        {
            _path = "../../DataAccess/Data/Movies.json";
            _movies = new List<Movie>();

            if (!File.Exists(_path))
            {
                File.WriteAllText(_path, "[]");
            }

            _movies = ReadAllMovies();
        }
        public Movie GetMovieById(Guid movieId)
        {
            foreach (var movie in _movies)
            {
                if (movie.Id == movieId)
                {
                    return movie;
                }
            }

            throw new InvalidOperationException($"Movie with :{movieId} ID is not found");
        }

        public List<Movie> ReadAllMovies()
        {
            var moviesJson = File.ReadAllText(_path);
            var movies = JsonSerializer.Deserialize<List<Movie>>(moviesJson) ?? new List<Movie>();
            return movies;
        }

        public void RemoveMovie(Guid movieId)
        {
            var movie = GetMovieById(movieId);
            _movies.Remove(movie);
            SaveData();
        }

        public void UpdateMovie(Movie movie)
        {
            var updatingMovie = GetMovieById(movie.Id);
            var index = _movies.IndexOf(updatingMovie);
            _movies[index] = movie;
            SaveData();
        }

        public Guid WriteMovie(Movie movie)
        {
            _movies.Add(movie);
            SaveData();
            return movie.Id;
        }
        private void SaveData()
        {
            var moviesJson = JsonSerializer.Serialize(_movies);
            File.WriteAllText(_path, moviesJson);
        }
    }
}
