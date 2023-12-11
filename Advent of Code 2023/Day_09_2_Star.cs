namespace Advent_of_Code_2023
{
    public class Day_09_2_Star
    {
        //  Problem to solve: https://adventofcode.com/2023/day/9 Part 2
        //  Get Puzzle Input here: https://adventofcode.com/2023/day/9/input

        public static string ReverseLine(string line)
        {
            List<string> numbers = [];

            foreach (string number in line.Split(' '))
            {
                numbers.Add(number);
            }

            numbers.Reverse();

            line = "";

            foreach (string number in numbers)
            {
                line += number + " ";
            }

            return line.Trim();
        }

        public static string GetResult()
        {
            try
            {
                StreamReader sr = new("E:\\Advent_of_Code_2023\\AdventOfCode_Day9_Input.txt");

                List<string> lines = [];

                int sum = 0;

                string? line = sr.ReadLine();

                while (line != null)
                {
                    sum += Day_09_1_Star.ExtrapolatedValue(ReverseLine(line));
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
