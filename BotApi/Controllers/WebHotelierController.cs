using BotApi.Models.WebHotelier;
using BotApi.Services.WebHotelier;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web;

namespace BotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebHotelierController : ControllerBase
    {
        private const string _webHotelier = "webHotelier";
        private readonly IHttpClientFactory _httpClientFactory;
        private string url = new Uri(new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build()
            .GetValue<string>("WebHotelierApi:Uri"))
            .ToString();
        public WebHotelierController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("properties")]
        public async Task<ActionResult> GetProperties(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return null;
            }

            var client = _httpClientFactory.CreateClient(_webHotelier);

            try
            {
                var propertyModel = await client.GetFromJsonAsync<PropertyModel>($"property?name={propertyName}");

                if (propertyModel.Data is null)
                {
                    return NotFound();
                }

                var result = propertyModel.Data.Hotels.ToList();

                return Ok(result);
            }
            catch (Exception)
            {
                //TODO 
                throw;
            }
        }

        [HttpGet]
        [Route("roomlistring")]
        public async Task<RoomListingModel> GetRoomListing(string propertyCode)
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

        [HttpGet]
        [Route("propertyinfo")]
        public async Task<ActionResult> GetPropertyInfo(string propertyCode)
        {
            //TODO 
            if (string.IsNullOrEmpty(propertyCode))
            {
                return null;
            }

            var client = _httpClientFactory.CreateClient(_webHotelier);

            try
            {
                var result = await client.GetFromJsonAsync<PropertyInfoModel>($"property/{propertyCode}");

                if (result.Data is null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("roomInfo")]
        public async Task<ActionResult> GetRoomInfo(string hotelCode, string roomId)
        {

            //TODO 
            if (string.IsNullOrEmpty(roomId) || string.IsNullOrEmpty(hotelCode))
            {
                return null;
            }

            var client = _httpClientFactory.CreateClient(_webHotelier);

            try
            {
                var result = await client.GetFromJsonAsync<RoomInfo>($"room/{hotelCode}/{roomId}");

                if (result.Data is null)
                {
                    return NotFound();
                }

                return Ok(result.Data);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("availabilityinfo")]
        public async Task<ActionResult> AvailabilityRequest(SingleAvailabilityPostObject availRequest)
        {
            //TODO 
            if (availRequest is null)
            {
                return null;
            }

            url += "availability/" + availRequest.Code;

            Dictionary<string, string> parameters = new()
            {
                { "checkin", availRequest.Checkin },
                { "checkout", availRequest.Checkout },
                { "nights", availRequest.Nights.ToString() },
                { "rooms", availRequest.Rooms.ToString() },
                { "adults", availRequest.Adults.ToString() },
                { "children", availRequest.Children.ToString() },
                { "location", availRequest.Location.ToString() },
                { "infants", availRequest.Infants.ToString() },
            };

            var newUrl = new Uri(QueryHelpers.AddQueryString(url, parameters));

            var client = _httpClientFactory.CreateClient(_webHotelier);

            try
            {
                /// availability / MAKEDONIAP ? checkin = 2021 - 09 - 15 & nights = 3
                var result = await client.GetFromJsonAsync<SingleAvailability>(newUrl);

                if (result.Data is null)
                {
                    return NotFound();
                }

                return Ok(result.Data.Rates.ToList());
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
