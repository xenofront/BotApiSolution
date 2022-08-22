using BotApi.Helpers;
using BotApi.Interfaces;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotApi.Commands.CallbackQueryCommands
{
    public class RegionsClb : IBotCommand
    {
        public async void Execute(Update update, TelegramBotClient telegramClient)
        {
            await telegramClient.AnswerCallbackQueryAsync(update.CallbackQuery.Id);

            var hotels = new List<string> { "Anthemus", "Sani", "Potidea", "Ikos" };
            var replyKeyboardM = Tel.GetInlineKeybord(hotels);

            await telegramClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Выберите отель", replyMarkup: replyKeyboardM);
        }
    }
}
