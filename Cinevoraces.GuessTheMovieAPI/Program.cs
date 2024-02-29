using Cinevoraces.GuessTheMovieAPI.Utils;

internal sealed class Program
{
    private static void Main(string[] args)
    {
        var api = CustomBuilder.CreateWebApplication(args);
        RegisterServices(api);
        api.Run();
    }

    private static void RegisterServices(WebApplication api)
    {
        api.UseSwagger().UseSwaggerUI().UseCors();
        api.MapControllers();
    }
}
