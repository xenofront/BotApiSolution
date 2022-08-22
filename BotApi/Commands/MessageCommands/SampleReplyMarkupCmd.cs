using BotApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotApi.Commands.MessageCommands
{
    public class SampleReplyMarkupCmd : IBotCommand
    {
        public async void Execute(Update update, TelegramBotClient telegramClient)
        {
            var cities = new List<string>() { "Athens", "Thessaloniki", "Larissa", "Piraeus", "Heraklion", "Peristeri", "Acharnes", "Evosmos" };

            var rows = new List<InlineKeyboardButton[]>();
            var cols = new List<InlineKeyboardButton>();

            int index = 0;
            foreach (var city in cities)
            {
                index++;
                cols.Add(InlineKeyboardButton.WithCallbackData(city, city));

                if (index % 3 != 0)
                    continue;

                rows.Add(cols.ToArray());
                cols = new List<InlineKeyboardButton>();
            }

            var replyKeyboardM = new InlineKeyboardMarkup(rows.ToArray());
            var message = update.Message;

            await telegramClient.SendTextMessageAsync(message.From.Id, "Please choose next options", replyMarkup: replyKeyboardM);
        }
    }
}