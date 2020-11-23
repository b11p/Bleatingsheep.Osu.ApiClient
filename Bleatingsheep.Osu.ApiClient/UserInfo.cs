using System;
using Newtonsoft.Json;

namespace Bleatingsheep.Osu.ApiClient
{
    [JsonObject(MemberSerialization.OptIn)]
    public partial class UserInfo
    {
        [JsonProperty("user_id")]
        public long Id { get; set; }

        [JsonProperty("username")]
        public string Name { get; set; }

        /// <summary>
        /// In UTC.
        /// </summary>
        [JsonProperty("join_date")]
        public DateTime JoinDate { get; set; }

        [JsonProperty("count300", NullValueHandling = NullValueHandling.Ignore)]
        public int Count300 { get; set; }

        [JsonProperty("count100", NullValueHandling = NullValueHandling.Ignore)]
        public int Count100 { get; set; }

        [JsonProperty("count50", NullValueHandling = NullValueHandling.Ignore)]
        public int Count50 { get; set; }

        public int TotalHits => Count300 + Count100 + Count50;

        [JsonProperty("playcount", NullValueHandling = NullValueHandling.Ignore)]
        public int PlayCount { get; set; }

        [JsonProperty("ranked_score", NullValueHandling = NullValueHandling.Ignore)]
        public long RankedScore { get; set; }

        [JsonProperty("total_score", NullValueHandling = NullValueHandling.Ignore)]
        public long TotalScore { get; set; }

        [JsonProperty("pp_rank", NullValueHandling = NullValueHandling.Ignore)]
        public int Rank { get; set; }

        [JsonProperty("level", NullValueHandling = NullValueHandling.Ignore)]
        public double Level { get; set; }

        /// <summary>
        /// For inactive players this will be 0 to purge them from leaderboards.
        /// </summary>
        [JsonProperty("pp_raw", NullValueHandling = NullValueHandling.Ignore)]
        public double Performance { get; set; }

        /// <summary>
        /// Accuracy that ranges from 0 to 100.
        /// </summary>
        [JsonProperty("accuracy", NullValueHandling = NullValueHandling.Ignore)]
        public double AccuracyPercent { get; set; }

        /// <summary>
        /// Accuracy that ranges from 0 to 1.
        /// </summary>
        [Obsolete("Please use AccuracyFloat.")]
        public double AccuracyRatio => AccuracyFloat;

        /// <summary>
        /// Accuracy that ranges from 0 to 1.
        /// </summary>
        public double AccuracyFloat => AccuracyPercent / 100;

        [JsonProperty("count_rank_ss", NullValueHandling = NullValueHandling.Ignore)]
        public int CountRankSS { get; set; }

        [JsonProperty("count_rank_ssh", NullValueHandling = NullValueHandling.Ignore)]
        public int CountRankSSH { get; set; }

        [JsonProperty("count_rank_s", NullValueHandling = NullValueHandling.Ignore)]
        public int CountRankS { get; set; }

        [JsonProperty("count_rank_sh", NullValueHandling = NullValueHandling.Ignore)]
        public int CountRankSH { get; set; }

        [JsonProperty("count_rank_a", NullValueHandling = NullValueHandling.Ignore)]
        public int CountRankA { get; set; }

        [JsonProperty("country")]
        public string CountryCode { get; set; }

        public string CountryName => Iso3166.CountryOf(CountryCode);

        [JsonProperty("total_seconds_played", NullValueHandling = NullValueHandling.Ignore)]
        public int TotalSecondsPlayed { get; set; }

        public TimeSpan PlayTime => new TimeSpan(0, 0, TotalSecondsPlayed);

        [JsonProperty("pp_country_rank", NullValueHandling = NullValueHandling.Ignore)]
        public int CountryRank { get; set; }

        [JsonProperty("events")]
        public UserEvent[] Events { get; set; }

        public override string ToString()
            => Name;
    }

    public class UserEvent
    {
        [JsonProperty("display_html")]
        public string DisplayHtml { get; set; }

        [JsonProperty("beatmap_id", NullValueHandling = NullValueHandling.Ignore)]
        public int BeatmapId { get; set; }

        [JsonProperty("beatmapset_id", NullValueHandling = NullValueHandling.Ignore)]
        public int BeatmapSetId { get; set; }

        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("epicfactor")]
        public int EpicFactor { get; set; }
    }
}
