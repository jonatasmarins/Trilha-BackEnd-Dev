namespace Nivel1.Domain.ValueObject
{
    public class Name
    {
        public string Value { get; private set; }      

        protected Name() {}  

        public Name(string value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}