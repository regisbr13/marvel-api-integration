namespace MarvelApiIntegration.Application.Extensions
{
    public static class StringExtensions
    {
        public static string RemoveAllBreakLines(this string value)
            => value.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
    }
}