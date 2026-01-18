using StarTrekAdventures.Models;

namespace StarTrekAdventures.FrontEnd.Services;

public class StarTrekApiClient(HttpClient http)
{
    private readonly HttpClient _http = http;

    public async Task<Character?> GenerateCharacterAsync(string? species)
    {
        try
        {
            // Build the URL with optional query param
            var url = string.IsNullOrWhiteSpace(species)
                ? "/api/v2/character/generate"
                : $"/api/v2/character/generate?species={Uri.EscapeDataString(species)}";

            var response = await _http.PostAsync(url, null);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Character>();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"HTTP error calling backend: {ex.Message}");
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"StarTrekApiClient error: {ex.Message}");
            return null;
        }
    }

    public async Task<List<string>?> GetSpeciesNames()
    {
        var response = await _http.GetAsync($"/api/v2/species/names");
        if (!response.IsSuccessStatusCode) return null;
        return await response.Content.ReadFromJsonAsync<List<string>>();
    }

    public async Task<Species?> GetSpeciesAsync(string species)
    {
        var response = await _http.GetAsync($"/api/v2/species/{species}");
        if (!response.IsSuccessStatusCode) return null;
        return await response.Content.ReadFromJsonAsync<Species>();
    }

    public async Task<SpeciesAbility?> GetSpeciesAbilityAsync(string species)
    {
        var response = await _http.GetAsync($"/api/v2/species/{species}/ability");
        if (!response.IsSuccessStatusCode) return null;
        return await response.Content.ReadFromJsonAsync<SpeciesAbility>();
    }
}
