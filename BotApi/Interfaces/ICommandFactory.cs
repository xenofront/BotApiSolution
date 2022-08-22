using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace BotApi.Interfaces
{
    public interface ICommandFactory
    {
        Task<IBotCommand> CreateCommand(Update update);
    }
}
