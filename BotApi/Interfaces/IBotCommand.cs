using BotApi.Commands.MessageCommands;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotApi.Interfaces
{
    public interface IBotCommand
    {
        void Execute(Update update, TelegramBotClient telegramClient);
    }
}
