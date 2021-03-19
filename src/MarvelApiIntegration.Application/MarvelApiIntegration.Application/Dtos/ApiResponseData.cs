using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MarvelApiIntegration.Application.Dtos
{
    public class ApiResponseData
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }

        [JsonPropertyName("results")]
        public List<ComicBook> ComicBooks { get; set; }
    }
}