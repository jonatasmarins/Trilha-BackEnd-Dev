using System.Collections.Generic;
using Nivel1.Domain.ExternalServices.Marvel.Models;
using Nivel1.Domain.Models.Interfaces;

namespace Nivel1.Domain.ExternalServices.Models
{
    public class Creator
    {
        public Creator()
        {

        }

        public Creator(int Code, string Name, string Role)
        {
            this.Code = Code;
            this.Name = Name;
            this.Role = Role;
        }

        public int CreatorID { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public IList<ComicCreator> Comics { get; set; }
    }
}