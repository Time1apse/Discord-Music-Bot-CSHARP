using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discord_Music_Bot_CSHARP.Core.Commands
{
    public class TextCommands : ModuleBase<SocketCommandContext>
    {
        [Command("бебра")]
        [Alias("b")]
        [Summary("Ну бебра, как бебра, че бубнить то")]
        public Task SayBebraAsync() =>
        ReplyAsync($"{Context.Message.Author.Mention} сам ты беб... бебр... иди нахуй короче");

        [Command("стена")]
        [Summary("Стену пили долбаеб")]
        public Task SayStenaAsync() =>
            ReplyAsync($"{Context.Message.Author.Mention} стену пили долбаеб");
    }
}
