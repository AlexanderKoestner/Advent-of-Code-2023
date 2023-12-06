using System.Text.RegularExpressions;

namespace Advent_of_Code_2023
{
    public class Day_6_2_Star
    {
        //  Problem to solve: https://adventofcode.com/2023/day/6 Part 2
        //  Get Puzzle Input here: https://adventofcode.com/2023/day/6/input

        private static long LowestWin(long timeMax, long distanceToBeat)
        {
            int divider = 6;
            long timeDivided = timeMax / divider;

            long timeToTest = 0;

            for (int i = 1; i < 7; i++)
            {
                timeToTest = timeDivided * i;
                if(IsPossibleWin(timeToTest, timeMax, distanceToBeat))
                {
                    break;
                }
            }

            for (long i = timeToTest; i > 0; i--)
            {
                if(!IsPossibleWin(i, timeMax, distanceToBeat))
                {
                    timeToTest = i + 1;
                    break;
                }
            }

            return timeToTest;
        }

        private static long HighestWin(long timeMax, long distanceToBeat)
        {
            int divider = 6;
            long timeDivided = timeMax / divider;

            long timeToTest = 0;

            for (int i = 6; i > 0; i--)
            {
                timeToTest = timeDivided * i;
                if (IsPossibleWin(timeToTest, timeMax, distanceToBeat))
                {
                    break;
                }
            }

            for (long i = timeToTest; i < timeMax; i++)
            {
                if (!IsPossibleWin(i, timeMax, distanceToBeat))
                {
                    timeToTest = i;
                    break;
                }
            }

            return timeToTest;
        }

        private static bool IsPossibleWin(long timeHoldingButton, long timeMax, long distanceToBeat)
        {
            long timeLeft = timeMax - timeHoldingButton;
            long distance = timeHoldingButton * timeLeft;

            if (distance > distanceToBeat)
            {
                return true;
            }

            return false;
        }

        public static string GetResult()
        {
            try
            {
                StreamReader sr = new("E:\\Advent_of_Code_2023\\AdventOfCode_Day6_Input.txt");

                List<string> lines = [];

                string? line = sr.ReadLine();

                while (line != null)
                {
                    lines.Add(line);
                    line = sr.ReadLine();
                }

                string timeString = lines[0].Split(':')[1];
                string distanceString = lines[1].Split(':')[1];

                string actualTime = "";
                string actualDistance = "";

                foreach(char character in timeString)
                {
                    if(Regex.IsMatch(character.ToString(), "[0-9]"))
                    {
                        actualTime += character;
                    }
                }

                foreach (char character in distanceString)
                {
                    if (Regex.IsMatch(character.ToString(), "[0-9]"))
                    {
                        actualDistance += character;
                    }
                }

                sr.Close();

                long highest = HighestWin(long.Parse(actualTime), long.Parse(actualDistance));
                long lowest = LowestWin(long.Parse(actualTime), long.Parse(actualDistance));

                return (highest - lowest).ToString();
            }
            catch (Exception ex)
            {
                return "Exception: " + ex.Message.ToString();
            }
        }
    }
}
