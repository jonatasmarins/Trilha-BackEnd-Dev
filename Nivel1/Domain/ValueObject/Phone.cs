namespace Nivel1.Domain.ValueObject
{
    public class Phone
    {
        public string Value { get; private set; }

        protected Phone() {}

        public Phone(string value)
        {
            this.Value = value.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}