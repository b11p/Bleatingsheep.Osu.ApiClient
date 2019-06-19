using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiClient;
using WebApiClient.Attributes;
using WebApiClient.Contexts;
using WebApiClient.DataAnnotations;

namespace Bleatingsheep.Osu.ApiClient
{
    [HttpHost("https://osu.ppy.sh/api/")]
    //[TraceFilter(OutputTarget = OutputTarget.Console)]
    public interface IOsuApiClient : IHttpApi
    {
        [HttpGet("get_user")]
        [OneElementArrayJsonReturn]
        [AddUrlQueryFilter("type", "id")]
        Task<UserInfo> GetUser(
            [AliasAs("u")]int id,
            [AliasAs("m")]Mode mode = Mode.Standard,
            [AliasAs("event_days")]int eventDays = 1
            );

        [HttpGet("get_user")]
        [OneElementArrayJsonReturn]
        [AddUrlQueryFilter("type", "string")]
        Task<UserInfo> GetUser(
            [Required, AliasAs("u")]string name,
            [AliasAs("m")]Mode mode = Mode.Standard,
            [AliasAs("event_days")]int eventDays = 1
            );

        [OneElementArrayJsonReturn]
        [HttpGet("get_beatmaps")]
        Task<BeatmapInfo> GetBeatmap(
            [AliasAs("b")] int id,
            [AliasAs("mods")] Mods mods = Mods.None);

        [OneElementArrayJsonReturn]
        [HttpGet("get_beatmaps")]
        Task<BeatmapInfo> GetBeatmap(
            [AliasAs("b")] int id,
            [AliasAs("m")] Mode mode,
            [AliasAs("a"), Type(TypeCode.Int32)] bool includeConvertedBeatmaps = true,
            [AliasAs("mods")] Mods mods = Mods.None);

        [OneElementArrayJsonReturn]
        [HttpGet("get_beatmaps")]
        Task<BeatmapInfo> GetBeatmap(
            [AliasAs("h")] string fileMd5,
            [AliasAs("mods")] Mods mods = Mods.None);

        [OneElementArrayJsonReturn]
        [HttpGet("get_beatmaps")]
        Task<BeatmapInfo> GetBeatmap(
            [AliasAs("h")] string fileMd5,
            [AliasAs("m")] Mode mode,
            [AliasAs("a"), Type(TypeCode.Int32)] bool includeConvertedBeatmaps = true,
            [AliasAs("mods")] Mods mods = Mods.None);

        [HttpGet("get_beatmaps")]
        Task<BeatmapInfo[]> GetBeatmaps(
            [AliasAs("since"), PathQuery("yyyy-M-d H:m:s")] DateTime? since = null,
            [AliasAs("limit")] int limit = 500,
            [AliasAs("mods")] Mods mods = Mods.None);

        [HttpGet("get_beatmaps")]
        Task<BeatmapInfo[]> GetBeatmaps(
            [AliasAs("m")] Mode mode,
            [AliasAs("a"), Type(TypeCode.Int32)] bool includeConvertedBeatmaps = false,
            [AliasAs("since"), PathQuery("yyyy-M-d H:m:s")] DateTime? since = null,
            [AliasAs("limit")] int limit = 500,
            [AliasAs("mods")] Mods mods = Mods.None);

        [HttpGet("get_beatmaps")]
        [AddUrlQueryFilter("type", "id")]
        Task<BeatmapInfo[]> GetBeatmapsFromUser(
            [AliasAs("u")] int userId,
            [AliasAs("since"), PathQuery("yyyy-M-d H:m:s")] DateTime? since = null,
            [AliasAs("limit")] int limit = 500,
            [AliasAs("mods")] Mods mods = Mods.None);

        [HttpGet("get_beatmaps")]
        [AddUrlQueryFilter("type", "id")]
        Task<BeatmapInfo[]> GetBeatmapsFromUser(
            [AliasAs("u")] int userId,
            [AliasAs("m")] Mode mode,
            [AliasAs("a"), Type(TypeCode.Int32)] bool includeConvertedBeatmaps = false,
            [AliasAs("since"), PathQuery("yyyy-M-d H:m:s")] DateTime? since = null,
            [AliasAs("limit")] int limit = 500,
            [AliasAs("mods")] Mods mods = Mods.None);

        [HttpGet("get_beatmaps")]
        [AddUrlQueryFilter("type", "string")]
        Task<BeatmapInfo[]> GetBeatmapsFromUser(
            [AliasAs("u"), Required] string userName,
            [AliasAs("since"), PathQuery("yyyy-M-d H:m:s")] DateTime? since = null,
            [AliasAs("limit")] int limit = 500,
            [AliasAs("mods")] Mods mods = Mods.None);

