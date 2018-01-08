using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NEWBOTv3.Modules
{
    public class UserHelp : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task UserHelpAsync(string userSelection = "general")
        {
            EmbedBuilder builder = new EmbedBuilder();

            switch (userSelection)
            {
                case "general":
                    builder.AddField("General Help", "TIP: You can get help for specific commands by typing '-help <command name>'.")
                        .AddInlineField("General Commands", "roll\ntime\nhelp\nuserprofile\ntopwins\ntopticks\ntopemmett\ngachi")
                        .AddInlineField("Admin Commands", "adduser\ndeluser\naddwin\nundowin\naddtick\nundotick\naddemmett\nundoemmett")
                    .WithColor(Color.LighterGrey);

                    await ReplyAsync("", false, builder.Build());
                    break;
                case "roll":
                    builder.WithTitle("roll")
                    .WithDescription("Rolls a die.\nUsage: '-roll <number of sides>'.")
                    .WithColor(Color.LighterGrey);

                    await ReplyAsync("", false, builder.Build());
                    break;
                case "time":
                    builder.WithTitle("time")
                    .WithDescription("Checks the current time.\nUsage: '-time'.")
                    .WithColor(Color.LighterGrey);

                    await ReplyAsync("", false, builder.Build());
                    break;
                case "topticks":
                    builder.WithTitle("topticks")
                    .WithDescription("Checks to see who has the most ticks.\nUsage: '-topticks'.")
                    .WithColor(Color.LighterGrey);

                    await ReplyAsync("", false, builder.Build());
                    break;
                case "topwins":
                    builder.WithTitle("topwins")
                    .WithDescription("Checks to see who has the most wins.\nUsage: '-topwins'.")
                    .WithColor(Color.LighterGrey);

                    await ReplyAsync("", false, builder.Build());
                    break;
                case "topemmett":
                    builder.WithTitle("topemmett")
                    .WithDescription("Checks to see who is the most Emmett.\nUsage: '-topemmett'.")
                    .WithColor(Color.LighterGrey);

                    await ReplyAsync("", false, builder.Build());
                    break;
                case "help":
                    builder.WithTitle("help")
                    .WithDescription("Gives a list of commands.\nGeneral usage: '-help'.\nSpecific usage: '-help <command name>'.")
                    .WithColor(Color.LighterGrey);

                    await ReplyAsync("", false, builder.Build());
                    break;
                case "gachi":
                    builder.WithTitle("gachi")
                    .WithDescription("Makes some nice art.\nUsage: '-gachi'.")
                    .WithColor(Color.LighterGrey);

                    await ReplyAsync("", false, builder.Build());
                    break;
                case "userprofile":
                    builder.WithTitle("userprofile")
                    .WithDescription("Checks the specific information for a particular user.\nUsage: '-userprofile <name of user>'.")
                    .WithColor(Color.LighterGrey);

                    await ReplyAsync("", false, builder.Build());
                    break;
                case "adduser":
                case "deluser":
                case "addwin":
                case "undowin":
                case "addtick":
                case "undotick":
                    builder.WithTitle("Error")
                    .WithDescription("That information is not to be disclosed on this server.")
                    .WithColor(Color.Red);

                    await ReplyAsync("", false, builder.Build());
                    break;
                default:
                    builder.WithTitle("Error")
                    .WithDescription("That is not a known command. Please try typing '-help' for a list of known commands.")
                    .WithColor(Color.Red);

                    await ReplyAsync("", false, builder.Build());
                    break;
            }
        }
    }
}
