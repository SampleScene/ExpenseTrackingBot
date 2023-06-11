using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;

namespace ExpenseTrackingBot.TelegramBot
{
    public class TelegramBot
    {
        private TelegramBotClient _botClient;
        private string _token  = "5642020284:AAF2ea2zqGMpq_DPHpzH7k7Prv1sI9yfkG8";
        
        public TelegramBot()
        {
            _botClient = new TelegramBotClient(token: _token);
            //_botClient.OnMessage += BotOnMessageReceived;
            //_botClient.OnMessageEdited += BotOnMessageReceived;
        }
        
        public void Start()
        {
            _botClient.StartReceiving(HandleUpdateAsync, HandleErrorAsync);
            Console.WriteLine("Bot started");
            consoleInputHandler();
        }

        private void consoleInputHandler()
        {
            while(true)
            {
                var input = Console.ReadLine();
                if (input == "exit")
                    break;
                
            }
            Console.WriteLine("Bot finished");
            //_botClient();
        }

        static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }


        async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message && update?.Message?.Text != null)
            {
                //await HandleMessage(botClient, update.Message);
                return;

            }

            if (update.Type == UpdateType.CallbackQuery)
            {
                
                // await HendleCallbeckQuery(botClient, update.CallbackQuery);
                return;
            }
        }
    }
}
