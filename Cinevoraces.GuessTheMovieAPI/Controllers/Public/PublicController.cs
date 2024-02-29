using Microsoft.AspNetCore.Mvc;

namespace Cinevoraces.GuessTheMovieAPI;

[ApiController]
[Route("/")]
public class PublicController : ControllerBase
{
    [HttpGet("/")]
    public IActionResult GetRoot() => Ok("Welcome to Cinevoraces Guess the movie game API !");
}
