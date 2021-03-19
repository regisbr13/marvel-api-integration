using System.Security.Cryptography;
using System.Text;

namespace MarvelApiIntegration.Application.Dtos
{
    public class MarvelComicsApiSettings
    {
        public string BaseUrl { get; set; }
        public int TimeSpan { get; set; }
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }

        public string GetValidPathPrefix() => $"ts={TimeSpan}&apikey={PublicKey}&hash={GetUrlHashCode()}";

        private string GetUrlHashCode()
        {
            var md5Hash = MD5.Create();
            var inputBytes = md5Hash.ComputeHash(Encoding.ASCII.GetBytes($"{TimeSpan}{PrivateKey}{PublicKey}"));
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < inputBytes.Length; i++)
            {
                stringBuilder.Append(inputBytes[i].ToString("X2"));
            }

            return stringBuilder.ToString().ToLower();
        }
    }
}