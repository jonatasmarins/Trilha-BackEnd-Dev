namespace Nivel1.Domain.ValueObject
{
    public class Email
    {
        public string Value { get; private set; }

        protected Email() {}

        public Email(string value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}