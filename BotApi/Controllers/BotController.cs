using BotApi.Interfaces;
using BotApi.Commands;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BotApi.Controllers
{
    [ApiController]
    [Route("api/bot")]
    public class BotController : ControllerBase
    {
        private readonly ICommandFactory _commandFactory;
        private readonly IConfiguration _config;

        public BotController(ICommandFactory commandFactory, IConfiguration config)
        {
            _commandFactory = commandFactory;
            _config = config;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            TelegramBotClient telegramClient = new(_config.GetValue<string>("Telegram:Token"));

            await _commandFactory.CreateCommand(update).ContinueWith(t => t.Result.Execute(update, telegramClient));

            //var hook = string.Format("https://ce9ddcf5a063.ngrok.io/api/bot");
            //await client.SetWebhookAsync(hook);
            return Ok();
        }
    }
}
