namespace Nivel1.Domain.ValueObject
{
    public class Cpf
    {
        protected Cpf() { }
        public Cpf(string value)
        {
            this.Value = value;
        }

        public string Value { get; private set;}

        public override string ToString()
        {
            return this.Value;
        }
    }
}