
using Nivel1.Domain.Models.Interfaces;
using Nivel1.Domain.ValueObject;

namespace Nivel1.Domain.Models
{
    public class User : IModel
    {
        public User(Name name, YearsOld yearold, Cpf document, Email email, Phone phone, string address)
        {
            this.Name = name;
            this.YearsOld = yearold;
            this.Document = document;
            this.Email = email;
            this.Phone = phone;
            this.Address = address;
        }

        protected User() {}
        
        public Name Name { get; private set; }
        public YearsOld YearsOld { get; private set; }
        public Cpf Document { get; private set; }
        public Email Email { get; private set; }
        public Phone Phone { get; private set; }
        public string Address { get; private set; }

        public string GetAddress()
        {
            return Address;
        }

        public void SetAddress(string value)
        {
            Address = value;
        }                

        public Phone GetPhone()
        {
            return Phone;
        }

        public void SetPhone(Phone value)
        {            
            this.Phone = value;
        }

        public Email GetEmail()
        {
            return Email;
        }

        public void SetEmail(Email value)
        {
            this.Email = value;            
        }        

        public Cpf GetDocumentNumber()
        {
            return Document;
        }

        private void SetDocumentNumber(Cpf value)
        {
            this.Document = value;            
        }

        public YearsOld GetYearsOld()
        {
            return YearsOld;
        }

        public void SetYearsOld(YearsOld value)
        {
            this.YearsOld = value;            
        }        
                
        public Name GetName()
        {
            return Name;
        }
        public void SetName(Name value)
        {
            this.Name = value;            
        }
    }
}