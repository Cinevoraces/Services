namespace Cinevoraces.Utils.Http;

public class HttpClient : IHttpClient
{
    private const string BaseUrl = "https://api.themoviedb.org/3";
    private readonly string APIKey;
    private readonly System.Net.Http.HttpClient Client;

    public HttpClient(string apiKey)
    {
        Client = new System.Net.Http.HttpClient();
        APIKey = apiKey;
    }

    public async Task GetMovieByIdAsync(int id)
    // public async Task<TMDBMovieModel> GetMovieByIdAsync(int id)
    {
        var res = await Client.GetAsync($"{BaseUrl}/movie/{id}?api_key={APIKey}");
    }

    private async Task<T> HandleResponse<T>(Func<Task<HttpResponseMessage>> request)
    {
        var response = await request();
        var content = await response.Content.ReadAsStringAsync();
        return Serialization.Deserialize<T>(content.Length == 0 ? "{}" : content);
    }

    private async Task<T> GetAsync<T>(string endpoint) =>
        await HandleResponse<T>(async () => await Client.GetAsync($"{BaseUrl}/{endpoint}"));
    // private async Task<T> GetAsync<T>(string endpoint) => await HandleResponse<T>(async () => await Client.GetAsync($"{BaseUrl}/{endpoint}"));
    // private async Task<T> GetAsync<T>(string endpoint) => await HandleResponse<T>(async () => await Client.GetAsync($"{BaseUrl}/{endpoint}"));
    // private async Task<T> GetAsync<T>(string endpoint) => await HandleResponse<T>(async () => await Client.GetAsync($"{BaseUrl}/{endpoint}"));
}
