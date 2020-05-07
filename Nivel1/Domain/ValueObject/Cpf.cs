namespace Nivel1.Domain.ValueObject
{
    public class Cpf
    {
        protected Cpf() { }
        public Cpf(string value)
        {
            this.Value = value.Replace(".", "").Replace("-", "");
        }

        public string Value { get; private set;}

        public override string ToString()
        {
            return this.Value;
        }
    }
}