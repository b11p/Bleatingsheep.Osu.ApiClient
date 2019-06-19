using System;
using Newtonsoft.Json;

namespace Bleatingsheep.Osu.ApiClient
{
    [JsonObject(MemberSerialization.OptIn)]
    public class UserBest
    {
        [JsonProperty("beatmap_id")]
        public int BeatmapId { get; set; }

        [JsonProperty("score_id")]
        public long ScoreId { get; set; }

        [JsonProperty("score")]
        public long Score { get; set; }

        [JsonProperty("maxcombo")]
        public int MaxCombo { get; set; }

        [JsonProperty("count50")]
        public int Count50 { get; set; }

        [JsonProperty("count100")]
        public int Count100 { get; set; }

        [JsonProperty("count300")]
        public int Count300 { get; set; }

        [JsonProperty("countmiss")]
        public int CountMiss { get; set; }

        [JsonProperty("countkatu")]
        public int CountKatu { get; set; }

        [JsonProperty("countgeki")]
        public int CountGeki { get; set; }

        [JsonProperty("perfect")]
        private int _perfect;

        /// <summary>
        /// Maximum combo of map reached.
        /// </summary>
        public bool Perfect
        {
            get => Convert.ToBoolean(_perfect);
            set => _perfect = Convert.ToInt32(value);
        }

        [JsonProperty("enabled_mods")]
        public Mods EnabledMods { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("rank")]
        public string Rank { get; set; }

        [JsonProperty("pp")]
        public double Performance { get; set; }
    }
}