using System.Collections.Generic;

namespace Nivel1.Domain.ExternalServices.Models
{
    public class Comic
    {
        public Comic()
        {
            Characters = new List<Character>();
            Creators = new List<Creator>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Ean { get; set; }
        public int PageCount { get; set; }
        public string UrlWiki { get; set; }
        public IList<Character> Characters { get; set; }
        public IList<Creator> Creators { get; set; }
    }
}