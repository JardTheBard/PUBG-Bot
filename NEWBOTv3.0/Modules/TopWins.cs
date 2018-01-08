using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NEWBOTv3.Modules
{
    public class TopWins : ModuleBase<SocketCommandContext>
    {
        [Command("topwins")]
        public async Task TopWinsAsync()
        {
            List<string> topUsers = new List<string>();
            int topValue;
            string userChoice = "getWins";
            string concatenatedUsers = "";
            EmbedBuilder builder = new EmbedBuilder();
            int i = 1;

            (topUsers, topValue) = UserDataHandling.GetTopStats(userChoice);

            if (topUsers.Count == 2)
            {
                concatenatedUsers = topUsers[0] + "' and '" + topUsers[1];

                builder.WithTitle("Top Wins")
                    .WithDescription($"The users '{concatenatedUsers}' have the most wins with {topValue} wins.")
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

                builder.WithTitle("Top Wins")
                    .WithDescription($"The users {concatenatedUsers} have the most wins with {topValue} wins.")
                    .WithColor(Color.LighterGrey);

                await ReplyAsync("", false, builder.Build());
            }
            else
            {
                builder.WithTitle("Top Wins")
                    .WithDescription($"The user '{topUsers[0]}' has the most wins with {topValue} wins.")
                    .WithColor(Color.LighterGrey);

                await ReplyAsync("", false, builder.Build());
            }
        }
    }
}
