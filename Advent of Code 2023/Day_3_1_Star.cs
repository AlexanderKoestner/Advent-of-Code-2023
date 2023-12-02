namespace Advent_of_Code_2023
{
    internal class Day_3_1_Star
    {
        public static string GetResult()
        {
            try
            {
                StreamReader sr = new("E:\\Advent_of_Code_2023\\AdventOfCode_Day3_Input.txt");

                string? line = sr.ReadLine();

                while (line != null)
                {
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

