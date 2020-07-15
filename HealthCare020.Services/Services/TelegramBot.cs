using System;
using System.Threading.Tasks;
using HealthCare020.Services.Configuration;
using HealthCare020.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace HealthCare020.Services.Services
{
    public class TelegramBot : ITelegramBot
    {
        private readonly TelegramBotClient _bot;
        private readonly ChatId GROUP_CHAT_ID;

        public TelegramBot(IOptions<ServicesConfiguration> options, IWebHostEnvironment env)
        {
            GROUP_CHAT_ID = new ChatId(env.IsDevelopment()
                ? options.Value.TelegramBot.ChatId
                : Environment.GetEnvironmentVariable("AZURE_TelegramBot_ChatId"));
            if (env.IsDevelopment())
            {
                _bot = new TelegramBotClient(options.Value.TelegramBot.Token);
            }
            else
            {
                _bot = new TelegramBotClient(options.Value.TelegramBot.Token);

                //_bot = new TelegramBotClient(Environment.GetEnvironmentVariable("AZURE_TelegramBot_Token"));
            }
        }

        public async Task SendMessageAsync(string message)
        {
            if (string.IsNullOrEmpty(message))
                return;

            await _bot.SendTextMessageAsync(GROUP_CHAT_ID,message);
        }
    }
}