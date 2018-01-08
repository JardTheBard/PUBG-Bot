using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NEWBOTv3.Modules
{
    public class UserProfile : ModuleBase<SocketCommandContext>
    {
        [Command("userprofile")]
        public async Task CheckUserAsync([Remainder] string userName = "")
        {
            string[] userData = new string[7];
            EmbedBuilder builder = new EmbedBuilder();

            userData = UserDataHandling.ReadUserData(userName);

            if (userData[0] == "recordedData")
            {
                string prestigeTag = UserDataHandling.GetEmmettPrestige(userData[6]);

                builder.WithTitle(userName)
                    .WithDescription($"Wins: {userData[1]}\nTicks: {userData[2]}\nEmmett Level: {prestigeTag}{userData[3]}\n")
                    .WithColor(Color.Green);

                await ReplyAsync("", false, builder.Build());
            }
            else if (userData[0] == "userNonexistent")
            {
                builder.WithTitle("Error")
                    .WithDescription("This user does not exist.")
                    .WithColor(Color.Red);

                await ReplyAsync("", false, builder.Build());
            }
            else
            {
                builder.WithTitle("Error")
                    .WithDescription("An unexpected error occurred. Please contact the server administrators.")
                    .WithColor(Color.Orange);

                await ReplyAsync("", false, builder.Build());
            }
        }
    }
}
