using ExpenseTrackingBot.TelegramBot;

internal class EntryPoint
{
    static void Main(string[] args)
    {
        TelegramBot bot = new TelegramBot();
        bot.Start();
    }
    


}

