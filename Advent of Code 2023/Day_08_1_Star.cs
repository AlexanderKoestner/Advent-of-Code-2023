namespace Advent_of_Code_2023
{
    public class Day_08_1_Star
    {
        //  Problem to solve: https://adventofcode.com/2023/day/8 Part 1
        //  Get Puzzle Input here: https://adventofcode.com/2023/day/8/input

        public static string GetResult()
        {
            try
            {
                StreamReader sr = new("E:\\Advent_of_Code_2023\\AdventOfCode_Day8_Input.txt");

                Dictionary<string, string> locations = [];

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
                    }
                    else
                    {
                        instructions += line;
                    }
                    line = sr.ReadLine();
                }

                bool locationNotFound = true;
                string nextLocation;
                string currentLocation = "AAA";
                int loops = 0;
                int steps = 0;

                while (locationNotFound)
                {
                    steps = 0;
                    for (int i = 0; i < instructions.Length; i++)
                    {
                        steps++;

                        if (instructions[i].Equals('L'))
                        {
                            nextLocation = locations[currentLocation].Substring(1, 3);
                        }
                        else
                        {
                            nextLocation = locations[currentLocation].Substring(6, 3);
                        }
                        
                        if(nextLocation.Equals("ZZZ"))
                        {
                            locationNotFound = false;
                            break;
                        }

                        currentLocation = nextLocation;
                    }

                    if (locationNotFound)
                    {
                        loops++;
                    }
                }

                sr.Close();

                return ((loops * instructions.Length) + steps).ToString();
            }
            catch (Exception ex)
            {
                return "Exception: " + ex.Message.ToString();
            }
        }
    }
}
