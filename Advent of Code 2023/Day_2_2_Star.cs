namespace Advent_of_Code_2023
{
    public class Day_2_2_Star
    {
        //  Problem to solve: https://adventofcode.com/2023/day/2 Part 2
        //  Get Puzzle Input here: https://adventofcode.com/2023/day/2/input

        private static int PowerOf(string line)
        {
            int redCubes = 1;
            int greenCubes = 1;
            int blueCubes = 1;

            foreach (string value in line[7..].Split(';'))
            {
                if (value.Contains("red"))
                {
                    if(int.Parse(value.Substring(value.IndexOf("red") - 3, 2)) > redCubes)
                    {
                        redCubes = int.Parse(value.Substring(value.IndexOf("red") - 3, 2));
                    }
                }

                if (value.Contains("green"))
                {
                    if (int.Parse(value.Substring(value.IndexOf("green") - 3, 2)) > greenCubes)
                    {
                        greenCubes = int.Parse(value.Substring(value.IndexOf("green") - 3, 2));
                    }
                }

                if (value.Contains("blue"))
                {
                    if (int.Parse(value.Substring(value.IndexOf("blue") - 3, 2)) > blueCubes)
                    {
                        blueCubes = int.Parse(value.Substring(value.IndexOf("blue") - 3, 2));
                    }
                }
            }

            return redCubes * greenCubes * blueCubes;
        }
        public static string GetResult()
        {
            try
            {
                StreamReader sr = new("E:\\Advent_of_Code_2023\\AdventOfCode_Day2_Input.txt");

                int sum = 0;

                string? line = sr.ReadLine();

                while (line != null)
                {
                    sum += PowerOf(line);

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
