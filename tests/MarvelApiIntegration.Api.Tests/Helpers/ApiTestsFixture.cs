﻿using Bogus;
using Moq.AutoMock;

namespace MarvelApiIntegration.Api.Tests.Helpers
{
    public class ApiTestsFixture
    {
        public Faker Faker => new Faker();
        public AutoMocker AutoMocker { get; private set; }

        public ApiTestsFixture() => AutoMocker = new AutoMocker();
    }
}