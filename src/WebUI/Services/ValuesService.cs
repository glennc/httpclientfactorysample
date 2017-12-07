using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebUI.Services
{

    public class ValuesService
    {
        public HttpClient Client { get; set; }
        public IMemoryCache Cache { get; set; }

        private ILogger<ValuesService> _logger;

        public ValuesService() { }

        public ValuesService(HttpClient client, IMemoryCache cache, ILogger<ValuesService> logger)
        {
            Client = client;
            Cache = cache;
            _logger = logger;
        }

        public virtual async Task<IEnumerable<string>> GetValues()
        {
            var result = await Client.GetAsync("api/values");
            var resultObj = Enumerable.Empty<string>();
            //TODO: This will be a try/catch with polly.
            if (result.IsSuccessStatusCode)
            {
                resultObj = JsonConvert.DeserializeObject<IEnumerable<string>>(await result.Content.ReadAsStringAsync());
                Cache.Set("GetValue", resultObj);
            }
            else
            {
                if (Cache.TryGetValue("GetValue", out resultObj))
                {
                    _logger.LogWarning("Returning cached values as the values service is unavailable.");
                    return resultObj;
                }
                result.EnsureSuccessStatusCode();
            }
            return resultObj;
        }
    }
}
