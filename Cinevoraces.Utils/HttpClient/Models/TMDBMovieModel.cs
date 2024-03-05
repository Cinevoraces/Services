namespace Cinevoraces.Utils.Http;

public class TMDBMovieModel
{
    public bool Adult { get; set; }
    public int Id { get; set; }
    public required string OriginalTitle { get; set; }
    public List<TMDBMovieGenreModel>? Genres { get; set; }
}

public class TMDBMovieGenreModel
{
    public int Id { get; set; }
    public required string Name { get; set; }
}
