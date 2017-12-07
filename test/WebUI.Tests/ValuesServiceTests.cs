using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebUI.Services;
using Xunit;

namespace WebUI.Tests
{
    public class ValuesServiceTests
    {
        Mock<ILogger<ValuesService>> _logger;

        public ValuesServiceTests()
        {
            _logger = new Mock<ILogger<ValuesService>>();
        }

        [Fact]
        public async Task will_return_last_known_good()
        {
            var firstCall = true;
            var handler = new MockMessageHandler(req =>
            {
                if(firstCall)
                {
                    firstCall = false;
                    var resp = new HttpResponseMessage(HttpStatusCode.OK);
                    resp.Content = new StringContent("[\"testval\"]");
                    return resp;
                }
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            });

            var client = new HttpClient(handler);
            client.BaseAddress = new Uri("http://test.local");
            var cache = new MemoryCache(Options.Create(new MemoryCacheOptions()));

            var service = new ValuesService(client, cache, _logger.Object);

            await service.GetValues();
            var values = await service.GetValues();

            Assert.False(firstCall);
            Assert.Equal("testval", values.First());
        }

        public class MockMessageHandler : HttpMessageHandler
        {
            private Func<HttpRequestMessage, HttpResponseMessage> _handler;

            public MockMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> handler)
            {
                _handler = handler;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_handler(request));
            }
        }

    }
}