        [HttpGet("get_beatmaps")]
        [AddUrlQueryFilter("type", "string")]
        Task<BeatmapInfo[]> GetBeatmapsFromUser(
            [AliasAs("u"), Required] string userName,
            [AliasAs("m")] Mode mode,
            [AliasAs("a"), Type(TypeCode.Int32)] bool includeConvertedBeatmaps = false,
            [AliasAs("since"), PathQuery("yyyy-M-d H:m:s")] DateTime? since = null,
            [AliasAs("limit")] int limit = 500,
            [AliasAs("mods")] Mods mods = Mods.None);

        [HttpGet("get_beatmaps")]
        Task<BeatmapInfo[]> GetBeatmapSet(
            [AliasAs("s")] int setId,
            [AliasAs("mods")] Mods mods = Mods.None);

        [HttpGet("get_beatmaps")]
        Task<BeatmapInfo[]> GetBeatmapSet(
            [AliasAs("s")] int setId,
            [AliasAs("m")] Mode mode,
            [AliasAs("a"), Type(TypeCode.Int32)] bool includeConvertedBeatmaps,
            [AliasAs("mods")] Mods mods = Mods.None);

        /// <summary>
        /// Retrieve information about the top 100 scores of a specified beatmap.
        /// </summary>
        /// <param name="mode">Mode. Note that default value is <see cref="Mode.Standard"/>,
        /// even if the beatmap is not an osu!standard beatmap. In that case, an empty array
        /// will be returned.</param>
        /// <returns></returns>
        [HttpGet("get_scores")]
        Task<ScoreInfo[]> GetScores(
            [AliasAs("b")] int beatmapId,
            [AliasAs("m")] Mode mode = Mode.Standard,
            [AliasAs("limit")] int limit = 50);

        /// <summary>
        /// Retrieve information about the top 100 scores of a specified beatmap.
        /// </summary>
        /// <param name="mode">Mode. Note that default value is <see cref="Mode.Standard"/>,
        /// even if the beatmap is not an osu!standard beatmap. In that case, an empty array
        /// will be returned.</param>
        /// <returns></returns>
        [HttpGet("get_scores")]
        [AddUrlQueryFilter("type", "id")]
        Task<ScoreInfo[]> GetScores(
            [AliasAs("b")] int beatmapId,
            [AliasAs("u")] int userId,
            [AliasAs("m")] Mode mode = Mode.Standard,
            [AliasAs("limit")] int limit = 50);

        /// <summary>
        /// Retrieve information about the top 100 scores of a specified beatmap.
        /// </summary>
        /// <param name="mode">Mode. Note that default value is <see cref="Mode.Standard"/>,
        /// even if the beatmap is not an osu!standard beatmap. In that case, an empty array
        /// will be returned.</param>
        /// <returns></returns>
        [HttpGet("get_scores")]
        [AddUrlQueryFilter("type", "string")]
        Task<ScoreInfo[]> GetScores(
            [AliasAs("b")] int beatmapId,
            [AliasAs("u"), Required] string userName,
            [AliasAs("m")] Mode mode = Mode.Standard,
            [AliasAs("limit")] int limit = 50);

        /// <summary>
        /// Retrieve information about the top 100 scores of a specified beatmap.
        /// </summary>
        /// <param name="mode">Mode. Note that default value is <see cref="Mode.Standard"/>,
        /// even if the beatmap is not an osu!standard beatmap. In that case, an empty array
        /// will be returned.</param>
        /// <returns></returns>
        [HttpGet("get_scores")]
        Task<ScoreInfo[]> GetScores(
            [AliasAs("b")] int beatmapId,
            [AliasAs("m")] Mode mode = Mode.Standard,
            [AliasAs("limit")] int limit = 50,
            [AliasAs("mods")] Mods mods = Mods.None);

        /// <summary>
        /// Retrieve information about the top 100 scores of a specified beatmap.
        /// </summary>
        /// <param name="mode">Mode. Note that default value is <see cref="Mode.Standard"/>,
        /// even if the beatmap is not an osu!standard beatmap. In that case, an empty array
        /// will be returned.</param>
        /// <returns></returns>
        [HttpGet("get_scores")]
        [AddUrlQueryFilter("type", "id")]
        Task<ScoreInfo[]> GetScores(
            [AliasAs("b")] int beatmapId,
            [AliasAs("u")] int userId,
            [AliasAs("m")] Mode mode = Mode.Standard,
            [AliasAs("limit")] int limit = 50,
            [AliasAs("mods")] Mods mods = Mods.None);

        /// <summary>
        /// Retrieve information about the top 100 scores of a specified beatmap.
        /// </summary>
        /// <param name="mode">Mode. Note that default value is <see cref="Mode.Standard"/>,
        /// even if the beatmap is not an osu!standard beatmap. In that case, an empty array
        /// will be returned.</param>
        /// <returns></returns>
        [HttpGet("get_scores")]
        [AddUrlQueryFilter("type", "string")]
        Task<ScoreInfo[]> GetScores(
            [AliasAs("b")] int beatmapId,
            [AliasAs("u"), Required] string userName,
            [AliasAs("m")] Mode mode = Mode.Standard,
            [AliasAs("limit")] int limit = 50,
            [AliasAs("mods")] Mods mods = Mods.None);

