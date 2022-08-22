using BotApi.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace BotApi.Commands.CallbackQueryCommands
{
    public class CheckAvailabilityHotelClb : IBotCommand
    {
        public async void Execute(Update update, TelegramBotClient telegramClient)
        {
            await telegramClient.AnswerCallbackQueryAsync(update.CallbackQuery.Id);

            var text = "Для проверки наличия напишите комманду \"hotel?\" и потом интересуемый отель. Т.е. hotel? Makedonia Palace";

            await telegramClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, text);
        }
    }
}
