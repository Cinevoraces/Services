namespace Cinevoraces.GuessTheMovieAPI.Utils;

public static class CustomBuilder
{
    public static WebApplication CreateWebApplication(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        return builder.LoadAppSettings().SetCorsPolicy().AddControllers().AddSwaggerDoc().Build();
    }

    private static WebApplicationBuilder LoadAppSettings(this WebApplicationBuilder builder)
    {
        var env = builder.Environment.EnvironmentName;
        builder
            .Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
        return builder;
    }

    private static WebApplicationBuilder SetCorsPolicy(this WebApplicationBuilder builder)
    {
        var allowedOrigins = builder.Configuration.GetCorsAllowedOrigins();
        builder.Services.AddCors(
            (opts) =>
            {
                opts.AddDefaultPolicy(
                    (builder) =>
                    {
                        builder
                            .WithOrigins(allowedOrigins)
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    }
                );
            }
        );
        return builder;
    }

    private static WebApplicationBuilder AddControllers(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        return builder;
    }

    private static WebApplicationBuilder AddSwaggerDoc(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(
            (opts) =>
            {
                opts.SwaggerDoc("v1", new() { Title = "Guess the movie API", Version = "v1.0" });
            }
        );
        return builder;
    }

    private static string[] GetCorsAllowedOrigins(this ConfigurationManager config) =>
        config.GetSection("CorsAllowedOrigins").Get<string[]>()
        ?? throw new InvalidOperationException("No allowed origins found in appsettings files");
}
