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