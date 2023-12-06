namespace Advent_of_Code_2023
{
    public class Day_5_2_Star
    {
        //  Problem to solve: https://adventofcode.com/2023/day/5 Part 2
        //  Get Puzzle Input here: https://adventofcode.com/2023/day/5/input
        public static string GetResult()
        {
            try
            {
                StreamReader sr = new("E:\\Advent_of_Code_2023\\AdventOfCode_Day5_Input.txt");

                List<string> lines = [];

                string? line = sr.ReadLine();

                while (line != null)
                {
                    lines.Add(line);
                    line = sr.ReadLine();
                }

                string seedString = lines[0].Split(':')[1].Trim();

                List<long> seeds = [];

                foreach(string seed in seedString.Split(' '))
                {
                    seeds.Add(long.Parse(seed));
                }

                //Console.WriteLine("All Seeds:\n");

                //for (int i = 0; i < seeds.Count; i += 2)
                //{
                //    Console.Write(seeds[i].ToString("#,##0").PadLeft(15) + " - " + (seeds[i] + seeds[i + 1]).ToString("#,##0").PadLeft(13) + " with Range " + seeds[i + 1].ToString("#,##0").PadLeft(11) + "\n\n");
                //}



               


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
