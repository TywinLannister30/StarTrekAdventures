using StarTrekAdventures.Models;

namespace StarTrekAdventures.Managers;

public interface INpcManager
{
    List<NonPlayerCharacter> GetAll();

    List<string> GetAllNames();

    NonPlayerCharacter Get(string name);

    NonPlayerCharacter GenerateNpc(string name);
}
