namespace Shortcuts.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }
    }
}