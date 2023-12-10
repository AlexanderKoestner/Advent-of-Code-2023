using System.Text.RegularExpressions;

namespace Advent_of_Code_2023
{
    public class Day_08_2_Star
    {
        //  Problem to solve: https://adventofcode.com/2023/day/8 Part 2
        //  Get Puzzle Input here: https://adventofcode.com/2023/day/8/input

        public static string GetResult()
        {
            try
            {
                StreamReader sr = new("E:\\Advent_of_Code_2023\\AdventOfCode_Day8_Input.txt");

                Dictionary<string, string> locations = [];
                List<string> startingLocations = [];

                string location;
                string leftAndRight;
                string instructions = "";

                string? line = sr.ReadLine();

                while (line != null)
                {
                    if (line.Equals(""))
                    {
                        line = sr.ReadLine();
                        continue;
                    }

                    if (line.Contains('='))
                    {
                        location = line.Split('=')[0].Trim();
                        leftAndRight = line.Split("=")[1].Trim();
                        locations.Add(location, leftAndRight);

                        if(location.EndsWith('A'))
                        {
                            startingLocations.Add(location);
                        }
                    }
                    else
                    {
                        instructions += line;
                    }
                    line = sr.ReadLine();
                }

                sr.Close();

                return "TBD";
            }
            catch (Exception ex)
            {
                return "Exception: " + ex.Message.ToString();
            }
        }
    }
}
