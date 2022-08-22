using BotApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InlineQueryResults;

namespace BotApi.Commands
{
    public class InlineTemp : IBotCommand
    {
        public async void Execute(Update update, TelegramBotClient telegramClient)
        {
            var hotels = new List<string> { "Anthemus", "Sani", "Potidea", "Ikos" };

            //var inlineHotels = Tel.GetInlineKeybord(hotels);

            //var message = update.Message;

            InlineQueryResultBase[] results = {
    new InlineQueryResultArticle(
        // id's should be unique for each type of response
        id: "1",
        // Title of the option
        title: "hotel",
        // This is what is returned
        new InputTextMessageContent("text that is returned") {ParseMode = Telegram.Bot.Types.Enums.ParseMode.Default })
    {
        // This is just the description shown for the option
        Description = "Anthemus"
    },
    new InlineQueryResultArticle(
        // id's should be unique for each type of response
        id: "2",
        // Title of the option
        title: "sample title",
        // This is what is returned
        new InputTextMessageContent("text that is returned") {ParseMode = Telegram.Bot.Types.Enums.ParseMode.Default })
    {
        // This is just the description shown for the option
        Description = "Sani"
    }
};

            await telegramClient.AnswerInlineQueryAsync(update.InlineQuery.Id, results: results);
        }
    }
}
