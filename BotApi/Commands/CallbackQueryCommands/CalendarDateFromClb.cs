using BotApi.DB;
using BotApi.Helpers;
using BotApi.Interfaces;
using BotApi.Models;
using System;
using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotApi.Commands.CallbackQueryCommands
{
    public class CalendarDateFromClb : IBotCommand
    {
        private readonly ReservationRepository _reservationRepository = new();
        private static readonly BotUserRepository _userRepository = new();

        private static readonly string _pattern = new Regex("^pick-date-from\\/(.*)").ToString();
        public async void Execute(Update update, TelegramBotClient telegramClient)
        {
            await telegramClient.AnswerCallbackQueryAsync(update.CallbackQuery.Id);

            var message = update.CallbackQuery.Data;
            var dateFrom = Tel.ExtractTextFromRegexByGroup(message, _pattern, 1);

            var userObjId = await _userRepository.GetUserId(update.CallbackQuery.From.Id);

            var record = new ReservationModel
            {
                DateFrom = DateTime.Parse(dateFrom),
                User = userObjId
            };

            await _reservationRepository.UpsertOneAsync(record, userObjId);

            var calendar = Calendar.GetCalendar(DateTime.Now, dateFromOrDateUntil: C.PickDateUntil);

            await telegramClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Выберите дату выезда", replyMarkup: calendar);
        }
    }
}
