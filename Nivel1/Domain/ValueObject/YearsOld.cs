namespace Nivel1.Domain.ValueObject
{
    public class YearsOld
    {
        public int Value { get; private set; }

        protected YearsOld() { }

        public YearsOld(int value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}