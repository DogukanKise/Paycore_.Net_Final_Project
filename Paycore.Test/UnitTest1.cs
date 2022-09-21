using System;
using System.Net;
using Xunit;

namespace Paycore.Test
{
    public class UnitTest1
    {
        [Fact]
        public async void GetServiceTest()
        {
            var client = new TestClientProvider().Client;

            //act
            var okResult = await client.GetAsync("values/1");

            okResult.EnsureSuccessStatusCode();

            //Assert

            Assert.Equal(HttpStatusCode.OK, okResult.StatusCode);
        }
    }
}
