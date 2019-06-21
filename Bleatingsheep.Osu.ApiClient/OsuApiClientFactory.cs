using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WebApiClient;
using WebApiClient.Defaults;

namespace Bleatingsheep.Osu.ApiClient
{
    public class OsuApiClientFactory
    {
        private readonly ApiKeyFilter _apiKeyFilter;
        private HttpApiFactory<IOsuApiClient> _httpApiFactory;

        public static HttpApiFactory<IOsuApiClient> CreateFactory(string apiKey, Action<HttpApiConfig> options = null)
        {
            var keyFilter = new ApiKeyFilter(apiKey);
            HttpApiFactory<IOsuApiClient> httpApiFactory = CreateFactory(keyFilter, options);

            return httpApiFactory;
        }

        public static HttpApiFactory<IOsuApiClient> CreateFactory(params string[] apiKeys)
        {
            var keyFilter = new ApiKeyFilter(apiKeys);
            HttpApiFactory<IOsuApiClient> httpApiFactory = CreateFactory(keyFilter);

            return httpApiFactory;
        }

        public static HttpApiFactory<IOsuApiClient> CreateFactory(IEnumerable<string> apiKeys, Action<HttpApiConfig> options = null)
        {
            var keyFilter = new ApiKeyFilter(apiKeys);
            HttpApiFactory<IOsuApiClient> httpApiFactory = CreateFactory(keyFilter, options);

            return httpApiFactory;
        }

        private static HttpApiFactory<IOsuApiClient> CreateFactory(ApiKeyFilter keyFilter, Action<HttpApiConfig> options = null)
        {
            return new HttpApiFactory<IOsuApiClient>()
                .ConfigureHttpApiConfig(c =>
                {
                    var formatter = new JsonFormatter();
                    formatter.Settings = s =>
                    {
                        s.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                        s.NullValueHandling = NullValueHandling.Ignore;
                    };
                    c.JsonFormatter = formatter;

                    c.GlobalFilters.Add(keyFilter);

                    options?.Invoke(c);
                });
        }

        public static IOsuApiClient CreateClient(string apiKey)
            => CreateFactory(apiKey).CreateHttpApi();

        public IOsuApiClient CreateClient()
        {
            if (_httpApiFactory == null)
            {
                _httpApiFactory = CreateFactory(_apiKeyFilter);
            }

            return _httpApiFactory.CreateHttpApi();
        }
    }
}
