using System;
using System.IO;
using System.Threading;
using Newtonsoft.Json;

namespace Bleatingsheep.Osu.ApiClient
{
    internal class ReplayData
    {
        private readonly Lazy<byte[]> _contentBytesLazy;

        public ReplayData()
        {
            _contentBytesLazy = new Lazy<byte[]>(GetContentBytes, LazyThreadSafetyMode.ExecutionAndPublication);
        }

        private byte[] GetContentBytes()
        {
            var compressed = Convert.FromBase64String(Content);
            var compressedStream = new MemoryStream(compressed, false);

            throw new NotImplementedException();
        }

        [JsonProperty("content")]
        public string Content { get; set; }

        /// <summary>
        /// Get uncompressed bytes.
        /// </summary>
        public byte[] ContentBytes => _contentBytesLazy.Value;

        [JsonProperty("encoding")]
        public string Encoding { get; set; }
    }
}