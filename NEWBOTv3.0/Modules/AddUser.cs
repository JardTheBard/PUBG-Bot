using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NEWBOTv3.Modules
{
    public class AddUser : ModuleBase<SocketCommandContext>
    {
        [Command("adduser")]
        public async Task AddUserAsync([Remainder] string userName = "")
        {
            string filePath = "D:\\GoogleDrive\\Discord_Bot\\Player_Profiles\\" + userName + ".txt";
            EmbedBuilder builder = new EmbedBuilder();

            switch (Context.User.Id)
            {
                case 176815679599542274: //Jared
                case 170671108675076108: //Thomas
                case 175755733395046400: //Colin
                    if (!File.Exists(filePath))
                    {
                        using (StreamWriter sw = File.CreateText(filePath))
                        {
                            sw.WriteLine("0");
                            sw.WriteLine("0");
                            sw.WriteLine("0");
                            sw.WriteLine("0");
                            sw.WriteLine("0");
                            sw.WriteLine("0");
                            sw.Close();
                        }
                        builder.WithTitle("Success!")
                            .WithDescription($"The user '{userName}' has been successfully created.")
                            .WithColor(Color.Green);

                        await ReplyAsync("", false, builder.Build());
                    }
                    else
                    {
                        builder.WithTitle("Error")
                            .WithDescription($"The user '{userName}' already exists.")
                            .WithColor(Color.Red);

                        await ReplyAsync("", false, builder.Build());
                    }
                    break;
                default:
                    builder.WithTitle("Error")
                            .WithDescription("You do not have permission to use this command.")
                            .WithColor(Color.Red);

                    await ReplyAsync("", false, builder.Build());
                    break;
            }
        }
    }
}
