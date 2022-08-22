using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BotApi.Services.WebHotelier
{
    public class PropertyModel
    {
        [JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonPropertyName("http_method")]
        public string HttpMethod { get; set; }

        [JsonPropertyName("http_code")]
        public int HttpCode { get; set; }

        [JsonPropertyName("error_code")]
        public string ErrorCode { get; set; }

        [JsonPropertyName("error_msg")]
        public string ErrorMsg { get; set; }

        [JsonPropertyName("params")]
        public List<PropertyModelParam> Params { get; set; }

        [JsonPropertyName("data")]
        public PropertyModelData Data { get; set; }
    }

    public class PropertyModelParam
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class PropertyModelLocation
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lon")]
        public double Lon { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
    }

    public class PropertyModelHotel
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("infourl")]
        public string Infourl { get; set; }

        [JsonPropertyName("bookurl")]
        public string Bookurl { get; set; }

        [JsonPropertyName("photo")]
        public string Photo { get; set; }

        [JsonPropertyName("distance")]
        public int Distance { get; set; }

        [JsonPropertyName("location")]
        public PropertyModelLocation Location { get; set; }
    }

    public class PropertyModelData
    {
        [JsonPropertyName("hotels")]
        public List<PropertyModelHotel> Hotels { get; set; }
    }
}