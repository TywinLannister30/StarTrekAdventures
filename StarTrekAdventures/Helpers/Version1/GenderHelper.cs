using StarTrekAdventures.Models.Version1;
using static StarTrekAdventures.Constants.Enums;

namespace StarTrekAdventures.Helpers.Version1
{
    public static class GenderHelper
    {
        public static Gender GetGender(Character character)
        {
            var randomNumber = Util.GetRandom(2) + 1;

            return (Gender)randomNumber;
        }
    }
}
