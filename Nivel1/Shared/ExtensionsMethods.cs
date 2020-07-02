namespace System
{
    public static class ExtensionMethods
    {
        public static bool IsNumber(this string str)
        {
            double output;
            return double.TryParse(str, out output);
        }
    }
}