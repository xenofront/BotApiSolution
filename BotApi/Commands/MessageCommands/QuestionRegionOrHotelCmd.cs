using BotApi.Helpers;
using BotApi.Interfaces;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotApi.Commands.MessageCommands
{
    public class QuestionRegionOrHotelCmd : IBotCommand
    {
        public async void Execute(Update update, TelegramBotClient telegramClient)
        {
            var questionsDictionary = new Dictionary<string, string>
            {
                { "Отелю", C.CheckAvailabilityHotel }, { "Региону", C.CheckAvailabilityRegion }
            };

            var replyKeyboardM = Tel.GetInlineKeybordByDictionary(questionsDictionary, columns: 2);
            var message = update.Message;

            await telegramClient.SendTextMessageAsync(message.From.Id, "Проверить наличие по", replyMarkup: replyKeyboardM);
        }
    }
}
