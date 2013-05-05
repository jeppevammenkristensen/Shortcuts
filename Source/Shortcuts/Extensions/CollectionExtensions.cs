namespace Shortcuts.Extensions
{
    public static class CollectionExtensions
    {
         public static string GetIndexValueOrNull(this string[] source, int index)
         {
             if (source == null || source.Length == 0)
                 return string.Empty;

             if (source.Length >= index)
                 return source[index];

             return string.Empty;
         }
    }
}