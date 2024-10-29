using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private static readonly HttpClient client = new HttpClient();

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(List<PokemonModel> pokemonList = null)
    {
        pokemonList ??= new List<PokemonModel>(); // Initialize as empty if null
        return View(pokemonList);
    }


    [HttpPost]
    public async Task<IActionResult> FetchPokemonList(string pokemonNames)
    {
        var pokemonNamesOrIds = pokemonNames.Split(',')
                                             .Select(name => name.Trim())
                                             .ToList();

        var pokemonList = new List<PokemonModel>();

        foreach (var nameOrId in pokemonNamesOrIds)
        {
            try
            {
                var response = await client.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{nameOrId}");
                var apiData = JsonConvert.DeserializeObject<PokemonModel>(response);

                pokemonList.Add(new PokemonModel
                {
                    Name = apiData.Name,
                    Id = apiData.Id,
                    SpriteUrl = apiData.Sprites.FrontDefault
                });
            }
            catch
            {
                // Handle errors if necessary
            }
        }

        // Pass the data to Index view
        return View("Index", pokemonList);
    }
}
