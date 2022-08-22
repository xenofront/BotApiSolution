using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BotApi.Models.WebHotelier
{
    public class RoomInfoModelCapacity
    {
        [JsonPropertyName("min_pers")]
        public int MinPers { get; set; }

        [JsonPropertyName("max_pers")]
        public int MaxPers { get; set; }

        [JsonPropertyName("max_adults")]
        public int MaxAdults { get; set; }

        [JsonPropertyName("max_infants")]
        public int MaxInfants { get; set; }

        [JsonPropertyName("children_allowed")]
        public bool ChildrenAllowed { get; set; }
    }

    public class RoomInfoModelPhoto
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("xsmall")]
        public string Xsmall { get; set; }

        [JsonPropertyName("small")]
        public string Small { get; set; }

        [JsonPropertyName("medium")]
        public string Medium { get; set; }

        [JsonPropertyName("large")]
        public string Large { get; set; }
    }

    public class RoomInfoModelData
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("unit_type")]
        public string UnitType { get; set; }

        [JsonPropertyName("license_number")]
        public object LicenseNumber { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("sort_order")]
        public int SortOrder { get; set; }

        [JsonPropertyName("capacity")]
        public RoomInfoModelCapacity Capacity { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("amenities")]
        public List<string> Amenities { get; set; }

        [JsonPropertyName("photos")]
        public List<RoomInfoModelPhoto> Photos { get; set; }
    }

    public class RoomInfo
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
        public List<object> Params { get; set; }

        [JsonPropertyName("data")]
        public RoomInfoModelData Data { get; set; }
    }
}
