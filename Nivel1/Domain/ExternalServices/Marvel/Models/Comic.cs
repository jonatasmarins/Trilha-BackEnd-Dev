using System.Collections.Generic;
using Nivel1.Domain.ExternalServices.Marvel.Models;
using Nivel1.Domain.Models.Interfaces;

namespace Nivel1.Domain.ExternalServices.Models
{
    public class Comic
    {
        public Comic()
        {
            Characters = new List<ComicCharacter>();
            Creators = new List<ComicCreator>();
        }

        public int ComicID { get; set; }
        public int Code { get; set; }
        public string Title { get; set; }
        public string Ean { get; set; }
        public int PageCount { get; set; }
        public string UrlWiki { get; set; }
        public IList<ComicCharacter> Characters { get; set; }
        public IList<ComicCreator> Creators { get; set; }
    }
}