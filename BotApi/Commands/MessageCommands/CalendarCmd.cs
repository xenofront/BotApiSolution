using BotApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using Telegram.Bot;
using Telegram.Bot.Types;
using BotApi.Helpers;

namespace BotApi.Commands.MessageCommands
{
    public class CalendarCmd : IBotCommand
    {
        public async void Execute(Update update, TelegramBotClient telegramClient)
        {
            var message = update.Message;

            var calendar = Helpers.Calendar.GetCalendar(DateTime.Now);

            await telegramClient.SendTextMessageAsync(message.From.Id, "Выберите дату", replyMarkup: calendar);
        }
    }
}
