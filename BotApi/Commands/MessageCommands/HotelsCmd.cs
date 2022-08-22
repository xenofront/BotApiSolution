using BotApi.Helpers;
using BotApi.Interfaces;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotApi.Commands.MessageCommands
{
    public class HotelsCmd : IBotCommand
    {
        public async void Execute(Update update, TelegramBotClient telegramClient)
        {
            var hotels = new List<string> { "Anthemus", "Sani", "Potidea", "Ikos" };

            var inlineHotels = Tel.GetInlineKeybord(hotels);

            var message = update.Message;

            await telegramClient.SendTextMessageAsync(message.From.Id, "Выберите отель", replyMarkup: inlineHotels);
        }
    }
}
