using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord_Music_Bot_CSHARP.Core.Handlers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Victoria.Node;

namespace Discord_Music_Bot_CSHARP.Core;

public class Bot {

    private Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }

    private DiscordSocketClient _client;
    private CommandService _commands;
    private LavaNode _node;
    private ILogger<LavaNode>? _logger;

    public Bot()
    {
        _client = new DiscordSocketClient();
        _client.Log += Log;

        _commands = new CommandService(new CommandServiceConfig()
        {
            LogLevel = LogSeverity.Debug,
            CaseSensitiveCommands = false,
            DefaultRunMode = RunMode.Async,
            IgnoreExtraArgs = true
        });

        _node = new LavaNode(_client, new NodeConfiguration()
        {
            Hostname = "localhost",
            Port = 2333,
            Authorization = "youshallnotpass",
            SelfDeaf = true
        },_logger);

        var collection = new ServiceCollection();
        collection.AddSingleton(_client);
        collection.AddSingleton(_commands);
        collection.AddSingleton(_node);

        ServiceManager.SetProvider(collection);
    }

    public async Task MainAsync()
    { 
        var token = "ODgxMzk0ODA1MjQ5Mjk4NDYy.GMKVMc.zAJlJ8pqI50hP8xhR73sCP3Lr_zVyF0Po0kOkw";

        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        await CommandsHandler.LoadCommandsAsync();

        await Task.Delay(-1);
    }
       
}