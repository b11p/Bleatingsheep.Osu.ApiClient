# Osu! API Client
This is an osu! API wrapper. See https://github.com/ppy/osu-api/wiki.

## Usage
1.
Install [Nuget package](https://www.nuget.org/packages/Bleatingsheep.Osu.ApiClient/).

2.
See this code.
```C#
using Bleatingsheep.Osu.ApiClient;

var osuApiClient = OsuApiClientFactory.CreateClient("your-API-key");
var user = await osuApiClient.GetUser(124493, Mode.Standard);
var user2 = await osuApiClient.GetUser("idke");
var beatmaps = await osuApiClient.GetBeatmaps(Mode.Mania, false, DateTime.Now - TimeSpan.FromDays(2), 100);
```

### Use factory
```C#
using Bleatingsheep.Osu.ApiClient;

var factory = OsuApiClientFactory.CreateFactory("your-API-key");
var osuApiClient = factory.CreateHttpApi();
var user = await osuApiClient.GetUser(124493, Mode.Standard);
var user2 = await osuApiClient.GetUser("idke");
var beatmaps = await osuApiClient.GetBeatmaps(Mode.Mania, false, DateTime.Now - TimeSpan.FromDays(2), 100);
```

### Use ASP .NET Core
#### 1. Configure Services
Add following content to your `ConfigureServices` method.
```C#
public void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IHttpApiFactory<IOsuApiClient>>(p =>
    {
        return OsuApiClientFactory.CreateFactory("your-API-key",
            c =>
            {
                c.LoggerFactory = p.GetRequiredService<ILoggerFactory>();
                c.GlobalFilters.Add(new TraceFilterAttribute { OutputTarget = OutputTarget.LoggerFactory });
            });
    });
    services.AddTransient<IOsuApiClient>(p =>
    {
        var factory = p.GetRequiredService<IHttpApiFactory<IOsuApiClient>>();
        return factory.CreateHttpApi();
    });
}
```
You should replace `your-API-key` with your osu! API key from configuration file or other places.
#### 2. Edit Controller
```C#
public class OsuApiController : Controller
{
    private readonly IOsuApiClient _osuApiClient;

    public OsuApiController(IOsuApiClient osuApiClient)
    {
        this._osuApiClient = osuApiClient;
    }

    public async Task<string> Index()
    {
        var user = await _osuApiClient.GetUser("bleatingsheep");
        return $"{user.Name} | {user.Performance} PP";
    }
}
```