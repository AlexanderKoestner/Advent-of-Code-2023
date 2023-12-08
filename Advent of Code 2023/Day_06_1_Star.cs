using System.Security.Principal;

namespace Advent_of_Code_2023
{
    public class Day_06_1_Star
    {
        //  Problem to solve: https://adventofcode.com/2023/day/6 Part 1
        //  Get Puzzle Input here: https://adventofcode.com/2023/day/6/input

        private static bool IsPossibleWin(int timeHoldingButton, int timeMax, int distanceToBeat)
        {
            int timeLeft = timeMax - timeHoldingButton;
            int distance = timeHoldingButton * timeLeft;

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

                List<int> timings = [];
                List<int> distances = [];
                List<string> lines = [];

                string timeString;
                string distanceString;
                int currentDistance;
                int currentTime;

                string? line = sr.ReadLine();

                while (line != null)
                {
                    lines.Add(line);
                    
                    line = sr.ReadLine();
                }

                timeString = lines[0].Split(':')[1].Trim();

                foreach (string time in timeString.Split(' '))
                {
                    if (time.Equals(' ') || time.Equals(""))
                    {
                        continue;
                    }

                    currentTime = int.Parse(time.Trim());

                    timings.Add(currentTime);
                }

                distanceString = lines[1].Split(':')[1].Trim();

                foreach (string distance in distanceString.Split(' '))
                {
                    if (distance.Equals(' ') || distance.Equals(""))
                    {
                        continue;
                    }

                    currentDistance = int.Parse(distance.Trim());

                    distances.Add(currentDistance);
                }

                List<int> wins = [];

                int win;

                for (int i = 0; i < distances.Count; i++)
                {
                    win = 0;

                    for (int j = 0; j < timings[i] + 1; j++)
                    {
                        if (IsPossibleWin(j, timings[i], distances[i]))
                        {
                            win++;
                        }
                    }

                    if (win == 0)
                    {
                        continue;
                    }

                    wins.Add(win);
                }

                int sum = 1;

                foreach (int number in wins)
                {
                    sum *= number;
                }

                sr.Close();

                return sum.ToString();
            }
            catch (Exception ex)
            {
                return "Exception: " + ex.Message.ToString();
            }
        }
    }
}
