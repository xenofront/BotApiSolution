using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BotApi.Models.WebHotelier
{
    public class PropertyInfoModel
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
        public PropertyInfoModelData Data { get; set; }
    }

    public class PropertyInfoModelContact
    {
        [JsonPropertyName("tel")]
        public string Tel { get; set; }

        [JsonPropertyName("fax")]
        public string Fax { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("skype")]
        public string Skype { get; set; }
    }

    public class PropertyInfoModelLocation
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lon")]
        public double Lon { get; set; }

        [JsonPropertyName("utc_offset")]
        public int UtcOffset { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("zip")]
        public string Zip { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }
    }

    public class PropertyInfoModelChildren
    {
        [JsonPropertyName("allowed")]
        public int Allowed { get; set; }

        [JsonPropertyName("age_from")]
        public int AgeFrom { get; set; }

        [JsonPropertyName("age_to")]
        public int AgeTo { get; set; }

        [JsonPropertyName("policy")]
        public string Policy { get; set; }
    }

    public class PropertyInfoModelSettings
    {
        [JsonPropertyName("nights_min")]
        public int NightsMin { get; set; }

        [JsonPropertyName("nights_max")]
        public int NightsMax { get; set; }

        [JsonPropertyName("rooms_max")]
        public int RoomsMax { get; set; }
    }

    public class PropertyInfoModelOperation
    {
        [JsonPropertyName("checkout_time")]
        public string CheckoutTime { get; set; }

        [JsonPropertyName("checkin_time")]
        public string CheckinTime { get; set; }

        [JsonPropertyName("open_from")]
        public string OpenFrom { get; set; }

        [JsonPropertyName("open_to")]
        public string OpenTo { get; set; }
    }

    public class PropertyInfoModelRoom
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class PropertyInfoModelPhoto
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

    public class PropertyInfoModelData
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("general_terms")]
        public string GeneralTerms { get; set; }

        [JsonPropertyName("directions")]
        public string Directions { get; set; }

        [JsonPropertyName("license_number")]
        public string LicenseNumber { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("bookurl")]
        public string Bookurl { get; set; }

        [JsonPropertyName("contact")]
        public PropertyInfoModelContact Contact { get; set; }

        [JsonPropertyName("location")]
        public PropertyInfoModelLocation Location { get; set; }

        [JsonPropertyName("children")]
        public PropertyInfoModelChildren Children { get; set; }

        [JsonPropertyName("settings")]
        public PropertyInfoModelSettings Settings { get; set; }

        [JsonPropertyName("operation")]
        public PropertyInfoModelOperation Operation { get; set; }

        [JsonPropertyName("rooms")]
        public List<PropertyInfoModelRoom> Rooms { get; set; }

        [JsonPropertyName("facilities")]
        public List<string> Facilities { get; set; }

        [JsonPropertyName("photos")]
        public List<PropertyInfoModelPhoto> Photos { get; set; }

        [JsonPropertyName("logourl")]
        public string Logourl { get; set; }
    }
}