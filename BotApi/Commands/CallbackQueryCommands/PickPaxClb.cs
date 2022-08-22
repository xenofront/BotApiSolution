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
    public class PickPaxClb : IBotCommand
    {
        private readonly ReservationRepository _reservationRepository = new();
        private static readonly BotUserRepository _userRepository = new();

        private static readonly string _pattern = new Regex("^pick-pax\\/(.*)").ToString();

        public async void Execute(Update update, TelegramBotClient telegramClient)
        {
            await telegramClient.AnswerCallbackQueryAsync(update.CallbackQuery.Id);

            var message = update.CallbackQuery.Data;
            var pax = Tel.ExtractTextFromRegexByGroup(message, _pattern, 1);

            var userObjId = await _userRepository.GetUserId(update.CallbackQuery.From.Id);

            var record = new ReservationModel
            {
                User = userObjId,
                Pax = 100
            };

            await _reservationRepository.UpsertOneAsync(record, userObjId);

            var doc = await _reservationRepository.GetOneAsync(userObjId);

            var text = @$"Вы выбрали отель {doc.Hotel}.
Даты проживания {doc.DateFrom:dd/MM/yy}-{doc.DateUntil:dd/MM/yy} -> {doc.Pax}";

            await telegramClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, text);
        }
    }
}
