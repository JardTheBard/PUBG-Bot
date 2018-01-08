using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NEWBOTv3.Modules
{
    public class TestCommand : ModuleBase<SocketCommandContext>
    {
        [Command("testcommand")]
        public async Task TimeAsync()
        {
            var user = Context.Client.GetUser(176815679599542274);
            await ReplyAsync($"Ree {user}");
        }
    }
}
