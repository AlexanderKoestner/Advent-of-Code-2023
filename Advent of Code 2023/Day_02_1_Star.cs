namespace Advent_of_Code_2023
{
    public class Day_02_1_Star
    {
        //  Problem to solve: https://adventofcode.com/2023/day/2 Part 1
        //  Get Puzzle Input here: https://adventofcode.com/2023/day/2/input

        private static bool IsPossible(string line, int redCubes, int greenCubes, int blueCubes)
        {
            if (line.Contains("red"))
            {
                if (int.Parse(line.Substring(line.IndexOf("red") - 3, 2)) > redCubes)
                {
                    return false;
                }
            }

            if (line.Contains("green"))
            {
                if (int.Parse(line.Substring(line.IndexOf("green") - 3, 2)) > greenCubes)
                {
                    return false;
                }
            }

            if (line.Contains("blue"))
            {
                if (int.Parse(line.Substring(line.IndexOf("blue") - 3, 2)) > blueCubes)
                {
                    return false;
                }
            }

            return true;
        }
        public static string GetResult()
        {
            try
            {
                StreamReader sr = new("E:\\Advent_of_Code_2023\\AdventOfCode_Day2_Input.txt");

                int redCubes = 12;
                int greenCubes = 13;
                int blueCubes = 14;

                bool gamePossible;

                int sum = 0;

                string? line = sr.ReadLine();

                while (line != null)
                {
                    gamePossible = true;

                    foreach(string value in line[7..].Split(';'))
                    {
                        if (!IsPossible(value, redCubes, greenCubes, blueCubes))
                        {
                            gamePossible = false;
                            break;
                        }
                    }
                    
                    if (!gamePossible)
                    {
                        line = sr.ReadLine();
                        continue;
                    }

                    sum += int.Parse(line.Split(':')[0][5..]);

                    line = sr.ReadLine();
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
