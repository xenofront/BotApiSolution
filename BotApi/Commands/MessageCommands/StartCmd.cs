using BotApi.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotApi.Commands.MessageCommands
{
    public class StartCmd : IBotCommand
    {
        public async void Execute(Update update, TelegramBotClient telegramClient)
        {
            var chatId = update.Message.Chat.Id;
            var message = update.Message;

            var txt = $"Привет, {message.Chat.FirstName}\n" +
                      $"Начало {C.Start}\n" +
                      $"Выбрать регион {C.Regions}\n" +
                      $"Выбрать отель {C.Hotels}\n";

            await telegramClient.SendTextMessageAsync(chatId, txt);
        }
    }
}
