using Discord.Commands;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Music_Bot_CSHARP.Core.Handlers
{
    public class CommandsHandler
    {
        private static readonly DiscordSocketClient _client = ServiceManager.GetService<DiscordSocketClient>();
        private static readonly CommandService _commands = ServiceManager.GetService<CommandService>();
        
        public static async Task LoadCommandsAsync()
        {
            _client.MessageReceived += HandleCommandAsync;

            await _commands.AddModuleAsync(Assembly.GetEntryAssembly().GetType(), ServiceManager.ServiceProvider);

            foreach (var command in _commands.Commands)
            {
                Console.WriteLine($"Command {command.Name} was loaded");
            }
        }

        private static async Task HandleCommandAsync(SocketMessage message)
        {
            var _message = message as SocketUserMessage;
            if (_message == null) return;

            int argPos = 0;

            if (!(_message.HasCharPrefix('$', ref argPos)
                || _message.HasMentionPrefix(_client.CurrentUser, ref argPos))
                || _message.Author.IsBot) return;

            var context = new SocketCommandContext(_client, _message);

            await _commands.ExecuteAsync(
                context: context,
                argPos: argPos,
               // services: ServiceManager.ServiceProvider
               services: null
               );
        }
        
    }
}
