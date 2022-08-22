using BotApi.Helpers;
using BotApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotApi.Commands.CallbackQueryCommands
{
    public class CalendarNoCommandCellClb : IBotCommand
    {
        public async void Execute(Update update, TelegramBotClient telegramClient)
        {
            await telegramClient.AnswerCallbackQueryAsync(update.CallbackQuery.Id);

            await telegramClient.DeleteMessageAsync(update.CallbackQuery.Message.Chat.Id, update.CallbackQuery.Message.MessageId);

            //Todo if user has chosen "from" date
            var calendar = Calendar.GetCalendar(DateTime.Now);

            await telegramClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Необходимо выбрать верную дату", replyMarkup: calendar);
        }
    }
}
