using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Music_Bot_CSHARP.Core;

public class Bot {

    private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }

    private DiscordSocketClient _client;

    public async Task MainAsync()
    {
        _client = new DiscordSocketClient();
        _client.Log += Log;

        var token = "ODgxMzk0ODA1MjQ5Mjk4NDYy.GMKVMc.zAJlJ8pqI50hP8xhR73sCP3Lr_zVyF0Po0kOkw";

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        await Task.Delay(-1);
    }
       
}