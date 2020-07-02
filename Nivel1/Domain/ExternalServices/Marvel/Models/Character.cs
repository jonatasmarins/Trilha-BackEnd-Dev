using System.Collections.Generic;
using Nivel1.Domain.ExternalServices.Marvel.Models;
using Nivel1.Domain.Models.Interfaces;

namespace Nivel1.Domain.ExternalServices.Models
{
    public class Character
    {
        public Character()
        {

        }

        public Character(int Code, string Name, string UrlWiki, string UrlImage)
        {
            this.Code = Code;
            this.Name = Name;
            this.UrlWiki = UrlWiki;
            this.UrlImage = UrlImage;
        }

        public int CharacterID { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string UrlWiki { get; set; }
        public string UrlImage { get; set; }
        public IList<ComicCharacter> Comics { get; set; }
    }
}
