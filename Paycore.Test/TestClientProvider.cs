using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Paycore.Api;
using System.Net.Http;

namespace Paycore.Test
{
    class TestClientProvider
    {
        public HttpClient Client { get; set; }

        public TestClientProvider()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
        }

    }
}
