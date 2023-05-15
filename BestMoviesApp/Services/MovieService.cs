using BestMoviesApp.Models;

namespace BestMoviesApp.Services;

public class MovieService : IMovieService
{
    private readonly HttpClient httpClient;

    public MovieService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<Movie?> GetMovieDetails(long movieId)
    {
        var response = await httpClient.GetAsync($"Movie/Details?movieId={movieId}");

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<Movie>();
    }

    public async Task RateMovie(Rate rate)
    {
        var response = await httpClient.PostAsJsonAsync("Movie/Rate", rate);
        response.EnsureSuccessStatusCode();
    }
}