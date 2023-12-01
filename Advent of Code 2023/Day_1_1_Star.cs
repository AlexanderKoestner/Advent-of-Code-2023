namespace Advent_of_Code_2023
{
    public class Day_1_1_Star
    {
        private static readonly System.Buffers.SearchValues<char> s_myChars = System.Buffers.SearchValues.Create("0123456789");

        public static string GetResult()
        {
            try
            {
                StreamReader sr = new("E:\\Advent_of_Code_2023\\AdventOfCode_Day1_Input.txt");

                string firstDigit;
                string lastDigit;

                int sum = 0;

                string? line = sr.ReadLine();

                while (line != null)
                {
                    firstDigit = line[line.AsSpan().IndexOfAny(s_myChars)].ToString();
                    lastDigit = line[line.AsSpan().LastIndexOfAny(s_myChars)].ToString();

                    sum += int.Parse(firstDigit + lastDigit);

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
