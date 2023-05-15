using BestMoviesApp.Models;

namespace BestMoviesApp.Services;

public interface IMovieService
{
    public Task<Movie?> GetMovieDetails(long movieId);
    public Task RateMovie(Rate rate);
}