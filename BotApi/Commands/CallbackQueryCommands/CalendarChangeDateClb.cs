using BotApi.Helpers;
using BotApi.Interfaces;
using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotApi.Commands.CallbackQueryCommands
{
    public class CalendarChangeDateClb : IBotCommand
    {
        public async void Execute(Update update, TelegramBotClient telegramClient)
        {
            var callbackQuery = update.CallbackQuery;

            try
            {
                await telegramClient.AnswerCallbackQueryAsync(callbackQuery.Id);
            }
            catch (Exception)
            {
                await telegramClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "Try again 'catch'");
            }

            DateTime date = DateTime.Now;
            if (callbackQuery.Data.Contains(C.ChangeMonth))
            {
                date = Convert.ToDateTime(Tel.TakeTextAfter(callbackQuery.Data, C.ChangeMonth));
            }
            if (callbackQuery.Data.Contains(C.NextYear))
            {
                date = Convert.ToDateTime(Tel.TakeTextAfter(callbackQuery.Data, C.NextYear)).AddYears(1);
            }
            if (callbackQuery.Data.Contains(C.PreviousYear))
            {
                date = Convert.ToDateTime(Tel.TakeTextAfter(callbackQuery.Data, C.PreviousYear)).AddYears(-1);
            }

            await telegramClient.DeleteMessageAsync(callbackQuery.Message.Chat.Id, callbackQuery.Message.MessageId);

            var calendar = Calendar.GetCalendar(date);

            await telegramClient.SendTextMessageAsync(callbackQuery.Message.Chat.Id, "variable for 'from/to'", replyMarkup: calendar);
        }
    }
}
