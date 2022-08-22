using BotApi.Interfaces;
using BotApi.Commands.CallbackQueryCommands;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using BotApi.Commands.MessageCommands;
using System.Text.RegularExpressions;
using BotApi.DB;
using System.Threading.Tasks;
using BotApi.Models;

namespace BotApi.Commands
{
    public class CommandFactory : ICommandFactory
    {
        private readonly BotUserRepository _userRepository = new();

        public async Task<IBotCommand> CreateCommand(Update update)
        {
            string message;

            if (update.Type == UpdateType.Message)
            {
                var user = new BotUser { TelegramUserId = update.Message.From.Id, UserName = update.Message.From.Username };

                await InitializeUser(user);
                message = update.Message.Text;

                return update.Type switch
                {
                    _ when Regex.IsMatch(message, "^hotel\\?", RegexOptions.IgnoreCase) => new PropertySearchCmd(),
                    _ when message == C.Start => new StartCmd(),
                    _ when message == C.Regions => new RegionsCmd(),
                    _ when message == C.Hotels => new HotelsCmd(),
                    _ when message == C.Calendar => new CalendarCmd(),
                    _ when message == C.QuestionRegionOrHotel => new QuestionRegionOrHotelCmd(),
                    _ => new MesseageNotFoundCmd(),
                };
            }

            if (update.Type == UpdateType.CallbackQuery)
            {
                var user = new BotUser { TelegramUserId = update.CallbackQuery.From.Id, UserName = update.CallbackQuery.From.Username };

                await InitializeUser(user);
                message = update.CallbackQuery.Data;

                return update.Type switch
                {
                    _ when Regex.IsMatch(message, "^hotel-pick\\/") => new HotelPickClb(),
                    _ when Regex.IsMatch(message, "^pick-date-from\\/") => new CalendarDateFromClb(),
                    _ when Regex.IsMatch(message, "^pick-pax\\/") => new PickPaxClb(),
                    _ when message.Contains(C.PickDateUntil) => new CalendarDateUntilClb(),
                    _ when message.Contains(C.ChangeMonth) => new CalendarChangeDateClb(),
                    _ when (message.Contains(C.NextYear) || message.Contains(C.PreviousYear)) => new CalendarChangeDateClb(),
                    _ when message == C.NoCommandCell => new CalendarNoCommandCellClb(),
                    _ when message == C.CheckAvailabilityHotel => new CheckAvailabilityHotelClb(),
                    _ => new MessageNotFoundClb(),
                };
            }

            if (update.Type == UpdateType.InlineQuery)
            {
                return new InlineTemp();
            }

            return new MesseageNotFoundCmd();
        }

        private async Task InitializeUser(IBotUser user)
        {
            await _userRepository.FindOrUpdateAsync(user);
        }
    }
}
