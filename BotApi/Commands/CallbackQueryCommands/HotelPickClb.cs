using BotApi.Helpers;
using BotApi.Interfaces;
using BotApi.Models;
using BotApi.DB;
using System;
using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotApi.Commands.CallbackQueryCommands
{
    public class HotelPickClb : IBotCommand
    {
        private readonly ReservationRepository _reservationRepository = new();
        private readonly BotUserRepository _userRepository = new();
        private static readonly string _pattern = new Regex("(^hotel-pick\\/)(.*):(.*)").ToString();

        public async void Execute(Update update, TelegramBotClient telegramClient)
        {
            //TODO query is too old
            await telegramClient.AnswerCallbackQueryAsync(update.CallbackQuery.Id);

            var message = update.CallbackQuery.Data;

            var chosenHotel = Tel.ExtractTextFromRegexByGroup(message, _pattern, 2);
            var hotelCode = Tel.ExtractTextFromRegexByGroup(message, _pattern, 3);

            var userObjId = await _userRepository.GetUserId(update.CallbackQuery.From.Id);

            var record = new ReservationModel
            {
                Hotel = chosenHotel,
                HotelCode = hotelCode,
                User = userObjId,
            };

            await _reservationRepository.UpsertOneAsync(record, userObjId);

            var calendar = Calendar.GetCalendar(DateTime.Now, dateFromOrDateUntil: C.PickDateFrom);

            await telegramClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Выберите дату заезда", replyMarkup: calendar);
        }
    }
}
