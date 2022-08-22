using BotApi.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotApi.Commands.MessageCommands
{
    public class MesseageNotFoundCmd : IBotCommand
    {
        public async void Execute(Update update, TelegramBotClient telegramClient)
        {
            //Todoooooo!!!
            if (update.Type == UpdateType.MyChatMember)
            {
                if (update.MyChatMember.NewChatMember.Status == ChatMemberStatus.Kicked)
                {
                    return;
                }
            }
            else
            {
                var chatId = update.Message.Chat.Id;
                var message = update.Message;

                await telegramClient.SendTextMessageAsync(chatId, $"{message.Chat.FirstName} Message not found");
            }
        }
    }
}
