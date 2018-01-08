using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NEWBOTv3.Modules
{
    public class UndoEmmett : ModuleBase<SocketCommandContext>
    {
        [Command("undoemmett")]
        public async Task UndoEmmettAsync([Remainder] string userName = "")
        {
            string[] userData = new string[5]; //0 is value status, 1 is variable value, 2 is secondary variable value, 3 is type of change, 4 is prestige level
            EmbedBuilder builder = new EmbedBuilder();
            userData[3] = "undoEmmett";

            switch (Context.User.Id)
            {
                case 176815679599542274: //Jared
                case 170671108675076108: //Thomas
                case 175755733395046400: //Colin
                    userData = UserDataHandling.WriteEmmettLevel(userName, userData);

                    if (userData[0] == "userNonexistent")
                    {
                        builder.WithTitle("Error")
                            .WithDescription("This user does not exist.")
                            .WithColor(Color.Red);

                        await ReplyAsync("", false, builder.Build());
                    }
                    else if (userData[1] == "cannotBeChanged")
                    {
                        builder.WithTitle("Error")
                            .WithDescription("This user's data cannot be changed.")
                            .WithColor(Color.Red);

                        await ReplyAsync("", false, builder.Build());
                    }
                    else if (userData[0] == "recordedData")
                    {
                        string prestigeTag = UserDataHandling.GetEmmettPrestige(userData[4]);

                        builder.WithTitle(userName)
                            .WithDescription($"Value updated. This user is now Emmett level {prestigeTag}{userData[1]}.")
                            .WithColor(Color.Green);

                        await ReplyAsync("", false, builder.Build());
                    }
                    else if (userData[0] == "divideByZero")
                    {
                        builder.WithTitle("Error")
                            .WithDescription("This user's level of Emmett is already at 0. It cannot be lowered further.")
                            .WithColor(Color.Red);

                        await ReplyAsync("", false, builder.Build());
                    }
                    else
                    {
                        builder.WithTitle("Error")
                            .WithDescription("An unexpected error occurred. Please contact the server administrators.")
                            .WithColor(Color.Red);

                        await ReplyAsync("", false, builder.Build());
                    }

                    break;
                default:
                    builder.WithTitle("Error")
                    .WithDescription("You do not have the correct priveleges to complete this action.")
                    .WithColor(Color.Red);

                    await ReplyAsync("", false, builder.Build());
                    break;
            }
        }
    }
}
