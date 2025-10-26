using StarTrekAdventures.Models;

namespace StarTrekAdventures.FrontEnd.Services;

public class StarTrekApiClient(HttpClient http)
{
    private readonly HttpClient _http = http;

    public async Task<Character?> GenerateCharacterAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return null;
        try
        {
            var response = await _http.PostAsJsonAsync($"/api/v2/character/generate", new { });
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Character>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"StarTrekApiClient error: {ex.Message}");
            return null;
        }
    }
}