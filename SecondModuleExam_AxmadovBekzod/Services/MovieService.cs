using SecondModuleExam_AxmadovBekzod.DTOs;
using SecondModuleExam_AxmadovBekzod.Entity;
using SecondModuleExam_AxmadovBekzod.Repositories;
using SecondModuleExam_AxmadovBekzod.Services.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondModuleExam_AxmadovBekzod.Services
{
    
    public class MovieService : IMovieServie
    {
        private readonly IMovieRepository _movieRepository;
        public List<BaseMovieDto> GetAllMoviesByDirector(string director)
        {
            var movies = _movieRepository.ReadAllMovies();

            List<BaseMovieDto> moviesList = new List<BaseMovieDto>();
            foreach (var movie in movies)
            {
                if (movie.Director == director )
                {
                    moviesList.Add(ConvertToDto(movie));
                }
            }
            return moviesList;
        }

        public BaseMovieDto GetHighestGrossingMovie()
        {
            var movies = _movieRepository.ReadAllMovies();
            var HighGrossing = movies[0].BoxOfficeEarnings;
            BaseMovieDto highest = null;
            foreach (var movie in movies) 
            {
                if (movie.Rating > HighGrossing) 
                {
                    HighGrossing = movie.BoxOfficeEarnings;
                    highest = ConvertToDto(movie);
                }
            }
            return highest;
        }

        public List<BaseMovieDto> GetMoviesReleasedafterYear(int year)
        {
            var movies = _movieRepository.ReadAllMovies();
            List<BaseMovieDto> moviesList = new List<BaseMovieDto>();
            foreach (var movie in movies)
            {
                if (movie.ReleaseDate <= year) 
                {
                    moviesList.Add(ConvertToDto(movie));
                }
            }
            return moviesList;
        }

        public List<BaseMovieDto> GetMoviesSortedByRating()
        {
            var movies = _movieRepository.ReadAllMovies();
            List<BaseMovieDto> moviesList = new List<BaseMovieDto>();
            return (List<BaseMovieDto>)moviesList.OrderByDescending(x => x.Rating);
        }

        public List<BaseMovieDto> GetMoviesWithDurationRange(int minMinutes, int maxMinutes)
        {
            var movies = _movieRepository.ReadAllMovies();
            List<BaseMovieDto> moviesList = new List<BaseMovieDto>();
            foreach (var movie in movies)
            {
                if (movie.DurationMinutes <=maxMinutes && (minMinutes > 0 && maxMinutes > 0) ) 
                {
                    moviesList.Add(ConvertToDto(movie));
                }
            }
            return moviesList;
        }

        public List<BaseMovieDto> GetRecentMovies(int years)
        {
            var movies = _movieRepository.ReadAllMovies();
            List<BaseMovieDto> moviesList = new List<BaseMovieDto>();
            foreach (var movie in movies)
            {
                if (movie.ReleaseDate >= years)
                {
                    moviesList.Add(ConvertToDto(movie));
                }
            }
            return moviesList;
        }

        public BaseMovieDto GetTopRatedMovie()
        {
            var movies = _movieRepository.ReadAllMovies();
            var HighRating = movies[0].Rating;
            BaseMovieDto highest = null;
            foreach (var movie in movies)
            {
                if (movie.Rating > HighRating)
                {
                    HighRating = movie.BoxOfficeEarnings;
                    highest = ConvertToDto(movie);
                }
            }
            return highest;

        }

        public long GetTotalBoxOfficeEarningsByDirector(string director)
        {
            var movies = _movieRepository.ReadAllMovies();
            long Total = 0;
            foreach (var movie in movies) 
            {
                if (movie.Director == director) 
                {
                    Total += movie.BoxOfficeEarnings;
                }
            }
            return Total;
        }

        public List<BaseMovieDto> SearchingMoviesByTitle(string keyWord)
        {
            var movies = _movieRepository.ReadAllMovies();
            List<BaseMovieDto> moviesList = new List<BaseMovieDto>();
            foreach (var movie in movies)
            {
                if (movie.Title == keyWord)
                {
                    moviesList.Add(ConvertToDto(movie));
                }
              
            }
            return moviesList;

        }
        private BaseMovieDto ConvertToDto(Movie movie)
        {
            return new BaseMovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Director = movie.Director,
                DurationMinutes = movie.DurationMinutes,
                Rating = movie.Rating,
                ReleaseDate = movie.ReleaseDate,
                BoxOfficeEarnings = movie.BoxOfficeEarnings,

                
            };
        }

        private Movie ConverToEntity(MovieCreateDtocs movieCreateDto)
        {
            return new Movie
            {
                Id = Guid.NewGuid(),
                Title = movieCreateDto.Title,
                Director = movieCreateDto.Director,
                DurationMinutes = movieCreateDto.DurationMinutes,
                Rating = movieCreateDto.Rating,
                ReleaseDate = movieCreateDto.ReleaseDate,
                BoxOfficeEarnings = movieCreateDto.BoxOfficeEarnings
            };
        }
    }
}
