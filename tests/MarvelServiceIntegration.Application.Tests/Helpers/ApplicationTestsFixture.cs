using Bogus;
using MarvelServiceIntegration.Application.Dtos;
using MarvelServiceIntegration.Application.Services;
using Moq;
using Moq.AutoMock;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MarvelServiceIntegration.Application.Tests.Helpers
{
    public class ApplicationTestsFixture
    {
        public Faker Faker => new Faker();
        public AutoMocker AutoMocker { get; private set; }

        private MarvelComicsApiSettings MarvelComicsApiSettings
            => new Faker<MarvelComicsApiSettings>().CustomInstantiator(f => new MarvelComicsApiSettings
            {
                BaseUrl = f.Internet.Url()
            });

        public ApplicationTestsFixture() => AutoMocker = new AutoMocker();

        public List<ComicBook> GetComics()
        {
            var faker = new Faker<ComicBook>();
            return faker.CustomInstantiator(f => new ComicBook
            {
                Id = f.Random.Int(1, 200),
                Title = f.Lorem.Text()
            }).Generate(5);
        }

        public string GetStringWithBreakLines()
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < 3; i++)
            {
                stringBuilder.AppendLine(Faker.Random.String2(15));
            }

            return stringBuilder.ToString();
        }

        public StringContent MarvelApiResponseContent(List<ComicBook> comics)
        {
            var apiResponse = AutoMocker.GetMock<ApiResponse>().Object;
            apiResponse.Data = new Faker<ApiResponseData>()
                .CustomInstantiator(f => new ApiResponseData { ComicBooks = comics });
            return new StringContent
            (
                JsonSerializer.Serialize(apiResponse),
                Encoding.UTF8,
                "application/json"
            );
        }

        public HttpResponseMessage GetSuccessfulResponse(StringContent content)
            => new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = content
            };

        public HttpResponseMessage GetUnsuccessfulResponse()
            => new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.BadRequest,
            };

        public HttpClient GetHttpClient(HttpResponseMessage response)
        {
            var httpMessageHandler = new Mock<HttpMessageHandler>();
            var uri = new Faker<Uri>("pt_BR")
                .CustomInstantiator(f => new Uri(MarvelComicsApiSettings.BaseUrl));
            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync((HttpRequestMessage request, CancellationToken token) => response);

            var client = new Mock<HttpClient>(httpMessageHandler.Object);
            client.Object.BaseAddress = uri;

            return client.Object;
        }

        public MarvelApiService GetMarvelApiService(HttpClient httpClient)
        => new Faker<MarvelApiService>()
            .CustomInstantiator(f => new MarvelApiService
            (
                httpClient ?? AutoMocker.GetMock<HttpClient>().Object,
                AutoMocker.GetMock<MarvelComicsApiSettings>().Object
            ));
    }
}