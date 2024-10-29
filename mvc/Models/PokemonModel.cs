using Newtonsoft.Json;


public class PokemonModel
{
    public string Name { get; set; }
    public int Id { get; set; }
    public string SpriteUrl { get; set; }
    public Sprites Sprites { get; set; }
    public List<AbilityInfo> Abilities { get; set; }
}

public class Sprites
{
    [JsonProperty("front_default")]
    public string FrontDefault { get; set; }  // Main image
}

public class AbilityInfo
{
    public Ability Ability { get; set; }
    public bool IsHidden { get; set; }
    public int Slot { get; set; }
}

public class Ability
{
    public string Name { get; set; }
    public string Url { get; set; }
}
