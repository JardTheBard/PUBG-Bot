using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NEWBOTv3.Modules
{
    public class TopEmmett : ModuleBase<SocketCommandContext>
    {
        [Command("topemmett")]
        public async Task TopEmmettAsync()
        {
            List<string> topUsers = new List<string>();
            int topValue;
            string userChoice = "getEmmett";
            string concatenatedUsers = "";
            EmbedBuilder builder = new EmbedBuilder();
            int i = 1;
            string emmettCount;

            (topUsers, topValue) = UserDataHandling.GetTopStats(userChoice);
            emmettCount = UserDataHandling.GetEmmettActualRank(topUsers);


            if (topUsers.Count == 2)
            {
                concatenatedUsers = topUsers[0] + "' and '" + topUsers[1];

                builder.WithTitle("Top Wins")
                    .WithDescription($"The users '{concatenatedUsers}' are the most Emmett with rank {emmettCount}.")
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
                    .WithDescription($"The users {concatenatedUsers} are the most Emmett with rank {emmettCount}.")
                    .WithColor(Color.LighterGrey);

                await ReplyAsync("", false, builder.Build());
            }
            else
            {
                builder.WithTitle("Top Wins")
                    .WithDescription($"The user '{topUsers[0]}' is the most Emmett with rank {emmettCount}.")
                    .WithColor(Color.LighterGrey);

                await ReplyAsync("", false, builder.Build());
            }
        }
    }
}
