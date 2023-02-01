namespace Discord_Music_Bot_CSHARP.Core;
public class Program {
    public static async Task Main(string[] args) => new Bot().MainAsync().GetAwaiter().GetResult();
}

//https://github.com/Yucked/Victoria/wiki https://github.com/Yucked/Victoria/blob/examples/v6/AudioService.cs https://discordnet.dev/guides/text_commands/intro.html https://github.com/Time1apse/Discord-Music-Bot/blob/b7561bd0a1d3a8952ea7d4dcbc704adcb65b0116/Core/Bot.cs#L11  https://github.com/Time1apse/Discord-Music-Bot/blob/master/Core/Managers/TextCommands.cs