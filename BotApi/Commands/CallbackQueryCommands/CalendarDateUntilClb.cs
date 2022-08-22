using BotApi.Helpers;
using BotApi.Interfaces;
using BotApi.Models;
using BotApi.DB;
using System;
using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Collections.Generic;
using BotApi.Services;
using BotApi.Models.WebHotelier;

namespace BotApi.Commands.CallbackQueryCommands
{
    public class CalendarDateUntilClb : IBotCommand
    {
        private readonly ReservationRepository _reservationRepository = new();
        private static readonly BotUserRepository _userRepository = new();

        private static readonly string _pattern = new Regex("^pick-date-until\\/(.*)").ToString();

        public async void Execute(Update update, TelegramBotClient telegramClient)
        {
            await telegramClient.AnswerCallbackQueryAsync(update.CallbackQuery.Id);

            var message = update.CallbackQuery.Data;
            var dateUntil = Tel.ExtractTextFromRegexByGroup(message, _pattern, 1);

            var userId = await _userRepository.GetUserId(update.CallbackQuery.From.Id);

            var record = new ReservationModel
            {
                DateUntil = DateTime.Parse(dateUntil),
                User = userId
            };

            await _reservationRepository.UpsertOneAsync(record, userId);

            var doc = await _reservationRepository.FindOneAsync(userId);
            var roomListing = await WebHotelierService.GetRoomListing(doc.HotelCode);

            var paxCombinations = new List<RoomListingModelRoom>();

            foreach (var r in roomListing.Data.Rooms)
            {
                var s = new RoomListingModelRoom
                {
                    Active = r.Active,
                    Code = r.Code,
                    Name = r.Name,
                    UnitType = r.UnitType,
                    Amenities = r.Amenities,
                    LicenseNumber = r.LicenseNumber,
                    Photos = r.Photos,
                    SortOrder = r.SortOrder,
                    Capacity = new RoomListingModelCapacity
                    {
                        ChildrenAllowed = r.Capacity.ChildrenAllowed,
                        MaxInfants = r.Capacity.MaxInfants,
                        MinPers = r.Capacity.MinPers,
                        MaxAdults = r.Capacity.MaxAdults,
                        MaxPers = r.Capacity.MaxPers
                    },
                    Description = r.Description
                };

                paxCombinations.Add(s);
            }

            var paxInlineKeyboardM = Tel.GetInlineKeyboardPax(paxCombinations, callbackMessage: C.PickPax);

            var text = $@"<b>Please choose next options</b>" + Environment.NewLine;

            foreach (var r in paxCombinations)
            {
                //string description = Tel.GetTextFromHtml(r.Description);

                text += $@"{Environment.NewLine}{Emojis.SmallDiamond} <b>{r.Name}</b>
Мин размещение {r.Capacity.MinPers}
Макс размещение {r.Capacity.MaxPers}";
            }

            await telegramClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, text, parseMode: Telegram.Bot.Types.Enums.ParseMode.Html);
        }
    }
}

//< b > bold </ b > 
//    < strong > bold </ strong >
//      < i > italic </ i >
//      < em > italic </ em >
//            < u > underline </ u >
//            < ins > underline </ ins >
//                  < s > strikethrough </ s >
//                  < strike > strikethrough </ strike >
//                  < del > strikethrough </ del >

//<a href="http://www.example.com/">inline URL</a>
//<a href="tg://user?id=123456789">inline mention of a user</a>
//<code>inline fixed-width code</code>
//<pre>pre-formatted fixed-width code block</pre>
//<pre><code class= "language-python" > pre - formatted fixed-width code block written in the Python programming language </ code ></ pre >