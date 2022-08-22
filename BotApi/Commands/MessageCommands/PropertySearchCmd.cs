using BotApi.Helpers;
using BotApi.Interfaces;
using BotApi.Services;
using System.Text.RegularExpressions;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotApi.Commands.MessageCommands
{
    public class PropertySearchCmd : IBotCommand
    {
        private static readonly string _pattern = new Regex("hotel\\?(.*)").ToString();
        public async void Execute(Update update, TelegramBotClient telegramClient)
        {
            var properties = Tel.ExtractTextFromRegexByGroup(update.Message.Text, _pattern, 1);

            var hotels = await WebHotelierService.GetProperties(properties);
            var message = update.Message;

            if (hotels is null || hotels.Data is null)
            {
                await telegramClient.SendTextMessageAsync(message.From.Id, "Отель не найден");
                return;
            }

            var replyKeyboardM = Tel.GetInlineKeyboard(hotels, 2);

            await telegramClient.SendTextMessageAsync(message.From.Id, "Выберите отель", replyMarkup: replyKeyboardM);
        }
    }
}