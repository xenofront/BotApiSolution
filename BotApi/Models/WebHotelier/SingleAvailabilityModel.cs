using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BotApi.Models.WebHotelier
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class SingleAvailabilityParam
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class SingleAvailabilityUrl
    {
        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("info")]
        public string Info { get; set; }

        [JsonPropertyName("engine")]
        public string Engine { get; set; }

        [JsonPropertyName("photo")]
        public string Photo { get; set; }

        [JsonPropertyName("photoM")]
        public string PhotoM { get; set; }

        [JsonPropertyName("photoL")]
        public string PhotoL { get; set; }

        [JsonPropertyName("rate")]
        public string Rate { get; set; }

        [JsonPropertyName("room")]
        public string Room { get; set; }
    }

    public class SingleAvailabilityLocation
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lon")]
        public double Lon { get; set; }
    }

    public class SingleAvailabilityPricing
    {
        [JsonPropertyName("stay")]
        public double Stay { get; set; }

        [JsonPropertyName("extras")]
        public int Extras { get; set; }

        [JsonPropertyName("taxes")]
        public int Taxes { get; set; }

        [JsonPropertyName("excluded_charges")]
        public int ExcludedCharges { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("margin")]
        public double Margin { get; set; }
    }

    public class SingleAvailabilityRetail
    {
        [JsonPropertyName("stay")]
        public int Stay { get; set; }

        [JsonPropertyName("extras")]
        public int Extras { get; set; }

        [JsonPropertyName("taxes")]
        public int Taxes { get; set; }

        [JsonPropertyName("excluded_charges")]
        public int ExcludedCharges { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }

        [JsonPropertyName("discount")]
        public int Discount { get; set; }
    }

    public class SingleAvailabilityPayment
    {
        [JsonPropertyName("due")]
        public DateTime Due { get; set; }

        [JsonPropertyName("amount")]
        public double Amount { get; set; }
    }

    public class SingleAvailabilityCancellationFee
    {
        [JsonPropertyName("after")]
        public DateTime After { get; set; }

        [JsonPropertyName("fee")]
        public double Fee { get; set; }
    }

    public class SingleAvailabilityRate
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("room")]
        public string Room { get; set; }

        [JsonPropertyName("rate")]
        public string Rate { get; set; }

        [JsonPropertyName("rate_desc")]
        public string RateDesc { get; set; }

        [JsonPropertyName("payment_policy")]
        public string PaymentPolicy { get; set; }

        [JsonPropertyName("payment_policy_id")]
        public int PaymentPolicyId { get; set; }

        [JsonPropertyName("cancellation_policy")]
        public string CancellationPolicy { get; set; }

        [JsonPropertyName("cancellation_policy_id")]
        public int CancellationPolicyId { get; set; }

        [JsonPropertyName("cancellation_penalty")]
        public string CancellationPenalty { get; set; }

        [JsonPropertyName("remaining")]
        public int Remaining { get; set; }

        [JsonPropertyName("min_stay")]
        public int MinStay { get; set; }

        [JsonPropertyName("cancellation_expiry")]
        public object CancellationExpiry { get; set; }

        [JsonPropertyName("board")]
        public int Board { get; set; }

        [JsonPropertyName("url")]
        public SingleAvailabilityUrl Url { get; set; }

        [JsonPropertyName("pricing")]
        public SingleAvailabilityPricing Pricing { get; set; }

        [JsonPropertyName("retail")]
        public SingleAvailabilityRetail Retail { get; set; }

        [JsonPropertyName("payments")]
        public List<SingleAvailabilityPayment> Payments { get; set; }

        [JsonPropertyName("cancellation_fees")]
        public List<SingleAvailabilityCancellationFee> CancellationFees { get; set; }
    }

    public class SingleAvailabilityData
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("url")]
        public SingleAvailabilityUrl Url { get; set; }

        [JsonPropertyName("location")]
        public SingleAvailabilityLocation Location { get; set; }

        [JsonPropertyName("rates")]
        public List<SingleAvailabilityRate> Rates { get; set; }
    }

    public class SingleAvailability
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
        public List<SingleAvailabilityParam> Params { get; set; }

        [JsonPropertyName("data")]
        public SingleAvailabilityData Data { get; set; }
    }

    public class SingleAvailabilityPostObject
    {
        public string Code { get; set; }
        public string Checkin { get; set; }
        public int Nights { get; set; }
        public string Checkout { get; set; }
        public string Location { get; set; }
        public int Rooms { get; set; }
        public int Adults { get; set; }
        public int Children { get; set; }
        public int Infants { get; set; }
    }
}
