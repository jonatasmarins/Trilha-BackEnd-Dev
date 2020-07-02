using System.ComponentModel.DataAnnotations;

namespace Nivel1.Domain.Models.Interfaces
{
    public abstract class IModel
    {
        [Key]
        public int Id { get; set; }
    }
}