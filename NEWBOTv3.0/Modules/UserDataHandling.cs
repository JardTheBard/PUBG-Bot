using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NEWBOTv3.Modules
{
    class UserDataHandling
    {
        public static string[] ReadUserData(string userName)
        {
            string[] userData = new string[7];
            StreamReader sr;
            userData[0] = "startingValue";

            try
            {
                sr = new StreamReader("D:\\GoogleDrive\\Discord_Bot\\Player_Profiles\\" + userName + ".txt");
                sr.Close();
            }
            catch (IOException)
            {
                userData[0] = "userNonexistent";
            }

            switch (userData[0])
            {
                case "startingValue":
                    sr = new StreamReader("D:\\GoogleDrive\\Discord_Bot\\Player_Profiles\\" + userName + ".txt");
                    userData[1] = sr.ReadLine();
                    userData[2] = sr.ReadLine();
                    userData[3] = sr.ReadLine();
                    userData[4] = sr.ReadLine();
                    userData[5] = sr.ReadLine();
                    userData[6] = sr.ReadLine();
                    sr.Close();
                    userData[0] = "recordedData";
                    break;
                default:
                    userData[0] = "errorOccurred";
                    break;
            }

            return userData;
        }

        public static string[] WriteUserWins(string userName, string[] userData)
        {
            //0 is value status, 1 is variable value, 2 is type of change
            int oldWinsValue = 0;
            int newWinsValue = 0;
            string ticksValue = "0";
            string emmettRank = "0";
            string emmettInfractions = "0";
            string discordID = "0";
            string emmettPrestige = "0";
            StreamReader sr;
            StreamWriter sw;

            Console.WriteLine(userName);

            if (userName != "defaultValue")
            {
                try
                {
                    sr = new StreamReader("D:\\GoogleDrive\\Discord_Bot\\Player_Profiles\\" + userName + ".txt");
                    sr.Close();
                }
                catch (IOException)
                {
                    userData[0] = "userNonexistent";
                }

                switch (userData[0])
                {
                    case "startingValue":
                        sr = new StreamReader("D:\\GoogleDrive\\Discord_Bot\\Player_Profiles\\" + userName + ".txt");
                        userData[1] = sr.ReadLine();
                        ticksValue = sr.ReadLine();
                        emmettRank = sr.ReadLine();
                        emmettInfractions = sr.ReadLine();
                        discordID = sr.ReadLine();
                        emmettPrestige = sr.ReadLine();
                        sr.Close();

                        try
                        {
                            oldWinsValue = Convert.ToInt32(userData[1]);
                        }
                        catch (FormatException)
                        {
                            userData[0] = "cannotBeChanged";
                        }

                        if (userData[0] != "cannotBeChanged")
                        {
                            switch (userData[2])
                            {
                                case "addWin":
                                    newWinsValue = oldWinsValue + 1;
                                    userData[0] = "recordedData";
                                    break;
                                case "undoWin":
                                    newWinsValue = oldWinsValue - 1;
                                    userData[0] = "recordedData";
                                    break;
                                default:
                                    newWinsValue = oldWinsValue;
                                    userData[0] = "cannotBeChangeda";
                                    break;
                            }

                            userData[1] = Convert.ToString(newWinsValue);

                            sw = new StreamWriter("D:\\GoogleDrive\\Discord_Bot\\Player_Profiles\\" + userName + ".txt", false);
                            sw.WriteLine(newWinsValue);
                            sw.WriteLine(ticksValue);
                            sw.WriteLine(emmettRank);
                            sw.WriteLine(emmettInfractions);
                            sw.WriteLine(discordID);
                            sw.WriteLine(emmettPrestige);
                            sw.Close();
                        }
                        break;
                    default:
                        userData[0] = "errorOccurred";
                        break;
                }
            }
            else if (userName == "defaultUser")
            {
                userData[0] = "noEntry";
            }

            return userData;
        }

        public static string[] WriteUserTicks(string userName, string[] userData)
        {
            //0 is value status, 1 is variable value, 2 is type of change
            string winsValue = "0";
            int oldTicksValue = 0;
            int newTicksValue = 0;
            string emmettRank = "0";
            string emmettInfractions = "0";
            string discordID = "0";
            string emmettPrestige = "0";
            StreamReader sr;
            StreamWriter sw;
            userData[0] = "startingValue";

            try
            {
                sr = new StreamReader("D:\\GoogleDrive\\Discord_Bot\\Player_Profiles\\" + userName + ".txt");
                sr.Close();
            }
            catch (IOException)
            {
                userData[0] = "userNonexistent";
            }

            switch (userData[0])
            {
                case "startingValue":
                    sr = new StreamReader("D:\\GoogleDrive\\Discord_Bot\\Player_Profiles\\" + userName + ".txt");
                    winsValue = sr.ReadLine();
                    userData[1] = sr.ReadLine();
                    emmettRank = sr.ReadLine();
                    emmettInfractions = sr.ReadLine();
                    discordID = sr.ReadLine();
                    emmettPrestige = sr.ReadLine();
                    sr.Close();

                    try
                    {
                        oldTicksValue = Convert.ToInt32(userData[1]);
                    }
                    catch (FormatException)
                    {
                        userData[1] = "cannotBeChanged";
                    }

                    if (userData[1] != "cannotBeChanged")
                    {
                        switch (userData[2])
                        {
                            case "addTick":
                                newTicksValue = oldTicksValue + 1;
                                userData[0] = "recordedData";
                                break;
                            case "undoTick":
                                newTicksValue = oldTicksValue - 1;
                                userData[0] = "recordedData";
                                break;
                            default:
                                newTicksValue = oldTicksValue;
                                userData[0] = "unchangedData";
                                break;
                        }

                        userData[1] = Convert.ToString(newTicksValue);

                        sw = new StreamWriter("D:\\GoogleDrive\\Discord_Bot\\Player_Profiles\\" + userName + ".txt", false);
                        sw.WriteLine(winsValue);
                        sw.WriteLine(newTicksValue);
                        sw.WriteLine(emmettRank);
                        sw.WriteLine(emmettInfractions);
                        sw.WriteLine(discordID);
                        sw.WriteLine(emmettPrestige);
                        sw.Close();
                    }
                    break;
                default:
                    userData[1] = "errorOccurred";
                    break;
            }

            return userData;
        }

        public static string[] WriteEmmettLevel(string userName, string[] userData)
        {
            //0 is value status, 1 is variable value, 2 is secondary variable value, 3 is type of change, 4 is prestige level
            long oldEmmettRank = 0;
            long newEmmettRank = 0;
            int oldEmmettInfractions = 0;
            int newEmmettInfractions = 0;
            int oldEmmettPrestige = 0;
            int newEmmettPrestige = 0;
            string discordID = "0";
            string winsValue = "0";
            string ticksValue = "0";
            StreamReader sr;
            StreamWriter sw;
            userData[0] = "startingValue";

            try
            {
                sr = new StreamReader("D:\\GoogleDrive\\Discord_Bot\\Player_Profiles\\" + userName + ".txt");
                sr.Close();
            }
            catch (IOException)
            {
                userData[0] = "userNonexistent";
            }

            switch (userData[0])
            {
                case "startingValue":
                    sr = new StreamReader("D:\\GoogleDrive\\Discord_Bot\\Player_Profiles\\" + userName + ".txt");
                    winsValue = sr.ReadLine();
                    ticksValue = sr.ReadLine();
                    userData[1] = sr.ReadLine();
                    userData[2] = sr.ReadLine();
                    discordID = sr.ReadLine();
                    userData[4] = sr.ReadLine();
                    sr.Close();

                    try
                    {
                        oldEmmettRank = Convert.ToInt32(userData[1]);
                    }
                    catch (FormatException)
                    {
                        userData[0] = "cannotBeChanged";
                    }

                    try
                    {
                        oldEmmettInfractions = Convert.ToInt32(userData[2]);
                    }
                    catch (FormatException)
                    {
                        userData[0] = "cannotBeChanged";
                    }

                    try
                    {
                        oldEmmettPrestige = Convert.ToInt32(userData[4]);
                    }
                    catch (FormatException)
                    {
                        userData[0] = "cannotBeChanged";
                    }

                    if (userData[0] != "cannotBeChanged")
                    {
                        switch (userData[3])
                        {
                            case "addEmmett":
                                if (oldEmmettInfractions % 13 == 0)
                                {
                                    newEmmettRank = 1;
                                    newEmmettInfractions = 1;
                                    newEmmettPrestige = oldEmmettPrestige;
                                    userData[0] = "recordedData";
                                }
                                else if (oldEmmettInfractions % 12 == 0)
                                {
                                    newEmmettPrestige = oldEmmettPrestige + 1;
                                    newEmmettRank = 0;
                                    newEmmettInfractions = oldEmmettInfractions + 1;
                                    userData[0] = "recordedData";
                                }
                                else
                                {
                                    newEmmettRank = oldEmmettRank * (oldEmmettInfractions + 1);
                                    newEmmettInfractions = oldEmmettInfractions + 1;
                                    newEmmettPrestige = oldEmmettPrestige;
                                    userData[0] = "recordedData";
                                }
                                break;
                            case "undoEmmett":
                                if (oldEmmettRank == 1)
                                {
                                    newEmmettRank = oldEmmettRank - 1;
                                    newEmmettInfractions = oldEmmettInfractions - 1;
                                    newEmmettPrestige = oldEmmettPrestige;
                                    userData[0] = "recordedData";
                                }
                                else if (oldEmmettInfractions == 0)
                                {
                                    newEmmettRank = oldEmmettRank;
                                    newEmmettInfractions = oldEmmettInfractions;
                                    newEmmettPrestige = oldEmmettPrestige;
                                    userData[0] = "divideByZero";
                                }
                                else if (oldEmmettInfractions % 13 == 0)
                                {
                                    newEmmettPrestige = oldEmmettPrestige - 1;
                                    newEmmettRank = 479001600;
                                    newEmmettInfractions = oldEmmettInfractions - 1;
                                    userData[0] = "recordedData";
                                }
                                else if (oldEmmettInfractions != 0)
                                {
                                    newEmmettRank = oldEmmettRank / oldEmmettInfractions;
                                    newEmmettInfractions = oldEmmettInfractions - 1;
                                    newEmmettPrestige = oldEmmettPrestige;
                                    userData[0] = "recordedData";
                                }
                                else
                                {
                                    newEmmettRank = oldEmmettRank;
                                    newEmmettInfractions = oldEmmettInfractions;
                                    newEmmettPrestige = oldEmmettPrestige;
                                    userData[0] = "unchangedData";
                                }
                                break;
                            default:
                                newEmmettRank = oldEmmettRank;
                                newEmmettInfractions = oldEmmettInfractions;
                                newEmmettPrestige = oldEmmettPrestige;
                                userData[0] = "unchangedData";
                                break;
                        }

                        userData[1] = Convert.ToString(newEmmettRank);
                        userData[2] = Convert.ToString(newEmmettInfractions);
                        userData[4] = Convert.ToString(newEmmettPrestige);

                        sw = new StreamWriter("D:\\GoogleDrive\\Discord_Bot\\Player_Profiles\\" + userName + ".txt", false);
                        sw.WriteLine(winsValue);
                        sw.WriteLine(ticksValue);
                        sw.WriteLine(newEmmettRank);
                        sw.WriteLine(newEmmettInfractions);
                        sw.WriteLine(discordID);
                        sw.WriteLine(newEmmettPrestige);
                        sw.Close();
                    }
                    break;
                default:
                    userData[1] = "errorOccurred";
                    break;
            }

            return userData;
        }

        public static string GetEmmettPrestige(string emmettPrestigeLevel)
        {
            string prestigeTag = "";
            int i = 0;

            int prestigeCount = Convert.ToInt32(emmettPrestigeLevel);
            while (i < prestigeCount)
            {
                prestigeTag = prestigeTag + ":star:";
                i = i + 1;
            }

            return prestigeTag;
        }

        public static (List<string>, int) GetTopStats(string userChoice)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            int topValue = 0;
            List<string> topUsers = new List<string>();
            string placeHolder;
            string strPrestigeValue;
            int intPrestigeValue;
            string strRankValue;
            int intRankValue;
            int addedValues;
            string[] filePaths;
            StreamReader sr;

            topUsers.Add("defaultValue");

            filePaths = Directory.GetFileSystemEntries("D:\\GoogleDrive\\Discord_Bot\\Player_Profiles");

            string[] stringDataValues = new string[filePaths.Length];
            int[] intDataValues = new int[filePaths.Length];

            while (i < filePaths.Length)
            {
                sr = new StreamReader(filePaths[i]);

                if (userChoice == "getWins")
                {
                    stringDataValues[i] = sr.ReadLine();
                    sr.Close();
                }
                else if (userChoice == "getTicks")
                {
                    placeHolder = sr.ReadLine();
                    stringDataValues[i] = sr.ReadLine();
                    sr.Close();
                }
                else if (userChoice == "getEmmett")
                {
                    placeHolder = sr.ReadLine();
                    placeHolder = sr.ReadLine();
                    placeHolder = sr.ReadLine();
                    strRankValue = sr.ReadLine();
                    placeHolder = sr.ReadLine();
                    strPrestigeValue = sr.ReadLine();
                    sr.Close();

                    intRankValue = Convert.ToInt32(strRankValue);
                    intPrestigeValue = Convert.ToInt32(strPrestigeValue);

                    addedValues = (intPrestigeValue * 13) + intRankValue;

                    stringDataValues[i] = Convert.ToString(addedValues);
                }

                i = i + 1;
            }

            while (j < filePaths.Length)
            {
                try
                {
                    intDataValues[j] = Convert.ToInt32(stringDataValues[j]);
                }
                catch (FormatException)
                {
                    intDataValues[j] = 0;
                }
                j = j + 1;
            }

            while (k < filePaths.Length)
            {
                if (intDataValues[k] > topValue)
                {
                    topUsers.Clear();
                    topValue = intDataValues[k];
                    topUsers.Add(TrimUserFile(filePaths[k]));
                }
                else if ((intDataValues[k] ==  topValue) && (topUsers[0] != "defaultUser"))
                {
                    topUsers.Add(TrimUserFile(filePaths[k]));
                }
                k = k + 1;
            }

            return (topUsers, topValue);
        }

        public static string TrimUserFile(string filePath)
        {
            string cutName = filePath.Replace("D:\\GoogleDrive\\Discord_Bot\\Player_Profiles\\", "");
            cutName = cutName.Replace(".txt", "");

            return cutName;
        }

        public static string GetEmmettActualRank(List<string> users)
        {
            StreamReader sr;
            string placeHolder;
            string userPrestige;
            string strUserRank;
            int intUserRank;

            sr = new StreamReader("D:\\GoogleDrive\\Discord_Bot\\Player_Profiles\\" + users[0] + ".txt");
            placeHolder = sr.ReadLine();
            placeHolder = sr.ReadLine();
            strUserRank = sr.ReadLine();
            placeHolder = sr.ReadLine();
            placeHolder = sr.ReadLine();
            userPrestige = sr.ReadLine();
            sr.Close();

            intUserRank = Convert.ToInt32(strUserRank);

            string starPrestige = UserDataHandling.GetEmmettPrestige(userPrestige);

            string finalRanking = starPrestige + intUserRank;


            return finalRanking;
        }
        
    }
}
