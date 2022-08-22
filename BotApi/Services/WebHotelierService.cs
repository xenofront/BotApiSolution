using BotApi.Models.WebHotelier;
using BotApi.Services.WebHotelier;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BotApi.Services
{
    public static class WebHotelierService
    {
        private const string _webHotelier = "webHotelier";
        private static readonly IConfigurationRoot _config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        private static readonly IHttpClientBuilder _httpClientBuilder = new ServiceCollection().AddHttpClient(_webHotelier, c =>
        {
            c.BaseAddress = new Uri(_config.GetValue<string>("WebHotelierApi:Uri"));
            c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", _config.GetValue<string>("WebHotelierApi:Secret"));
            c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        });
        private static readonly IHttpClientFactory _httpClientFactory = _httpClientBuilder.Services.BuildServiceProvider().GetRequiredService<IHttpClientFactory>();

        public static async Task<PropertyModel> GetProperties(string propertyName)
        {
            var client = _httpClientFactory.CreateClient(_webHotelier);

            //TODO 
            if (string.IsNullOrEmpty(propertyName))
            {
                return null;
            }

            try
            {
                return await client.GetFromJsonAsync<PropertyModel>($"property?name={propertyName}");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<RoomListingModel> GetRoomListing(string propertyCode)
        {
            var client = _httpClientFactory.CreateClient(_webHotelier);

            //TODO 
            if (string.IsNullOrEmpty(propertyCode))
            {
                return null;
            }

            try
            {
                return await client.GetFromJsonAsync<RoomListingModel>($"room/{propertyCode}");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<PropertyInfoModel> GetPropertyInfo(string propertyCode)
        {
            var client = _httpClientFactory.CreateClient(_webHotelier);

            //TODO 
            if (string.IsNullOrEmpty(propertyCode))
            {
                return null;
            }

            try
            {
                return await client.GetFromJsonAsync<PropertyInfoModel>($"property/{propertyCode}");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}


