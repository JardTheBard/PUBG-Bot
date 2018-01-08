using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NEWBOTv3.Modules
{
    public class Roll : ModuleBase<SocketCommandContext>
    {
        [Command("roll")]
        public async Task RollAsync(string numberOfSides = "defaultValue")
        {
            char errorOccurred = 'F';
            int randomMax = 0;
            EmbedBuilder builder = new EmbedBuilder();

            try
            {
                randomMax = Convert.ToInt32(numberOfSides);
            }
            catch (FormatException)
            {
                builder.WithTitle("Error")
                    .WithDescription("You did not enter an integer.")
                    .WithColor(Color.Red);

                await ReplyAsync("", false, builder.Build());
                errorOccurred = 'T';
            }
            catch (OverflowException)
            {
                builder.WithTitle("Error")
                    .WithDescription("The number you entered was too large.")
                    .WithColor(Color.Red);

                await ReplyAsync("", false, builder.Build());
                errorOccurred = 'T';
            }

            if (errorOccurred == 'F')
            {
                if (randomMax > 0)
                {
                    Random rnd = new Random();
                    int randomRoll = rnd.Next(1, randomMax);

                    builder.WithTitle("Dice Roll Results")
                    .WithDescription($"You rolled a {randomRoll}.")
                    .WithColor(Color.Green);

                    await ReplyAsync("", false, builder.Build());
                }
                else
                {
                    builder.WithTitle("Error")
                    .WithDescription("You entered an invalid number.")
                    .WithColor(Color.Red);

                    await ReplyAsync("", false, builder.Build());
                }
            }
        }
    }
}
