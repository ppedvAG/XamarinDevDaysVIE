using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WosIsDes.Models
{
    // https://azure.microsoft.com/de-de/try/cognitive-services/
    // https://azure.microsoft.com/en-us/services/cognitive-services/computer-vision/
    public class AnalyzedImage
    {
        [JsonProperty("categories")]
        public Category[] Categories { get; set; }
        [JsonProperty("adult")]
        public Adult Adult { get; set; }
        [JsonProperty("tags")]
        public Tag[] Tags { get; set; }
        [JsonProperty("description")]
        public Description Description { get; set; }
        [JsonProperty("requestId")]
        public string RequestId { get; set; }
        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }
    }

    public class Adult
    {
        [JsonProperty("isAdultContent")]
        public bool IsAdultContent { get; set; }
        [JsonProperty("isRacyContent")]
        public bool IsRacyContent { get; set; }
        [JsonProperty("adultScore")]
        public float AdultScore { get; set; }
        [JsonProperty("racyScore")]
        public float RacyScore { get; set; }
    }

    public class Description
    {
        [JsonProperty("tags")]
        public string[] Tags { get; set; }
        [JsonProperty("captions")]
        public Caption[] Captions { get; set; }
    }

    public class Caption
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("confidence")]
        public float Confidence { get; set; }
    }

    public class Metadata
    {
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("format")]
        public string Format { get; set; }
    }

    public class Category
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("score")]
        public float Score { get; set; }
    }

    public class Tag
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("confidence")]
        public float Confidence { get; set; }
    }
}
