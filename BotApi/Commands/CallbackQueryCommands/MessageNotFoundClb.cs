using BotApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotApi.Commands.CallbackQueryCommands
{
    public class MessageNotFoundClb : IBotCommand
    {
        public async void Execute(Update update, TelegramBotClient telegramClient)
        {
            await telegramClient.AnswerCallbackQueryAsync(update.CallbackQuery.Id);

            var text = "Not found callback";

            await telegramClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, text);
        }
    }
}
