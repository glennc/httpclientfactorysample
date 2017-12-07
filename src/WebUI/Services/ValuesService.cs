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

        public ValuesSettings Settings { get; set; }

        public ValuesService() { }

        public ValuesService(HttpClient client, IOptions<ValuesSettings> settings)
        {
            Client = client;
            Settings = settings.Value;
        }

        public virtual async Task<IEnumerable<string>> GetValues()
        {
            var valuesUri = new Uri(new Uri(Settings.Uri), "api/values");
            var result = await Client.GetStringAsync(valuesUri);
            return JsonConvert.DeserializeObject<IEnumerable<string>>(result);
        }
    }
}
