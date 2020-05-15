using Nivel1.Domain.ExternalServices.Models;

namespace Nivel1.Domain.ExternalServices.Marvel.Models
{
    public class ComicCharacter
    {
        public int ComicID { get; set; }
        public Comic Comic { get; set; }

        public int CharacterID { get; set; }
        public Character Character { get; set; }
    }
}
