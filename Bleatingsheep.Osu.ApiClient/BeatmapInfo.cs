using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Bleatingsheep.Osu.ApiClient
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BeatmapInfo
    {
        [JsonProperty("beatmapset_id")]
        public int SetId { get; set; }

        [JsonProperty("beatmap_id")]
        public int Id { get; set; }

        [JsonProperty("approved")]
        public Approved Approved { get; set; }

        /// <summary>
        /// Seconds from first note to last note including breaks.
        /// </summary>
        [JsonProperty("total_length")]
        public int TotalLength { get; set; }

        /// <summary>
        /// Seconds from first note to last note not including breaks.
        /// </summary>
        [JsonProperty("hit_length")]
        public int HitLength { get; set; }

        [JsonProperty("version")]
        public string DifficultyName { get; set; }

        [JsonProperty("file_md5")]
        public string FileMd5 { get; set; }

        /// <summary>
        /// CS.
        /// </summary>
        [JsonProperty("diff_size", NullValueHandling = NullValueHandling.Ignore)]
        public double DiffCircleSize { get; set; }

        /// <summary>
        /// OD.
        /// </summary>
        [JsonProperty("diff_overall", NullValueHandling = NullValueHandling.Ignore)]
        public double DiffOverallDifficulty { get; set; }

        /// <summary>
        /// AR.
        /// </summary>
        [JsonProperty("diff_approach", NullValueHandling = NullValueHandling.Ignore)]
        public double DiffApproachRate { get; set; }

        /// <summary>
        /// HP.
        /// </summary>
        [JsonProperty("diff_drain", NullValueHandling = NullValueHandling.Ignore)]
        public double DiffHPDrain { get; set; }

        [JsonProperty("mode")]
        public Mode Mode { get; set; }

        [JsonProperty("count_normal")]
        public int CountNormal { get; set; }

        [JsonProperty("count_slider")]
        public int CountSlider { get; set; }

        [JsonProperty("count_spinner")]
        public int CountSpinner { get; set; }

        [JsonProperty("submit_date")]
        public DateTime SubmitDate { get; set; }

        [JsonProperty("approved_date")]
        public DateTime? ApprovedDate { get; set; }

        /// <summary>
        /// May be after approved_date if map was unranked and reranked.
        /// </summary>
        [JsonProperty("last_update")]
        public DateTime LastUpdate { get; set; }

        [JsonProperty("artist")]
        public string Artist { get; set; }

        /// <summary>
        /// Song name.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("creator")]
        public string Creator { get; set; }

        [JsonProperty("creator_id")]
        public int CreatorId { get; set; }

        [JsonProperty("bpm", NullValueHandling = NullValueHandling.Ignore)]
        public double Bpm { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("genre_id")]
        public Genre Genre { get; set; }

        [JsonProperty("language_id")]
        public Language Language { get; set; }

        [JsonProperty("favourite_count")]
        public long FavouriteCount { get; set; }

        [JsonProperty("rating", NullValueHandling = NullValueHandling.Ignore)]
        public double Rating { get; set; }

        [JsonProperty("download_unavailable")]
        private int _downloadUnavailable;

        public bool DownloadUnavailable
        {
            get => Convert.ToBoolean(_downloadUnavailable);
            set => _downloadUnavailable = Convert.ToInt32(value);
        }

        [JsonProperty("audio_unavailable")]
        private int _audioUnavailable;

        public bool AudioUnavailable
        {
            get => Convert.ToBoolean(_audioUnavailable);
            set => _audioUnavailable = Convert.ToInt32(value);
        }

        [JsonProperty("playcount")]
        public long PlayCount { get; set; }

        [JsonProperty("passcount")]
        public long PassCount { get; set; }

        /// <summary>
        /// Only exists in osu! and osu!catch.
        /// </summary>
        [JsonProperty("max_combo", NullValueHandling = NullValueHandling.Ignore)]
        public int MaxCombo { get; set; }

        /// <summary>
        /// Only exists in osu! and osu!catch
        /// </summary>
        [JsonProperty("diff_aim", NullValueHandling = NullValueHandling.Ignore)]
        public double DiffAim { get; set; }

        /// <summary>
        /// Only exists in osu!.
        /// </summary>
        [JsonProperty("diff_speed", NullValueHandling = NullValueHandling.Ignore)]
        public double DiffSpeed { get; set; }

        [JsonProperty("difficultyrating", NullValueHandling = NullValueHandling.Ignore)]
        public double Stars { get; set; }

        public override string ToString()
            => $"{Artist} - {Title} [{DifficultyName}]({Creator})";
    }
}
