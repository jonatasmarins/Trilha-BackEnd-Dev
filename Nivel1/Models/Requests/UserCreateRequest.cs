namespace Nivel1.Models
{
    public class UserCreateRequest
    {
        public string Name { get; set; }
        public int YearsOld { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}