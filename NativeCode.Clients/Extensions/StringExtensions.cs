namespace NativeCode.Clients.Extensions
{
    public static class StringExtensions
    {
        public static bool HasNoValue(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static bool HasValue(this string value)
        {
            return string.IsNullOrWhiteSpace(value) == false;
        }
    }
}