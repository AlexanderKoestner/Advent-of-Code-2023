namespace Advent_of_Code_2023
{
    public class Day_8_2_Star
    {
        //  Problem to solve: https://adventofcode.com/2023/day/8 Part 2
        //  Get Puzzle Input here: https://adventofcode.com/2023/day/8/input

        public static string GetResult()
        {
            try
            {
                StreamReader sr = new("E:\\Advent_of_Code_2023\\AdventOfCode_Day8_Input.txt");

                List<string> lines = [];

                string? line = sr.ReadLine();

                while (line != null)
                {
                    lines.Add(line);
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
