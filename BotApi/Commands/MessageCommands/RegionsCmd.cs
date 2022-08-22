using System.Collections.Generic;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;
using BotApi.Interfaces;
using BotApi.Helpers;

namespace BotApi.Commands.MessageCommands
{
    public class RegionsCmd : IBotCommand
    {
        public async void Execute(Update update, TelegramBotClient telegramClient)
        {
            var cities = new List<string>() { "Athens", "Thessaloniki", "Larissa", "Piraeus", "Heraklion", "Peristeri", "Acharnes", "Evosmos" };
            var replyKeyboardM = Tel.GetInlineKeybord(cities);
            var message = update.Message;

            await telegramClient.SendTextMessageAsync(message.From.Id, "Выберите регион", replyMarkup: replyKeyboardM);
        }
    }
}
