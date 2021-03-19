namespace MarvelApiIntegration.Application.Dtos
{
    public class ApiResponse
    {
        public int Code { get; set; }
        public string Status { get; set; }
        public string Copyright { get; set; }
        public string Etag { get; set; }
        public ApiResponseData Data { get; set; }
    }
}