        [HttpGet("get_user_best")]
        [AddUrlQueryFilter("type", "id")]
        Task<UserBest[]> GetUserBest(
            [AliasAs("u")] int userId,
            [AliasAs("m")] Mode mode = Mode.Standard,
            [AliasAs("limit")] int limit = 10);

        [HttpGet("get_user_best")]
        [AddUrlQueryFilter("type", "string")]
        Task<UserBest[]> GetUserBest(
            [AliasAs("u"), Required] string userName,
            [AliasAs("m")] Mode mode = Mode.Standard,
            [AliasAs("limit")] int limit = 10);

        [HttpGet("get_user_recent")]
        [AddUrlQueryFilter("type", "id")]
        Task<UserRecent[]> GetUserRecent(
            [AliasAs("u")] int userId,
            [AliasAs("m")] Mode mode = Mode.Standard,
            [AliasAs("limit")] int limit = 10);

        [HttpGet("get_user_recent")]
        [AddUrlQueryFilter("type", "string")]
        Task<UserRecent[]> GetUserRecent(
            [AliasAs("u"), Required] string userName,
            [AliasAs("m")] Mode mode = Mode.Standard,
            [AliasAs("limit")] int limit = 10);
    }

    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    internal class TypeAttribute : Attribute, IApiParameterAttribute
    {
        private readonly TypeCode _typeCode;

        public TypeAttribute(TypeCode typeCode)
            => _typeCode = typeCode;

        public Task BeforeRequestAsync(ApiActionContext context, ApiParameterDescriptor parameter)
        {
            var convertedValue = Convert.ChangeType(parameter.Value, _typeCode, CultureInfo.InvariantCulture);
            context.RequestMessage.AddUrlQuery(
                parameter.Name,
                Convert.ToString(convertedValue, CultureInfo.InvariantCulture));
            return Task.CompletedTask;
        }
    }

    /// <summary>
    /// Represents that the return value is an array but includes no more than one element.
    /// </summary>
    internal class OneElementArrayJsonReturnAttribute : JsonReturnAttribute
    {
        protected override async Task<object> GetTaskResult(ApiActionContext context)
        {
            var response = context.ResponseMessage;
            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var dataType = context.ApiActionDescriptor.Return.DataType.Type;
            var arrayType = dataType.MakeArrayType();
            var result = (object[])context.HttpApiConfig.JsonFormatter.Deserialize(json, arrayType);
            return result.FirstOrDefault();
        }
    }

    /// <summary>
    /// Add API Key.
    /// </summary>
    internal class ApiKeyFilter : IApiActionFilter
    {
        private readonly string _apiKey;

        private readonly IReadOnlyList<string> _apiKeys;
        private int _calls;
        private readonly bool _hasManyKeys;

        public ApiKeyFilter(string apiKey)
        {
            _hasManyKeys = false;
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        }

        public ApiKeyFilter(params string[] apiKeys) : this((IEnumerable<string>)apiKeys)
        {
        }

        public ApiKeyFilter(IEnumerable<string> apiKeys)
        {
            if (apiKeys == null)
            {
                throw new System.ArgumentNullException(nameof(apiKeys));
            }

            if (!_apiKeys.Any())
                throw new ArgumentException($"{nameof(apiKeys)} does not contain any elements.");

            if (apiKeys.Count() > 1)
            {
                _hasManyKeys = true;
                _apiKeys = apiKeys.ToList().AsReadOnly();
                _calls = 0;

                if (_apiKeys.Any(k => string.IsNullOrEmpty(k)))
                    throw new ArgumentException($"One or some elements of {nameof(apiKeys)} are null or empty.");
            }
            else
            {
                var apiKey = apiKeys.First();

                _hasManyKeys = false;
                _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
            }
        }

        public Task OnBeginRequestAsync(ApiActionContext context)
        {
            string apiKey;
            if (_hasManyKeys)
            {
                var calls = Interlocked.Increment(ref _calls) - 1;
                var selectedIndex = calls % _apiKeys.Count;

                if (selectedIndex < 0)
                {
                    selectedIndex += _apiKeys.Count;
                }

                apiKey = _apiKeys[selectedIndex];
            }
            else
            {
                apiKey = _apiKey;
            }
            context.RequestMessage.AddUrlQuery("k", apiKey);
            return base.OnBeginRequestAsync(context);
        }

        public Task OnEndRequestAsync(ApiActionContext context) => Task.CompletedTask;
    }

    /// <summary>
    /// Add url query string.
    /// </summary>
    internal class AddUrlQueryFilterAttribute : ApiActionFilterAttribute
    {
        private readonly string _key;
        private readonly string _value;

        public AddUrlQueryFilterAttribute(string key, string value)
        {
            _key = key;
            _value = value;
        }

        public override Task OnBeginRequestAsync(ApiActionContext context)
        {
            context.RequestMessage.AddUrlQuery(_key, _value);
            return base.OnBeginRequestAsync(context);
        }
    }
}
