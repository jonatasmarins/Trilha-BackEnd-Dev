using Nivel1.Domain.ExternalServices.Models;

namespace Nivel1.Domain.ExternalServices.Marvel.Models
{
    public class ComicCreator
    {
        public int ComicID { get; set; }
        public Comic Comic { get; set; }

        public int CreatorID { get; set; }
        public Creator Creator { get; set; }
    }
}