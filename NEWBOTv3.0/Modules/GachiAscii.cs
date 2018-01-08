using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NEWBOTv3.Modules
{
    public class GachiAscii : ModuleBase<SocketCommandContext>
    {
        [Command("gachi")]
        public async Task GachiAsciiAsync()
        {
            await ReplyAsync(@"             **THANK YOU SIR**
                               ░░░░░▓▓▓▓▓▓▓▓▓▓▓░░░░░░░░
                               ░░░▓▓▓▓▓▓▒▒▒▒▒▒▓▓░░░░░░░
                               ░░▓▓▓▓▒░░▒▒▓▓▒▒▓▓▓▓░░░░░
                               ░▓▓▓▓▒░░▓▓▓▒▄▓░▒▄▄▄▓░░░░
                               ▓▓▓▓▓▒░░▒▀▀▀▀▒░▄░▄▒▓▓░░░
                               ▓▓▓▓▓▒░░▒▒▒▒▒▓▒▀▒▀▒▓▒▓░░
                               ▓▓▓▓▓▒▒░░░▒▒▒░░▄▀▀▀▄▓▒▓░
                               ▓▓▓▓▓▓▒▒░░░▒▒▓▀▄▄▄▄▓▒▒▒▓
                               ░▓█▀▄▒▓▒▒░░░▒▒░░▀▀▀▒▒▒▒░
                               ░░▓█▒▒▄▒▒▒▒▒▒▒░░▒▒▒▒▒▒▓░
                               ░░░▓▓▓▓▒▒▒▒▒▒▒▒░░░▒▒▒▓▓░
                               ░░░░░▓▓▒░░▒▒▒▒▒▒▒▒▒▒▒▓▓░
                               ░░░░░░▓▒▒░░░░▒▒▒▒▒▒▒▓▓░░");
        }
    }
}
