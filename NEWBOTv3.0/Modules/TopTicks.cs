using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NEWBOTv3.Modules
{
    public class TopTicks : ModuleBase<SocketCommandContext>
    {
        [Command("topticks")]
        public async Task TopTicksAsync()
        {
            List<string> topUsers = new List<string>();
            int topValue;
            string userChoice = "getTicks";
            string concatenatedUsers = "";
            EmbedBuilder builder = new EmbedBuilder();
            int i = 1;

            (topUsers, topValue) = UserDataHandling.GetTopStats(userChoice);

            if (topUsers.Count == 2)
            {
                concatenatedUsers = topUsers[0] + "' and '" + topUsers[1];

                builder.WithTitle("Top Ticks")
                    .WithDescription($"The users '{concatenatedUsers}' have the most ticks with {topValue} ticks.")
                    .WithColor(Color.LighterGrey);

                await ReplyAsync("", false, builder.Build());
            }
            else if (topUsers.Count > 2)
            {
                while (i < topUsers.Count)
                {
                    concatenatedUsers = concatenatedUsers + "'" + topUsers[i - 1] + "', ";
                    i = i + 1;
                }
                concatenatedUsers = concatenatedUsers + "and '" + topUsers[i - 1] + "'";

                builder.WithTitle("Top Ticks")
                    .WithDescription($"The users {concatenatedUsers} have the most ticks with {topValue} ticks.")
                    .WithColor(Color.LighterGrey);

                await ReplyAsync("", false, builder.Build());
            }
            else
            {
                builder.WithTitle("Top Ticks")
                    .WithDescription($"The user '{topUsers[0]}' has the most ticks with {topValue} ticks.")
                    .WithColor(Color.LighterGrey);

                await ReplyAsync("", false, builder.Build());
            }
        }
    }
}
