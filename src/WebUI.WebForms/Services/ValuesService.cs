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

        private ILogger<ValuesService> _logger;

        public ValuesService() { }

        public ValuesService(HttpClient client, ILogger<ValuesService> logger)
        {
            Client = client;
            _logger = logger;
        }

        public virtual async Task<IEnumerable<string>> GetValues()
        {
            var result = await Client.GetStringAsync("api/values");
            return JsonConvert.DeserializeObject<IEnumerable<string>>(result);
        }
    }
}
