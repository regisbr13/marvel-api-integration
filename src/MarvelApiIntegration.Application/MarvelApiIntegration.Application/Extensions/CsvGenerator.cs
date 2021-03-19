using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarvelApiIntegration.Application.Extensions
{
    public static class CsvGenerator
    {
        public static string GetContent<T>(List<T> values) where T : class
        {
            var propertyNames = typeof(T).GetProperties().Select(p => p.Name).ToList();
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Join(";", propertyNames));
            foreach (var item in values)
            {
                var propertyValues = item.GetType().GetProperties()
                    .Select(p => p.GetValue(item)?.ToString().RemoveAllBreakLines());
                stringBuilder.AppendLine(string.Join(";", propertyValues));
            }

            return stringBuilder.ToString();
        }
    }
}