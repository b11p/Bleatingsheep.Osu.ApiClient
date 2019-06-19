using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using WebApiClient;
using WebApiClient.Defaults;

namespace Bleatingsheep.Osu.ApiClient
{
    public class OsuApiClientFactory
    {
        private readonly ApiKeyFilter _apiKeyFilter;
        private HttpApiFactory<IOsuApiClient> _httpApiFactory;

        public static HttpApiFactory<IOsuApiClient> CreateFactory(string apiKey)
        {
            var _apiKeyFilter = new ApiKeyFilter(apiKey);
            HttpApiFactory<IOsuApiClient> httpApiFactory = CreateFactory(keyFilter);

            return httpApiFactory;
        }

        public static HttpApiFactory<IOsuApiClient> CreateFactory(params string[] apiKeys)
        {
            var keyFilter = new ApiKeyFilter(apiKeys);
            HttpApiFactory<IOsuApiClient> httpApiFactory = CreateFactory(keyFilter);

            return httpApiFactory;
        }

        public static HttpApiFactory<IOsuApiClient> CreateFactory(IEnumerable<string> apiKeys)
        {
            var keyFilter = new ApiKeyFilter(apiKeys);
            HttpApiFactory<IOsuApiClient> httpApiFactory = CreateFactory(keyFilter);

            return httpApiFactory;
        }

        public static IOsuApiClient CreateClient(string apiKey)
            => CreateFactory(apiKey).CreateHttpApi();

        public IOsuApiClient CreateClient()
        {
            if (_httpApiFactory == null)
            {
                _httpApiFactory = new HttpApiFactory<IOsuApiClient>()
                    .ConfigureHttpApiConfig(c =>
                    {
                        var formatter = new JsonFormatter();
                        formatter.Settings = s =>
                        {
                            s.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                            s.NullValueHandling = NullValueHandling.Ignore;
                        };
                        c.JsonFormatter = formatter;

                        c.GlobalFilters.Add(_apiKeyFilter);
                    });
            }

            return _httpApiFactory.CreateHttpApi();
        }
    }
}
