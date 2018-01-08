using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NEWBOTv3.Modules
{
    public class AddWin : ModuleBase<SocketCommandContext>
    {
        [Command("addwin")]
        public async Task AddWinAsync(string user1Name = "defaultValue", string user2Name = "defaultValue", string user3Name = "defaultValue", string user4Name = "defaultValue")
        {
            string[] user1Data = new string[3]; //0 is value status, 1 is variable value, 2 is type of change
            string[] user2Data = new string[3];
            string[] user3Data = new string[3];
            string[] user4Data = new string[3];
            EmbedBuilder builder = new EmbedBuilder();
            user1Data[2] = "addWin";
            user2Data[2] = "addWin";
            user3Data[2] = "addWin";
            user4Data[2] = "addWin";
            string user1Message = "";
            string user2Message = "";
            string user3Message = "";
            string user4Message = "";
            user1Data[0] = "startingValue";
            user2Data[0] = "startingValue";
            user3Data[0] = "startingValue";
            user4Data[0] = "startingValue";

            switch (Context.User.Id)
            {
                case 176815679599542274: //Jared
                case 170671108675076108: //Thomas
                case 175755733395046400: //Colin
                    user1Data = UserDataHandling.WriteUserWins(user1Name, user1Data);
                    user2Data = UserDataHandling.WriteUserWins(user2Name, user2Data);
                    user3Data = UserDataHandling.WriteUserWins(user3Name, user3Data);
                    user4Data = UserDataHandling.WriteUserWins(user4Name, user4Data);

                    switch (user1Data[0])
                    {
                        case "noEntry":
                            user1Message = "";
                            break;
                        case "cannotBeChanged":
                            user1Message = "Data for the user '" + user1Name + "' cannot be changed.\n";
                            break;
                        case "userNonexistent":
                            user1Message = "The user '" + user1Name + "' does not exist.\n";
                            break;
                        case "recordedData":
                            user1Message = "The user '" + user1Name + "' now has " + user1Data[1] + " wins.\n";
                            break;
                    }
                    switch (user2Data[0])
                    {
                        case "noEntry":
                            user2Message = "";
                            break;
                        case "cannotBeChanged":
                            user2Message = "Data for the user '" + user2Name + "' cannot be changed.\n";
                            break;
                        case "userNonexistent":
                            user2Message = "The user '" + user2Name + "' does not exist.\n";
                            break;
                        case "recordedData":
                            user2Message = "The user '" + user2Name + "' now has " + user2Data[1] + " wins.\n";
                            break;
                    }
                    switch (user3Data[0])
                    {
                        case "noEntry":
                            user3Message = "";
                            break;
                        case "cannotBeChanged":
                            user3Message = "Data for the user '" + user3Name + "' cannot be changed.\n";
                            break;
                        case "userNonexistent":
                            user3Message = "The user '" + user3Name + "' does not exist.\n";
                            break;
                        case "recordedData":
                            user3Message = "The user '" + user3Name + "' now has " + user3Data[1] + " wins.\n";
                            break;
                    }
                    switch (user4Data[0])
                    {
                        case "noEntry":
                            user4Message = "";
                            break;
                        case "cannotBeChanged":
                            user4Message = "Data for the user '" + user4Name + "' cannot be changed.\n";
                            break;
                        case "userNonexistent":
                            user4Message = "The user '" + user4Name + "' does not exist.\n";
                            break;
                        case "recordedData":
                            user4Message = "The user '" + user4Name + "' now has " + user4Data[1] + " wins.\n";
                            break;
                    }

                    Console.WriteLine(user1Data[0]);

                    builder.WithTitle("Value(s) Updated")
                    .WithDescription($"{user1Message}{user2Message}{user3Message}{user4Message}")
                    .WithColor(Color.Green);

                    await ReplyAsync("", false, builder.Build());
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
